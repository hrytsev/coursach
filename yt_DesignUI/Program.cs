using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using yt_DesignUI.Forms;
using yt_DesignUI.Models;

namespace yt_DesignUI
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения..
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            Application.Run(new
                                 //GetInfoEmployee(super,entr)
                                 Entrance()
                //WritingNewLetter(super,entr)
                //Editing(super,entr)
                //  Removing(super, entr)
               //  EnterpriseOperations(super, entr)
                ) ;
        }
    }
}
