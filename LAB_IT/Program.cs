using LAB_IT.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_IT
{
    static class Program
    {
        public static DatabaseManager databaseManager = new DatabaseManager();
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            databaseManager.Init();
            Application.Run(new DataBaseMainForm());
        }
    }
}
