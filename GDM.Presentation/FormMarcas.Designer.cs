namespace GDM.Presentation
{
    partial class FormMarcas
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
            this.lblEstudiante = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.panelBusqueda = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnRetroceder = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.grpDatos.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.panelBusqueda.SuspendLayout();
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
            this.panelTop.Size = new System.Drawing.Size(884, 50);
            this.panelTop.TabIndex = 0;
            // 
            // lblEstudiante
            // 
            this.lblEstudiante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEstudiante.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular);
            this.lblEstudiante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblEstudiante.Location = new System.Drawing.Point(440, 15);
            this.lblEstudiante.Name = "lblEstudiante";
            this.lblEstudiante.Size = new System.Drawing.Size(432, 23);
            this.lblEstudiante.TabIndex = 1;
            this.lblEstudiante.Text = "G. Martínez (A00106912) | G. Durant (A00110065) | E. Villanueva (A00116168)";
            this.lblEstudiante.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(309, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "DMI - Marcas (Laboratorios)";
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.grpDatos);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 50);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(15);
            this.panelLeft.Size = new System.Drawing.Size(320, 451);
            this.panelLeft.TabIndex = 1;
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.cmbEstado);
            this.grpDatos.Controls.Add(this.lblEstado);
            this.grpDatos.Controls.Add(this.txtDescripcion);
            this.grpDatos.Controls.Add(this.lblDescripcion);
            this.grpDatos.Controls.Add(this.txtID);
            this.grpDatos.Controls.Add(this.lblID);
            this.grpDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDatos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.grpDatos.Location = new System.Drawing.Point(15, 15);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(290, 421);
            this.grpDatos.TabIndex = 0;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Datos de la Marca";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbEstado.Location = new System.Drawing.Point(20, 195);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(250, 25);
            this.cmbEstado.TabIndex = 5;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblEstado.Location = new System.Drawing.Point(16, 172);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(53, 19);
            this.lblEstado.TabIndex = 4;
            this.lblEstado.Text = "Estado:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtDescripcion.Location = new System.Drawing.Point(20, 125);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(250, 25);
            this.txtDescripcion.TabIndex = 3;
            this.txtDescripcion.Enter += new System.EventHandler(this.txtInput_Enter);
            this.txtDescripcion.Leave += new System.EventHandler(this.txtInput_Leave);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblDescripcion.Location = new System.Drawing.Point(16, 102);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(82, 19);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtID.Location = new System.Drawing.Point(20, 60);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(250, 25);
            this.txtID.TabIndex = 1;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblID.Location = new System.Drawing.Point(16, 38);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(95, 19);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "Identificador:";
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.dgvDatos);
            this.panelRight.Controls.Add(this.panelBusqueda);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(320, 50);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(0, 15, 15, 15);
            this.panelRight.Size = new System.Drawing.Size(564, 451);
            this.panelRight.TabIndex = 2;
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
            this.dgvDatos.Location = new System.Drawing.Point(0, 60);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(549, 376);
            this.dgvDatos.TabIndex = 1;
            this.dgvDatos.SelectionChanged += new System.EventHandler(this.dgvDatos_SelectionChanged);
            // 
            // panelBusqueda
            // 
            this.panelBusqueda.Controls.Add(this.txtBuscar);
            this.panelBusqueda.Controls.Add(this.lblBuscar);
            this.panelBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBusqueda.Location = new System.Drawing.Point(0, 15);
            this.panelBusqueda.Name = "panelBusqueda";
            this.panelBusqueda.Size = new System.Drawing.Size(549, 45);
            this.panelBusqueda.TabIndex = 0;
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtBuscar.Location = new System.Drawing.Point(62, 10);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(487, 25);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.Enter += new System.EventHandler(this.txtInput_Enter);
            this.txtBuscar.Leave += new System.EventHandler(this.txtInput_Leave);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblBuscar.Location = new System.Drawing.Point(6, 12);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(50, 19);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar:";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelBottom.Controls.Add(this.btnRetroceder);
            this.panelBottom.Controls.Add(this.btnEliminar);
            this.panelBottom.Controls.Add(this.btnNuevo);
            this.panelBottom.Controls.Add(this.btnCancelar);
            this.panelBottom.Controls.Add(this.btnGuardar);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 501);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(0, 10, 15, 10);
            this.panelBottom.Size = new System.Drawing.Size(884, 60);
            this.panelBottom.TabIndex = 3;
            // 
            // btnRetroceder
            // 
            this.btnRetroceder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetroceder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetroceder.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRetroceder.Location = new System.Drawing.Point(15, 10);
            this.btnRetroceder.Name = "btnRetroceder";
            this.btnRetroceder.Size = new System.Drawing.Size(130, 40);
            this.btnRetroceder.TabIndex = 4;
            this.btnRetroceder.Text = "Retroceder";
            this.btnRetroceder.UseVisualStyleBackColor = true;
            this.btnRetroceder.Click += new System.EventHandler(this.btnRetroceder_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.Location = new System.Drawing.Point(301, 10);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(130, 40);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.Location = new System.Drawing.Point(447, 10);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(130, 40);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancelar.Location = new System.Drawing.Point(593, 10);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(130, 40);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Location = new System.Drawing.Point(739, 10);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 40);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FormMarcas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormMarcas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DMI";
            this.Load += new System.EventHandler(this.FormMarcas_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.panelBusqueda.ResumeLayout(false);
            this.panelBusqueda.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblEstudiante;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelBusqueda;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnRetroceder;
    }
}
