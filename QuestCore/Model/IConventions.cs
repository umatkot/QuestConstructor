using System;

namespace QuestCore
{
    public delegate Action QuestionTypeEvent(QuestType entityType);
    public delegate string QuestionTypeConvention(QuestType entityType);
    public delegate QuestTypeDataSet QuestionTypeConventionAsElement(QuestType entityType);
    //public delegate QuestType QuestionTypeNameConvention(string entityType);

    public interface IConventions
    {
        QuestionTypeConventionAsElement QuestionTypeConventionAsElement { get; }
        QuestionTypeConvention QuestionTypeConvention { get; }
        QuestionTypeEvent QuestionTypeEvent { get; }
        //QuestionTypeNameConvention QuestionTypeNameConvention { get; }

        QuestTypeDataSet[] GenerateQuestTypes();
    }
}
