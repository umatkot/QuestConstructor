using System;
using System.Threading;
using System.Windows.Forms;

namespace QuestConstructorNS
{
    public static class ExceptionHandler
    {
        public static void Init()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException -= Handle;
            Application.ThreadException += Handle;
            AppDomain.CurrentDomain.UnhandledException -= CurrentDomain_UnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //здесь обрабатываются исключения не UI потоков
            var exc = GetInnerException((Exception)e.ExceptionObject);
            MessageBox.Show(exc.Message, @"Thread exception");
        }

        static void Handle(object sender, ThreadExceptionEventArgs e)
        {
            var exc = GetInnerException(e.Exception);
            MessageBox.Show(exc.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static Exception GetInnerException(Exception exc)
        {
            while (exc.InnerException != null)
                exc = exc.InnerException;
            return exc;
        }
    }
}
