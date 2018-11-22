using System;

namespace QuestCore
{
    /// <summary>
    /// Условие, которое может возвращать true или false в зависимости от ответов в Anketa
    /// </summary>
    [Serializable]
    public class Condition
    {
        /*Интересно, почему вызывается конструктор без параметра, даже если я не указываю Default вариант?*/
        public Condition(string expression = "")
        {
            Expression = expression;
        }

        public Condition()
        {
            Expression = string.Empty;
        }

        public string Expression { get; }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Expression) ? "Если..." : Expression;
        }

        public override bool Equals(object obj)
        {
            return Equals((Condition)obj);
        }

        protected bool Equals(Condition other)
        {
            return string.Equals(Expression, other.Expression);
        }

        public override int GetHashCode()
        {
            return (Expression != null ? Expression.GetHashCode() : 0);
        }
    }
}
