using System;
using System.Drawing;
using System.Windows.Forms;

namespace GDM.Presentation
{
    /// <summary>
    /// Clase helper para aplicar el tema visual Clinical Light & Navy a cualquier formulario.
    /// </summary>
    public static class EstilizadorFormularios
    {
        public static void AplicarTema(Form form)
        {
            if (form == null) return;

            // Fondo general del subformulario
            form.BackColor = Color.FromArgb(248, 250, 252); // Gris/Azul clínico muy suave

            // Procesar todos los controles recursivamente
            ProcesarControles(form.Controls);
        }


        public static void EstilizarControl(Control ctrl)
        {
            if (ctrl == null) return;

            // Ocultar cabeceras redundantes
            if (ctrl.Name.Equals("panelTop", StringComparison.OrdinalIgnoreCase) || 
                ctrl.Name.Equals("btnRetroceder", StringComparison.OrdinalIgnoreCase))
            {
                ctrl.Visible = false;
                return;
            }

            // GroupBox (Tarjetas Blancas)
            if (ctrl is GroupBox grp)
            {
                grp.BackColor = Color.White;
                grp.ForeColor = Color.FromArgb(15, 41, 74); // Medical Navy
                grp.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
                
                // Procesar controles internos de la tarjeta
                foreach (Control subCtrl in grp.Controls)
                {
                    EstilizarControl(subCtrl);
                }
                return;
            }

            // Panel de búsqueda superior en grillas
            if (ctrl.Name.Equals("panelBusqueda", StringComparison.OrdinalIgnoreCase))
            {
                ctrl.BackColor = Color.Transparent;
            }

            // TextBoxes y MaskedTextBoxes
            if (ctrl is TextBox || ctrl is MaskedTextBox)
            {
                ctrl.BackColor = Color.White;
                ctrl.ForeColor = Color.FromArgb(15, 23, 42); // Text Primary
                if (ctrl is TextBox txt)
                {
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (ctrl is MaskedTextBox msk)
                {
                    msk.BorderStyle = BorderStyle.FixedSingle;
                }

                // Efectos de enfoque
                ctrl.Enter += (s, e) => { ctrl.BackColor = Color.FromArgb(248, 250, 252); };
                ctrl.Leave += (s, e) => { ctrl.BackColor = Color.White; };
            }

            // ComboBoxes
            if (ctrl is ComboBox cmb)
            {
                cmb.BackColor = Color.White;
                cmb.ForeColor = Color.FromArgb(15, 23, 42);
                cmb.FlatStyle = FlatStyle.Standard; // Renderizado plano nativo de Windows
            }

            // Labels
            if (ctrl is Label lbl)
            {
                // Si está dentro de un GroupBox blanco, texto primario. Si no, texto secundario.
                if (lbl.Parent is GroupBox)
                {
                    lbl.ForeColor = Color.FromArgb(15, 23, 42);
                    lbl.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                }
                else
                {
                    lbl.ForeColor = Color.FromArgb(100, 116, 139); // Slate Muted
                    lbl.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                }
            }

            // Botones
            if (ctrl is Button btn)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.Cursor = Cursors.Hand;
                btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

                string name = btn.Name.ToLower();

                if (name.Contains("guardar") || name.Contains("nuevo") || name.Contains("filtrar") || name.Contains("buscar"))
                {
                    btn.FlatAppearance.BorderSize = 0; // Sin bordes para un diseño 100% plano
                    btn.BackColor = Color.FromArgb(14, 165, 233); // Celeste Accent
                    btn.ForeColor = Color.White;

                    btn.MouseEnter += (s, e) => { btn.BackColor = Color.FromArgb(2, 132, 199); };
                    btn.MouseLeave += (s, e) => { btn.BackColor = Color.FromArgb(14, 165, 233); };
                }
                else if (name.Contains("eliminar"))
                {
                    btn.FlatAppearance.BorderSize = 0; // Sin bordes para un diseño 100% plano
                    btn.BackColor = Color.FromArgb(239, 68, 68); // Crimson
                    btn.ForeColor = Color.White;

                    btn.MouseEnter += (s, e) => { btn.BackColor = Color.FromArgb(220, 38, 38); };
                    btn.MouseLeave += (s, e) => { btn.BackColor = Color.FromArgb(239, 68, 68); };
                }
                else // Cancelar, Limpiar, Retroceder, etc.
                {
                    btn.FlatAppearance.BorderSize = 1;
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = Color.FromArgb(100, 116, 139); // Slate Muted
                    btn.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240); // Borde claro y suave

                    btn.MouseEnter += (s, e) => { 
                        btn.BackColor = Color.FromArgb(248, 250, 252);
                        btn.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
                    };
                    btn.MouseLeave += (s, e) => { 
                        btn.BackColor = Color.Transparent;
                        btn.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
                    };
                }
            }

            // Grillas (DataGridView)
            if (ctrl is DataGridView dgv)
            {
                dgv.BackgroundColor = Color.White;
                dgv.GridColor = Color.FromArgb(226, 232, 240);
                dgv.BorderStyle = BorderStyle.None;
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgv.EnableHeadersVisualStyles = false;

                // Estilo de Cabeceras
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 41, 74); // Medical Navy
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                dgv.ColumnHeadersHeight = 35;
                dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                // Estilo de Celdas
                dgv.DefaultCellStyle.BackColor = Color.White;
                dgv.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254); // Celeste/Sky muy suave y moderno
                dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);   // Texto oscuro legible en selección

                // Zebra striping y altura de filas
                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
                dgv.RowTemplate.Height = 32; // Filas más altas y espaciosas, aspecto web moderno
                dgv.RowHeadersVisible = false;
            }

            // Recursividad sobre otros controles contenedores (paneles, etc.)
            if (ctrl.HasChildren)
            {
                foreach (Control child in ctrl.Controls)
                {
                    EstilizarControl(child);
                }
            }
        }

        private static void ProcesarControles(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                EstilizarControl(ctrl);
            }
        }
    }
}
