using System;
using System.Windows.Forms;
using QuestCore;

namespace QuestConstructorNS
{
    public partial class ConditionForm : Form
    {
        private Condition _condition;
        private Questionnaire _questionnaire;

        public event Action Changed = delegate { };

        public ConditionForm()
        {
            InitializeComponent();
        }

        public void Build(Questionnaire questionnaire, Condition condition)
        {
            _questionnaire = questionnaire;
            _condition = condition;

            tbExpression.Text = _condition.Expression;

            /*Указываю в имени формы идентификатор вопроса для наглядности*/
            Text = questionnaire.CurrentQuestion.Title;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            var expression = tbExpression.Text.Trim();

            //проверяем корректность выражения
            try
            {
                new ConditionCalculator().Check(_questionnaire, expression);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            //обновляем доменный объект
            _condition = new Condition(expression);

            //сигнализируем наверх о том, что объект поменялся
            Changed();
            //закрываем окно
            DialogResult = DialogResult.OK;
        }
    }
}
