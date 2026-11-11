using System;
using System.Windows.Forms;

namespace AVATAR
{

static class Program
{

/// <summary>
/// Punto de entrada principal para la aplicación AVATAR.
/// </summary>
        [STAThread]
        static void Main()
        {
        
        	Application.EnableVisualStyles();
        	Application.SetCompatibleTextRenderingDefault(false);
        	
        	
        	Application.Run(new FormMenu());
        
        
        
        }


}


}