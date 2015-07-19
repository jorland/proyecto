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
    public partial class formAsientos : Form
    {
        private int idAvion;
        public formAsientos(int idAvion)
        {
            InitializeComponent();
            this.idAvion = idAvion;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void formAsientos_Load(object sender, EventArgs e)
        {
            actualizarGrid(); 
        }
        public void actualizarGrid()
        {
            DataSet ds = new DataSet();
            avion.verAsientosCriterio(idAvion).Fill(ds, "AEROLINEA_UAM");
            dataGridView1.DataSource = ds.Tables["AEROLINEA_UAM"];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow fila = dataGridView1.CurrentRow;
            int idAsiento = Convert.ToInt32(fila.Cells[1].Value);
            avion.inactivarAsiento(idAsiento);
            MessageBox.Show("Asiento inhabilitado.");
            actualizarGrid();
        }
    }
}
