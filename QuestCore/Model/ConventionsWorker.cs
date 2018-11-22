using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestCore
{
    public class ConventionsWorker : Conventions
    {
        private Quest Quest { get; set; }
        private Answer Answer { get; set; }
        private InterviewManipulator InterviewManipulator { get; set; }

        public ConventionsWorker(Action[] actions) : base(actions) {}

        public void Init(InterviewManipulator interviewManipulator, Quest quest, Answer answer, bool readOnly)
        {
            Quest = quest;
            Answer = answer;
            InterviewManipulator = interviewManipulator;
            DoActionByQuestionType(readOnly ? QuestType.ReadOnlyAnswer : quest.QuestType);
        }

        /// <summary>
        /// получаем список разрешенных к показу альтернатив
        /// </summary>
        /// <returns></returns>
        public List<Alternative> GetAllowedAlternatives()
        {
            return InterviewManipulator.GetAllowedAlternatives().ToList();
        }

        public Alternative GetSingleAlternative()
        {
            var alternative = Quest.FirstOrDefault(a => a.Code == Answer.AlternativeCode);
            if (alternative == null) return null;

            alternative.FormattedTitle = Answer.Text;
            return alternative;
        }

        public void SetAlternativeCode(int alternativeCode)
        {
            Answer.AlternativeCode = alternativeCode;
        }

        public void SetAnswerText(string text)
        {
            Answer.Text = text;
        }
    }
}