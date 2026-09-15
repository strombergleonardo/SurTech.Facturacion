using System;
using System.Windows.Forms;
using SurTech.Facturacion.Core.Entities;
using SurTech.Facturacion.Data.Context;
using SurTech.Facturacion.Data.Repositories;
using SurTech.Facturacion.Services.BusinessLogic;

namespace SurTech.Facturacion.UI
{
    public partial class FrmRegistroAlumno : Form
    {
        public FrmRegistroAlumno()
        {
            InitializeComponent();
        }

        private void BtnRegistrar_Click(object? sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text.Trim();
            string confirmarClave = txtConfirmarClave.Text.Trim();

            // 1. Validaciones básicas de entrada
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clave != confirmarClave)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var context = new FacturacionDbContext())
                {
                    var repo = new UsuarioRepository(context);
                    var authService = new AutenticacionService(repo);

                    // 2. Verificar si el nombre de usuario ya existe
                    if (repo.ObtenerPorNombreUsuario(usuario) != null)
                    {
                        MessageBox.Show("El nombre de usuario ya está registrado. Elija otro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 3. Usar el servicio de autenticación para registrar al alumno (realiza hash y guarda)
                    bool registrado = authService.RegistrarAlumno(usuario, clave);
                    if (!registrado)
                    {
                        MessageBox.Show("No se pudo registrar el alumno. Verifique los datos e intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("¡Registro completado con éxito! Ahora puede iniciar sesión.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al registrar el alumno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}