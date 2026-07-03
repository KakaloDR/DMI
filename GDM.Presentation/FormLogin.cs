using System;
using System.Drawing;
using System.Windows.Forms;
using GDM.Business;

namespace GDM.Presentation
{
    public partial class FormLogin : Form
    {
        private readonly UsuarioBLL _usuarioBll = new UsuarioBLL();

        public FormLogin()
        {
            InitializeComponent();
            AplicarEstilos();
        }

        private void AplicarEstilos()
        {
            // Canvas base
            this.BackColor = Color.FromArgb(248, 250, 252); // Clinical Light Background
            panelTop.BackColor = Color.FromArgb(15, 41, 74); // Medical Navy
            panelBottom.BackColor = Color.FromArgb(248, 250, 252);

            // Labels
            lblUsuario.ForeColor = Color.FromArgb(15, 23, 42); // Text Primary
            lblClave.ForeColor = Color.FromArgb(15, 23, 42);

            // TextBoxes
            txtUsuario.BackColor = Color.White;
            txtUsuario.ForeColor = Color.FromArgb(15, 23, 42);
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;

            txtClave.BackColor = Color.White;
            txtClave.ForeColor = Color.FromArgb(15, 23, 42);
            txtClave.BorderStyle = BorderStyle.FixedSingle;

            // Botón Ingresar (Celeste Accent)
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.FlatAppearance.BorderSize = 1;
            btnIngresar.BackColor = Color.FromArgb(14, 165, 233);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.FlatAppearance.BorderColor = Color.FromArgb(14, 165, 233);
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.MouseEnter += (s, e) => { btnIngresar.BackColor = Color.FromArgb(2, 132, 199); };
            btnIngresar.MouseLeave += (s, e) => { btnIngresar.BackColor = Color.FromArgb(14, 165, 233); };

            // Botón Cancelar (Slate)
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderSize = 1;
            btnCancelar.BackColor = Color.Transparent;
            btnCancelar.ForeColor = Color.FromArgb(100, 116, 139);
            btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.MouseEnter += (s, e) => { 
                btnCancelar.BackColor = Color.FromArgb(241, 245, 249);
                btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            };
            btnCancelar.MouseLeave += (s, e) => { 
                btnCancelar.BackColor = Color.Transparent;
                btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
            };
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = txtUsuario.Text;
                string clave = txtClave.Text;

                // Validación de credenciales
                bool accesoConcedido = _usuarioBll.ValidarAcceso(usuario, clave);

                if (accesoConcedido)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message, 
                    "Fallo de Autenticación", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning
                );
                txtClave.Focus();
                txtClave.SelectAll();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtInput_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox txt)
            {
                txt.BackColor = Color.FromArgb(248, 250, 252);
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
