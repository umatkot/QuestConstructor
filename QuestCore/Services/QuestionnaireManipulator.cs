using System.Linq;

namespace QuestCore
{
    /// <summary>
    /// Производит манипуляции с опросником
    /// </summary>
    public class QuestionnaireManipulator
    {
        private const string DefaultQuestPrefix = "A";

        /// <summary>
        /// Добавить новый вопрос
        /// </summary>
        public Quest AddNewQuest(Questionnaire questionnaire)
        {
            //подбираем уникальное имя вопроса
            var counter = 1;
            var name = DefaultQuestPrefix + counter;

            while (questionnaire.Any(q => q.Id == name))//увеличиваем счетчик, пока не найдем имени, которого еще нет в опроснике
            {
                counter++;
                name = DefaultQuestPrefix + counter;
            }
            //
            var quest = new Quest {Id = name, Title = "Текст вопроса"};
            questionnaire.Add(quest);
            return quest;
        }

        /// <summary>
        /// Удалить вопрос
        /// </summary>
        public void RemoveQuest(Questionnaire questionnaire, Quest quest)
        {
            questionnaire.Remove(quest);
        }

        /// <summary>
        /// Перемещение вопроса
        /// </summary>
        public void MoveQuest(Questionnaire questionnaire, Quest quest, int dir)
        {
            ListHelper.MoveElement(questionnaire, quest, dir);
        }
    }
}
