using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SurTech.Facturacion.Core.Entities;
using SurTech.Facturacion.Services.Interfaces;

namespace SurTech.Facturacion.UI
{
    public partial class FrmCargaPdf : Form
    {
        private readonly IFacturacionService _facturacionService;
        private readonly IArticuloService _articuloService;
        private readonly Usuario _usuarioLogueado;

        private readonly List<ComprobanteDetalle> _detallesManuales = new List<ComprobanteDetalle>();
        private decimal _porcentajeDescuentoAplicado = 0m;

        public FrmCargaPdf(
            IFacturacionService facturacionService,
            IArticuloService articuloService,
            Usuario usuarioLogueado)
        {
            InitializeComponent();

            _facturacionService = facturacionService ?? throw new ArgumentNullException(nameof(facturacionService));
            _articuloService = articuloService ?? throw new ArgumentNullException(nameof(articuloService));
            _usuarioLogueado = usuarioLogueado ?? throw new ArgumentNullException(nameof(usuarioLogueado));
        }

        private async void FrmCargaPdf_Load(object sender, EventArgs e)
        {
            try
            {
                await pdfWebView.EnsureCoreWebView2Async(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo inicializar el visor PDF: {ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            cmbTipoComprobante.Items.Clear();
            cmbTipoComprobante.Items.Add("Factura A");
            cmbTipoComprobante.Items.Add("Factura B");
            cmbTipoComprobante.Items.Add("Factura E");
            cmbTipoComprobante.SelectedIndex = 0;

            cmbTipoComprobante.SelectedIndexChanged += cmbTipoComprobante_SelectedIndexChanged;

            CargarProductosCombo();
            ActualizarGrillaYTotales();
        }

        private void BtnCargarPdf_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
                openFileDialog.Title = "Seleccionar PDF de Factura";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaPdf = openFileDialog.FileName;
                    if (pdfWebView != null && pdfWebView.CoreWebView2 != null)
                    {
                        pdfWebView.CoreWebView2.Navigate(new Uri(rutaPdf).AbsoluteUri);
                    }
                }
            }
        }

        private void CargarProductosCombo()
        {
            try
            {
                var articulos = _articuloService.ObtenerTodos().ToList();
                cmbProductos.DataSource = null;
                cmbProductos.DataSource = articulos;
                cmbProductos.DisplayMember = "Descripcion";
                cmbProductos.ValueMember = "IdArticulo";
                cmbProductos.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el catálogo de productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAgregarItem_Click(object sender, EventArgs e)
        {
            string nombreProducto = cmbProductos.Text.Trim();
            int cantidad = (int)numCantidad.Value;
            decimal precio = numPrecioUnitario.Value;

            if (string.IsNullOrEmpty(nombreProducto))
            {
                MessageBox.Show("Ingrese o seleccione un nombre de producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cantidad <= 0 || precio <= 0)
            {
                MessageBox.Show("Ingrese una cantidad y un precio mayores a 0.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idArticuloAsignado = 0;

            var articuloExistente = _articuloService.ObtenerTodos()
                .FirstOrDefault(a => a.Descripcion.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase));

            if (articuloExistente != null)
            {
                idArticuloAsignado = articuloExistente.IdArticulo;
            }
            else
            {
                var nuevoArticulo = new Articulo
                {
                    Descripcion = nombreProducto,
                    PrecioUnitario = precio,
                    StockActual = cantidad
                };

                _articuloService.Agregar(nuevoArticulo);
                idArticuloAsignado = nuevoArticulo.IdArticulo;

                CargarProductosCombo();
            }

            decimal subtotal = cantidad * precio;

            _detallesManuales.Add(new ComprobanteDetalle
            {
                IdArticulo = idArticuloAsignado,
                Cantidad = cantidad,
                PrecioUnitario = precio,
                Subtotal = subtotal
            });

            ActualizarGrillaYTotales();

            cmbProductos.Text = string.Empty;
            cmbProductos.SelectedIndex = -1;
            numCantidad.Value = 1;
            numPrecioUnitario.Value = 0;
        }

        private void BtnAplicarDescuento_Click(object sender, EventArgs e)
        {
            _porcentajeDescuentoAplicado = numDescuentoPorcentaje.Value;
            ActualizarGrillaYTotales();
            MessageBox.Show($"Descuento del {_porcentajeDescuentoAplicado}% aplicado correctamente.", "Descuento", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbTipoComprobante_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ActualizarGrillaYTotales();
        }

        private void ActualizarGrillaYTotales()
        {
            dgvDetalles.DataSource = null;
            dgvDetalles.DataSource = _detallesManuales;

            decimal sumaSubtotales = _detallesManuales.Sum(d => d.Subtotal);
            decimal montoDescuento = Math.Round(sumaSubtotales * (_porcentajeDescuentoAplicado / 100m), 2);
            decimal subtotalConDescuento = sumaSubtotales - montoDescuento;

            decimal netoGravado = 0m;
            decimal importeIva = 0m;
            decimal total = 0m;

            string tipoSeleccionado = cmbTipoComprobante.SelectedItem?.ToString() ?? "Factura A";

            if (tipoSeleccionado.Contains("A"))
            {
                netoGravado = subtotalConDescuento;
                importeIva = Math.Round(netoGravado * 0.21m, 2);
                total = netoGravado + importeIva;
            }
            else if (tipoSeleccionado.Contains("B"))
            {
                total = subtotalConDescuento;
                netoGravado = Math.Round(total / 1.21m, 2);
                importeIva = total - netoGravado;
            }
            else // Factura E
            {
                netoGravado = subtotalConDescuento;
                importeIva = 0m;
                total = subtotalConDescuento;
            }

            lblSubtotal.Text = sumaSubtotales.ToString("N2");
            lblDescuentoMonto.Text = montoDescuento.ToString("N2");
            lblNeto.Text = netoGravado.ToString("N2");
            lblIva.Text = importeIva.ToString("N2");
            lblTotal.Text = total.ToString("N2");
        }

        private void BtnGuardarDatos_Click(object sender, EventArgs e)
        {
            if (!_detallesManuales.Any())
            {
                MessageBox.Show("Debe ingresar al menos un ítem al comprobante.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tipoSeleccionado = cmbTipoComprobante.SelectedItem?.ToString() ?? "Factura A";

            string letraComprobante = "A";
            if (tipoSeleccionado.Contains("B")) letraComprobante = "B";
            else if (tipoSeleccionado.Contains("E")) letraComprobante = "E";

            decimal sumaSubtotales = _detallesManuales.Sum(d => d.Subtotal);
            decimal montoDescuento = Math.Round(sumaSubtotales * (_porcentajeDescuentoAplicado / 100m), 2);
            decimal subtotalConDescuento = sumaSubtotales - montoDescuento;

            decimal netoGravado = 0m;
            decimal importeIva = 0m;
            decimal total = 0m;

            if (letraComprobante == "A")
            {
                netoGravado = subtotalConDescuento;
                importeIva = Math.Round(netoGravado * 0.21m, 2);
                total = netoGravado + importeIva;
            }
            else if (letraComprobante == "B")
            {
                total = subtotalConDescuento;
                netoGravado = Math.Round(total / 1.21m, 2);
                importeIva = total - netoGravado;
            }
            else
            {
                netoGravado = subtotalConDescuento;
                importeIva = 0m;
                total = subtotalConDescuento;
            }

            var comprobante = new Comprobante
            {
                IdUsuario = _usuarioLogueado.IdUsuario,
                IdEntidad = 1,
                TipoOperacion = $"Factura {letraComprobante} - {txtNombreCliente.Text.Trim()}",
                TipoComprobante = letraComprobante,
                FechaEmision = dtpFechaEmision.Value,
                NetoGravado = netoGravado,
                ImporteIva = importeIva,
                Total = total,
                Detalles = _detallesManuales
            };

            if (_facturacionService.RegistrarFactura(comprobante, out string mensajeError))
            {
                MessageBox.Show($"¡Factura Tipo {letraComprobante} registrada con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show(mensajeError, "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            _detallesManuales.Clear();
            _porcentajeDescuentoAplicado = 0m;
            numDescuentoPorcentaje.Value = 0;

            txtNombreCliente.Text = string.Empty;
            txtCuitCliente.Text = string.Empty;
            numPuntoVenta.Value = 1;
            numNumeroFactura.Value = 0;

            ActualizarGrillaYTotales();

            cmbTipoComprobante.SelectedIndex = 0;
            dtpFechaEmision.Value = DateTime.Now;
            cmbProductos.Text = string.Empty;
            cmbProductos.SelectedIndex = -1;
            numCantidad.Value = 1;
            numPrecioUnitario.Value = 0;
        }
    }
}