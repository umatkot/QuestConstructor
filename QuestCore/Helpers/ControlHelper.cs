using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuestCore
{
    public class ControlHelper
    {
        private int _scrollValue;
        private readonly ScrollableControl _ctrl;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        public ControlHelper(ScrollableControl ctrl)
        {
            this._ctrl = ctrl;
            StopDrawing();
        }

        private void StopDrawing()
        {
            SendMessage(_ctrl.Handle, WM_SETREDRAW, false, 0);
            _scrollValue = _ctrl.VerticalScroll.Value;
            _ctrl.SuspendLayout();
        }

        public void ResumeDrawing()
        {
            _ctrl.VerticalScroll.Value = Math.Min(_ctrl.VerticalScroll.Maximum, _scrollValue);
            _ctrl.ResumeLayout();
            SendMessage(_ctrl.Handle, WM_SETREDRAW, true, 0);
            _ctrl.Refresh();
        }
    }
}
