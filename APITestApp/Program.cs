using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using APITestApp.Functions;

namespace APITestApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {

                CommonFunctions.SaveErrorToFile("An unhandled exception has been encountered. See latest Logs file for details", ex.InnerException, true);
            }
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            CommonFunctions.SaveErrorToFile("An unhandled thread exception has been encountered. See latest Logs file for details", e.Exception, true);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            CommonFunctions.SaveErrorToFile("An unhandled UI exception has been encountered. See latest Logs file for details", e.ExceptionObject as Exception, true);
        }
    }
}
