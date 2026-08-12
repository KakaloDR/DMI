namespace GDM.Presentation
{
    partial class FormConsultaVisitas
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
        /// Required method for Designer modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.chkFiltrarFechas = new System.Windows.Forms.CheckBox();
            this.cmbPaciente = new System.Windows.Forms.ComboBox();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.cmbMedico = new System.Windows.Forms.ComboBox();
            this.lblMedico = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnRetroceder = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1010, 50);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(262, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "DMI - Consulta por Criterios";
            // 
            // panelFiltros
            // 
            this.panelFiltros.Controls.Add(this.grpFiltros);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 50);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelFiltros.Size = new System.Drawing.Size(1010, 110);
            this.panelFiltros.TabIndex = 1;
            // 
            // grpFiltros
            // 
            this.grpFiltros.BackColor = System.Drawing.Color.White;
            this.grpFiltros.Controls.Add(this.btnLimpiar);
            this.grpFiltros.Controls.Add(this.btnFiltrar);
            this.grpFiltros.Controls.Add(this.dtpHasta);
            this.grpFiltros.Controls.Add(this.dtpDesde);
            this.grpFiltros.Controls.Add(this.chkFiltrarFechas);
            this.grpFiltros.Controls.Add(this.cmbPaciente);
            this.grpFiltros.Controls.Add(this.lblPaciente);
            this.grpFiltros.Controls.Add(this.cmbMedico);
            this.grpFiltros.Controls.Add(this.lblMedico);
            this.grpFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFiltros.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpFiltros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.grpFiltros.Location = new System.Drawing.Point(15, 10);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(980, 90);
            this.grpFiltros.TabIndex = 0;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros de Búsqueda";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLimpiar.Location = new System.Drawing.Point(860, 42);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(105, 32);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.Location = new System.Drawing.Point(745, 42);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(105, 32);
            this.btnFiltrar.TabIndex = 7;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Enabled = false;
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(600, 48);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(125, 24);
            this.dtpHasta.TabIndex = 6;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Enabled = false;
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(460, 48);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(125, 24);
            this.dtpDesde.TabIndex = 5;
            // 
            // chkFiltrarFechas
            // 
            this.chkFiltrarFechas.AutoSize = true;
            this.chkFiltrarFechas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkFiltrarFechas.Location = new System.Drawing.Point(460, 23);
            this.chkFiltrarFechas.Name = "chkFiltrarFechas";
            this.chkFiltrarFechas.Size = new System.Drawing.Size(183, 21);
            this.chkFiltrarFechas.TabIndex = 4;
            this.chkFiltrarFechas.Text = "Filtrar por Rango de Fechas";
            this.chkFiltrarFechas.UseVisualStyleBackColor = true;
            this.chkFiltrarFechas.CheckedChanged += new System.EventHandler(this.chkFiltrarFechas_CheckedChanged);
            // 
            // cmbPaciente
            // 
            this.cmbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaciente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbPaciente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.cmbPaciente.FormattingEnabled = true;
            this.cmbPaciente.Location = new System.Drawing.Point(240, 48);
            this.cmbPaciente.Name = "cmbPaciente";
            this.cmbPaciente.Size = new System.Drawing.Size(200, 25);
            this.cmbPaciente.TabIndex = 3;
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPaciente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblPaciente.Location = new System.Drawing.Point(236, 26);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(59, 17);
            this.lblPaciente.TabIndex = 2;
            this.lblPaciente.Text = "Paciente:";
            // 
            // cmbMedico
            // 
            this.cmbMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedico.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbMedico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.cmbMedico.FormattingEnabled = true;
            this.cmbMedico.Location = new System.Drawing.Point(20, 48);
            this.cmbMedico.Name = "cmbMedico";
            this.cmbMedico.Size = new System.Drawing.Size(200, 25);
            this.cmbMedico.TabIndex = 1;
            // 
            // lblMedico
            // 
            this.lblMedico.AutoSize = true;
            this.lblMedico.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMedico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblMedico.Location = new System.Drawing.Point(16, 26);
            this.lblMedico.Name = "lblMedico";
            this.lblMedico.Size = new System.Drawing.Size(54, 17);
            this.lblMedico.TabIndex = 0;
            this.lblMedico.Text = "Médico:";
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDatos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.Location = new System.Drawing.Point(0, 160);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(1010, 460);
            this.dgvDatos.TabIndex = 2;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lblTotal);
            this.panelBottom.Controls.Add(this.btnExportar);
            this.panelBottom.Controls.Add(this.btnRetroceder);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 620);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(0, 10, 15, 10);
            this.panelBottom.Size = new System.Drawing.Size(1010, 60);
            this.panelBottom.TabIndex = 3;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.lblTotal.Location = new System.Drawing.Point(15, 10);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(500, 40);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Total de registros encontrados: 0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExportar.Location = new System.Drawing.Point(690, 10);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(160, 40);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "Exportar a CSV";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnRetroceder
            // 
            this.btnRetroceder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetroceder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetroceder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetroceder.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRetroceder.Location = new System.Drawing.Point(860, 10);
            this.btnRetroceder.Name = "btnRetroceder";
            this.btnRetroceder.Size = new System.Drawing.Size(130, 40);
            this.btnRetroceder.TabIndex = 0;
            this.btnRetroceder.Text = "Retroceder";
            this.btnRetroceder.UseVisualStyleBackColor = true;
            this.btnRetroceder.Click += new System.EventHandler(this.btnRetroceder_Click);
            // 
            // FormConsultaVisitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1010, 680);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormConsultaVisitas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DMI";
            this.Load += new System.EventHandler(this.FormConsultaVisitas_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelFiltros.ResumeLayout(false);
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.ComboBox cmbMedico;
        private System.Windows.Forms.Label lblMedico;
        private System.Windows.Forms.ComboBox cmbPaciente;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.CheckBox chkFiltrarFechas;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnRetroceder;
    }
}
