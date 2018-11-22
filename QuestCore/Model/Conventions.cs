using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestCore
{
    public class Conventions : IConventions
    {
        public QuestionTypeConvention QuestionTypeConvention { get; protected set; }
        public QuestionTypeEvent QuestionTypeEvent { get; protected set; }
        //public QuestionTypeNameConvention QuestionTypeNameConvention { get; protected set; }
        public QuestionTypeConventionAsElement QuestionTypeConventionAsElement { get; protected set; }

        public Conventions(Action[] actions = null)
        {
            var questionType = new Dictionary<QuestType, String>
            {
                {QuestType.OpenQuestion, @"Произвольный ответ"},
                {QuestType.SingleAnswer, @"Выбор варианта"}
            };

            /*
            var questionTypeString = new Dictionary<String, QuestType>
            {
                {@"Открытый вопрос", QuestType.OpenQuestion},
                {@"Однозначный вопрос", QuestType.SingleAnswer}
            };
            */

            QuestionTypeConvention = type =>
            {
                if (questionType.ContainsKey(type))
                    return questionType[type];
                throw new NotSupportedException();
            };
            /*
            QuestionTypeNameConvention = type =>
            {
                if (questionTypeString.ContainsKey(type))
                    return questionTypeString[type];
                throw new NotSupportedException();
            };
            */
            QuestionTypeConventionAsElement = type => new QuestTypeDataSet
            {
                Value = type,
                Text = QuestionTypeConvention(type)
            };

            if (actions == null) return;

            /*Сопоставляет каждое действие своему типу*/
            var questionEvents = ((QuestType[])Enum.GetValues(typeof(QuestType))).Zip(actions, (type, action) => new
                {
                    key = type,
                    val = action
                }).Where(e => e.val != null)
                .ToDictionary(a => a.key, a => a.val);

            QuestionTypeEvent = type =>
            {
                if (questionEvents.ContainsKey(type))
                    return questionEvents[type];
                throw new NotSupportedException();
            };
        }

        public QuestTypeDataSet[] GenerateQuestTypes()
        {
            return ((QuestType[]) Enum.GetValues(typeof(QuestType)))
                .Where(qt => qt != QuestType.ReadOnlyAnswer)
                .Select(qt => QuestionTypeConventionAsElement(qt))
                .ToArray();
        }

        public void DoActionByQuestionType(QuestType questType)
        {
            QuestionTypeEvent(questType).Invoke();
        }
    }
}
