namespace SurTech.Facturacion.UI
{
    partial class FrmRegistroAlumno
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label lblConfirmarClave;
        private System.Windows.Forms.TextBox txtConfirmarClave;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnCancelar;

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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.lblConfirmarClave = new System.Windows.Forms.Label();
            this.txtConfirmarClave = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(30, 20);
            this.lblTitulo.Text = "Registro de Nuevo Alumno";

            // lblUsuario
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(30, 65);
            this.lblUsuario.Text = "Nombre de Usuario:";

            // txtUsuario
            this.txtUsuario.Location = new System.Drawing.Point(30, 85);
            this.txtUsuario.Size = new System.Drawing.Size(260, 23);

            // lblClave
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(30, 125);
            this.lblClave.Text = "Contraseña:";

            // txtClave
            this.txtClave.Location = new System.Drawing.Point(30, 145);
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(260, 23);

            // lblConfirmarClave
            this.lblConfirmarClave.AutoSize = true;
            this.lblConfirmarClave.Location = new System.Drawing.Point(30, 185);
            this.lblConfirmarClave.Text = "Confirmar Contraseña:";

            // txtConfirmarClave
            this.txtConfirmarClave.Location = new System.Drawing.Point(30, 205);
            this.txtConfirmarClave.PasswordChar = '*';
            this.txtConfirmarClave.Size = new System.Drawing.Size(260, 23);

            // btnRegistrar
            this.btnRegistrar.Location = new System.Drawing.Point(30, 255);
            this.btnRegistrar.Size = new System.Drawing.Size(120, 32);
            this.btnRegistrar.Text = "Registrarse";
            this.btnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);

            // btnCancelar
            this.btnCancelar.Location = new System.Drawing.Point(170, 255);
            this.btnCancelar.Size = new System.Drawing.Size(120, 32);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);

            // FrmRegistroAlumno
            this.ClientSize = new System.Drawing.Size(320, 310);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.lblConfirmarClave);
            this.Controls.Add(this.txtConfirmarClave);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registro de Alumno";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}