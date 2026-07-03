using System;
using System.Windows.Forms;

namespace GDM.Presentation;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        // 1. Mostrar pantalla de Login de Seguridad
        using (var login = new FormLogin())
        {
            if (login.ShowDialog() == DialogResult.OK)
            {
                // 2. Si las credenciales fueron correctas, iniciar el Dashboard
                Application.Run(new Form1());
            }
            else
            {
                Application.Exit();
            }
        }
    }    
}