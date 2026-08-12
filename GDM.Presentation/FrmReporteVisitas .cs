```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GDM.Presentation
{
public partial class FrmReporteVisitas : Form
{
public FrmReporteVisitas()
{
InitializeComponent();

        ConfigurarFormulario();
    }

    private void ConfigurarFormulario()
    {
        dtpFechaFin.Value = DateTime.Today;

        dtpFechaInicio.Value =
            DateTime.Today.AddDays(-30);

        dgvReporte.AutoGenerateColumns = true;
        dgvReporte.ReadOnly = true;
        dgvReporte.AllowUserToAddRows = false;
        dgvReporte.AllowUserToDeleteRows = false;
        dgvReporte.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        MostrarTodasLasVisitas();
    }

    private void btnGenerarReporte_Click(object sender, EventArgs e)
    {
        DateTime fechaInicio = dtpFechaInicio.Value.Date;
        DateTime fechaFin = dtpFechaFin.Value.Date;

        if (fechaInicio > fechaFin)
        {
            MessageBox.Show(
                "La fecha de inicio no puede ser mayor " +
                "que la fecha final.",
                "Fechas incorrectas",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            return;
        }

        List<Visita> reporte = Datos.Visitas
            .Where(v =>
                v.Fecha.Date >= fechaInicio &&
                v.Fecha.Date <= fechaFin)
            .OrderBy(v => v.Fecha)
            .ToList();

        dgvReporte.DataSource = null;

        dgvReporte.DataSource = reporte;

        lblTotalVisitas.Text =
            "Total de visitas: " + reporte.Count;

        if (reporte.Count == 0)
        {
            MessageBox.Show(
                "No existen visitas registradas " +
                "dentro del período seleccionado.",
                "Reporte de visitas",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        else
        {
            MessageBox.Show(
                "Reporte generado correctamente." +
                "\n\nFecha inicial: "
                + fechaInicio.ToShortDateString() +
                "\nFecha final: "
                + fechaFin.ToShortDateString() +
                "\nTotal de visitas: "
                + reporte.Count,
                "Reporte de visitas",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }

    private void btnMostrarTodas_Click(object sender, EventArgs e)
    {
        MostrarTodasLasVisitas();
    }

    private void MostrarTodasLasVisitas()
    {
        List<Visita> todasLasVisitas =
            Datos.Visitas
            .OrderBy(v => v.Fecha)
            .ToList();

        dgvReporte.DataSource = null;

        dgvReporte.DataSource = todasLasVisitas;

        lblTotalVisitas.Text =
            "Total de visitas: "
            + todasLasVisitas.Count;
    }

    private void dtpFechaInicio_ValueChanged(
        object sender,
        EventArgs e)
    {
        if (dtpFechaInicio.Value.Date >
            dtpFechaFin.Value.Date)
        {
            dtpFechaFin.Value =
                dtpFechaInicio.Value;
        }
    }

    private void dtpFechaFin_ValueChanged(
        object sender,
        EventArgs e)
    {
        if (dtpFechaFin.Value.Date <
            dtpFechaInicio.Value.Date)
        {
            dtpFechaInicio.Value =
                dtpFechaFin.Value;
        }
    }
}
}
```
