using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestCore
{
    /// <summary>
    /// Проверяет корректность опросника.
    /// Генерирует исключение с текстом, описывающим суть проблемы.
    /// </summary>
    public class QuestionnaireValidator
    {
        public void Validate(Questionnaire questionnaire)
        {
            //проверяем уникальность имен вопросов
            var names = new HashSet<string>();
            foreach(var q in questionnaire)
            if(!names.Add(q.Id))
                throw new Exception("Дублируется имя вопроса " + q.Id);

            //проверяем уникальность кодов альтернатив и их число
            foreach (var quest in questionnaire.Where(q => q.QuestType.Equals(QuestType.SingleAnswer)))
            {
                var codes = new HashSet<int>();

                if(!quest.Any())
                    throw new Exception("В вопросе " + quest.Id + " нет альтернатив");

                foreach (var questionAlternative in quest)
                {
                    if (!codes.Add(questionAlternative.Code))
                        throw new Exception("В вопросе " + quest.Id + " дублируется код альтернативы " + questionAlternative.Code);
                }
            }
        }
    }
}
