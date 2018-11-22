using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuestCore;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //создаем опросник
            var questionnaire = new Questionnaire();
            //создаем вопрос
            var quest = new Quest { Id = "A1", Title = "Заголовок вопроса" };
            //создаем альтренативу
            var alt = new Alternative {Code = 1, Title = "Вариант1"};
            //добавляем альтернативу в вопрос
            quest.Add(alt);
            //добавляем вопрос в опросник
            questionnaire.Add(quest);

            //сохраняем опросник в файл
            SaverLoader.Save(questionnaire, "c:\\temp.q");

            //читаем опросник из файла
            var loadedQuestionnaire = SaverLoader.Load<Questionnaire>("c:\\temp.q");

            //проверяем число вопросов и альтернатив в загруженном опроснике
            Assert.AreEqual(loadedQuestionnaire.Count, questionnaire.Count);
            Assert.AreEqual(loadedQuestionnaire[0].Count, questionnaire[0].Count);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //создаем анкету
            var anketa = new Anketa();
            //создаем ответ
            var answer = new Answer{ QuestId = "A1", AlternativeCode = 1 };
            //добавляем ответ в анкету
            anketa.Add(answer);

            //сохраняем анкету в файл
            SaverLoader.Save(anketa, "c:\\temp.a");

            //читаем анкету из файла
            var loadedAnketa = SaverLoader.Load<Anketa>("c:\\temp.a");

            //проверяем число ответов в загруженной анкете
            Assert.AreEqual(loadedAnketa.Count, anketa.Count);
        }

        //проверка валидатора
        [TestMethod]
        public void TestMethod3()
        {
            //создаем опросник
            var questionnaire = new Questionnaire();
            //создаем вопросы с одинаковыми именами
            questionnaire.Add(new Quest { Id = "A1", Title = "Заголовок вопроса" });
            questionnaire.Add(new Quest { Id = "A1", Title = "Заголовок вопроса" });

            //запускаем валидатор
            try
            {
                new QuestionnaireValidator().Validate(questionnaire);
                Assert.Fail("Validator passes duplicates");
            }
            catch
            {
                //все ок
            }
        }

        //проверка калькулятора условий
        [TestMethod]
        public void TestMethod4()
        {
            //создаем опросник
            var questionnaire = new Questionnaire();
            //создаем вопросы
            questionnaire.Add(new Quest { Id = "A1"});
            questionnaire.Add(new Quest { Id = "A2"});

            //создакем калькулятор
            var calc = new ConditionCalculator();

            //проверка синтаксиса с ошибкой
            try
            {
                calc.Check(questionnaire, "A1 - 23");
                calc.Check(questionnaire, "A1 = 2 + ");
                Assert.Fail("Calculator.Check() false positive");
            }
            catch
            {
                //все ок
            }

            //проверка несуществующих вопросов
            try
            {
                calc.Check(questionnaire, "A23 = 1");
                Assert.Fail("Calculator.Check() false positive");
            }
            catch
            {
                //все ок
            }

            //проверка корректных выражений
            var anketa = new Anketa();
            anketa.Add(new Answer {QuestId = "A1", AlternativeCode = 1});
            anketa.Add(new Answer { QuestId = "A2", AlternativeCode = 1 });
            anketa.Add(new Answer { QuestId = "A3", Text = "YES" });
            Assert.IsTrue(calc.Calculate(anketa, new Condition {Expression = "A1 = 1"}));
            Assert.IsTrue(calc.Calculate(anketa, new Condition { Expression = "A1 = A2" }));
            Assert.IsTrue(calc.Calculate(anketa, new Condition { Expression = "A3 <> 'NO'" }));
            Assert.IsTrue(calc.Calculate(anketa, new Condition { Expression = "A1 + A2 = 2" }));
            Assert.IsTrue(calc.Calculate(anketa, new Condition { Expression = "(A1 = 1) and (A3 = 'YES')" }));
            Assert.IsTrue(calc.Calculate(anketa, new Condition { Expression = "(A1 = 5) or (A3 = 'YES')" }));
        }
    }
}
