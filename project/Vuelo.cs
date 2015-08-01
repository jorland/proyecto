using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


/////////////////////////////////////COMENTARIOS DEL CODIGO///////////////////////////////////////////
//Fecha de creacion: 20-06-2015                                                                     //   
//Creado por: Everson                                                                               //
//Descripcion: Clase base de vuelos variables, retorno de variables,                                //
//Fecha de Modificacion: 27-06-2015                                                                 //
//Modificado por: Everson                                                                           //
//Descripcion: Store Procedure PRDB_OBT_CANTIDAD_ASIENTOS_DISPONIBLES, PRDB_NUEVO_VUELO             //
//Fecha de Modificacion: 28-06-2015                                                                 //
//Modificado por: Everson                                                                           //
//Descripcion: Consultas a la base de datos verVuelos para refrescar y completar el datagridview    //                                    //
//Fecha de Modificacion: 07-07-2015                                                                 //
//Modificado por: jorland                                                                           //
//Descripcion: editado metodo agregarVuelo                                                          //
//////////////////////////////////////////////////////////////////////////////////////////////////////

namespace project
{
    class Vuelo
    {
        //Variables
        //prueba git
        private int idVuelo;
        private int idAvion;
        private int millas;
        private string origen;
        private string destino;
        private string fechaVuelo;
        private float precioDolares;

        public int IdVuelo
        {
            get { return idVuelo; }
            set { this.idVuelo = value; }
        }

        public int Millas
        {
            get { return millas; }
            set { this.millas = value; }
        }

        public string Origen
        {
            get { return origen; }
            set { origen = value; }
        }

        public string Destino
        {
            get { return destino; }
            set { destino = value; }
        }

        public string FechaVuelo
        {
            get { return fechaVuelo; }
            set { this.fechaVuelo = value; }
        }

        //Constructor por defecto cuyo caso el objeto será iniciado con los valores predeterminados por el sistema
        public Vuelo() { }

        //Constructor que retorno las variables
        public Vuelo(int vidVuelo, int vidAvion, int vmillas, string vorigen, string vdestino, string vfechaVuelo, float precioDolares)
        {
            this.idVuelo = vidVuelo;
            this.idAvion = vidAvion;
            this.millas = vmillas;
            this.origen = vorigen;
            this.destino = vdestino;
            this.fechaVuelo = vfechaVuelo;
            this.precioDolares = precioDolares;

        }

        //Metodo para obtener los asientos
        public static int cantAsientos(int id)
        {
            int cant = 0;

            //Instancia de la clase myConnection para utilizar la base de datos
            myConnection myConnection = new myConnection();
            SqlConnection conexion = myConnection.createConnection();
            SqlCommand comando = myConnection.createCommand(conexion);
            //Lectura de la BD
            SqlDataReader dr;

            //Utiliza el SP
            comando.CommandText = "PRDB_OBT_CANTIDAD_ASIENTOS_DISPONIBLES";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@pIDVUELO", id);
            
            //Abre la conexion con la BD
            conexion.Open();

            //Lee datos en BD
            dr = comando.ExecuteReader();
            
            //Lee los asientos y retorna el valor
            if (dr.Read())
            {
                cant = Convert.ToInt32(dr.GetValue(0));
            }

            //Cierra la conexion
            conexion.Close();

            //retorna el valor de los asientos en la variable cant
            return cant;
        }//Fin de cantAsientos

        //Metodo de retorna los vuelos por medio de una sentencia de sql
        public static SqlDataAdapter verVuelos()
        {
            //Instancia de la clase myConnection para utilizar la base de datos
            myConnection myConnection = new myConnection();
            string consulta = "select * from VUELO"; //Ingresa el select de la base de datos a una variable de tipo string
            SqlConnection conexion = myConnection.createConnection(); //Crea la connexion a la BD
            SqlDataAdapter da = new SqlDataAdapter(consulta, conexion); //Transfiere los datos
            return da; //retorna la variable llena al string
        }//Fin de verVuelos

        //Metodo para realizar la conexion y la sentencia de SQL
        public static SqlDataAdapter verVuelos(string pais)
        {
            //Instancia de la clase myConnection para utilizar la base de datos
            myConnection myConnection = new myConnection();
            string consulta = String.Format("select * from VUELO WHERE DESTINO = '{0}'", pais); //Ingresa el select de la base de datos a una variable de tipo string con los nombres del pais
            SqlConnection conexion = myConnection.createConnection(); //Crea la connexion a la BD
            SqlDataAdapter da = new SqlDataAdapter(consulta, conexion); //Transfiere los datos
            return da; //retorna la variable llena al string

        }
       

        //Metodo para la comunicacion con la BD y llamar al SP
        public void Agregar(Vuelo vuelo)
        {
            //Instancia de la clase myConnection para utilizar la base de datos
            myConnection coneccion = new myConnection();
            SqlConnection cnn = coneccion.createConnection();
            SqlCommand command = coneccion.createCommand(cnn);
            cnn.Open(); //Abre la comunicacion con la BD

            //Invoca al SP
            command.CommandText = "PRDB_NUEVO_VUELO";
            command.CommandType = CommandType.StoredProcedure;
            //Agrega los campos a la base de datos por medio del SP
            command.Parameters.AddWithValue("@pIDVuelo", vuelo.IdVuelo); //Campo de la BD
            command.Parameters.AddWithValue("@pOrigenVuelo", vuelo.Origen); //Campo de la BD
            command.Parameters.AddWithValue("@pDestinoVuelo", vuelo.Destino); //Campo de la BD
            command.Parameters.AddWithValue("@pMillasVuelo", vuelo.Millas); //Campo de la BD
            command.Parameters.AddWithValue("@pFechaVuelo", vuelo.FechaVuelo); //Campo de la BD
            command.Parameters.AddWithValue("@pID_AVION", vuelo.idAvion); //Campo de la BD
            command.Parameters.AddWithValue("@pPrecioDolares", vuelo.precioDolares); //Campo de la BD
             //Retorna el query
            command.ExecuteNonQuery();
            //cierra la consulta
            cnn.Close();

        }//Fin de agregar vuelo
    } //Fin de la clase Vuelo
} //Fin del Proyecto