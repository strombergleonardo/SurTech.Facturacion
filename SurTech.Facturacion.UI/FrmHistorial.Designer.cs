namespace SurTech.Facturacion.UI
{
    partial class FrmHistorial
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvComprobantes;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.Label lblComprobantes;
        private System.Windows.Forms.Label lblDetalles;
        private System.Windows.Forms.Button btnExportar;

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
            this.dgvComprobantes = new System.Windows.Forms.DataGridView();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.lblComprobantes = new System.Windows.Forms.Label();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.SuspendLayout();

            // lblComprobantes
            this.lblComprobantes.AutoSize = true;
            this.lblComprobantes.Location = new System.Drawing.Point(15, 10);
            this.lblComprobantes.Text = "Comprobantes Registrados:";
            this.lblComprobantes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            // dgvComprobantes
            this.dgvComprobantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComprobantes.Location = new System.Drawing.Point(15, 30);
            this.dgvComprobantes.ReadOnly = true;
            this.dgvComprobantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComprobantes.Size = new System.Drawing.Size(650, 160);
            this.dgvComprobantes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvComprobantes_CellClick);

            // lblDetalles
            this.lblDetalles.AutoSize = true;
            this.lblDetalles.Location = new System.Drawing.Point(15, 200);
            this.lblDetalles.Text = "Detalle de Productos del Comprobante Seleccionado:";
            this.lblDetalles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            // dgvDetalles
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Location = new System.Drawing.Point(15, 220);
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalles.Size = new System.Drawing.Size(650, 130);

            // btnExportar
            this.btnExportar.Location = new System.Drawing.Point(445, 360);
            this.btnExportar.Size = new System.Drawing.Size(220, 32);
            this.btnExportar.Text = "Ver / Exportar Comprobante";
            this.btnExportar.Click += new System.EventHandler(this.BtnExportar_Click);

            // FrmHistorial
            this.ClientSize = new System.Drawing.Size(680, 405);
            this.Controls.Add(this.lblComprobantes);
            this.Controls.Add(this.dgvComprobantes);
            this.Controls.Add(this.lblDetalles);
            this.Controls.Add(this.dgvDetalles);
            this.Controls.Add(this.btnExportar);
            this.Text = "Consulta de Histórico de Comprobantes";

            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}