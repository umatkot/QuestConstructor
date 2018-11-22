using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QuestCore;

namespace QuestConstructorNS
{
    public partial class MainForm : Form
    {
        // Текущий опросник
        private Questionnaire _questionnaire = new Questionnaire();
        private bool _changed;
        private FlowPanelActionHelper FlowPanelActionHelper { get; set; }

        public MainForm()
        {
            InitializeComponent();

            FlowPanelActionHelper = new FlowPanelActionHelper(pnMain);

            //строим интерфейс
            Build();
        }

        private void Build()
        {
            //обновляем интерфейс
            UpdateInterface();
        }

        private void UpdateInterface()
        {
            btSave.Enabled = _changed;
        }

        private void LoadQuestionnaireFromFile(string filePath)
        {
            //загружаем из файла
            _questionnaire = SaverLoader.Load<Questionnaire>(filePath);
            //сбрасываем флажок изменений
            _changed = false;
            //перестриваем интерфейс
            Build();
        }

        private void SaveQuestionnaireToFile(string filePath)
        {
            //проверяем опросник
            new QuestionnaireValidator().Validate(_questionnaire);
            //сбрасываем флажок изменений
            _changed = false;
            //сохраняем в файл
            SaverLoader.Save(_questionnaire, filePath);
            //
            UpdateInterface();
        }

        private void RunQuestionnaire()
        {
            //проверяем опросник
            new QuestionnaireValidator().Validate(_questionnaire);
            //запускаем интервью
            new QuestInterviewNS.MainForm(_questionnaire).ShowDialog(this);
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            AskAboutSaveCurrentQuestionnaire();
            var ofd = new OpenFileDialog() {Filter = @"Опросник|*.q"};
            if (ofd.ShowDialog() == DialogResult.OK)
                LoadQuestionnaireFromFile(ofd.FileName);
        }

        private void AskAboutSaveCurrentQuestionnaire()
        {
            if (_changed && _questionnaire.Any())
            {
                var question = $"В текущем опроснике есть несохраненные данные.{Environment.NewLine}Вы хотите сохранить опросник?";
                if (MessageBox.Show(question, @"Несохраненные изменения", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    btSave.PerformClick();
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Filter = @"Опросник|*.q" };
            if (sfd.ShowDialog() == DialogResult.OK)
                SaveQuestionnaireToFile(sfd.FileName);
        }

        private void btAddQuest_Click(object sender, EventArgs e)
        {
            //добавляем новый вопрос в опросник
            var question2Add = new QuestionnaireManipulator().AddNewQuest(_questionnaire);

            //выставлем флажок изменения
            _changed = true;

            AddQuestion2Interface(question2Add);
        }

        private void AddQuestion2Interface(Quest question2Add)
        {
            //создаем usercontrol для вопроса
            var pn = new QuestPanel();

            //строим его
            pn.Build(_questionnaire, question2Add);

            //подписываемся на события
            pn.QuestionnaireListChanged += ProcessQuestionListAction;

            //перестриваем интерфейс, если изменился список вопросов
            pn.Changed += () =>
            {
                _changed = true; //выставлем флажок изменения
                UpdateInterface();
            };

            pnMain.Controls.Add(pn);//добавляем на главную панель
        }


        private void ProcessQuestionListAction(string questionPanelKey, UserPanelActionType actionType)
        {
            _changed = true;//выставлем флажок изменения

            if (actionType == UserPanelActionType.Add)
            {
                var question2Add = _questionnaire.First(q => q.Id.Equals(questionPanelKey));
                AddQuestion2Interface(question2Add);
                return;//Дальше делать нечего
            }

            //создаем хелпер отрисовки, останавливаем отрисовку
            FlowPanelActionHelper.ProcessElements(questionPanelKey, actionType);
        }

        private void btRun_Click(object sender, EventArgs e)
        {
            RunQuestionnaire();
        }

        private void btExportCSV_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFolderDialog();
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                //получаем список анкет в выбранной папке
                var anketas = Directory.GetFiles(ofd.Folder, "*.a").Select(path => SaverLoader.Load<Anketa>(path)).ToList();
                if (anketas.Count == 0)
                {
                    MessageBox.Show(@"В этой папке не найдены анкеты");
                    return;
                }

                //запрашиваем имя выходного csv файла
                var sfd = new SaveFileDialog() {Filter = @"CSV|*.csv"};
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //экспортируем
                    new ExportToCSV().Export(anketas, sfd.FileName);
                    MessageBox.Show(@"Экспортировано " + anketas.Count + @" анкет");
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AskAboutSaveCurrentQuestionnaire();
        }
    }
}
