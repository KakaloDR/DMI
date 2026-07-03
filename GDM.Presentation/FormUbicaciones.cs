using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GDM.Business;
using GDM.Data.Modelos;

namespace GDM.Presentation
{
    public partial class FormUbicaciones : Form
    {
        private readonly UbicacionBLL _bll = new UbicacionBLL();
        private List<Ubicacion> _listaOriginal = new List<Ubicacion>();

        public FormUbicaciones()
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

            dgvDatos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 30, 54); // Primary
            dgvDatos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDatos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvDatos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249); // Zebra striping
        }

        private void FormUbicaciones_Load(object sender, EventArgs e)
        {
            cmbEstado.SelectedIndex = 0; // Por defecto 'Activo'
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
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    x.Estante.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    x.Tramo.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    x.Celda.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    x.ID_Ubicacion.ToString().Contains(filtro)
                ).ToList();
            }

            dgvDatos.DataSource = null;
            dgvDatos.DataSource = listaFiltrada;

            // Formatear columnas
            if (dgvDatos.Columns["ID_Ubicacion"] != null)
            {
                dgvDatos.Columns["ID_Ubicacion"].HeaderText = "Identificador";
                dgvDatos.Columns["ID_Ubicacion"].Width = 90;
            }
            if (dgvDatos.Columns["Descripcion"] != null)
            {
                dgvDatos.Columns["Descripcion"].HeaderText = "Descripción";
                dgvDatos.Columns["Descripcion"].Width = 180;
            }
            if (dgvDatos.Columns["Estante"] != null)
            {
                dgvDatos.Columns["Estante"].HeaderText = "Estante";
                dgvDatos.Columns["Estante"].Width = 90;
            }
            if (dgvDatos.Columns["Tramo"] != null)
            {
                dgvDatos.Columns["Tramo"].HeaderText = "Tramo";
                dgvDatos.Columns["Tramo"].Width = 90;
            }
            if (dgvDatos.Columns["Celda"] != null)
            {
                dgvDatos.Columns["Celda"].HeaderText = "Celda";
                dgvDatos.Columns["Celda"].Width = 90;
            }
            if (dgvDatos.Columns["Estado"] != null)
            {
                dgvDatos.Columns["Estado"].HeaderText = "Estado";
                dgvDatos.Columns["Estado"].Width = 80;
            }
        }

        private void LimpiarFormulario()
        {
            txtID.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtEstante.Text = string.Empty;
            txtTramo.Text = string.Empty;
            txtCelda.Text = string.Empty;
            cmbEstado.SelectedIndex = 0;
            if (dgvDatos.SelectedRows.Count > 0)
            {
                dgvDatos.ClearSelection();
            }
        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                var ubi = (Ubicacion)dgvDatos.SelectedRows[0].DataBoundItem;
                txtID.Text = ubi.ID_Ubicacion.ToString();
                txtDescripcion.Text = ubi.Descripcion;
                txtEstante.Text = ubi.Estante;
                txtTramo.Text = ubi.Tramo;
                txtCelda.Text = ubi.Celda;
                cmbEstado.SelectedItem = ubi.Estado;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var ubi = new Ubicacion
                {
                    Descripcion = txtDescripcion.Text,
                    Estante = txtEstante.Text,
                    Tramo = txtTramo.Text,
                    Celda = txtCelda.Text,
                    Estado = cmbEstado.SelectedItem?.ToString() ?? "Activo"
                };

                if (!string.IsNullOrEmpty(txtID.Text))
                {
                    ubi.ID_Ubicacion = int.Parse(txtID.Text);
                }

                _bll.Guardar(ubi);
                MessageBox.Show("Ubicación guardada exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Seleccione una ubicación para eliminar de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtID.Text);

            var confirm = MessageBox.Show(
                "¿Está seguro de que desea eliminar esta ubicación?",
                "Confirmación de Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _bll.Eliminar(id);
                    MessageBox.Show("Ubicación eliminada exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No se pudo eliminar el registro. Esto ocurre si la ubicación ya está asignada a uno o más medicamentos registrados.\nDetalle: " + ex.Message, 
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
