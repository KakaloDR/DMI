using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using GDM.Business;
using GDM.Data.Modelos;

namespace GDM.Presentation
{
    public partial class FormConsultaVisitas : Form
    {
        private readonly VisitaBLL _visitaBll = new VisitaBLL();
        private readonly MedicoBLL _medicoBll = new MedicoBLL();
        private readonly PacienteBLL _pacienteBll = new PacienteBLL();

        public FormConsultaVisitas()
        {
            InitializeComponent();
            AplicarEstilos();
        }

        private void AplicarEstilos()
        {
            // Botón Filtrar
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.FlatAppearance.BorderSize = 1;
            btnFiltrar.BackColor = Color.FromArgb(2, 132, 199); // Ice Blue
            btnFiltrar.ForeColor = Color.White;
            btnFiltrar.FlatAppearance.BorderColor = Color.FromArgb(2, 132, 199);
            btnFiltrar.Cursor = Cursors.Hand;

            // Botón Limpiar
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.FlatAppearance.BorderSize = 1;
            btnLimpiar.BackColor = Color.Transparent;
            btnLimpiar.ForeColor = Color.FromArgb(100, 116, 139); // Slate
            btnLimpiar.FlatAppearance.BorderColor = Color.FromArgb(100, 116, 139);
            btnLimpiar.Cursor = Cursors.Hand;

            // Botón Exportar
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.FlatAppearance.BorderSize = 1;
            btnExportar.BackColor = Color.FromArgb(2, 132, 199); // Ice Blue
            btnExportar.ForeColor = Color.White;
            btnExportar.FlatAppearance.BorderColor = Color.FromArgb(2, 132, 199);
            btnExportar.Cursor = Cursors.Hand;

            // Botón Retroceder
            btnRetroceder.FlatStyle = FlatStyle.Flat;
            btnRetroceder.FlatAppearance.BorderSize = 1;
            btnRetroceder.BackColor = Color.FromArgb(100, 116, 139); // Slate
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

        private void FormConsultaVisitas_Load(object sender, EventArgs e)
        {
            CargarCombos();
            FiltrarDatos();
        }

        private void CargarCombos()
        {
            try
            {
                // Cargar Médicos
                var medicos = new List<Medico> { new Medico { ID_Medico = 0, Nombre = "[Todos los Médicos]" } };
                medicos.AddRange(_medicoBll.ObtenerTodos());
                cmbMedico.DataSource = medicos;
                cmbMedico.DisplayMember = "Nombre";
                cmbMedico.ValueMember = "ID_Medico";
                cmbMedico.SelectedIndex = 0;

                // Cargar Pacientes
                var pacientes = new List<Paciente> { new Paciente { ID_Paciente = 0, Nombre = "[Todos los Pacientes]" } };
                pacientes.AddRange(_pacienteBll.ObtenerTodos());
                cmbPaciente.DataSource = pacientes;
                cmbPaciente.DisplayMember = "Nombre";
                cmbPaciente.ValueMember = "ID_Paciente";
                cmbPaciente.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar listados analíticos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkFiltrarFechas_CheckedChanged(object sender, EventArgs e)
        {
            dtpDesde.Enabled = chkFiltrarFechas.Checked;
            dtpHasta.Enabled = chkFiltrarFechas.Checked;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbMedico.SelectedIndex = 0;
            cmbPaciente.SelectedIndex = 0;
            chkFiltrarFechas.Checked = false;
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
            FiltrarDatos();
        }

        private void FiltrarDatos()
        {
            try
            {
                int? medicoId = null;
                if (cmbMedico.SelectedValue != null && (int)cmbMedico.SelectedValue > 0)
                {
                    medicoId = (int)cmbMedico.SelectedValue;
                }

                int? pacienteId = null;
                if (cmbPaciente.SelectedValue != null && (int)cmbPaciente.SelectedValue > 0)
                {
                    pacienteId = (int)cmbPaciente.SelectedValue;
                }

                DateTime? desde = null;
                DateTime? hasta = null;

                if (chkFiltrarFechas.Checked)
                {
                    desde = dtpDesde.Value.Date;
                    hasta = dtpHasta.Value.Date;
                }

                var list = _visitaBll.ObtenerPorCriterios(medicoId, pacienteId, desde, hasta);

                dgvDatos.DataSource = null;
                dgvDatos.DataSource = list;

                // Ocultar llaves
                if (dgvDatos.Columns["FK_Medico"] != null) dgvDatos.Columns["FK_Medico"].Visible = false;
                if (dgvDatos.Columns["FK_Paciente"] != null) dgvDatos.Columns["FK_Paciente"].Visible = false;
                if (dgvDatos.Columns["FK_Medicamento"] != null) dgvDatos.Columns["FK_Medicamento"].Visible = false;

                // Formatear
                if (dgvDatos.Columns["ID_Visita"] != null)
                {
                    dgvDatos.Columns["ID_Visita"].HeaderText = "ID";
                    dgvDatos.Columns["ID_Visita"].Width = 40;
                }
                if (dgvDatos.Columns["PacienteNombre"] != null)
                {
                    dgvDatos.Columns["PacienteNombre"].HeaderText = "Paciente";
                    dgvDatos.Columns["PacienteNombre"].Width = 150;
                }
                if (dgvDatos.Columns["MedicoNombre"] != null)
                {
                    dgvDatos.Columns["MedicoNombre"].HeaderText = "Médico";
                    dgvDatos.Columns["MedicoNombre"].Width = 150;
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
                    dgvDatos.Columns["MedicamentoDescripcion"].Width = 150;
                }
                if (dgvDatos.Columns["Sintomas"] != null)
                {
                    dgvDatos.Columns["Sintomas"].HeaderText = "Síntomas";
                    dgvDatos.Columns["Sintomas"].Width = 180;
                }
                if (dgvDatos.Columns["Recomendaciones"] != null)
                {
                    dgvDatos.Columns["Recomendaciones"].HeaderText = "Recomendaciones";
                    dgvDatos.Columns["Recomendaciones"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                if (dgvDatos.Columns["Estado"] != null)
                {
                    dgvDatos.Columns["Estado"].HeaderText = "Estado";
                    dgvDatos.Columns["Estado"].Width = 60;
                }

                lblTotal.Text = "Total de registros encontrados: " + list.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar visitas: " + ex.Message, "Error de Filtrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos disponibles para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivos CSV (*.csv)|*.csv";
                sfd.FileName = $"Reporte_Visitas_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                sfd.Title = "Exportar Reporte de Visitas";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sb = new StringBuilder();

                        // Escribir cabecera (excluyendo columnas ocultas)
                        var headers = new List<string>();
                        foreach (DataGridViewColumn col in dgvDatos.Columns)
                        {
                            if (col.Visible)
                            {
                                headers.Add(FormatearCeldaCSV(col.HeaderText));
                            }
                        }
                        sb.AppendLine(string.Join(",", headers));

                        // Escribir filas
                        foreach (DataGridViewRow row in dgvDatos.Rows)
                        {
                            if (row.IsNewRow) continue;

                            var cells = new List<string>();
                            foreach (DataGridViewColumn col in dgvDatos.Columns)
                            {
                                if (col.Visible)
                                {
                                    object? val = row.Cells[col.Index].Value;
                                    string strVal = string.Empty;
                                    if (val != null)
                                    {
                                        if (val is DateTime dt)
                                        {
                                            strVal = dt.ToString("dd/MM/yyyy");
                                        }
                                        else
                                        {
                                            strVal = val.ToString() ?? string.Empty;
                                        }
                                    }
                                    cells.Add(FormatearCeldaCSV(strVal));
                                }
                            }
                            sb.AppendLine(string.Join(",", cells));
                        }

                        // Guardar con codificación UTF-8 que incluya el BOM para compatibilidad con Excel
                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                        MessageBox.Show("Reporte exportado exitosamente a formato CSV.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al exportar reporte: " + ex.Message, "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string FormatearCeldaCSV(string value)
        {
            if (string.IsNullOrEmpty(value)) return "\"\"";

            // Reemplazar comillas dobles por dobles comillas dobles
            string escaped = value.Replace("\"", "\"\"");

            // Rodear el campo con comillas si contiene comas, comillas o nuevas líneas
            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n") || value.Contains("\r"))
            {
                return $"\"{escaped}\"";
            }
            return $"\"{escaped}\""; // Por seguridad, rodeamos todos los campos de texto
        }

        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
