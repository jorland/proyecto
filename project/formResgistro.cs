using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace project
{
    public partial class formResgistro : Form
    {
        public formResgistro()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtCedula.Text == "")
                {
                    throw new Exception("El N° de cédula es incorrecta.");
                }
                else if (txtNombre.Text == "")
                {
                    throw new Exception("El campo *Nombre* no puede estar en blanco.");
                }
                else if (txtContrasena.Text == "")
                {
                    throw new Exception("El campo *Contraseña* no puede estar en blanco.");
                }
                else
                {
                    if (rbtRegular.Checked)
                    {
                        cliente nuevo = new clienteRegular(txtCedula.Text, txtNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text, txtContrasena.Text, "regular", "cliente");
                        nuevo.guardarCliente();
                    }
                    else if (rbtPlatino.Checked)
                    {
                        cliente nuevo = new clientePlatino(txtCedula.Text, txtNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text, txtContrasena.Text, "platino", "cliente");
                        nuevo.guardarCliente();
                    }
                    else if (rbtDiamante.Checked)
                    {
                        cliente nuevo = new ClienteDiamante(txtCedula.Text, txtNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text, txtContrasena.Text, "diamante", "cliente");
                        nuevo.guardarCliente();
                    }

                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                "Important Note",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            }



        }
        
    }
}
