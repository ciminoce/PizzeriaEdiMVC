using System;
using System.Windows.Forms;
using PizzeriaEdiMVC.Windows.Mapeador;
using PizzeriaEdiMVC.Windows.Ninject;

namespace PizzeriaEdiMVC.Windows
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DI.Inicialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AutoMapperConfig.Init();
            Application.Run(DI.Create<FrmMenuPrincipal>());
        }
    }
}
