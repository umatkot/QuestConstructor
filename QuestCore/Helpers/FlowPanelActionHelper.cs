using System.Linq;
using System.Windows.Forms;

namespace QuestCore
{
    public class FlowPanelActionHelper
    {
        private FlowLayoutPanel FlowLayoutPanel { get; }

        public FlowPanelActionHelper(FlowLayoutPanel flowLayoutPanel)
        {
            FlowLayoutPanel = flowLayoutPanel;
        }

        /// <summary>
        /// Управление пользовательскими элементами управления внутри FlowLayoutControl
        /// </summary>
        /// <param name="elementKey">Ключ элемента управления</param>
        /// <param name="actionType">Тип действия над элементом управления</param>
        public void ProcessElements(string elementKey, UserPanelActionType actionType)
        {

            switch (actionType)
            {
                case UserPanelActionType.Remove:
                    FlowLayoutPanel.Controls.RemoveByKey(elementKey);
                    break;
                case UserPanelActionType.MoveUp:
                case UserPanelActionType.MoveDown:
                    
                    var movingAlt = FlowLayoutPanel.Controls.Find(elementKey, false).First();
                    if (movingAlt == null) break;

                    var controlIndex = FlowLayoutPanel.Controls.IndexOfKey(elementKey);

                    /*ограничение на циклическую перестановку пользовательских элементов управления внутри FlowLayoutControl*/
                    if (controlIndex == 0 && actionType == UserPanelActionType.MoveUp) break;

                    //создаем хелпер отрисовки, останавливаем отрисовку
                    var helper = new ControlHelper(FlowLayoutPanel);
                    FlowLayoutPanel.Controls.SetChildIndex(movingAlt, controlIndex + (int)actionType);
                    helper.ResumeDrawing();
                    break;
            }

        }
    }
}
