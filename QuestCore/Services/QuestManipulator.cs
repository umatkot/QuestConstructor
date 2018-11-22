using System.Linq;
using System.Windows.Forms;

namespace QuestCore
{
    /// <summary>
    /// Производит манипуляции с вопросом
    /// </summary>
    public class QuestManipulator
    {
        /// <summary>
        /// Добавить новую альтернативу
        /// </summary>
        public Alternative AddNewAlt(Quest quest)
        {
            if (quest.QuestType != QuestType.SingleAnswer)
            {
                MessageBox.Show(@"Для данного типа вопроса не требуется альтернатива", @"Добавление альтернатив", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            //подбираем уникальный код альтернативы
            var code = 1;

            while (quest.Any(a => a.Code == code))//увеличиваем счетчик, пока не найдем кода, которого еще нет
                code++;

            var alt = new Alternative { Code = code, Title = "Вариант "  + code };
            quest.Add(alt);

            return alt;
        }

        /// <summary>
        /// Удалить альтренативу
        /// </summary>
        public void RemoveAlt(Quest quest, Alternative alt)
        {
            quest.Remove(alt);
        }

        public void ClearAllAlts(Quest quest)
        {
            quest.Clear();
        }

        /// <summary>
        /// Перемещение альтернативы
        /// </summary>
        public void MoveAlt(Quest quest, Alternative alt, UserPanelActionType dir)
        {
            ListHelper.MoveElement(quest, alt, (int)dir);
        }
    }
}