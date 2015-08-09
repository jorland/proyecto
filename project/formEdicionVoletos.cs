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


/////////////////////////////////////COMENTARIOS DEL CODIGO///////////////////////////////////////////
//Fecha de creacion: 27-06-2015                                                                     //   
//Creado por: Johana                                                                                //
//Descripcion: Clase base de tiquetes, retorno de variables, ComboBox, SP "PRDB_OBTIENE_ASIENTO"    //
//Fecha de Modificacion: 04-07-2015                                                                 //
//Modificado por: johana                                                                            //
//Descripcion: Actualiza el DataGridView (Lsita de Vuelos)                                          //
//Fecha de Modificacion: 06-07-2015                                                                 //
//Modificado por: Jorland                                                                           //
//Descripcion: Ingresa los tiquetes a la base datos , Boton de Dollares, Boton Colones y Metodos 
//             validaciones al comprar
//                                                                                                  //
//////////////////////////////////////////////////////////////////////////////////////////////////////





namespace project
{
    public partial class formEdicionVoletos : Form
    {
        //Nuevas variables privadas para la clase
        private double precio;
        private int idVuelo;
        private int cantAsientos;
        private string fecha;
        private string origen;
        private string destino;
            
        public formEdicionVoletos()
        {
            InitializeComponent();
            actualizarDataGrid();//Actualiza la lista de vuelos apenas ocurra algun cambio
        }

        //Label que se muestra en el campo Nombre del Cliente
        private void formEdicionVoletos_Load(object sender, EventArgs e)
        {
            label5.Text = cliente.nombreSeccionActual; //Toma el metodo de la clase cliente y la pasa al label que esta en el camp "Usuario Actual"
        }//Fin del Label que esta en el campo Nombre del Cliente
        
        //Llena el comboBox de Asientos 
        public void llenarComboBox(int id) //guarda el "id" del vuelo
        {
            
            //Conneccion a la base de datos
            myConnection coneccion = new myConnection();
            SqlConnection cnn = coneccion.createConnection();
            SqlCommand command = coneccion.createCommand(cnn);
            //Abre la conneccion a la base
            cnn.Open();

            //Invoca el SP PRDB_OBTIENE_ASIENTO
            command.CommandText = "PRDB_OBTIENE_ASIENTO";
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = command.ExecuteReader();

            //Try para la captura de excepciones
            try
            {
                //recorre los datos de paises en la base
                while (dr.Read())
                {
                    //Compara el ID_VUELO (de la BD) con el "id" que se paso y revisa que el estado en la BD (campo ESTADO) este "D" = desocupado
                    if (Convert.ToInt32(dr["ID_VUELO"]) == id && dr["ESTADO"].Equals("D"))
                    {
                        //Agrega el valor del combo box de el campo Asiento del from y lo pasa a la BD
                        comboBox1.Items.Add(dr["CONS_ASIENTO"].ToString());
                    
                    } //Fin del if
                    
                } //Fin del While
                
                dr.Close(); //Deja de realizar la lectura de BD
                cnn.Close(); //Cierra la conexion a la BD
            
            } //Fin del Try

            //Captura las excepciones
            catch (Exception )
            {
                
            }
        } //Fin de llenarComboBox
        
        //Actualiza el DataGridView (Lista de vuelo)
        public void actualizarDataGrid()
        {
            //Instacia para ingresar datos
            //DataSet ds = new DataSet();
            //Vuelo.verVuelos().Fill(ds, "AEROLINEA_UAM"); //Metodo verVuelos que ejecuta el SP que trae la consulta de la base de datos
            dgvVuelos.DataSource = Vuelo.verVuelos();
        
        } //Fin del DataGridView (Lista de vuelo)


        public void actualizarDataGridCriterio()
        {
            // Modificado por everson
            dgvVuelos.DataSource = Vuelo.verVuelos(textBox1.Text);
        }

        private void dgvVuelos_Validating(object sender, CancelEventArgs e)
        {

        }

        //
        public void obtenerDatos()
        {
            //Try para la captura de excepciones
            try
            {
                DataGridViewRow fila = dgvVuelos.CurrentRow; //Retorna la fila selecciona del DataGridView (Lista de Vuelos)
                idVuelo = (Convert.ToInt32(fila.Cells[0].Value)); //guarda el valor de la posicion 0 en la variable idVuelo
                cantAsientos = Vuelo.cantAsientos(idVuelo); //Guarda el asiento del ComboBox Asiento en la variable cantAsientos
                fecha = fila.Cells[4].Value.ToString(); //Guarda la fecha del vuelo del DataGridView (Lista de vuelo) de la 4 en la variable fecha
                origen = fila.Cells[2].Value.ToString(); //Guarda el valor del DataGridView (Lista de Vuelos) de la posicion 2 en la variablie Origen
                destino = fila.Cells[3].Value.ToString(); //Guarda el destino del DataGridView (Lista de Vuelos) de la posicion 3 en la variable destino
                precio = Double.Parse(fila.Cells[7].Value.ToString()); //Guarda el precio del DataGridView (Lista de Vuelos) de la posicion 7 en la variable precio
                comboBox1.Items.Clear(); //Limpia el ComboBox
                comboBox1.ResetText(); //Reinicia el ComboBox

                label2.Text = precio.ToString(); //Llena el label2 que es el que esta junto al campo "Precio en dolares"
                llenarComboBox(idVuelo); //Llena el comboBox con el idVuelo
                comboBox1.SelectedIndex = 0; ////Para que aparezca de una vez el nombre en el comboBox

            } //Fin del Try

            catch (Exception)//Captura de Excepciones
            {

            }

        }//Fin del metodo obtenerDatos

        //Toma el valor del DataGridView (Lista de Vuelos) el PRECIO
        private void dgvVuelos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            label2.Text = precio.ToString();//Pasa el precio a el label2
            rbColones.Enabled = true;//Boton colones 
            rbDolares.Enabled = false;//Boton Dollares
            rbDolares.Checked=true;
            obtenerDatos(); //

        }//Fin DataGridView (Lista de Vuelos)

        //Boton para comprar los tiquetes
        private void IngresarTiuete_Click(object sender, EventArgs e)
        {
            //Toma la primera fila del DataGridView que es la busqueda del vuelo
            DataGridViewRow fila = dgvVuelos.CurrentRow;
            
            //Variables nuevas
            string fecha;
            int millas;
            int asiento;
            int idVuelo=0; //Se inicializa

            //Try para la captura de excepciones
            try
            {

                 fila = dgvVuelos.CurrentRow; //guarda la fila completa de la lista de vuelos en la variable fila
                 fecha = fila.Cells[4].Value.ToString(); //guarda la fecha de la fila de la posicion 4 en la variable fecha
                 millas = Convert.ToInt32(fila.Cells[1].Value.ToString()); //guarda las millas de la fila de la posicion 1  en la variable millas
                 asiento = Convert.ToInt32(comboBox1.Text); //guarda el asiento del combobox que es el campo que se selecciona
                 idVuelo = (Convert.ToInt32(fila.Cells[0].Value)); //guarda el idVuelo que esta en la fila en la posicion 0 en la variable idVuelo

                 if (comboBox1.Text == "")
                 {
                     throw new Exception();
                 }
                 if (dgvVuelos.SelectedRows==null)
                 {
                    throw new Exception(); 
                 }

                //Evalua los tipos de clientes en este caso si es PLATINO
                if (cliente.tipoClienteSeccionActual.Equals("platino"))
                {
                    tiquete nuevo = new tiquete(fecha, cliente.idSeccionActual);
                    nuevo.ingresarTiquete(nuevo);
                    //Aplica el descuento del 5% y lo muestra en pantalla
                    MessageBox.Show("Descuento 5% " + (precio -= precio * 0.05).ToString()); //Transforma el resultado en un string para mostrar 
                    cliente.agregarMillas(millas, cliente.idSeccionActual); //Pasa las millas al metodo agregarMillas para llevar el conteo dependiendo del cliente
                    avion.inactivarAsiento(asiento); //Inactiva el asiento seleccionado del avion llamando el metodo inactivarAsiento 

                }//Fin de el cliente PLATINO

                //Si no / SI es PLATINO Evalua si es DIAMANTE
                else if (cliente.tipoClienteSeccionActual.Equals("diamante")) //Revisa en el metodo tipoClienteSeccionActual de que tipo es el cliente de la base de datos
                {
                    tiquete nuevo = new tiquete(fecha, cliente.idSeccionActual);
                    nuevo.ingresarTiquete(nuevo);
                    //Aplica el descuento del 10% y lo muestra en pantalla
                    MessageBox.Show("Descuento 10% " + (precio -= precio * 0.10).ToString()); //Transforma el resultado en un string para mostrar en pantalla
                    cliente.agregarMillas(millas, cliente.idSeccionActual); //Pasa las millas al metodo agregarMillas para llevar el conteo dependiendo del cliente
                    avion.inactivarAsiento(asiento); //Inactiva el asiento seleccionado del avion llamando el metodo inactivarAsiento 
                
                } //Fin del else if / de el cliente DIAMANTE

                //SI NO Evalua el Cliente que es gratuito ingresando solo los datos
                else
                {
                    MessageBox.Show(asiento.ToString()); //Pasa el asiento a tipo string y los muestra en el mensaje
                    tiquete nuevo = new tiquete(fecha, cliente.idSeccionActual); //Ingresa la fecha seleccionada del metodo idSeccionActual al objeto "nuevo" de la instancia de tiquete
                    nuevo.ingresarTiquete(nuevo);
                    cliente.agregarMillas(millas, cliente.idSeccionActual); //Pasa las millas al metodo agregarMillas para llevar el conteo
                    avion.inactivarAsiento(asiento); //Inactiva el asiento seleccionado del avion llamando el metodo inactivarAsiento 
                    MessageBox.Show("Su compra a sido exitosa. Gracias por preferirnos."); //Muestra el mensaje final de que la compra es exitosa
                } //fin else
            } //Fin del try
            
            catch(Exception ex ) //Captura algun problema con los campos
            {
                MessageBox.Show("Verifique las opciones que se encuentran vacias."); //Muestra en pantalla si un campo esta vacio
            } //Fin del Catch  
            
            comboBox1.Items.Clear(); //Limpia el comboBox
            comboBox1.ResetText(); //
            llenarComboBox(idVuelo); //Llena el comboBox de el idVuelo
            
        } //Fin del boton de Ingresar tiquete
       
        //Boton de Dollares para cambiar el valor de el Label (etiqueta) de $$$ cuando se cambia el valor del vuelo y lo deja en $$
        private void rbDolares_Click(object sender, EventArgs e)
        {
            //Transforma de colones a dolares
            precio = moneda.colonesToDollars(Double.Parse(label2.Text)); //Llama al metodo "colonesToDollars" de la clase moneda
            label2.Text = precio.ToString(); //El texto del valor de Precio (anterior) lo pasa a un string para asignarlo a el label (etiqueta) que esta en el form
            rbColones.Enabled = true; //Si no se selecciona colones no lo habilita
            rbDolares.Enabled = false; //Si se selecciona la opcion $$ muetra el precio en el Label2 osea la que sale en el form asi $$$
        }//Fin de la ejecucion del Boton o check de Dollares

        //Boton de Colones para cambiar el valor de el Label (etiqueta) de $$$ cuando se cambia el valor del vuelo y lo deja en colones
        private void rbColones_Click(object sender, EventArgs e)
        {
            //Transforma de dollares a colones
            precio = moneda.dollarsTocolones(Double.Parse(label2.Text)); //Llama al metodo "dollarsTocolones" de la clase moneda
            label2.Text = precio.ToString(); //El texto del valor de Precio (anterior) lo pasa a un string para asignarlo a el label (etiqueta) que esta en el form
            rbDolares.Enabled = true; //Si no se selecciona dolares no lo habilita
            rbColones.Enabled = false; //Si se selecciona la opcion colones muetra el precio en el Label2 en colones
        }//Fin de la ejecucion del Boton o check colones

        //Boton con la imagen de lupa que ejecuta el llenado de los datos en el "DataGridView" de los vuelos 
        private void button1_Click(object sender, EventArgs e)
        {
            actualizarDataGridCriterio(); //LLamado del metodo para la busqueda de los buelos
        } //Fin del boton de lupa

        //Boton para realizar la reservacion
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("seleccione el asiento");

            }
            else
            {
                DataGridViewRow fila = dgvVuelos.CurrentRow; //Toma la fila del DataGridView (Lista de Vuelos) y lo guarda en fila
                int asiento = Convert.ToInt32(comboBox1.Text); //Toma el valor del Asiento seleccionado del comboBox y lo guarda en la variable asiento
                avion.reservarAsiento(asiento); //Llama al metodo "reservarAsiento" de la clase avion donde se ejecuta un SP para insertar los datos del id del Asiento
                MessageBox.Show("El Asiento con el número: " + asiento + " ha sido reservado."); //Mensaje que se muestra cuando se aparta un asiento de la BD
            }
            
        
        } //Fin del Boton para la reservacion

        //Boton de Salida
        private void button10_Click(object sender, EventArgs e)
        {
            //Cierra la aplicacion
            Application.Exit();
        
        } //Fin del boton de salida

        private void button11_Click(object sender, EventArgs e)
        {
            FormInicio inicio = new FormInicio(); //Instancia el form de Inicio
            this.Hide(); //Oculta la pantalla y retorna a la anterior
            inicio.Show(); //Muestra la pantalla de inicio luego de oprimir el boton volver

        } //Fin de el boton volver

        private void dgvVuelos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            formTiquetes nuevo = new formTiquetes();
            nuevo.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataGridViewRow fila = dgvVuelos.CurrentRow; //Retorna la fila selecciona del DataGridView (Lista de Vuelos)
            origen = fila.Cells[2].Value.ToString(); //Guarda el valor del DataGridView (Lista de Vuelos) de la posicion 2 en la variablie Origen
            destino = fila.Cells[3].Value.ToString(); //Guarda el destino del DataGridView (Lista de Vuelos) de la posicion 3 en la variable destino

            trayectoria t = new trayectoria(origen, destino);
            t.Show();
        }
    }//Fin del formEdicionVoletos
}//Fin del Project
