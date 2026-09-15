namespace SurTech.Facturacion.UI
{
    partial class FrmCargaPdf
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.SplitContainer splitContainer;
        private Microsoft.Web.WebView2.WinForms.WebView2 pdfWebView;
        private System.Windows.Forms.Button btnCargarPdf;

        // Cabecera: Cliente y Comprobante
        private System.Windows.Forms.Label lblTipoComprobante;
        private System.Windows.Forms.ComboBox cmbTipoComprobante;
        private System.Windows.Forms.Label lblPuntoVenta;
        private System.Windows.Forms.NumericUpDown numPuntoVenta;
        private System.Windows.Forms.Label lblNumeroFactura;
        private System.Windows.Forms.NumericUpDown numNumeroFactura;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFechaEmision;

        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.TextBox txtCuitCliente;

        // Carga de Artículos
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ComboBox cmbProductos;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.NumericUpDown numPrecioUnitario;
        private System.Windows.Forms.Button btnAgregarItem;

        // Grilla y Descuentos
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.NumericUpDown numDescuentoPorcentaje;
        private System.Windows.Forms.Button btnAplicarDescuento;

        // Totales
        private System.Windows.Forms.Label lblSubtotalTexto;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblDescuentoTexto;
        private System.Windows.Forms.Label lblDescuentoMonto;
        private System.Windows.Forms.Label lblNetoTexto;
        private System.Windows.Forms.Label lblNeto;
        private System.Windows.Forms.Label lblIvaTexto;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.Label lblTotalTexto;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnGuardarDatos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pdfWebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.btnCargarPdf = new System.Windows.Forms.Button();

            this.lblTipoComprobante = new System.Windows.Forms.Label();
            this.cmbTipoComprobante = new System.Windows.Forms.ComboBox();
            this.lblPuntoVenta = new System.Windows.Forms.Label();
            this.numPuntoVenta = new System.Windows.Forms.NumericUpDown();
            this.lblNumeroFactura = new System.Windows.Forms.Label();
            this.numNumeroFactura = new System.Windows.Forms.NumericUpDown();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFechaEmision = new System.Windows.Forms.DateTimePicker();

            this.lblCliente = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.lblCuit = new System.Windows.Forms.Label();
            this.txtCuitCliente = new System.Windows.Forms.TextBox();

            this.lblProducto = new System.Windows.Forms.Label();
            this.cmbProductos = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.numPrecioUnitario = new System.Windows.Forms.NumericUpDown();
            this.btnAgregarItem = new System.Windows.Forms.Button();

            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.numDescuentoPorcentaje = new System.Windows.Forms.NumericUpDown();
            this.btnAplicarDescuento = new System.Windows.Forms.Button();

            this.lblSubtotalTexto = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblDescuentoTexto = new System.Windows.Forms.Label();
            this.lblDescuentoMonto = new System.Windows.Forms.Label();
            this.lblNetoTexto = new System.Windows.Forms.Label();
            this.lblNeto = new System.Windows.Forms.Label();
            this.lblIvaTexto = new System.Windows.Forms.Label();
            this.lblIva = new System.Windows.Forms.Label();
            this.lblTotalTexto = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnGuardarDatos = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdfWebView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPuntoVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumeroFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioUnitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDescuentoPorcentaje)).BeginInit();
            this.SuspendLayout();

            // splitContainer
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Panel1.Controls.Add(this.btnCargarPdf);
            this.splitContainer.Panel1.Controls.Add(this.pdfWebView);

            // Panel Formulario
            this.splitContainer.Panel2.Controls.Add(this.lblTipoComprobante);
            this.splitContainer.Panel2.Controls.Add(this.cmbTipoComprobante);
            this.splitContainer.Panel2.Controls.Add(this.lblPuntoVenta);
            this.splitContainer.Panel2.Controls.Add(this.numPuntoVenta);
            this.splitContainer.Panel2.Controls.Add(this.lblNumeroFactura);
            this.splitContainer.Panel2.Controls.Add(this.numNumeroFactura);
            this.splitContainer.Panel2.Controls.Add(this.lblFecha);
            this.splitContainer.Panel2.Controls.Add(this.dtpFechaEmision);

            this.splitContainer.Panel2.Controls.Add(this.lblCliente);
            this.splitContainer.Panel2.Controls.Add(this.txtNombreCliente);
            this.splitContainer.Panel2.Controls.Add(this.lblCuit);
            this.splitContainer.Panel2.Controls.Add(this.txtCuitCliente);

            this.splitContainer.Panel2.Controls.Add(this.lblProducto);
            this.splitContainer.Panel2.Controls.Add(this.cmbProductos);
            this.splitContainer.Panel2.Controls.Add(this.lblCantidad);
            this.splitContainer.Panel2.Controls.Add(this.numCantidad);
            this.splitContainer.Panel2.Controls.Add(this.lblPrecio);
            this.splitContainer.Panel2.Controls.Add(this.numPrecioUnitario);
            this.splitContainer.Panel2.Controls.Add(this.btnAgregarItem);

            this.splitContainer.Panel2.Controls.Add(this.dgvDetalles);
            this.splitContainer.Panel2.Controls.Add(this.lblDescuento);
            this.splitContainer.Panel2.Controls.Add(this.numDescuentoPorcentaje);
            this.splitContainer.Panel2.Controls.Add(this.btnAplicarDescuento);

            this.splitContainer.Panel2.Controls.Add(this.lblSubtotalTexto);
            this.splitContainer.Panel2.Controls.Add(this.lblSubtotal);
            this.splitContainer.Panel2.Controls.Add(this.lblDescuentoTexto);
            this.splitContainer.Panel2.Controls.Add(this.lblDescuentoMonto);
            this.splitContainer.Panel2.Controls.Add(this.lblNetoTexto);
            this.splitContainer.Panel2.Controls.Add(this.lblNeto);
            this.splitContainer.Panel2.Controls.Add(this.lblIvaTexto);
            this.splitContainer.Panel2.Controls.Add(this.lblIva);
            this.splitContainer.Panel2.Controls.Add(this.lblTotalTexto);
            this.splitContainer.Panel2.Controls.Add(this.lblTotal);
            this.splitContainer.Panel2.Controls.Add(this.btnGuardarDatos);

            this.splitContainer.Size = new System.Drawing.Size(1200, 680);
            this.splitContainer.SplitterDistance = 520;

            // PDF Visor
            this.btnCargarPdf.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCargarPdf.Height = 35;
            this.btnCargarPdf.Text = "📁 Abrir PDF de Factura";
            this.btnCargarPdf.Click += new System.EventHandler(this.BtnCargarPdf_Click);

            this.pdfWebView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfWebView.Location = new System.Drawing.Point(0, 35);
            this.pdfWebView.Size = new System.Drawing.Size(520, 645);

            // Row 1: Tipo, PV, Nº Comprobante, Fecha
            this.lblTipoComprobante.Location = new System.Drawing.Point(15, 15);
            this.lblTipoComprobante.Text = "Tipo:";
            this.lblTipoComprobante.AutoSize = true;

            this.cmbTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoComprobante.Location = new System.Drawing.Point(55, 12);
            this.cmbTipoComprobante.Size = new System.Drawing.Size(90, 23);

            this.lblPuntoVenta.Location = new System.Drawing.Point(150, 15);
            this.lblPuntoVenta.Text = "P.V.:";
            this.lblPuntoVenta.AutoSize = true;

            this.numPuntoVenta.Location = new System.Drawing.Point(180, 12);
            this.numPuntoVenta.Maximum = 99999;
            this.numPuntoVenta.Value = 1;
            this.numPuntoVenta.Size = new System.Drawing.Size(55, 23);

            this.lblNumeroFactura.Location = new System.Drawing.Point(240, 15);
            this.lblNumeroFactura.Text = "Nº:";
            this.lblNumeroFactura.AutoSize = true;

            this.numNumeroFactura.Location = new System.Drawing.Point(265, 12);
            this.numNumeroFactura.Maximum = 99999999;
            this.numNumeroFactura.Size = new System.Drawing.Size(85, 23);

            this.lblFecha.Location = new System.Drawing.Point(355, 15);
            this.lblFecha.Text = "Fecha:";
            this.lblFecha.AutoSize = true;

            this.dtpFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEmision.Location = new System.Drawing.Point(400, 12);
            this.dtpFechaEmision.Size = new System.Drawing.Size(95, 23);

            // Row 2: Datos Cliente
            this.lblCliente.Location = new System.Drawing.Point(15, 50);
            this.lblCliente.Text = "Cliente:";
            this.lblCliente.AutoSize = true;

            this.txtNombreCliente.Location = new System.Drawing.Point(65, 47);
            this.txtNombreCliente.Size = new System.Drawing.Size(200, 23);

            this.lblCuit.Location = new System.Drawing.Point(275, 50);
            this.lblCuit.Text = "CUIT/DNI:";
            this.lblCuit.AutoSize = true;

            this.txtCuitCliente.Location = new System.Drawing.Point(340, 47);
            this.txtCuitCliente.Size = new System.Drawing.Size(155, 23);

            // Row 3: Artículos
            this.lblProducto.Location = new System.Drawing.Point(15, 85);
            this.lblProducto.Text = "Producto:";
            this.lblProducto.AutoSize = true;

            this.cmbProductos.FormattingEnabled = true;
            this.cmbProductos.Location = new System.Drawing.Point(80, 82);
            this.cmbProductos.Size = new System.Drawing.Size(180, 23);

            this.lblCantidad.Location = new System.Drawing.Point(265, 85);
            this.lblCantidad.Text = "Cant:";
            this.lblCantidad.AutoSize = true;

            this.numCantidad.Location = new System.Drawing.Point(300, 82);
            this.numCantidad.Minimum = 1;
            this.numCantidad.Value = 1;
            this.numCantidad.Size = new System.Drawing.Size(45, 23);

            this.lblPrecio.Location = new System.Drawing.Point(350, 85);
            this.lblPrecio.Text = "Precio:";
            this.lblPrecio.AutoSize = true;

            this.numPrecioUnitario.DecimalPlaces = 2;
            this.numPrecioUnitario.Location = new System.Drawing.Point(395, 82);
            this.numPrecioUnitario.Maximum = 10000000;
            this.numPrecioUnitario.Size = new System.Drawing.Size(100, 23);

            this.btnAgregarItem.Location = new System.Drawing.Point(15, 115);
            this.btnAgregarItem.Size = new System.Drawing.Size(480, 28);
            this.btnAgregarItem.Text = "➕ Agregar Ítem";
            this.btnAgregarItem.Click += new System.EventHandler(this.BtnAgregarItem_Click);

            // Grilla de detalles
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalles.Location = new System.Drawing.Point(15, 150);
            this.dgvDetalles.Size = new System.Drawing.Size(480, 280);
            this.dgvDetalles.ReadOnly = true;

            // Row Descuento
            this.lblDescuento.Location = new System.Drawing.Point(15, 442);
            this.lblDescuento.Text = "Descuento (%):";
            this.lblDescuento.AutoSize = true;

            this.numDescuentoPorcentaje.DecimalPlaces = 2;
            this.numDescuentoPorcentaje.Location = new System.Drawing.Point(105, 440);
            this.numDescuentoPorcentaje.Maximum = 100;
            this.numDescuentoPorcentaje.Size = new System.Drawing.Size(65, 23);

            this.btnAplicarDescuento.Location = new System.Drawing.Point(180, 438);
            this.btnAplicarDescuento.Size = new System.Drawing.Size(130, 26);
            this.btnAplicarDescuento.Text = "🏷️ Aplicar Descuento";
            this.btnAplicarDescuento.Click += new System.EventHandler(this.BtnAplicarDescuento_Click);

            // Totales
            this.lblSubtotalTexto.Location = new System.Drawing.Point(320, 470);
            this.lblSubtotalTexto.Text = "Subtotal:";
            this.lblSubtotalTexto.AutoSize = true;

            this.lblSubtotal.Location = new System.Drawing.Point(420, 470);
            this.lblSubtotal.Text = "$ 0,00";
            this.lblSubtotal.AutoSize = true;

            this.lblDescuentoTexto.Location = new System.Drawing.Point(320, 495);
            this.lblDescuentoTexto.Text = "Descuento:";
            this.lblDescuentoTexto.AutoSize = true;

            this.lblDescuentoMonto.Location = new System.Drawing.Point(420, 495);
            this.lblDescuentoMonto.Text = "$ 0,00";
            this.lblDescuentoMonto.AutoSize = true;

            this.lblNetoTexto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNetoTexto.Location = new System.Drawing.Point(320, 520);
            this.lblNetoTexto.Text = "Neto Gravado:";
            this.lblNetoTexto.AutoSize = true;

            this.lblNeto.Location = new System.Drawing.Point(420, 520);
            this.lblNeto.Text = "$ 0,00";
            this.lblNeto.AutoSize = true;

            this.lblIvaTexto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIvaTexto.Location = new System.Drawing.Point(320, 545);
            this.lblIvaTexto.Text = "IVA:";
            this.lblIvaTexto.AutoSize = true;

            this.lblIva.Location = new System.Drawing.Point(420, 545);
            this.lblIva.Text = "$ 0,00";
            this.lblIva.AutoSize = true;

            this.lblTotalTexto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalTexto.Location = new System.Drawing.Point(320, 575);
            this.lblTotalTexto.Text = "TOTAL:";
            this.lblTotalTexto.AutoSize = true;

            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(420, 575);
            this.lblTotal.Text = "$ 0,00";
            this.lblTotal.AutoSize = true;

            this.btnGuardarDatos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardarDatos.Location = new System.Drawing.Point(15, 560);
            this.btnGuardarDatos.Size = new System.Drawing.Size(220, 45);
            this.btnGuardarDatos.Text = "💾 Guardar Comprobante";
            this.btnGuardarDatos.Click += new System.EventHandler(this.BtnGuardarDatos_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(1200, 680);
            this.Controls.Add(this.splitContainer);
            this.Name = "FrmCargaPdf";
            this.Text = "Carga Manual de Comprobantes con PDF";
            this.Load += new System.EventHandler(this.FrmCargaPdf_Load);

            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pdfWebView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPuntoVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumeroFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioUnitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDescuentoPorcentaje)).EndInit();
            this.ResumeLayout(false);
        }
    }
}