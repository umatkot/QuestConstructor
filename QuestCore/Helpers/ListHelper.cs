using System.Collections.Generic;

namespace QuestCore
{
    static class ListHelper
    {        
        /// <summary>
        /// Перемещение элемента вверх/вниз по списку
        /// </summary>
        public static void MoveElement<T>(IList<T> list, T element, int dir)
        {
            //получаем текущий индекс
            var i = list.IndexOf(element);
            if (i < 0) return;//хм...

            if (i == 0 && dir < 0) return; //не можем переместить вверх, потому что вопрос и так первый
            if (i >= list.Count - 1 && dir > 0) return; //не можем переместить вниз, потому что вопрос и так последний

            //перемещаем
            list.RemoveAt(i);
            list.Insert(i + dir, element);
        }
    }
}
