using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QuestCoreNS;

namespace QuestConstructorNS
{
    public partial class MainForm : Form
    {
        // Текущий опросник
        private Questionnaire questionnaire = new Questionnaire();
        private bool changed;

        public MainForm()
        {
            InitializeComponent();

            //строим интерфейс
            Build();
        }

        private void Build()
        {
            //создаем хелпер отрисовки, останавливаем отрисовку
            var helper = new ControlHelper(pnMain);

            //очищаем центральную панель
            pnMain.Controls.Clear();
            //создаем контролы для каждого вопроса
            foreach (var quest in questionnaire)
            {
                //создаем usercontrol для вопроса
                var pn = new QuestPanel();
                //строим его
                pn.Build(questionnaire, quest);

                //подписываемся на события
                pn.QuestionnaireListChanged += () =>
                {
                    changed = true;//выставлем флажок изменения
                    Build();
                };
                
                //перестриваем интерфейс, если изменился список вопросов
                pn.Changed += () => 
                {
                    changed = true; //выставлем флажок изменения
                    UpdateInterface();
                };

                pnMain.Controls.Add(pn);//добавляем на главную панель
            }
            //обновляем интерфейс
            UpdateInterface();

            //восстанавливаем отрисовку
            helper.ResumeDrawing();
        }

        private void UpdateInterface()
        {
            btSave.Enabled = changed;
        }

        private void LoadQuestionnaireFromFile(string filePath)
        {
            //загружаем из файла
            questionnaire = SaverLoader.Load<Questionnaire>(filePath);
            //сбрасываем флажок изменений
            changed = false;
            //перестриваем интерфейс
            Build();
        }

        private void SaveQuestionnaireToFile(string filePath)
        {
            //проверяем опросник
            new QuestionnaireValidator().Validate(questionnaire);
            //сбрасываем флажок изменений
            changed = false;
            //сохраняем в файл
            SaverLoader.Save(questionnaire, filePath);
            //
            UpdateInterface();
        }

        private void RunQuestionnaire()
        {
            //проверяем опросник
            new QuestionnaireValidator().Validate(questionnaire);
            //запускаем интервью
            new QuestInterviewNS.MainForm(questionnaire).ShowDialog(this);
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            AskAboutSaveCurrentQuestionnaire();
            var ofd = new OpenFileDialog() {Filter = "Опросник|*.q"};
            if (ofd.ShowDialog() == DialogResult.OK)
                LoadQuestionnaireFromFile(ofd.FileName);
        }

        private void AskAboutSaveCurrentQuestionnaire()
        {
            if (changed)
            {
                if (MessageBox.Show("В текущем опроснике есть несохраненные данные.\r\nВы хотите сохранить опросник?", "Несохраненные изменения", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    btSave.PerformClick();
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Filter = "Опросник|*.q" };
            if (sfd.ShowDialog() == DialogResult.OK)
                SaveQuestionnaireToFile(sfd.FileName);
        }

        private void btAddQuest_Click(object sender, EventArgs e)
        {
            //добавляем новый вопрос в опросник
            new QuestionnaireManipulator().AddNewQuest(questionnaire);
            //выставлем флажок изменения
            changed = true;
            //перестраиваем интерфейс
            Build();
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
                    MessageBox.Show("В этой папке не найдены анкеты");
                    return;
                }

                //запрашиваем имя выходного csv файла
                var sfd = new SaveFileDialog() {Filter = "CSV|*.csv"};
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //экспортируем
                    new ExportToCSV().Export(anketas, sfd.FileName);
                    MessageBox.Show("Экспортировано " + anketas.Count + " анкет");
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AskAboutSaveCurrentQuestionnaire();
        }
    }
}
