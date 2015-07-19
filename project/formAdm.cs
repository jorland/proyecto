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
    public partial class formAdm : Form
    {
        public formAdm()
        {
            InitializeComponent();

        }

        private void formAdm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formEdicionClientes open = new formEdicionClientes();
            open.ShowDialog();
            
            
        }

        private void formAdm_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formEdicionAviones open = new formEdicionAviones();
            open.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            formEdicionVuelos open = new formEdicionVuelos();
            open.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            FormInicio open = new FormInicio();
            this.Hide();
            open.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formEdicionVoletos open = new formEdicionVoletos();
            open.Show();

        }
    }
}
