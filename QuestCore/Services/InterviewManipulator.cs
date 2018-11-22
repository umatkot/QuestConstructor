using System.Collections.Generic;
using System.Linq;

namespace QuestCore
{
    /// <summary>
    /// Функционал для Interview
    /// </summary>
    public class InterviewManipulator
    {
        private Interview interview;

        public InterviewManipulator(Interview interview)
        {
            this.interview = interview;
        }

        /// <summary>
        /// Переходим к следующему вопросу
        /// </summary>
        public void GoToNextQuestion()
        {
            if (interview.IsFinished) return;//интервью уже завершено

            //получаем индекс текущего вопроса
            var currentQuestIndex = interview.CurrentAnswer == null ? -1 : interview.Questionnaire.FindIndex(q => q.Id == interview.CurrentAnswer.QuestId);

            //ищем следующий вопрос, у которго выполняется условие показа
            for (int i = currentQuestIndex + 1; i < interview.Questionnaire.Count; i++)
            {
                //получаем условие отображения вопроса
                var condition = interview.Questionnaire[i].Condition;

                //условие выполняется?
                var clalculator = new ConditionCalculator();
                if (clalculator.Calculate(interview.Anketa, condition))
                {
                    //нашли
                    var quest = interview.Questionnaire[i];

                    //добавляем текущий ответ в список отвеченных вопросов
                    if(interview.CurrentAnswer != null)
                        interview.PassedAnswers.Add(interview.CurrentAnswer);

                    //создаем новый Answer для нового вопроса
                    interview.CurrentAnswer = new Answer { QuestId = quest.Id };
                    interview.Anketa.Add(interview.CurrentAnswer);
                    //
                    return;
                }
            }

            //нет следующего вопроса, анкета завершена
            if (interview.CurrentAnswer != null)
            {
                interview.PassedAnswers.Add(interview.CurrentAnswer);
                interview.CurrentAnswer = null;
            }
            interview.IsFinished = true;
        }

        /// <summary>
        /// Получение списка альтренатив, разрешенных к показу, для текущего вопроса
        /// </summary>
        public IEnumerable<Alternative> GetAllowedAlternatives()
        {
            if (interview.IsFinished) yield break;//интервью уже завершено
            if (interview.CurrentAnswer == null) yield break;//нет текущего вопроса

            //получаем текущий вопрос
            var quest = interview.Questionnaire.First(q => q.Id == interview.CurrentAnswer.QuestId);

            //перебираем альтернативы, проверяем условние показа, возвращаем те, которые разрешены к показу
            var clalculator = new ConditionCalculator();
            foreach (var alt in quest)
            if (clalculator.Calculate(interview.Anketa, alt.Condition))
                yield return alt;
        }
    }
}