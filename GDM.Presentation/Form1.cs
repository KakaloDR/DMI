using System;
using System.Drawing;
using System.Windows.Forms;
using GDM.Business;

namespace GDM.Presentation
{
    public partial class Form1 : Form
    {
        private readonly ConexionService _conexionService;
        private Button? _btnActivo = null;

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
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.BackColor = Color.Transparent;
            btnSalir.ForeColor = Color.FromArgb(226, 232, 240);
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.TextAlign = ContentAlignment.MiddleLeft;
            btnSalir.Padding = new Padding(15, 0, 0, 0);
            btnSalir.MouseEnter += (s, e) => {
                btnSalir.BackColor = Color.FromArgb(239, 68, 68); // Rojo al salir/cerrar sesión
                btnSalir.ForeColor = Color.White;
            };
            btnSalir.MouseLeave += (s, e) => {
                btnSalir.BackColor = Color.Transparent;
                btnSalir.ForeColor = Color.FromArgb(226, 232, 240);
            };

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
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.Transparent;
            btn.ForeColor = Color.FromArgb(226, 232, 240);
            btn.Cursor = Cursors.Hand;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(15, 0, 0, 0);

            // Hover effects
            btn.MouseEnter += (s, e) => {
                if (btn != _btnActivo)
                {
                    btn.BackColor = Color.FromArgb(14, 165, 233); // Celeste Accent
                    btn.ForeColor = Color.White;
                }
            };
            btn.MouseLeave += (s, e) => {
                if (btn != _btnActivo)
                {
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = Color.FromArgb(226, 232, 240);
                }
            };
        }

        private void MarcarBotonActivo(Button btn, string titulo)
        {
            if (_btnActivo != null)
            {
                _btnActivo.BackColor = Color.Transparent;
                _btnActivo.ForeColor = Color.FromArgb(226, 232, 240);
            }

            _btnActivo = btn;
            _btnActivo.BackColor = Color.FromArgb(14, 165, 233); // Celeste
            _btnActivo.ForeColor = Color.White;

            lblTitulo.Text = titulo;
        }

        private void CargarFormularioEnWorkspace(Form subForm, Button btnNav, string titulo)
        {
            MarcarBotonActivo(btnNav, titulo);

            // Limpiar workspace anterior
            if (panelWorkspace.Controls.Count > 0)
            {
                var formAnterior = panelWorkspace.Controls[0] as Form;
                formAnterior?.Close();
                panelWorkspace.Controls.Clear();
            }

            subForm.TopLevel = false;
            subForm.FormBorderStyle = FormBorderStyle.None;
            subForm.Dock = DockStyle.Fill;
            
            // Aplicar tema clínico al subformulario
            EstilizadorFormularios.AplicarTema(subForm);

            panelWorkspace.Controls.Add(subForm);
            panelWorkspace.Tag = subForm;
            subForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RealizarPruebaConexion();
        }

        private void RealizarPruebaConexion()
        {
            bool conexionExitosa = _conexionService.VerificarConectividad();
            
            btnVisitas.Enabled = conexionExitosa;
            btnConsultaVisitas.Enabled = conexionExitosa;
            btnTiposFarmacos.Enabled = conexionExitosa;
            btnMarcas.Enabled = conexionExitosa;
            btnUbicaciones.Enabled = conexionExitosa;
            btnPacientes.Enabled = conexionExitosa;
            btnMedicos.Enabled = conexionExitosa;
            btnMedicamentos.Enabled = conexionExitosa;

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
            else
            {
                // Cargar Registro de Visitas por defecto
                CargarFormularioEnWorkspace(new FormVisitas(), btnVisitas, "DMI - Registro de Visitas");
            }
        }

        private void btnTiposFarmacos_Click(object sender, EventArgs e)
        {
            CargarFormularioEnWorkspace(new FormTiposFarmacos(), btnTiposFarmacos, "DMI - Tipos de Fármacos");
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            CargarFormularioEnWorkspace(new FormMarcas(), btnMarcas, "DMI - Marcas (Laboratorios)");
        }

        private void btnUbicaciones_Click(object sender, EventArgs e)
        {
            CargarFormularioEnWorkspace(new FormUbicaciones(), btnUbicaciones, "DMI - Ubicaciones Físicas");
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            CargarFormularioEnWorkspace(new FormPacientes(), btnPacientes, "DMI - Control de Pacientes");
        }

        private void btnMedicos_Click(object sender, EventArgs e)
        {
            CargarFormularioEnWorkspace(new FormMedicos(), btnMedicos, "DMI - Control de Médicos (Personal)");
        }

        private void btnMedicamentos_Click(object sender, EventArgs e)
        {
            CargarFormularioEnWorkspace(new FormMedicamentos(), btnMedicamentos, "DMI - Control de Medicamentos");
        }

        private void btnVisitas_Click(object sender, EventArgs e)
        {
            CargarFormularioEnWorkspace(new FormVisitas(), btnVisitas, "DMI - Registro de Visitas");
        }

        private void btnConsultaVisitas_Click(object sender, EventArgs e)
        {
            CargarFormularioEnWorkspace(new FormConsultaVisitas(), btnConsultaVisitas, "DMI - Consulta por Criterios");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
