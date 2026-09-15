using System;
using System.Windows.Forms;
using SurTech.Facturacion.Core.Entities;
using SurTech.Facturacion.Services.Interfaces;

namespace SurTech.Facturacion.UI
{
    public partial class FrmLogin : Form
    {
        private readonly IAutenticacionService _autenticacionService;

        // Propiedad para conservar el usuario que inició sesión exitosamente
        public Usuario? UsuarioAutenticado { get; private set; }

        public FrmLogin(IAutenticacionService autenticacionService)
        {
            InitializeComponent();
            _autenticacionService = autenticacionService ?? throw new ArgumentNullException(nameof(autenticacionService));
            ConfigurarControlesFormulario();
        }

        private void ConfigurarControlesFormulario()
        {
            this.Text = "SurTech - Sistema de Facturación Educativo";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }
        private void BtnRegistrarAlumno_Click(object? sender, EventArgs e)
        {
            using (var frmRegistro = new FrmRegistroAlumno())
            {
                frmRegistro.ShowDialog(this);
            }
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text;

            var usuarioValido = _autenticacionService.IniciarSesion(usuario, clave);

            if (usuarioValido != null)
            {
                UsuarioAutenticado = usuarioValido;
                MessageBox.Show($"Bienvenido/a {usuarioValido.NombreUsuario} ({usuarioValido.Rol})",
                                "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.",
                                "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClave.Clear();
                txtClave.Focus();
            }

        }
    }
}