using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GDM.Presentation
{
    public partial class FrmConsultaVisitas : Form
    {
        public FrmConsultaVisitas()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            cmbCriterio.Items.Clear();

            cmbCriterio.Items.Add("Todos");
            cmbCriterio.Items.Add("Médico");
            cmbCriterio.Items.Add("Paciente");
            cmbCriterio.Items.Add("Fecha");

            cmbCriterio.SelectedIndex = 0;

            txtCriterio.Clear();

            MostrarTodasLasVisitas();

            dgvResultados.AutoGenerateColumns = true;
            dgvResultados.ReadOnly = true;
            dgvResultados.AllowUserToAddRows = false;
            dgvResultados.AllowUserToDeleteRows = false;
            dgvResultados.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            lblCantidadResultados.Text =
                "Cantidad de visitas: " + Datos.Visitas.Count;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string criterio = txtCriterio.Text.Trim();

            string tipoBusqueda = cmbCriterio.SelectedItem.ToString();

            if (tipoBusqueda == "Todos")
            {
                MostrarTodasLasVisitas();
                return;
            }

            if (string.IsNullOrWhiteSpace(criterio))
            {
                MessageBox.Show(
                    "Por favor, escriba un criterio de búsqueda.",
                    "Consulta de visitas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtCriterio.Focus();
                return;
            }

            List<Visita> resultados = new List<Visita>();

            if (tipoBusqueda == "Médico")
            {
                resultados = Datos.Visitas
                    .Where(v =>
                        v.Medico != null &&
                        v.Medico.ToLower()
                        .Contains(criterio.ToLower()))
                    .ToList();
            }
            else if (tipoBusqueda == "Paciente")
            {
                resultados = Datos.Visitas
                    .Where(v =>
                        v.Paciente != null &&
                        v.Paciente.ToLower()
                        .Contains(criterio.ToLower()))
                    .ToList();
            }
            else if (tipoBusqueda == "Fecha")
            {
                DateTime fecha;

                if (!DateTime.TryParse(criterio, out fecha))
                {
                    MessageBox.Show(
                        "La fecha introducida no es válida." +
                        "\nEjemplo: 11/08/2026",
                        "Fecha incorrecta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtCriterio.Focus();
                    return;
                }

                resultados = Datos.Visitas
                    .Where(v => v.Fecha.Date == fecha.Date)
                    .ToList();
            }

            dgvResultados.DataSource = null;
            dgvResultados.DataSource = resultados;

            lblCantidadResultados.Text =
                "Cantidad de visitas encontradas: "
                + resultados.Count;

            if (resultados.Count == 0)
            {
                MessageBox.Show(
                    "No se encontraron visitas con el criterio indicado.",
                    "Consulta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void MostrarTodasLasVisitas()
        {
            dgvResultados.DataSource = null;
            dgvResultados.DataSource = Datos.Visitas.ToList();

            lblCantidadResultados.Text =
                "Cantidad de visitas: " + Datos.Visitas.Count;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCriterio.Clear();

            cmbCriterio.SelectedIndex = 0;

            MostrarTodasLasVisitas();

            txtCriterio.Focus();
        }
    }
}