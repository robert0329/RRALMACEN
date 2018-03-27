﻿using RRAlmacen.Almacen.Ingresos;
using RRAlmacen.Almacen.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RRAlmacen
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
            //Application.Run(new RRAlmacen.Splash.Loading());
            Application.Run(new Login());
        }
    }
}
