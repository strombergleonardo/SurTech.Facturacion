namespace SurTech.Facturacion.UI
{
    partial class FrmProductos
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.NumericUpDown numPrecio;
        private System.Windows.Forms.NumericUpDown numStock;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;

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
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.numPrecio = new System.Windows.Forms.NumericUpDown();
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            this.SuspendLayout();

            // dgvProductos
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(20, 20);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(420, 300);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProductos_CellClick);

            // Labels & Inputs
            this.lblCodigo.Location = new System.Drawing.Point(460, 20);
            this.lblCodigo.Text = "Código:";
            this.lblCodigo.AutoSize = true;

            this.txtCodigo.Location = new System.Drawing.Point(460, 40);
            this.txtCodigo.Size = new System.Drawing.Size(200, 23);

            this.lblDescripcion.Location = new System.Drawing.Point(460, 75);
            this.lblDescripcion.Text = "Descripción:";
            this.lblDescripcion.AutoSize = true;

            this.txtDescripcion.Location = new System.Drawing.Point(460, 95);
            this.txtDescripcion.Size = new System.Drawing.Size(200, 23);

            this.lblPrecio.Location = new System.Drawing.Point(460, 130);
            this.lblPrecio.Text = "Precio Unitario ($):";
            this.lblPrecio.AutoSize = true;

            this.numPrecio.Location = new System.Drawing.Point(460, 150);
            this.numPrecio.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            this.numPrecio.DecimalPlaces = 2;
            this.numPrecio.Size = new System.Drawing.Size(200, 23);

            this.lblStock.Location = new System.Drawing.Point(460, 185);
            this.lblStock.Text = "Stock Inicial:";
            this.lblStock.AutoSize = true;

            this.numStock.Location = new System.Drawing.Point(460, 205);
            this.numStock.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numStock.Size = new System.Drawing.Size(200, 23);

            // Buttons
            this.btnGuardar.Location = new System.Drawing.Point(460, 245);
            this.btnGuardar.Size = new System.Drawing.Size(200, 32);
            this.btnGuardar.Text = "Agregar Producto";
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);

            this.btnNuevo.Location = new System.Drawing.Point(460, 285);
            this.btnNuevo.Size = new System.Drawing.Size(200, 32);
            this.btnNuevo.Text = "Limpiar / Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(680, 340);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.numPrecio);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.numStock);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Text = "Catálogo de Productos y Stock";

            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}