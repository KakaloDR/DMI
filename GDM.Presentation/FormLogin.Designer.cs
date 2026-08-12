namespace GDM.Presentation
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblSub = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panelTop.Controls.Add(this.lblSub);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(434, 65);
            this.panelTop.TabIndex = 0;
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblSub.Location = new System.Drawing.Point(14, 38);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(185, 15);
            this.lblSub.TabIndex = 1;
            this.lblSub.Text = "Autenticación de Seguridad - DMI";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(283, 21);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "DMI";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblUsuario.Location = new System.Drawing.Point(40, 95);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(144, 19);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Nombre de Usuario:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtUsuario.Location = new System.Drawing.Point(44, 118);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(346, 27);
            this.txtUsuario.TabIndex = 2;
            this.txtUsuario.Enter += new System.EventHandler(this.txtInput_Enter);
            this.txtUsuario.Leave += new System.EventHandler(this.txtInput_Leave);
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblClave.Location = new System.Drawing.Point(40, 160);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(88, 19);
            this.lblClave.TabIndex = 3;
            this.lblClave.Text = "Contraseña:";
            // 
            // txtClave
            // 
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClave.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtClave.Location = new System.Drawing.Point(44, 183);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(346, 27);
            this.txtClave.TabIndex = 4;
            this.txtClave.UseSystemPasswordChar = true;
            this.txtClave.Enter += new System.EventHandler(this.txtInput_Enter);
            this.txtClave.Leave += new System.EventHandler(this.txtInput_Leave);
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.panelBottom.Controls.Add(this.btnCancelar);
            this.panelBottom.Controls.Add(this.btnIngresar);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 240);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(434, 60);
            this.panelBottom.TabIndex = 5;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancelar.Location = new System.Drawing.Point(140, 10);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 40);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnIngresar
            // 
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIngresar.Location = new System.Drawing.Point(270, 10);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(120, 40);
            this.btnIngresar.TabIndex = 0;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(434, 300);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DMI";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnIngresar;
    }
}
