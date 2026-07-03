using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GDM.Business;
using GDM.Data.Modelos;

namespace GDM.Presentation
{
    public partial class FormMedicamentos : Form
    {
        private readonly MedicamentoBLL _bll = new MedicamentoBLL();
        private readonly TipoFarmacoBLL _tipoBll = new TipoFarmacoBLL();
        private readonly MarcaBLL _marcaBll = new MarcaBLL();
        private readonly UbicacionBLL _ubiBll = new UbicacionBLL();
        private List<Medicamento> _listaOriginal = new List<Medicamento>();

        public FormMedicamentos()
        {
            InitializeComponent();
            AplicarEstilos();
        }

        private void AplicarEstilos()
        {
            // Botón Guardar (Ice Blue / Clínico)
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 1;
            btnGuardar.BackColor = Color.FromArgb(2, 132, 199);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.FlatAppearance.BorderColor = Color.FromArgb(2, 132, 199);
            btnGuardar.Cursor = Cursors.Hand;

            // Botón Cancelar (Slate)
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderSize = 1;
            btnCancelar.BackColor = Color.Transparent;
            btnCancelar.ForeColor = Color.FromArgb(100, 116, 139);
            btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(100, 116, 139);
            btnCancelar.Cursor = Cursors.Hand;

            // Botón Nuevo (Primary Corporativo Frío)
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.FlatAppearance.BorderSize = 1;
            btnNuevo.BackColor = Color.FromArgb(15, 30, 54);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.FlatAppearance.BorderColor = Color.FromArgb(15, 30, 54);
            btnNuevo.Cursor = Cursors.Hand;

            // Botón Eliminar (Crimson / Danger)
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.FlatAppearance.BorderSize = 1;
            btnEliminar.BackColor = Color.FromArgb(190, 18, 60);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.FlatAppearance.BorderColor = Color.FromArgb(190, 18, 60);
            btnEliminar.Cursor = Cursors.Hand;

            // Botón Retroceder (Slate)
            btnRetroceder.FlatStyle = FlatStyle.Flat;
            btnRetroceder.FlatAppearance.BorderSize = 1;
            btnRetroceder.BackColor = Color.FromArgb(100, 116, 139);
            btnRetroceder.ForeColor = Color.White;
            btnRetroceder.FlatAppearance.BorderColor = Color.FromArgb(100, 116, 139);
            btnRetroceder.Cursor = Cursors.Hand;

            // Grilla
            dgvDatos.BackgroundColor = Color.White;
            dgvDatos.BorderStyle = BorderStyle.None;
            dgvDatos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.MultiSelect = false;
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersVisible = false;
            dgvDatos.EnableHeadersVisualStyles = false;

            dgvDatos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 30, 54);
            dgvDatos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDatos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvDatos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
        }

        private void FormMedicamentos_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarDatos();
            LimpiarFormulario();
        }

        private void CargarCombos()
        {
            try
            {
                // Cargar tipos de fármacos activos
                var tipos = _tipoBll.ObtenerTodos().Where(x => x.Estado == "Activo").ToList();
                cmbTipoFarmaco.DataSource = tipos;
                cmbTipoFarmaco.DisplayMember = "Descripcion";
                cmbTipoFarmaco.ValueMember = "ID_Tipo_Farmaco";

                // Cargar marcas activas
                var marcas = _marcaBll.ObtenerTodos().Where(x => x.Estado == "Activo").ToList();
                cmbMarca.DataSource = marcas;
                cmbMarca.DisplayMember = "Descripcion";
                cmbMarca.ValueMember = "ID_Marca";

                // Cargar ubicaciones activas
                var ubis = _ubiBll.ObtenerTodos().Where(x => x.Estado == "Activo").ToList();
                cmbUbicacion.DataSource = ubis;
                cmbUbicacion.DisplayMember = "Descripcion";
                cmbUbicacion.ValueMember = "ID_Ubicacion";

                cmbEstado.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar listados maestros: " + ex.Message, "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatos()
        {
            try
            {
                _listaOriginal = _bll.ObtenerTodos();
                FiltrarYMostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar medicamentos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrarYMostrar()
        {
            string filtro = txtBuscar.Text.Trim();
            var listaFiltrada = _listaOriginal;

            if (!string.IsNullOrEmpty(filtro))
            {
                listaFiltrada = _listaOriginal.Where(x => 
                    x.Descripcion.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    x.TipoFarmacoDescripcion.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    x.MarcaDescripcion.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    x.Dosis.Contains(filtro, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            dgvDatos.DataSource = null;
            dgvDatos.DataSource = listaFiltrada;

            // Ocultar IDs foráneos en la grilla para que se vea limpio
            if (dgvDatos.Columns["FK_Tipo_Farmaco"] != null) dgvDatos.Columns["FK_Tipo_Farmaco"].Visible = false;
            if (dgvDatos.Columns["FK_Marca"] != null) dgvDatos.Columns["FK_Marca"].Visible = false;
            if (dgvDatos.Columns["FK_Ubicacion"] != null) dgvDatos.Columns["FK_Ubicacion"].Visible = false;

            // Formatear columnas
            if (dgvDatos.Columns["ID_Medicamento"] != null)
            {
                dgvDatos.Columns["ID_Medicamento"].HeaderText = "ID";
                dgvDatos.Columns["ID_Medicamento"].Width = 50;
            }
            if (dgvDatos.Columns["Descripcion"] != null)
            {
                dgvDatos.Columns["Descripcion"].HeaderText = "Nombre Comercial";
                dgvDatos.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (dgvDatos.Columns["TipoFarmacoDescripcion"] != null)
            {
                dgvDatos.Columns["TipoFarmacoDescripcion"].HeaderText = "Tipo Fármaco";
                dgvDatos.Columns["TipoFarmacoDescripcion"].Width = 110;
            }
            if (dgvDatos.Columns["MarcaDescripcion"] != null)
            {
                dgvDatos.Columns["MarcaDescripcion"].HeaderText = "Marca";
                dgvDatos.Columns["MarcaDescripcion"].Width = 110;
            }
            if (dgvDatos.Columns["Dosis"] != null)
            {
                dgvDatos.Columns["Dosis"].HeaderText = "Dosis";
                dgvDatos.Columns["Dosis"].Width = 120;
            }
            if (dgvDatos.Columns["Estado"] != null)
            {
                dgvDatos.Columns["Estado"].HeaderText = "Estado";
                dgvDatos.Columns["Estado"].Width = 70;
            }
            if (dgvDatos.Columns["UbicacionDescripcion"] != null)
            {
                dgvDatos.Columns["UbicacionDescripcion"].HeaderText = "Ubicación";
                dgvDatos.Columns["UbicacionDescripcion"].Width = 120;
            }
        }

        private void LimpiarFormulario()
        {
            txtID.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtDosis.Text = string.Empty;
            cmbEstado.SelectedIndex = 0;

            if (cmbTipoFarmaco.Items.Count > 0) cmbTipoFarmaco.SelectedIndex = 0;
            if (cmbMarca.Items.Count > 0) cmbMarca.SelectedIndex = 0;
            if (cmbUbicacion.Items.Count > 0) cmbUbicacion.SelectedIndex = 0;

            if (dgvDatos.SelectedRows.Count > 0)
            {
                dgvDatos.ClearSelection();
            }
            txtDescripcion.Focus();
        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                var m = (Medicamento)dgvDatos.SelectedRows[0].DataBoundItem;
                txtID.Text = m.ID_Medicamento.ToString();
                txtDescripcion.Text = m.Descripcion;
                txtDosis.Text = m.Dosis;
                cmbEstado.SelectedItem = m.Estado;

                // Seleccionar los elementos del combo correspondientes a los IDs guardados
                cmbTipoFarmaco.SelectedValue = m.FK_Tipo_Farmaco;
                cmbMarca.SelectedValue = m.FK_Marca;
                cmbUbicacion.SelectedValue = m.FK_Ubicacion;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipoFarmaco.SelectedValue == null)
                    throw new Exception("Debe registrar y seleccionar un Tipo de Fármaco activo.");

                if (cmbMarca.SelectedValue == null)
                    throw new Exception("Debe registrar y seleccionar una Marca activa.");

                if (cmbUbicacion.SelectedValue == null)
                    throw new Exception("Debe registrar y seleccionar una Ubicación activa.");

                var m = new Medicamento
                {
                    Descripcion = txtDescripcion.Text,
                    FK_Tipo_Farmaco = (int)cmbTipoFarmaco.SelectedValue,
                    FK_Marca = (int)cmbMarca.SelectedValue,
                    FK_Ubicacion = (int)cmbUbicacion.SelectedValue,
                    Dosis = txtDosis.Text,
                    Estado = cmbEstado.SelectedItem?.ToString() ?? "Activo"
                };

                if (!string.IsNullOrEmpty(txtID.Text))
                {
                    m.ID_Medicamento = int.Parse(txtID.Text);
                }

                _bll.Guardar(m);
                MessageBox.Show("Medicamento guardado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación o Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Seleccione un medicamento para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtID.Text);

            var confirm = MessageBox.Show(
                "¿Está seguro de que desea eliminar este medicamento?",
                "Confirmación de Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _bll.Eliminar(id);
                    MessageBox.Show("Medicamento eliminado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No se pudo eliminar el medicamento. Esto ocurre si ya ha sido recetado en alguna visita médica registrada.\nDetalle: " + ex.Message, 
                        "Error de Integridad", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarYMostrar();
        }

        private void txtInput_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox txt)
            {
                txt.BackColor = Color.FromArgb(241, 245, 249);
            }
        }

        private void txtInput_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox txt)
            {
                txt.BackColor = Color.White;
            }
        }
    }
}
