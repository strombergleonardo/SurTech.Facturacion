namespace SurTech.Facturacion.UI
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblEstadoUsuario;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnClientes;
        private System.Windows.Forms.ToolStripButton btnProductos;
        private System.Windows.Forms.ToolStripButton btnFacturacion;
        private System.Windows.Forms.ToolStripButton btnConfiguracionProfesor;
        private System.Windows.Forms.ToolStripButton btnCerrarSesion;

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
            statusStrip1 = new StatusStrip();
            lblEstadoUsuario = new ToolStripStatusLabel();
            toolStrip1 = new ToolStrip();
            btnClientes = new ToolStripButton();
            btnProductos = new ToolStripButton();
            btnFacturacion = new ToolStripButton();
            btnConfiguracionProfesor = new ToolStripButton();
            btnCerrarSesion = new ToolStripButton();
            btnCargarPdf = new ToolStripButton();
            statusStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblEstadoUsuario });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 0;
            // 
            // lblEstadoUsuario
            // 
            lblEstadoUsuario.Name = "lblEstadoUsuario";
            lblEstadoUsuario.Size = new Size(0, 17);
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnCargarPdf, btnFacturacion, btnProductos, btnClientes, btnConfiguracionProfesor, btnCerrarSesion });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 1;
            // 
            // btnClientes
            // 
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(108, 22);
            btnClientes.Text = "Historial / Clientes";
            btnClientes.Click += BtnClientes_Click;
            // 
            // btnProductos
            // 
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(105, 22);
            btnProductos.Text = "Productos / Stock";
            btnProductos.Click += BtnProductos_Click;
            // 
            // btnFacturacion
            // 
            btnFacturacion.Name = "btnFacturacion";
            btnFacturacion.Size = new Size(73, 22);
            btnFacturacion.Text = "Facturación";
            btnFacturacion.Click += BtnFacturacion_Click;
            // 
            // btnConfiguracionProfesor
            // 
            btnConfiguracionProfesor.Name = "btnConfiguracionProfesor";
            btnConfiguracionProfesor.Size = new Size(123, 22);
            btnConfiguracionProfesor.Text = "Evaluación / Profesor";
            btnConfiguracionProfesor.Click += BtnConfiguracionProfesor_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(33, 22);
            btnCerrarSesion.Text = "Salir";
            btnCerrarSesion.Click += BtnCerrarSesion_Click;
            // 
            // btnCargarPdf
            // 
            btnCargarPdf.Name = "btnCargarPdf";
            btnCargarPdf.Size = new Size(70, 22);
            btnCargarPdf.Text = "Cargar PDF";
            btnCargarPdf.Click += BtnCargarPdf_Click;
            // 
            // FrmMain
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            IsMdiContainer = true;
            Name = "FrmMain";
            Text = "SurTech - Principal";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private ToolStripButton btnCargarPdf;
    }
}