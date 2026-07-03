using System;
using System.Drawing;
using System.Windows.Forms;
using GDM.Business;

namespace GDM.Presentation
{
    public partial class Form1 : Form
    {
        private readonly ConexionService _conexionService;

        public Form1()
        {
            InitializeComponent();
            _conexionService = new ConexionService();
            AplicarEstilos();
        }

        private void AplicarEstilos()
        {
            // Botón Salir (Cerrar Sesión)
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.FlatAppearance.BorderSize = 1;
            btnSalir.BackColor = Color.Transparent;
            btnSalir.ForeColor = Color.FromArgb(100, 116, 139); // Slate Gray
            btnSalir.FlatAppearance.BorderColor = Color.FromArgb(100, 116, 139);
            btnSalir.Cursor = Cursors.Hand;

            // Botones de Menú
            EstilizarBotonMenu(btnVisitas);
            EstilizarBotonMenu(btnConsultaVisitas);
            EstilizarBotonMenu(btnTiposFarmacos);
            EstilizarBotonMenu(btnMarcas);
            EstilizarBotonMenu(btnUbicaciones);
            EstilizarBotonMenu(btnPacientes);
            EstilizarBotonMenu(btnMedicos);
            EstilizarBotonMenu(btnMedicamentos);
        }

        private void EstilizarBotonMenu(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.BackColor = Color.FromArgb(15, 30, 54); // Primary Corporativo Frío
            btn.ForeColor = Color.White;
            btn.FlatAppearance.BorderColor = Color.FromArgb(15, 30, 54);
            btn.Cursor = Cursors.Hand;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(2, 132, 199); // Ice Blue Accent on hover
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RealizarPruebaConexion();
        }

        private void RealizarPruebaConexion()
        {
            bool conexionExitosa = _conexionService.VerificarConectividad();
            grpProcesos.Enabled = conexionExitosa;
            grpCatalogos.Enabled = conexionExitosa;

            if (!conexionExitosa)
            {
                MessageBox.Show(
                    "Error al conectar con la base de datos SQL Server.\n" +
                    "Asegúrese de que el servicio SQL Server esté iniciado y configurado correctamente.", 
                    "Error de Conectividad", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnTiposFarmacos_Click(object sender, EventArgs e)
        {
            using (var form = new FormTiposFarmacos())
            {
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            using (var form = new FormMarcas())
            {
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
        }

        private void btnUbicaciones_Click(object sender, EventArgs e)
        {
            using (var form = new FormUbicaciones())
            {
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            using (var form = new FormPacientes())
            {
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
        }

        private void btnMedicos_Click(object sender, EventArgs e)
        {
            using (var form = new FormMedicos())
            {
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
        }

        private void btnMedicamentos_Click(object sender, EventArgs e)
        {
            using (var form = new FormMedicamentos())
            {
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Cierra la aplicación (y termina la ejecución)
            Application.Exit();
        }

        private void btnVisitas_Click(object sender, EventArgs e)
        {
            using (var form = new FormVisitas())
            {
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
        }

        private void btnConsultaVisitas_Click(object sender, EventArgs e)
        {
            using (var form = new FormConsultaVisitas())
            {
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
        }
    }
}
