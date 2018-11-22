using System;
using System.Collections.Generic;

namespace QuestCore
{
    /// <summary>
    /// Опросник.
    /// Содержит список вопросов.
    /// </summary>
    [Serializable]
    public class Questionnaire : List<Quest>
    {
        /// <summary>
        /// Идентификатор текущего вопроса в опроснике
        /// </summary>
        public string CurrentQuestId { get; set; }

        public Quest CurrentQuestion => Find(q => q.Id.Equals(CurrentQuestId));

        /// <summary>
        /// Устанавливает текущий элемент в структуре
        /// </summary>
        /// <param name="currentQuest">Текущий вопрос</param>
        /// <param name="currentAlternative">Текущий вариант</param>
        public void SetCurrentElement(Quest currentQuest, Alternative currentAlternative = null)
        {
            CurrentQuestId = currentQuest.Id;
            if(currentAlternative != null)
                currentQuest.CurrentAlternativeCode = currentAlternative.Code;
        }
    }

    /// <summary>
    /// Вопрос.
    /// Содержит список альтернатив.
    /// </summary>
    [Serializable]
    public class Quest : List<Alternative>
    {
        /// <summary>
        /// Идентификатор вопроса
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Тип вопроса
        /// </summary>
        public QuestType QuestType { get; set; }

        /// <summary>
        /// Условие показа
        /// </summary>
        public Condition Condition { get; set; }

        public int CurrentAlternativeCode { get; set; }
    }

    /// <summary>
    /// Тип вопроса
    /// </summary>
    [Serializable]
    public enum QuestType
    {
        /// <summary>
        /// Выбор одной альтренативы из фиксированного списка альтернатив
        /// </summary>
        SingleAnswer,
        /// <summary>
        /// Пользователь может вбить произвольный ответ в текстовое поле
        /// </summary>
        OpenQuestion,
        /// <summary>
        /// Для отображения уже завершённого вопроса
        /// </summary>
        ReadOnlyAnswer
    }

    /// <summary>
    /// Класс-структура для помещения значения в Combobox
    /// </summary>
    public class QuestTypeDataSet
    {
        public QuestType Value { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    /// <summary>
    /// Альтернатива вопроса
    /// </summary>
    [Serializable]
    public class Alternative
    {
        /// <summary>
        /// Код альтернативы
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Текст альтернативы
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Условие показа
        /// </summary>
        public Condition Condition { get; set; }

        /// <summary>
        /// Форматированный вывод заголовка
        /// Применяется, если конечному объекту для отображения потребуется второе значение
        /// </summary>
        public string FormattedTitle {

            get => _formattedTitle;

            set => _formattedTitle = $"{Title} {value}";
        }

        private string _formattedTitle;
    }
}
