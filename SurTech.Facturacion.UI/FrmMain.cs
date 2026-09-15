using System;
using System.Windows.Forms;
using SurTech.Facturacion.Core.Entities;

namespace SurTech.Facturacion.UI
{
    public partial class FrmMain : Form
    {
        private readonly Usuario _usuarioLogueado;

        public FrmMain(Usuario usuario)
        {
            InitializeComponent();
            _usuarioLogueado = usuario ?? throw new ArgumentNullException(nameof(usuario));

            ConfigurarInterfazPorRol();
        }

        private void ConfigurarInterfazPorRol()
        {
            this.Text = $"SurTech - Sistema de Facturación Educativo | Usuario: {_usuarioLogueado.NombreUsuario} [{_usuarioLogueado.Rol}]";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            lblEstadoUsuario.Text = $"Usuario actual: {_usuarioLogueado.NombreUsuario} | Rol: {_usuarioLogueado.Rol}";

            // Control de acceso por roles: Solo el Profesor accede a la configuración pedagógica
            if (_usuarioLogueado.Rol != "Profesor")
            {
                btnConfiguracionProfesor.Enabled = false;
            }

            // Asignar el evento para la opción del Profesor
            btnConfiguracionProfesor.Click += BtnConfiguracionProfesor_Click;
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            // Abrimos el Historial de Comprobantes emitidos
            using (var frmHistorial = new FrmHistorial())
            {
                frmHistorial.StartPosition = FormStartPosition.CenterParent;
                frmHistorial.ShowDialog(this);
            }
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            using (var context = new SurTech.Facturacion.Data.Context.FacturacionDbContext())
            {
                var repo = new SurTech.Facturacion.Data.Repositories.Repository<Articulo>(context);
                var service = new SurTech.Facturacion.Services.BusinessLogic.ArticuloService(repo);

                using (var frmProductos = new FrmProductos(service))
                {
                    frmProductos.StartPosition = FormStartPosition.CenterParent;
                    frmProductos.ShowDialog(this);
                }
            }
        }

        private void BtnFacturacion_Click(object sender, EventArgs e)
        {
            using (var context = new SurTech.Facturacion.Data.Context.FacturacionDbContext())
            {
                var articuloRepo = new SurTech.Facturacion.Data.Repositories.Repository<Articulo>(context);
                var articuloService = new SurTech.Facturacion.Services.BusinessLogic.ArticuloService(articuloRepo);
                var facturacionService = new SurTech.Facturacion.Services.BusinessLogic.FacturacionService(context);

                using (var frmFacturacion = new FrmFacturacion(facturacionService, articuloService, _usuarioLogueado))
                {
                    frmFacturacion.StartPosition = FormStartPosition.CenterParent;
                    frmFacturacion.ShowDialog(this);
                }
            }
        }

        private void BtnConfiguracionProfesor_Click(object? sender, EventArgs e)
        {
            MessageBox.Show($"Panel de Evaluación Activo.\n\nEl usuario '{_usuarioLogueado.NombreUsuario}' tiene permisos de revisión de práctica financiera.",
                            "Módulo del Profesor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnCargarPdf_Click(object? sender, EventArgs e)
        {
            using (var context = new SurTech.Facturacion.Data.Context.FacturacionDbContext())
            {
                var articuloRepo = new SurTech.Facturacion.Data.Repositories.Repository<Articulo>(context);
                var articuloService = new SurTech.Facturacion.Services.BusinessLogic.ArticuloService(articuloRepo);
                var facturacionService = new SurTech.Facturacion.Services.BusinessLogic.FacturacionService(context);

                using (var frmPdf = new FrmCargaPdf(facturacionService, articuloService, _usuarioLogueado))
                {
                    frmPdf.StartPosition = FormStartPosition.CenterParent;
                    frmPdf.ShowDialog(this);
                }
            }
        }
    }
}