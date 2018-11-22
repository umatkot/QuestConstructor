using System;
using System.Collections.Generic;

namespace QuestCore
{
    /// <summary>
    /// Заполненная анкета.
    /// Содержит список ответов.
    /// </summary>
    [Serializable]
    public class Anketa : List<Answer>
    {
    }

    /// <summary>
    /// Ответ респондента в конкретном вопросе
    /// </summary>
    [Serializable]
    public class Answer
    {
        /// <summary>
        /// Идентификатор вопроса
        /// </summary>
        public string QuestId { get; set; }

        /// <summary>
        /// Код выбранной альтернативы
        /// </summary>
        public int? AlternativeCode { get; set; }

        /// <summary>
        /// Текст ответа (для открытых вопросов)
        /// </summary>
        public string Text { get; set; }

        public override string ToString()
        {
            return Text != null ? Text : AlternativeCode.ToString();
        }
    }
}
