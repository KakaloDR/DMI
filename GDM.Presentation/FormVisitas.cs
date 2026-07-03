using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GDM.Business;
using GDM.Data.Modelos;

namespace GDM.Presentation
{
    public partial class FormVisitas : Form
    {
        private readonly VisitaBLL _bll = new VisitaBLL();
        private readonly MedicoBLL _medicoBll = new MedicoBLL();
        private readonly PacienteBLL _pacienteBll = new PacienteBLL();
        private readonly MedicamentoBLL _medBll = new MedicamentoBLL();
        private List<Visita> _listaOriginal = new List<Visita>();

        public FormVisitas()
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
            dgvDatos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvDatos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
        }

        private void FormVisitas_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarDatos();
            LimpiarFormulario();
        }

        private void CargarCombos()
        {
            try
            {
                // Cargar Médicos
                cmbMedico.DataSource = _medicoBll.ObtenerTodos();
                cmbMedico.DisplayMember = "Nombre";
                cmbMedico.ValueMember = "ID_Medico";

                // Cargar Pacientes
                cmbPaciente.DataSource = _pacienteBll.ObtenerTodos();
                cmbPaciente.DisplayMember = "Nombre";
                cmbPaciente.ValueMember = "ID_Paciente";

                // Cargar Medicamentos
                cmbMedicamento.DataSource = _medBll.ObtenerTodos();
                cmbMedicamento.DisplayMember = "Descripcion";
                cmbMedicamento.ValueMember = "ID_Medicamento";

                cmbEstado.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos maestros en combos: " + ex.Message, "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Error al cargar las visitas médicas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrarYMostrar()
        {
            string filtro = txtBuscar.Text.Trim();
            var listaFiltrada = _listaOriginal;

            if (!string.IsNullOrEmpty(filtro))
            {
                listaFiltrada = _listaOriginal.Where(x =>
                    x.MedicoNombre.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    x.PacienteNombre.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    x.MedicamentoDescripcion.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    x.Sintomas.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    x.Recomendaciones.Contains(filtro, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            dgvDatos.DataSource = null;
            dgvDatos.DataSource = listaFiltrada;

            // Ocultar llaves foráneas
            if (dgvDatos.Columns["FK_Medico"] != null) dgvDatos.Columns["FK_Medico"].Visible = false;
            if (dgvDatos.Columns["FK_Paciente"] != null) dgvDatos.Columns["FK_Paciente"].Visible = false;
            if (dgvDatos.Columns["FK_Medicamento"] != null) dgvDatos.Columns["FK_Medicamento"].Visible = false;

            // Formatear columnas
            if (dgvDatos.Columns["ID_Visita"] != null)
            {
                dgvDatos.Columns["ID_Visita"].HeaderText = "ID";
                dgvDatos.Columns["ID_Visita"].Width = 40;
            }
            if (dgvDatos.Columns["PacienteNombre"] != null)
            {
                dgvDatos.Columns["PacienteNombre"].HeaderText = "Paciente";
                dgvDatos.Columns["PacienteNombre"].Width = 140;
            }
            if (dgvDatos.Columns["MedicoNombre"] != null)
            {
                dgvDatos.Columns["MedicoNombre"].HeaderText = "Médico";
                dgvDatos.Columns["MedicoNombre"].Width = 140;
            }
            if (dgvDatos.Columns["Fecha_Visita"] != null)
            {
                dgvDatos.Columns["Fecha_Visita"].HeaderText = "Fecha";
                dgvDatos.Columns["Fecha_Visita"].Width = 80;
                dgvDatos.Columns["Fecha_Visita"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvDatos.Columns["Hora_Visita"] != null)
            {
                dgvDatos.Columns["Hora_Visita"].HeaderText = "Hora";
                dgvDatos.Columns["Hora_Visita"].Width = 60;
            }
            if (dgvDatos.Columns["MedicamentoDescripcion"] != null)
            {
                dgvDatos.Columns["MedicamentoDescripcion"].HeaderText = "Medicamento";
                dgvDatos.Columns["MedicamentoDescripcion"].Width = 140;
            }
            if (dgvDatos.Columns["Sintomas"] != null)
            {
                dgvDatos.Columns["Sintomas"].HeaderText = "Síntomas";
                dgvDatos.Columns["Sintomas"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (dgvDatos.Columns["Recomendaciones"] != null)
            {
                dgvDatos.Columns["Recomendaciones"].Visible = false; // Se ve al dar click
            }
            if (dgvDatos.Columns["Estado"] != null)
            {
                dgvDatos.Columns["Estado"].HeaderText = "Estado";
                dgvDatos.Columns["Estado"].Width = 60;
            }
        }

        private void LimpiarFormulario()
        {
            txtID.Text = string.Empty;
            txtSintomas.Text = string.Empty;
            txtRecomendaciones.Text = string.Empty;
            dtpFecha.Value = DateTime.Today;
            dtpHora.Value = DateTime.Now;
            cmbEstado.SelectedIndex = 0;

            if (cmbMedico.Items.Count > 0) cmbMedico.SelectedIndex = 0;
            if (cmbPaciente.Items.Count > 0) cmbPaciente.SelectedIndex = 0;
            if (cmbMedicamento.Items.Count > 0) cmbMedicamento.SelectedIndex = 0;

            if (dgvDatos.SelectedRows.Count > 0)
            {
                dgvDatos.ClearSelection();
            }
            cmbMedico.Focus();
        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                var v = (Visita)dgvDatos.SelectedRows[0].DataBoundItem;
                txtID.Text = v.ID_Visita.ToString();
                cmbMedico.SelectedValue = v.FK_Medico;
                cmbPaciente.SelectedValue = v.FK_Paciente;
                dtpFecha.Value = v.Fecha_Visita;
                dtpHora.Value = DateTime.Today.Add(v.Hora_Visita);
                txtSintomas.Text = v.Sintomas;
                cmbMedicamento.SelectedValue = v.FK_Medicamento;
                txtRecomendaciones.Text = v.Recomendaciones;
                cmbEstado.SelectedItem = v.Estado;
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
                if (cmbMedico.SelectedValue == null)
                    throw new Exception("Debe seleccionar un Médico.");
                if (cmbPaciente.SelectedValue == null)
                    throw new Exception("Debe seleccionar un Paciente.");
                if (cmbMedicamento.SelectedValue == null)
                    throw new Exception("Debe seleccionar un Medicamento.");

                var v = new Visita
                {
                    FK_Medico = (int)cmbMedico.SelectedValue,
                    FK_Paciente = (int)cmbPaciente.SelectedValue,
                    Fecha_Visita = dtpFecha.Value,
                    Hora_Visita = dtpHora.Value.TimeOfDay,
                    Sintomas = txtSintomas.Text,
                    FK_Medicamento = (int)cmbMedicamento.SelectedValue,
                    Recomendaciones = txtRecomendaciones.Text,
                    Estado = cmbEstado.SelectedItem?.ToString() ?? "Activo"
                };

                if (!string.IsNullOrEmpty(txtID.Text))
                {
                    v.ID_Visita = int.Parse(txtID.Text);
                }

                _bll.Guardar(v);
                MessageBox.Show("Registro de visita guardado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación o Error de Transacción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Seleccione un registro de visita para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtID.Text);

            var confirm = MessageBox.Show(
                "¿Está seguro de que desea eliminar este registro de visita?",
                "Confirmación de Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _bll.Eliminar(id);
                    MessageBox.Show("Visita eliminada exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar el registro de visita.\nDetalle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
