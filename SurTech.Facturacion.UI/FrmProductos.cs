using System;
using System.Linq;
using System.Windows.Forms;
using SurTech.Facturacion.Core.Entities;
using SurTech.Facturacion.Services.Interfaces;

namespace SurTech.Facturacion.UI
{
    public partial class FrmProductos : Form
    {
        private readonly IArticuloService _articuloService;
        private int _idArticuloSeleccionado = 0;

        public FrmProductos(IArticuloService articuloService)
        {
            InitializeComponent();
            _articuloService = articuloService ?? throw new ArgumentNullException(nameof(articuloService));
            CargarGrillaProductos();
        }

        private void CargarGrillaProductos()
        {
            dgvProductos.DataSource = _articuloService.ObtenerTodos().ToList();
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            _idArticuloSeleccionado = 0;
            txtCodigo.Clear();
            txtDescripcion.Clear();
            numPrecio.Value = 0;
            numStock.Value = 0;
            btnGuardar.Text = "Agregar Producto";
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            var articulo = new Articulo
            {
                IdArticulo = _idArticuloSeleccionado,
                Codigo = txtCodigo.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                PrecioUnitario = numPrecio.Value,
                StockActual = (int)numStock.Value
            };

            if (_articuloService.GuardarArticulo(articulo, out string mensajeError))
            {
                MessageBox.Show("Producto guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrillaProductos();
            }
            else
            {
                MessageBox.Show(mensajeError, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProductos.Rows[e.RowIndex].DataBoundItem is Articulo articulo)
            {
                _idArticuloSeleccionado = articulo.IdArticulo;
                txtCodigo.Text = articulo.Codigo;
                txtDescripcion.Text = articulo.Descripcion;
                numPrecio.Value = articulo.PrecioUnitario;
                numStock.Value = articulo.StockActual;
                btnGuardar.Text = "Actualizar Producto";
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}