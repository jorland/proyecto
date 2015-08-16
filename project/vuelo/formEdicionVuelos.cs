using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq.Mapping;
using System.Data.Linq.SqlClient;
using System.Data.Linq;

/////////////////////////////////////COMENTARIOS DEL CODIGO///////////////////////////////////////////
//Fecha de creacion: 20-06-2015                                                                     //   
//Creado por: Everson                                                                               //
//Descripcion: Clase para el ingreso, Busqueda, llenado del Combobox y Actualizacion de vuelos      //
//Fecha de Modificacion: 07-07-2015                                                                 //
//Modificado por: jorland                                                                           //
//Descripcion: Parametro extra(precioDolares) al ingresar un vuelo...Eliminado de tiquetes          //
//////////////////////////////////////////////////////////////////////////////////////////////////////



namespace project
{
    //Clase con herencia
    public partial class formEdicionVuelos : Form
    {
        public formEdicionVuelos()
        {
            InitializeComponent();

            llenarComboBox(); //Llama al metodo que muestra los datos de origen
            cbFecha.Value = DateTime.Today; //Llena el campo de fecha con la fecha actual

        } //Fin de formEdicionVuelos

        private void button1_Click(object sender, EventArgs e)
        {
            //Se declaran las variables
            int id;
            int idAvion;
            int millas;
            string origenVuelo;
            string destinoVuelo;
            string fechaHora;
            float precioDolares;

            //Try para la captura de excepciones
            try
            {
                //No permite que los campos esten vacios
                if (txtIdVuelo.Text == "" || cbAvion.Text == "" || txtMillasVuelo.Text == "" || txtPrecio.Text == "")
                {
                    throw new Exception("Ingrese los campos necesarios.");
                }

                //Si no permite el ingreso de los datos que estan llenos
                else
                {
                    id = Convert.ToInt32(txtIdVuelo.Text);
                    idAvion = Convert.ToInt32(cbAvion.Text);
                    millas = Convert.ToInt32(txtMillasVuelo.Text);
                    origenVuelo = cbOrigenVuelo.Text;
                    destinoVuelo = cbDestinoVuelo.Text;
                    fechaHora = cbFecha.Value.ToShortDateString() + "---" + cbHora.Value.ToShortTimeString();
                    precioDolares = float.Parse(txtPrecio.Text);
                }
                //Si el origen del vuelo es igual a el destino muestra el mensaje
                if (cbOrigenVuelo.Text == cbDestinoVuelo.Text)
                {
                    throw new Exception("Seleccione un destino diferente al de origen de vuelo.");
                }

                //Si la fecha es igual
                if (!validarFecha())
                {
                    throw new Exception("Seleccione una fecha futura.");
                }


                //Vuelo vuelo = new Vuelo(id, idAvion, millas, origenVuelo, destinoVuelo, fechaHora,precioDolares);

                Vuelo.Agregar(id, origenVuelo, destinoVuelo, millas, fechaHora, idAvion, precioDolares);
                asignarVueloEnAsientos(idAvion, id);
                avion.cambiarEstado(idAvion);
                actualizarDataGrid();
            } //Fin del try

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }//Fin del catch

        } //Fin del boton button1_Click (Ingresar vuelo)


        //nuevo
        public void asignarVueloEnAsientos(int idAvion, int idVuelo)
        {
            //Instacia de la clase myConnection
            myConnection mc = new myConnection();
            SqlConnection cnn = mc.createConnection();
            SqlCommand command = mc.createCommand(cnn);
            command.CommandText = "PRDB_CAMBIO_ID_VUELO_ASIENTO";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@pIdAvion", idAvion); //Campos de la BD del SP
            command.Parameters.AddWithValue("@pIdVuelo", idVuelo); //Campos de la BD del SP

            cnn.Open(); //Abre conexion con la BD
            command.ExecuteNonQuery(); //Ejecucion en la BD
            cnn.Close(); //Cierre de conexion a la BD

        }//Fin de asignarVueloEnAsientos


        //Metodo para validar la fecha
        public Boolean validarFecha()
        {
            Boolean salida = true; ; //si la salida es true la fecha esta bien
            if (cbFecha.Value.Date == DateTime.Today.Date && cbHora.Value <= DateTime.Now)
            {
                salida = false;//si la salida es false la fecha esta mal

            }

            return salida;

        } //Fin de validarFecha

        //Metodo que refresca el datagridview para mostrar los nuevos vuelos 
        public void actualizarDataGrid()
        {

            //DataSet ds = new DataSet();
            //Vuelo.verVuelos().Fill(ds, "AEROLINEA_UAM");
            listaVuelos.DataSource = Vuelo.verVuelos();

        } //Fin de actualizarDataGrid

        private void formEdicionVuelos_Load(object sender, EventArgs e)
        {
            actualizarDataGrid();

            llenarComboBox();  //Llamado del metodo para llenar los paises Origen/Destino
            llenarComboBoxAviones(); //Llamado del metodo para llenar aviones
        }

        //Metodo para llenar el campo de origen y destino con los paises
        public void llenarComboBox()
        {
            
            try
            {
                
                DataContext dc = new DataContext(myConnection.getConnection());
                var tabla = dc.GetTable<tablaPaises>();
                var paises = from p in tabla
                             select p;

                foreach (var pais in paises)
                {
                    cbOrigenVuelo.Items.Add(pais.DESCRIPCION);
                    cbDestinoVuelo.Items.Add(pais.DESCRIPCION);
                }

                cbOrigenVuelo.SelectedIndex = 0;//Para que aparezca de una vez el nombre de un pais
                cbDestinoVuelo.SelectedIndex = 0;//Para que aparezca de una vez el nombre de un pais
            } //Fin del try

            //Captura las excepciones
            catch (Exception ex)
            {
                MessageBox.Show("El campo no posee valores en lla base de datos. " + ex.ToString());
            } //Fin del Catch

        } //Fin de llenarComboBox()

        //Metodo para llenar el campo de aviones
        public void llenarComboBoxAviones()
        {
            //Realiza el llamado a la clase myConnection para utilizar la base de datos
            myConnection mc = new myConnection();
            SqlConnection cnn = mc.createConnection();
            SqlCommand command = mc.createCommand(cnn);
            //Sentencia de SQL que busca las columnas de avion
            command.CommandText = "SELECT * FROM AVION";
            //Abre la conexion
            cnn.Open();
            //Lee los datos de la BD
            SqlDataReader re = command.ExecuteReader();
            //Entra en ciclo para devolver los aviones que posean asientos disponibles
            while (re.Read())
            {
                //Solamente si el asiento es disponible lo devuelve
                if (re["ESTADO"].Equals("D"))
                {
                    cbAvion.Items.Add(re["ID_AVION"].ToString());
                } //Fin del if

            }//Fin del While

            cnn.Close();//Cierra la coneccion

            DataContext dc = new DataContext(myConnection.getConnection());
            var tabla = dc.GetTable<>();
            var paises = from p in tabla
                         select p;

            foreach (var pais in paises)
            {
                cbOrigenVuelo.Items.Add(pais.DESCRIPCION);
                cbDestinoVuelo.Items.Add(pais.DESCRIPCION);
            }

            cbOrigenVuelo.SelectedIndex = 0;//Para que aparezca de una vez el nombre de un pais
            cbDestinoVuelo.SelectedIndex = 0;//Para que aparezca de una vez el nombre de un pais

        } //Fin de llenar comboBoxAvion

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //Boton para el llamado de la busqueda de los vuelos con forma de lupa
        private void btBuscarVuelo_Click(object sender, EventArgs e)
        {
            ////Ingresa los datos de la busqueda en este caso el nombre del pais 
            ////de destino al Datagridview 
            //DataSet ds = new DataSet();
            ////Es el boton con una lupa
            //Vuelo.verVuelos(txtBuscar.Text).Fill(ds, "AEROLINEA_UAM");
            ////Llena el Datagridview al precionar el boton de lupa
            listaVuelos.DataSource = Vuelo.verVuelos(txtBuscar.Text);

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //Boton para el llamado para cerrar la ventana de ingreso
        private void button2_Click(object sender, EventArgs e)
        {
            //Cierra la ventana del form de Vuelos
            this.Close();

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void listaVuelos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    } //Fin de la clase formEdicionVuelos

} //Fin del Proyecto
