using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class FormInicio : Form
    {
        
        public FormInicio()
        {
            InitializeComponent();

            pictureBox1.Image = Image.FromFile("User.png");
        }

        private void btnResgisto_Click(object sender, EventArgs e)
        {
            formResgistro open = new formResgistro();
            open.Show();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            if (cliente.login(txtNombre.Text, txtContrasena.Text))
	        {
                if (cliente.getPrivilegio(txtNombre.Text, txtContrasena.Text).Equals("adm"))
                {
                   
                    formAdm open= new formAdm();
                    this.Hide();
                    open.Show();
                }
                else
                {
                    formEdicionVoletos open = new formEdicionVoletos();
                    this.Hide();
                    open.Show();

                }

            }
            else
            {
                MessageBox.Show("La información del usuario es incorrecta. Digite un nuevo usuario.");
            }
           
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            formAdm open = new formAdm();
            open.Show();
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
