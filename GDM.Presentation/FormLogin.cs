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
            // Botón Ingresar (Ice Blue Accent)
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.FlatAppearance.BorderSize = 1;
            btnIngresar.BackColor = Color.FromArgb(2, 132, 199);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.FlatAppearance.BorderColor = Color.FromArgb(2, 132, 199);
            btnIngresar.Cursor = Cursors.Hand;

            // Botón Cancelar (Slate)
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderSize = 1;
            btnCancelar.BackColor = Color.Transparent;
            btnCancelar.ForeColor = Color.FromArgb(100, 116, 139);
            btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(100, 116, 139);
            btnCancelar.Cursor = Cursors.Hand;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = txtUsuario.Text;
                string clave = txtClave.Text;

                // Llamada a la capa de negocio para validar (VALIDACIÓN DE SEGURIDAD PRINCIPAL)
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
