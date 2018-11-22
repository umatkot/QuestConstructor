using System;
using System.Data;
using System.Windows.Forms;
using QuestCore;

namespace QuestConstructorNS
{
    public partial class AlternativePanel : UserControl
    {
        private Quest _quest;
        private Alternative _alt;
        private Questionnaire _questionnaire;
        private int _updating;

        public event Action<string, UserPanelActionType> AlternativeListChanged = (altKey, actionType) => {};
        public event Action<string> AddQuestionByAlternative = questionId => {};

        public event Action Changed = delegate { };

        public AlternativePanel()
        {
            InitializeComponent();

            /*идентификатор для управления элементом управления(тафталогоанатом в деле)*/
            Name = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Строим интерфейс
        /// </summary>
        public void Build(Questionnaire questionnaire, Quest quest, Alternative alt)
        {
            _quest = quest;
            _alt = alt;
            _questionnaire = questionnaire;

            //выставляем флажок обновления
            _updating++;

            //переносим данные из объекта в интерфейс
            tbId.Text = alt.Code.ToString();
            tbTitle.Text = alt.Title;
            lbCondition.Text = alt.Condition?.ToString() ?? "Если...";

            //сбрасываем флажок обновления
            _updating--;
        }

        /// <summary>
        /// Обновляем объект из интерфеса
        /// </summary>
        private void UpdateObject()
        {
            //если режим обновления интерфейса - не реагируем
            if (_updating > 0) return;

            //переносим данные из интерфейса в объект
            _alt.Code = int.Parse(tbId.Text);
            _alt.Title = tbTitle.Text;

            //сигнализируем наверх о том, что объект изменился
            Changed();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Удалить альтернативу?", @"Удаление альтернативы", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //удаляем альтернативу
                new QuestManipulator().RemoveAlt(_quest, _alt);
                //сигнализируем наверх о том, что список поменялся
                AlternativeListChanged(Name, UserPanelActionType.Remove);
            }
        }

        private void btUp_Click(object sender, EventArgs e)
        {
            //передвигаем альтернативу вверх по списку
            new QuestManipulator().MoveAlt(_quest, _alt, UserPanelActionType.MoveUp);

            //сигнализируем наверх о том, что список поменялся
            AlternativeListChanged(Name, UserPanelActionType.MoveUp);
        }

        private void btDown_Click(object sender, EventArgs e)
        {
            //передвигаем альтернативу вниз по списку
            new QuestManipulator().MoveAlt(_quest, _alt, UserPanelActionType.MoveUp);
            //сигнализируем наверх о том, что список поменялся
            AlternativeListChanged(Name, UserPanelActionType.MoveDown);
        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            //обновляем объект
            UpdateObject();
        }

        private void lbCondition_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //установка вопроса, на котором вызвано изменение условия альтернативы
            //Требуется для того, чтобы в форме установки выражения можно было использовать параметры текущего вопроса
            //Пока это только имя вопроса, но может быть любое поле - поэтому пометил сам вопрос а не просто добавил его имя
            _questionnaire.SetCurrentElement(_quest);

            //создаем условие, если его еще нет
            if (_alt.Condition == null)
                _alt.Condition = new Condition();

            //показываем форму редактора условия
            var form = new ConditionForm();
            form.Build(_questionnaire, _alt.Condition);
            form.Changed += () => Changed();//сигнализируем наверх о том, что объект поменялся
            form.ShowDialog(this);//показываем конструктор условий

            //перестриваем интерфйес
            Build(_questionnaire, _quest, _alt);
        }

        /// <summary>
        /// Добавляется новый вопрос из текущего варианта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewQuestionByVariant_Click(object sender, EventArgs e)
        {
            //Условие от текущего варианта
            var condition = new Condition($"{_quest.Id}={_alt.Code}");

            /*Если уже есть вопрос с ссылкой на дальную альтернативу, то не добавляем аналог, так как у нас не предусмотрено разветвление*/
            /*Вообще-то было бы интересно: пользователь выбирает вариант, а программа его засыпает кучей вопросов - сразу пачкой)))*/
            if(new ConditionCalculator().CheckQuestionByConditionIfExists(_questionnaire, condition))
                return;

            var question2Add = new QuestionnaireManipulator().AddNewQuest(_questionnaire);

            question2Add.Condition = condition;

            AddQuestionByAlternative(question2Add.Id);
        }
    }
}
