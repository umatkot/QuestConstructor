using System;
using System.Linq;
using System.Windows.Forms;
using QuestCore;

namespace QuestConstructorNS
{
    public partial class QuestPanel : UserControl
    {
        private FlowPanelActionHelper FlowPanelActionHelper { get; }
        private Questionnaire _questionnaire;
        private Quest _quest;
        private int _updating;
        private IConventions Conventions { get; }

        public event Action<string, UserPanelActionType> QuestionnaireListChanged = (questionPamelKey, actionType) => {};
        public event Action Changed = delegate { };

        public QuestPanel()
        {
            InitializeComponent();
            Conventions = new Conventions();
            Name = Guid.NewGuid().ToString();
            FlowPanelActionHelper = new FlowPanelActionHelper(pnAlternatives);
        }

        /// <summary>
        /// Строим интерфейс
        /// </summary>
        public void Build(Questionnaire questionnaire, Quest quest)
        {
            _questionnaire = questionnaire;
            _quest = quest;

            //выставляем флажок обновления
            _updating++;

            //переносим данные из объекта в интерфейс
            tbId.Text = quest.Id;
            tbTitle.Text = quest.Title;
            lbCondition.Text = quest.Condition?.ToString() ?? "Если...";

            //инициализируем комбобокс с типом вопроса
            var questionTypes = Conventions.GenerateQuestTypes();

            cbQuestType.DataSource = questionTypes;
            cbQuestType.SelectedItem = quest.QuestType;

            //сбрасываем флажок обновления
            _updating--;
        }

        private void ProcessAlternativeListAction(string altKey, UserPanelActionType actionType)
        {
            FlowPanelActionHelper.ProcessElements(altKey, actionType);
            Changed(); //сигнализируем наверх о том, что объект изменился
        }

        /// <summary>
        /// Обновляем объект из интерфеса
        /// </summary>
        private void UpdateObject()
        {
            //если режим обновления интерфейса - не реагируем
            if (_updating > 0) return;

            //переносим данные из интерфейса в объект
            _quest.Id = tbId.Text;
            _quest.Title = tbTitle.Text;

            _quest.QuestType = ((QuestTypeDataSet)cbQuestType.SelectedItem).Value;

//В зависимости от типа вопроса ограничиваем пользователя в выборе альтернативы
            btAddAlt.Enabled = _quest.QuestType == QuestType.SingleAnswer;

            //сигнализируем наверх о том, что объект изменился
            Changed();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Удалить вопрос?", @"Удаление вопроса", MessageBoxButtons.OKCancel) !=
                DialogResult.OK) return;
            //удаляем вопрос
            new QuestionnaireManipulator().RemoveQuest(_questionnaire, _quest);
            //сигнализируем наверх о том, что список вопросов поменялся
            QuestionnaireListChanged(Name, UserPanelActionType.Remove);
        }

        private void btUp_Click(object sender, EventArgs e)
        {
            //передвигаем вопрос вверх по списку
            new QuestionnaireManipulator().MoveQuest(_questionnaire, _quest, (int)UserPanelActionType.MoveUp);
            //сигнализируем наверх о том, что список вопросов поменялся
            QuestionnaireListChanged(Name, UserPanelActionType.MoveUp);
        }

        private void btDown_Click(object sender, EventArgs e)
        {
            //передвигаем вопрос вниз по списку
            new QuestionnaireManipulator().MoveQuest(_questionnaire, _quest, (int)UserPanelActionType.MoveDown);
            //сигнализируем наверх о том, что список вопросов поменялся
            QuestionnaireListChanged(Name, UserPanelActionType.MoveDown);
        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            //обновляем объект
            UpdateObject();
        }

        private void btAddAlt_Click(object sender, EventArgs e)
        {
            //добавляем новую альтернативу
            if (new QuestManipulator().AddNewAlt(_quest) == null)
            {
                btAddAlt.Enabled = false;
                return;
            }

            /*Добавляем новую альтернативу*/
            var alt = _quest.LastOrDefault();
            if (alt == null) return;

            var pn = new AlternativePanel();

            pn.Build(_questionnaire, _quest, alt);
            pn.AlternativeListChanged += ProcessAlternativeListAction;
            pn.AddQuestionByAlternative += (questionId) => { QuestionnaireListChanged(questionId, UserPanelActionType.Add); };

            pn.Changed += () => Changed();
            pnAlternatives.Controls.Add(pn);
        }

        private void lbCondition_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _questionnaire.SetCurrentElement(_quest);

            //создаем условие, если его еще нет
            if (_quest.Condition == null)
                _quest.Condition = new Condition();

            //показываем форму редактора условия
            var form = new ConditionForm();
            form.Build(_questionnaire, _quest.Condition);
            form.Changed += () => Changed();//сигнализируем наверх о том, что объект поменялся
            form.ShowDialog(this);//показываем конструктор условий

            //перестриваем интерфйес
            Build(_questionnaire, _quest);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            //e.Graphics.DrawLine(Pens.Gray, ClientRectangle.Left, ClientRectangle.Top, ClientRectangle.Right, ClientRectangle.Top);
        }

        /// <summary>
        /// Обработка выбора типа вопроса - определено свойствами вопроса по альтернативам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbQuestType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var inputValue = cbQuestType.SelectedItem;
            
            if (((QuestTypeDataSet)inputValue).Value != QuestType.SingleAnswer && _quest.Any())
            {
                cbQuestType.SelectedItem = cbQuestType.Items.OfType<QuestTypeDataSet>().First(qti => qti.Value.Equals(_quest.QuestType));
                if (MessageBox.Show(
                        $@"Для заданного типа вопроса не требуются альтернативы.{Environment.NewLine}Удалить уже добавленные альтернативы?",
                        @"Смена типа вопроса",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _quest.Clear();
                    pnAlternatives.Controls.Clear();
                    cbQuestType.SelectedItem = inputValue;
                }
                else
                {
                    MessageBox.Show(
                        $@"У вопроса имеются альтернативы.{Environment.NewLine}Изменение типа вопроса невозможно",
                        @"Смена типа вопроса");
                    
                    return;//При отмене удаления альтернатив смена типа вопроса отменяется
                }
            }

            UpdateObject();
        }
    }
}
