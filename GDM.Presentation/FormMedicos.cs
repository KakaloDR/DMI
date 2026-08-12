using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GDM.Business;
using GDM.Data.Modelos;

namespace GDM.Presentation
{
    public partial class FormMedicos : Form
    {
        private readonly MedicoBLL _bll = new MedicoBLL();
        private List<Medico> _listaOriginal = new List<Medico>();
        private bool _limpiandoFormulario = false;

        public FormMedicos()
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

            // Botón Eliminar (Crimson / Danger)
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.FlatAppearance.BorderSize = 1;
            btnEliminar.BackColor = Color.FromArgb(190, 18, 60);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.FlatAppearance.BorderColor = Color.FromArgb(190, 18, 60);
            btnEliminar.Cursor = Cursors.Hand;

            // Botón Nuevo (Primary Corporativo Frío)
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.FlatAppearance.BorderSize = 1;
            btnNuevo.BackColor = Color.FromArgb(15, 30, 54);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.FlatAppearance.BorderColor = Color.FromArgb(15, 30, 54);
            btnNuevo.Cursor = Cursors.Hand;

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

        private void FormMedicos_Load(object sender, EventArgs e)
        {
            cmbTanda.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
            CargarDatos();
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
                MessageBox.Show("Error al cargar médicos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrarYMostrar()
        {
            string filtro = txtBuscar.Text.Trim();
            var listaFiltrada = _listaOriginal;

            if (!string.IsNullOrEmpty(filtro))
            {
                listaFiltrada = _listaOriginal.Where(x => 
                    x.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    x.Cedula.Contains(filtro) ||
                    x.Especialidad.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    x.Tanda_Labor.Contains(filtro, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            dgvDatos.DataSource = null;
            dgvDatos.DataSource = listaFiltrada;

            // Formatear columnas
            if (dgvDatos.Columns["ID_Medico"] != null)
            {
                dgvDatos.Columns["ID_Medico"].HeaderText = "ID";
                dgvDatos.Columns["ID_Medico"].Width = 60;
            }
            if (dgvDatos.Columns["Nombre"] != null)
            {
                dgvDatos.Columns["Nombre"].HeaderText = "Nombre del Médico";
                dgvDatos.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (dgvDatos.Columns["Cedula"] != null)
            {
                dgvDatos.Columns["Cedula"].HeaderText = "Cédula";
                dgvDatos.Columns["Cedula"].Width = 110;
            }
            if (dgvDatos.Columns["Tanda_Labor"] != null)
            {
                dgvDatos.Columns["Tanda_Labor"].HeaderText = "Tanda";
                dgvDatos.Columns["Tanda_Labor"].Width = 100;
            }
            if (dgvDatos.Columns["Especialidad"] != null)
            {
                dgvDatos.Columns["Especialidad"].HeaderText = "Especialidad";
                dgvDatos.Columns["Especialidad"].Width = 120;
            }
            if (dgvDatos.Columns["Estado"] != null)
            {
                dgvDatos.Columns["Estado"].HeaderText = "Estado";
                dgvDatos.Columns["Estado"].Width = 80;
            }
        }

        private void LimpiarFormulario()
        {
            _limpiandoFormulario = true;
            txtID.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtCedula.Text = string.Empty;
            txtEspecialidad.Text = string.Empty;
            cmbTanda.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
            dgvDatos.ClearSelection();
            if (dgvDatos.CurrentCell != null)
            {
                dgvDatos.CurrentCell = null;
            }
            _limpiandoFormulario = false;
        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (_limpiandoFormulario) return;

            if (dgvDatos.SelectedRows.Count > 0)
            {
                var m = (Medico)dgvDatos.SelectedRows[0].DataBoundItem;
                txtID.Text = m.ID_Medico.ToString();
                txtNombre.Text = m.Nombre;
                txtCedula.Text = m.Cedula;
                txtEspecialidad.Text = m.Especialidad;
                cmbTanda.SelectedItem = m.Tanda_Labor;
                cmbEstado.SelectedItem = m.Estado;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que la máscara de cédula esté completa
            if (!txtCedula.MaskCompleted)
            {
                MessageBox.Show("Debe ingresar los 11 dígitos de la cédula del médico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCedula.Focus();
                return;
            }

            try
            {
                var m = new Medico
                {
                    Nombre = txtNombre.Text,
                    Cedula = txtCedula.Text,
                    Tanda_Labor = cmbTanda.SelectedItem?.ToString() ?? "Matutina",
                    Especialidad = txtEspecialidad.Text,
                    Estado = cmbEstado.SelectedItem?.ToString() ?? "Activo"
                };

                if (!string.IsNullOrEmpty(txtID.Text))
                {
                    m.ID_Medico = int.Parse(txtID.Text);
                }

                _bll.Guardar(m);
                MessageBox.Show("Médico guardado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Seleccione un médico para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtID.Text);

            var confirm = MessageBox.Show(
                "¿Está seguro de que desea eliminar este médico del registro?",
                "Confirmación de Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _bll.Eliminar(id);
                    MessageBox.Show("Médico eliminado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No se pudo eliminar al médico. Esto ocurre si ya tiene visitas médicas registradas en el historial.\nDetalle: " + ex.Message, 
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

        private void btnNuevo_Click(object sender, EventArgs e)
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
            else if (sender is MaskedTextBox mtxt)
            {
                mtxt.BackColor = Color.FromArgb(241, 245, 249);
            }
        }

        private void txtInput_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox txt)
            {
                txt.BackColor = Color.White;
            }
            else if (sender is MaskedTextBox mtxt)
            {
                mtxt.BackColor = Color.White;
            }
        }
    }
}
