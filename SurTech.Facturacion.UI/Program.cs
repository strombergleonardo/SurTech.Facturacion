using System;
using System.Windows.Forms;
using SurTech.Facturacion.Core.Entities;
using SurTech.Facturacion.Data.Context;
using SurTech.Facturacion.Data.Repositories;
using SurTech.Facturacion.Services.BusinessLogic;

namespace SurTech.Facturacion.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize(); // Inicialización de WinForms

            // Variable para almacenar al usuario que logre autenticarse
            Usuario? usuarioAutenticado = null;

            // 1. Validar base de datos y autenticar en el Login
            using (var dbContext = new FacturacionDbContext())
            {
                dbContext.Database.EnsureCreated();

                var usuarioRepository = new UsuarioRepository(dbContext);
                var autenticacionService = new AutenticacionService(usuarioRepository);

                using (var frmLogin = new FrmLogin(autenticacionService))
                {
                    // Mostramos la ventana de Login como diálogo modal
                    if (frmLogin.ShowDialog() == DialogResult.OK)
                    {
                        usuarioAutenticado = frmLogin.UsuarioAutenticado;
                    }
                }
            } // Aquí se cierra y libera la conexión inicial del Login

            // 2. Si el usuario se autenticó correctamente, lanzamos la Aplicación Principal
            if (usuarioAutenticado != null)
            {
                // Application.Run mantiene la ventana FrmMain abierta hasta que el usuario decida salir
                Application.Run(new FrmMain(usuarioAutenticado));
            }
        }
    }
}