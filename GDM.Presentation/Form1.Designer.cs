namespace GDM.Presentation
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.lblDMI = new System.Windows.Forms.Label();
            this.btnVisitas = new System.Windows.Forms.Button();
            this.btnConsultaVisitas = new System.Windows.Forms.Button();
            this.btnTiposFarmacos = new System.Windows.Forms.Button();
            this.btnMarcas = new System.Windows.Forms.Button();
            this.btnUbicaciones = new System.Windows.Forms.Button();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.btnMedicos = new System.Windows.Forms.Button();
            this.btnMedicamentos = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelWorkspace = new System.Windows.Forms.Panel();
            this.panelSidebar.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(41)))), ((int)(((byte)(74)))));
            this.panelSidebar.Controls.Add(this.lblDMI);
            this.panelSidebar.Controls.Add(this.btnVisitas);
            this.panelSidebar.Controls.Add(this.btnConsultaVisitas);
            this.panelSidebar.Controls.Add(this.btnTiposFarmacos);
            this.panelSidebar.Controls.Add(this.btnMarcas);
            this.panelSidebar.Controls.Add(this.btnUbicaciones);
            this.panelSidebar.Controls.Add(this.btnPacientes);
            this.panelSidebar.Controls.Add(this.btnMedicos);
            this.panelSidebar.Controls.Add(this.btnMedicamentos);
            this.panelSidebar.Controls.Add(this.btnSalir);
            this.panelSidebar.Controls.Add(this.lblGrupo);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(250, 780);
            this.panelSidebar.TabIndex = 0;
            // 
            // lblDMI
            // 
            this.lblDMI.AutoSize = true;
            this.lblDMI.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblDMI.ForeColor = System.Drawing.Color.White;
            this.lblDMI.Location = new System.Drawing.Point(20, 20);
            this.lblDMI.Name = "lblDMI";
            this.lblDMI.Size = new System.Drawing.Size(86, 45);
            this.lblDMI.TabIndex = 0;
            this.lblDMI.Text = "DMI";
            // 
            // btnVisitas
            // 
            this.btnVisitas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVisitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisitas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVisitas.Location = new System.Drawing.Point(15, 90);
            this.btnVisitas.Name = "btnVisitas";
            this.btnVisitas.Size = new System.Drawing.Size(220, 45);
            this.btnVisitas.TabIndex = 1;
            this.btnVisitas.Text = "Registro de Visitas";
            this.btnVisitas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVisitas.UseVisualStyleBackColor = true;
            this.btnVisitas.Click += new System.EventHandler(this.btnVisitas_Click);
            // 
            // btnConsultaVisitas
            // 
            this.btnConsultaVisitas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultaVisitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultaVisitas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConsultaVisitas.Location = new System.Drawing.Point(15, 140);
            this.btnConsultaVisitas.Name = "btnConsultaVisitas";
            this.btnConsultaVisitas.Size = new System.Drawing.Size(220, 45);
            this.btnConsultaVisitas.TabIndex = 2;
            this.btnConsultaVisitas.Text = "Consulta de Visitas";
            this.btnConsultaVisitas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultaVisitas.UseVisualStyleBackColor = true;
            this.btnConsultaVisitas.Click += new System.EventHandler(this.btnConsultaVisitas_Click);
            // 
            // btnTiposFarmacos
            // 
            this.btnTiposFarmacos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTiposFarmacos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTiposFarmacos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTiposFarmacos.Location = new System.Drawing.Point(15, 190);
            this.btnTiposFarmacos.Name = "btnTiposFarmacos";
            this.btnTiposFarmacos.Size = new System.Drawing.Size(220, 45);
            this.btnTiposFarmacos.TabIndex = 3;
            this.btnTiposFarmacos.Text = "Tipos de Fármacos";
            this.btnTiposFarmacos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTiposFarmacos.UseVisualStyleBackColor = true;
            this.btnTiposFarmacos.Click += new System.EventHandler(this.btnTiposFarmacos_Click);
            // 
            // btnMarcas
            // 
            this.btnMarcas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarcas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarcas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMarcas.Location = new System.Drawing.Point(15, 240);
            this.btnMarcas.Name = "btnMarcas";
            this.btnMarcas.Size = new System.Drawing.Size(220, 45);
            this.btnMarcas.TabIndex = 4;
            this.btnMarcas.Text = "Marcas (Laboratorios)";
            this.btnMarcas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMarcas.UseVisualStyleBackColor = true;
            this.btnMarcas.Click += new System.EventHandler(this.btnMarcas_Click);
            // 
            // btnUbicaciones
            // 
            this.btnUbicaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUbicaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUbicaciones.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUbicaciones.Location = new System.Drawing.Point(15, 290);
            this.btnUbicaciones.Name = "btnUbicaciones";
            this.btnUbicaciones.Size = new System.Drawing.Size(220, 45);
            this.btnUbicaciones.TabIndex = 5;
            this.btnUbicaciones.Text = "Ubicaciones Físicas";
            this.btnUbicaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUbicaciones.UseVisualStyleBackColor = true;
            this.btnUbicaciones.Click += new System.EventHandler(this.btnUbicaciones_Click);
            // 
            // btnPacientes
            // 
            this.btnPacientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacientes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPacientes.Location = new System.Drawing.Point(15, 340);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(220, 45);
            this.btnPacientes.TabIndex = 6;
            this.btnPacientes.Text = "Pacientes";
            this.btnPacientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPacientes.UseVisualStyleBackColor = true;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // btnMedicos
            // 
            this.btnMedicos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMedicos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedicos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMedicos.Location = new System.Drawing.Point(15, 390);
            this.btnMedicos.Name = "btnMedicos";
            this.btnMedicos.Size = new System.Drawing.Size(220, 45);
            this.btnMedicos.TabIndex = 7;
            this.btnMedicos.Text = "Médicos (Personal)";
            this.btnMedicos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMedicos.UseVisualStyleBackColor = true;
            this.btnMedicos.Click += new System.EventHandler(this.btnMedicos_Click);
            // 
            // btnMedicamentos
            // 
            this.btnMedicamentos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMedicamentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedicamentos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMedicamentos.Location = new System.Drawing.Point(15, 440);
            this.btnMedicamentos.Name = "btnMedicamentos";
            this.btnMedicamentos.Size = new System.Drawing.Size(220, 45);
            this.btnMedicamentos.TabIndex = 8;
            this.btnMedicamentos.Text = "Medicamentos";
            this.btnMedicamentos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMedicamentos.UseVisualStyleBackColor = true;
            this.btnMedicamentos.Click += new System.EventHandler(this.btnMedicamentos_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSalir.Location = new System.Drawing.Point(15, 520);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(220, 45);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Cerrar Sesión";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblGrupo
            // 
            this.lblGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGrupo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular);
            this.lblGrupo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblGrupo.Location = new System.Drawing.Point(15, 580);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(220, 180);
            this.lblGrupo.TabIndex = 10;
            this.lblGrupo.Text = "Integrantes:\r\n- Giancarlo Martínez\r\n  A00106912\r\n- Gael Durant B.\r\n  A00110065\r\n- Eric Villanueva\r\n  A00116168\r\n- Bienvenido Hernández\r\n  A00115456";
            this.lblGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(250, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 65);
            this.panelHeader.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(41)))), ((int)(((byte)(74)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(188, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Panel de Control";
            // 
            // panelWorkspace
            // 
            this.panelWorkspace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panelWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorkspace.Location = new System.Drawing.Point(250, 65);
            this.panelWorkspace.Name = "panelWorkspace";
            this.panelWorkspace.Size = new System.Drawing.Size(1000, 715);
            this.panelWorkspace.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1250, 780);
            this.Controls.Add(this.panelWorkspace);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DMI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Label lblDMI;
        private System.Windows.Forms.Button btnVisitas;
        private System.Windows.Forms.Button btnConsultaVisitas;
        private System.Windows.Forms.Button btnTiposFarmacos;
        private System.Windows.Forms.Button btnMarcas;
        private System.Windows.Forms.Button btnUbicaciones;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Button btnMedicos;
        private System.Windows.Forms.Button btnMedicamentos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelWorkspace;
    }
}
