using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SurTech.Facturacion.Core.Entities;
using SurTech.Facturacion.Services.Interfaces;

namespace SurTech.Facturacion.UI
{
    public partial class FrmFacturacion : Form
    {
        private readonly IFacturacionService _facturacionService;
        private readonly IArticuloService _articuloService;
        private readonly Usuario _usuarioLogueado;

        private List<ComprobanteDetalle> _detallesFactura = new List<ComprobanteDetalle>();
        private List<Articulo> _listaArticulos = new List<Articulo>();

        public FrmFacturacion(IFacturacionService facturacionService, IArticuloService articuloService, Usuario usuario)
        {
            InitializeComponent();
            _facturacionService = facturacionService ?? throw new ArgumentNullException(nameof(facturacionService));
            _articuloService = articuloService ?? throw new ArgumentNullException(nameof(articuloService));
            _usuarioLogueado = usuario ?? throw new ArgumentNullException(nameof(usuario));

            CargarCombos();
            ActualizarGrillaDetalles();
        }

        private void CargarCombos()
        {
            _listaArticulos = _articuloService.ObtenerTodos().ToList();
            cmbProductos.DataSource = _listaArticulos;
            cmbProductos.DisplayMember = "Descripcion";
            cmbProductos.ValueMember = "IdArticulo";

            cmbTipoComprobante.SelectedIndex = 0; // "Factura B" por defecto
        }

        private void BtnAgregarRenglon_Click(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedItem is Articulo articuloSeleccionado)
            {
                int cantidad = (int)numCantidad.Value;
                if (cantidad <= 0)
                {
                    MessageBox.Show("Seleccione una cantidad válida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal subtotal = articuloSeleccionado.PrecioUnitario * cantidad;

                _detallesFactura.Add(new ComprobanteDetalle
                {
                    IdArticulo = articuloSeleccionado.IdArticulo,
                    Cantidad = cantidad,
                    PrecioUnitario = articuloSeleccionado.PrecioUnitario,
                    Subtotal = subtotal
                });

                ActualizarGrillaDetalles();
            }
        }

        private void ActualizarGrillaDetalles()
        {
            dgvDetalle.DataSource = null;
            dgvDetalle.DataSource = _detallesFactura;

            decimal neto = _detallesFactura.Sum(d => d.Subtotal);
            decimal iva = neto * 0.21m; // 21% IVA educacional
            decimal total = neto + iva;

            lblNeto.Text = $"Neto Gravado: ${neto:F2}";
            lblIva.Text = $"IVA (21%): ${iva:F2}";
            lblTotal.Text = $"TOTAL: ${total:F2}";
        }

        private void BtnEmitirFactura_Click(object sender, EventArgs e)
        {
            decimal neto = _detallesFactura.Sum(d => d.Subtotal);
            decimal iva = neto * 0.21m;

            var comprobante = new Comprobante
            {
                IdUsuario = _usuarioLogueado.IdUsuario,
                IdEntidad = 1, // Consumidor Final / Cliente Genérico
                TipoOperacion = "Venta",
                TipoComprobante = cmbTipoComprobante.SelectedItem?.ToString() ?? "B",
                FechaEmision = DateTime.Now,
                NetoGravado = neto,
                ImporteIva = iva,
                Total = neto + iva,
                Detalles = _detallesFactura
            };

            if (_facturacionService.RegistrarFactura(comprobante, out string mensajeError))
            {
                MessageBox.Show("¡Factura emitida y registrada exitosamente! El stock ha sido actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _detallesFactura.Clear();
                ActualizarGrillaDetalles();
                CargarCombos(); // Recargar productos con stock actualizado
            }
            else
            {
                MessageBox.Show(mensajeError, "Error al Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}