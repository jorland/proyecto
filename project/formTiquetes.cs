using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/////////////////////////////////////COMENTARIOS DEL CODIGO///////////////////////////////////////////
//Fecha de creacion: 06-07-2015                                                                     //   
//Descripcion: from para visualizar los tiquetes que posee un cliente                                                                                   //
//                                                                                                      //
//                                                                                                  //
//////////////////////////////////////////////////////////////////////////////////////////////////////

namespace project
{
    public partial class formTiquetes : Form
    {
        public formTiquetes()
        {
            InitializeComponent();
        }

        private void formTiquetes_Load(object sender, EventArgs e)
        {
            actualizarDataGridCriterio();
        }

        public void actualizarDataGridCriterio()
        {

            dataGridView1.DataSource = tiquete.verTiquetesCriterio(cliente.idSeccionActual);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
