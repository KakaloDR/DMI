namespace GDM.Presentation
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.grpProcesos = new System.Windows.Forms.GroupBox();
            this.btnVisitas = new System.Windows.Forms.Button();
            this.btnConsultaVisitas = new System.Windows.Forms.Button();
            this.grpCatalogos = new System.Windows.Forms.GroupBox();
            this.btnMedicamentos = new System.Windows.Forms.Button();
            this.btnMedicos = new System.Windows.Forms.Button();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.btnUbicaciones = new System.Windows.Forms.Button();
            this.btnMarcas = new System.Windows.Forms.Button();
            this.btnTiposFarmacos = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelContenedor.SuspendLayout();
            this.grpProcesos.SuspendLayout();
            this.grpCatalogos.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(784, 50);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(51, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "DMI";
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.White;
            this.panelContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContenedor.Controls.Add(this.grpProcesos);
            this.panelContenedor.Controls.Add(this.lblGrupo);
            this.panelContenedor.Controls.Add(this.grpCatalogos);
            this.panelContenedor.Controls.Add(this.btnSalir);
            this.panelContenedor.Location = new System.Drawing.Point(15, 65);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(754, 340);
            this.panelContenedor.TabIndex = 1;
            // 
            // grpProcesos
            // 
            this.grpProcesos.Controls.Add(this.btnConsultaVisitas);
            this.grpProcesos.Controls.Add(this.btnVisitas);
            this.grpProcesos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpProcesos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.grpProcesos.Location = new System.Drawing.Point(25, 20);
            this.grpProcesos.Name = "grpProcesos";
            this.grpProcesos.Size = new System.Drawing.Size(220, 238);
            this.grpProcesos.TabIndex = 4;
            this.grpProcesos.TabStop = false;
            this.grpProcesos.Text = "Procesos y Reportes";
            // 
            // btnVisitas
            // 
            this.btnVisitas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVisitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisitas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVisitas.Location = new System.Drawing.Point(20, 35);
            this.btnVisitas.Name = "btnVisitas";
            this.btnVisitas.Size = new System.Drawing.Size(180, 80);
            this.btnVisitas.TabIndex = 0;
            this.btnVisitas.Text = "Registro de Visitas";
            this.btnVisitas.UseVisualStyleBackColor = true;
            this.btnVisitas.Click += new System.EventHandler(this.btnVisitas_Click);
            // 
            // btnConsultaVisitas
            // 
            this.btnConsultaVisitas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultaVisitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultaVisitas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConsultaVisitas.Location = new System.Drawing.Point(20, 135);
            this.btnConsultaVisitas.Name = "btnConsultaVisitas";
            this.btnConsultaVisitas.Size = new System.Drawing.Size(180, 80);
            this.btnConsultaVisitas.TabIndex = 1;
            this.btnConsultaVisitas.Text = "Consulta de Visitas";
            this.btnConsultaVisitas.UseVisualStyleBackColor = true;
            this.btnConsultaVisitas.Click += new System.EventHandler(this.btnConsultaVisitas_Click);
            // 
            // grpCatalogos
            // 
            this.grpCatalogos.Controls.Add(this.btnMedicamentos);
            this.grpCatalogos.Controls.Add(this.btnMedicos);
            this.grpCatalogos.Controls.Add(this.btnPacientes);
            this.grpCatalogos.Controls.Add(this.btnUbicaciones);
            this.grpCatalogos.Controls.Add(this.btnMarcas);
            this.grpCatalogos.Controls.Add(this.btnTiposFarmacos);
            this.grpCatalogos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpCatalogos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.grpCatalogos.Location = new System.Drawing.Point(265, 20);
            this.grpCatalogos.Name = "grpCatalogos";
            this.grpCatalogos.Size = new System.Drawing.Size(463, 238);
            this.grpCatalogos.TabIndex = 5;
            this.grpCatalogos.TabStop = false;
            this.grpCatalogos.Text = "Catálogos Maestros";
            // 
            // btnMedicamentos
            // 
            this.btnMedicamentos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMedicamentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedicamentos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMedicamentos.Location = new System.Drawing.Point(245, 165);
            this.btnMedicamentos.Name = "btnMedicamentos";
            this.btnMedicamentos.Size = new System.Drawing.Size(195, 55);
            this.btnMedicamentos.TabIndex = 5;
            this.btnMedicamentos.Text = "Medicamentos";
            this.btnMedicamentos.UseVisualStyleBackColor = true;
            this.btnMedicamentos.Click += new System.EventHandler(this.btnMedicamentos_Click);
            // 
            // btnMedicos
            // 
            this.btnMedicos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMedicos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedicos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMedicos.Location = new System.Drawing.Point(245, 100);
            this.btnMedicos.Name = "btnMedicos";
            this.btnMedicos.Size = new System.Drawing.Size(195, 55);
            this.btnMedicos.TabIndex = 4;
            this.btnMedicos.Text = "Médicos (Personal)";
            this.btnMedicos.UseVisualStyleBackColor = true;
            this.btnMedicos.Click += new System.EventHandler(this.btnMedicos_Click);
            // 
            // btnPacientes
            // 
            this.btnPacientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacientes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPacientes.Location = new System.Drawing.Point(245, 35);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(195, 55);
            this.btnPacientes.TabIndex = 3;
            this.btnPacientes.Text = "Pacientes";
            this.btnPacientes.UseVisualStyleBackColor = true;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // btnUbicaciones
            // 
            this.btnUbicaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUbicaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUbicaciones.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUbicaciones.Location = new System.Drawing.Point(25, 165);
            this.btnUbicaciones.Name = "btnUbicaciones";
            this.btnUbicaciones.Size = new System.Drawing.Size(195, 55);
            this.btnUbicaciones.TabIndex = 2;
            this.btnUbicaciones.Text = "Ubicaciones Físicas";
            this.btnUbicaciones.UseVisualStyleBackColor = true;
            this.btnUbicaciones.Click += new System.EventHandler(this.btnUbicaciones_Click);
            // 
            // btnMarcas
            // 
            this.btnMarcas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarcas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarcas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMarcas.Location = new System.Drawing.Point(25, 100);
            this.btnMarcas.Name = "btnMarcas";
            this.btnMarcas.Size = new System.Drawing.Size(195, 55);
            this.btnMarcas.TabIndex = 1;
            this.btnMarcas.Text = "Marcas (Laboratorios)";
            this.btnMarcas.UseVisualStyleBackColor = true;
            this.btnMarcas.Click += new System.EventHandler(this.btnMarcas_Click);
            // 
            // btnTiposFarmacos
            // 
            this.btnTiposFarmacos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTiposFarmacos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTiposFarmacos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTiposFarmacos.Location = new System.Drawing.Point(25, 35);
            this.btnTiposFarmacos.Name = "btnTiposFarmacos";
            this.btnTiposFarmacos.Size = new System.Drawing.Size(195, 55);
            this.btnTiposFarmacos.TabIndex = 0;
            this.btnTiposFarmacos.Text = "Tipos de Fármacos";
            this.btnTiposFarmacos.UseVisualStyleBackColor = true;
            this.btnTiposFarmacos.Click += new System.EventHandler(this.btnTiposFarmacos_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSalir.Location = new System.Drawing.Point(588, 280);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(140, 40);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "Cerrar Sesión";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblGrupo
            // 
            this.lblGrupo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular);
            this.lblGrupo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblGrupo.Location = new System.Drawing.Point(25, 275);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(550, 50);
            this.lblGrupo.TabIndex = 6;
            this.lblGrupo.Text = "Integrantes:\r\nGiancarlo Martínez (A00106912) | Gael Durant (A00110065)\r\nEric Villanueva (A00116168) | Bienvenido Hernández (A00115456)";
            this.lblGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(784, 420);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DMI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelContenedor.ResumeLayout(false);
            this.grpProcesos.ResumeLayout(false);
            this.grpCatalogos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox grpProcesos;
        private System.Windows.Forms.Button btnVisitas;
        private System.Windows.Forms.Button btnConsultaVisitas;
        private System.Windows.Forms.GroupBox grpCatalogos;
        private System.Windows.Forms.Button btnUbicaciones;
        private System.Windows.Forms.Button btnMarcas;
        private System.Windows.Forms.Button btnTiposFarmacos;
        private System.Windows.Forms.Button btnMedicos;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Button btnMedicamentos;
        private System.Windows.Forms.Label lblGrupo;
    }
}
