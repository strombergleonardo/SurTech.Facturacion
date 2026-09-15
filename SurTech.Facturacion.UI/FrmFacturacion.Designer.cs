namespace SurTech.Facturacion.UI
{
    partial class FrmFacturacion
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbProductos;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Button btnAgregarRenglon;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.ComboBox cmbTipoComprobante;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblTipoComp;
        private System.Windows.Forms.Label lblNeto;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnEmitirFactura;

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
            this.cmbProductos = new System.Windows.Forms.ComboBox();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAgregarRenglon = new System.Windows.Forms.Button();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.cmbTipoComprobante = new System.Windows.Forms.ComboBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblTipoComp = new System.Windows.Forms.Label();
            this.lblNeto = new System.Windows.Forms.Label();
            this.lblIva = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnEmitirFactura = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();

            // lblTipoComp
            this.lblTipoComp.AutoSize = true;
            this.lblTipoComp.Location = new System.Drawing.Point(20, 15);
            this.lblTipoComp.Text = "Tipo de Comprobante:";

            // cmbTipoComprobante
            this.cmbTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoComprobante.Items.AddRange(new object[] { "A", "B", "C" });
            this.cmbTipoComprobante.Location = new System.Drawing.Point(20, 35);
            this.cmbTipoComprobante.Size = new System.Drawing.Size(120, 23);

            // lblProducto
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(160, 15);
            this.lblProducto.Text = "Producto:";

            // cmbProductos
            this.cmbProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductos.Location = new System.Drawing.Point(160, 35);
            this.cmbProductos.Size = new System.Drawing.Size(240, 23);

            // lblCantidad
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(420, 15);
            this.lblCantidad.Text = "Cantidad:";

            // numCantidad
            this.numCantidad.Location = new System.Drawing.Point(420, 35);
            this.numCantidad.Value = 1;
            this.numCantidad.Size = new System.Drawing.Size(80, 23);

            // btnAgregarRenglon
            this.btnAgregarRenglon.Location = new System.Drawing.Point(520, 33);
            this.btnAgregarRenglon.Size = new System.Drawing.Size(120, 26);
            this.btnAgregarRenglon.Text = "Agregar Item";
            this.btnAgregarRenglon.Click += new System.EventHandler(this.BtnAgregarRenglon_Click);

            // dgvDetalle
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(20, 80);
            this.dgvDetalle.Size = new System.Drawing.Size(620, 200);

            // Labels Totales
            this.lblNeto.AutoSize = true;
            this.lblNeto.Location = new System.Drawing.Point(20, 295);
            this.lblNeto.Text = "Neto Gravado: $0.00";

            this.lblIva.AutoSize = true;
            this.lblIva.Location = new System.Drawing.Point(200, 295);
            this.lblIva.Text = "IVA (21%): $0.00";

            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(420, 292);
            this.lblTotal.Text = "TOTAL: $0.00";

            // btnEmitirFactura
            this.btnEmitirFactura.Location = new System.Drawing.Point(420, 330);
            this.btnEmitirFactura.Size = new System.Drawing.Size(220, 35);
            this.btnEmitirFactura.Text = "Confirmar y Emitir Factura";
            this.btnEmitirFactura.Click += new System.EventHandler(this.BtnEmitirFactura_Click);

            // FrmFacturacion
            this.ClientSize = new System.Drawing.Size(660, 380);
            this.Controls.Add(this.lblTipoComp);
            this.Controls.Add(this.cmbTipoComprobante);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.cmbProductos);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.btnAgregarRenglon);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.lblNeto);
            this.Controls.Add(this.lblIva);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnEmitirFactura);
            this.Text = "Emisión de Comprobantes - Práctica de Facturación";

            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}