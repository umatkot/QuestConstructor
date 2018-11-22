using System;
using System.Windows.Forms;
using QuestCore;

namespace QuestInterviewNS.Controls
{
    /// <summary>
    /// Отображение вопроса и ответа
    /// </summary>
    public partial class AnswerPanel : UserControl
    {
        

        private ConventionsWorker ConventionsWorker { get; }

        /// <summary>
        /// Пользователь указал/изменил ответ
        /// </summary>
        public event Action Changed = delegate { };

        public AnswerPanel()
        {
            InitializeComponent();

            /*Устанавливаются делегаты на требуемые действия в зависимости от поступающего вопроса*/
            ConventionsWorker = new ConventionsWorker(new Action[]
            {
                BuildSingleAnswerInterface,
                BuildOpenAnswerInterface,
                BuildReadOnlyAnswerInterface
            });

        }

        /// <summary>
        /// Построение интерфейса
        /// </summary>
        public void Build(InterviewManipulator interviewManipulator, Quest quest, Answer answer, bool readOnly)
        {
            pnMain.Controls.Clear();
            lbQuestTitle.Text = quest.Title;
            ConventionsWorker.Init(interviewManipulator, quest, answer, readOnly);
        }

        private void BuildSingleAnswerInterface()
        {
            var alternatives = ConventionsWorker.GetAllowedAlternatives();
            //создаем комбобокс
            var cb = new ComboBox
            {
                DataSource = alternatives,
                ValueMember = "Code",
                DisplayMember = "Title",
                DropDownStyle = ComboBoxStyle.DropDownList,
                Parent = pnMain
            };

            cb.SelectedValueChanged += (sender, args) => OnValueSelected((int)cb.SelectedValue);//обрабатываем выбор
            //имитируем выбор первой альтернативы
            if(alternatives.Count > 0)
                OnValueSelected(alternatives[0].Code);
        }

        private void BuildOpenAnswerInterface()
        {
            //создаем текстбокс
            var tb = new TextBox { Parent = pnMain };
            tb.TextChanged += (sender, args) => OnValueSelected(tb.Text);//обрабатываем выбор
        }

        private void BuildReadOnlyAnswerInterface()
        {
            var alternative = ConventionsWorker.GetSingleAlternative();
            if (alternative == null) return;
            var label = new Label {Text = alternative.FormattedTitle, Parent = pnMain};
        }

        private void OnValueSelected(int alternativeCode)
        {
            //отправлем выбранное значение в доменный объект
            ConventionsWorker.SetAlternativeCode(alternativeCode);
            Changed();//сигнализируем наверх, о том, что пользователь что-то выбрал
        }

        private void OnValueSelected(string text)
        {
            //отправлем выбранное значение в доменный объект
            ConventionsWorker.SetAnswerText(text);
            Changed();//сигнализируем наверх, о том, что пользователь что-то выбрал
        }
    }
}
