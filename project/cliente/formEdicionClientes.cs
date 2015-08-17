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
    public partial class formEdicionClientes : Form
    {
        public formEdicionClientes()
        {
            InitializeComponent();
        }

        private void formEdicionClientes_Load(object sender, EventArgs e)
        {
            actualizarGrid();
        }

        public void actualizarGrid()
        {
            dataGridView1.DataSource = cliente.verClientes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formResgistro nuevo = new formResgistro();
            this.SendToBack();
            nuevo.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                DataGridViewRow fila = dataGridView1.CurrentRow;
                int id = ((Int32)fila.Cells[0].Value);
                cliente.inactivarCliente(id,"inactivo");
                MessageBox.Show("Usuario Inactivado de la base de datos.");
                actualizarGrid();
            }

            catch (Exception)
            {
                MessageBox.Show("El usuario no esta disponible.");
            }    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = cliente.verClientes(txtBuscar.Text);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            actualizarGrid();
        }
    }
}
