using System;
using System.Reflection;
using System.Windows.Forms;

namespace QuestConstructorNS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ExceptionHandler.Init();

            //иконка для всех форм
            var defaultIconField = typeof(Form).GetField("defaultIcon", BindingFlags.NonPublic | BindingFlags.Static);
            
                if(defaultIconField != null)
                    defaultIconField.SetValue(null, Properties.Resources.question1);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
