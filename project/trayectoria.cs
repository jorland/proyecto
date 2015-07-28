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
    public partial class trayectoria : Form
    {
        private string PaisOrigen;
        private string paisDestino;

        //contructor recibe los paises destino y origen 
        public trayectoria(string PaisOrigen,string paisDestino)
        {
            InitializeComponent();
            this.PaisOrigen = PaisOrigen;
            this.paisDestino = paisDestino;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void trayectoria_Load(object sender, EventArgs e)
        {
            string url = string.Format("http://pruebamaps.webatu.com/prueba.html?po={0}&pd={1}",PaisOrigen,paisDestino);

            webBrowser1.Navigate(url);//abre el sitio web en el componente webBrowser
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
