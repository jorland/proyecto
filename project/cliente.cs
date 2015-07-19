using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


/////////////////////////////////////COMENTARIOS DEL CODIGO///////////////////////////////////////////
//Fecha de creacion: 27-06-2015                                                                     //   
//Creado por: jorland                                                                                //
//Descripcion: metodos verClientes,inactivarCliente,guardarCliente,ingresar millas,login,privilegio    //
//Fecha de Modificacion: 04-07-2015                                                                 //
//Modificado por: jorland                                                                            //
// Descripcion: modificaciones de codigo en los metodos para hacerlos mas generales
//////////////////////////////////////////////////////////////////////////////////////////////////////

namespace project
{
    abstract class cliente
    {

        private string nombre;
        private string primerApellido;
        private string segundoApellido;
        private string cedula;
        private string contrasena;
        private int totalMillas;
        private Boolean condicion;
        private string tipoCliente;
        private string privilegio;
        public static string nombreSeccionActual;
        public static int idSeccionActual;
        public static string tipoClienteSeccionActual;

       

        public string TipoCliente
        {
            get { return tipoCliente; }
            set { tipoCliente = value; }
        }

        public Boolean Condicion
        {
            get { return condicion; }
            set { condicion = value; }
        }


        public int TotalMillas
        {
            get { return totalMillas; }
            set { totalMillas = value; }
        }


        public string Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }


        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }



        public cliente(string cedula, string nombre, string primerApellido, string segundoApellido, string contrasena, string tipoCliente, string privilegio)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
            this.contrasena = contrasena;
            this.tipoCliente = tipoCliente;
            this.privilegio = privilegio;
        }

        //retorna un SqlDataAdapter que contiene los usuarios filtrados
        public static SqlDataAdapter verClientes(string condicion)
        {
            myConnection myConnection = new myConnection();
            string consulta = String.Format("select * from CLIENTE WHERE CEDULA = '{0}' OR NOMBRE = '{0}' OR TIPO = '{0}' OR PRIVILEGIO = '{0}' OR CONDICION = '{0}' ", condicion);
            SqlConnection conexion = myConnection.createConnection();
            SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
            return da;

        }

        //inactiva cliente con criterios
        public static void inactivarCliente(int id,string estado)
        {
            myConnection myConnection = new myConnection();
            SqlConnection conexion = myConnection.createConnection();
            SqlCommand comando = myConnection.createCommand(conexion);


            comando.CommandText = "PRDB_CAMBIA_COND_CLIENTE";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@pID_CLIENTE", id);
            comando.Parameters.AddWithValue("@pCONDICION",estado );
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        //le suma millas al usuario
        public static void agregarMillas(int millas,int idCliente)
        {
            myConnection mc = new myConnection();
            SqlConnection cnn = mc.createConnection();
            SqlCommand command = mc.createCommand(cnn);
            command.CommandText = "PRDB_AGREGAR_MILLAS";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@pmillas", millas);
            command.Parameters.AddWithValue("@pID_CLIENTE", idCliente);

            cnn.Open();
            command.ExecuteNonQuery();
            cnn.Close();


        }


        //guarda el cliete en la base de datos
        public void guardarCliente()
        {
            myConnection mc = new myConnection();
            SqlConnection cnn = mc.createConnection();
            SqlCommand command = mc.createCommand(cnn);


            command.CommandText = "PRDB_INGRESAR_CLIENTE";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@pCEDULA ", cedula);
            command.Parameters.AddWithValue("@pNOMBRE", nombre);
            command.Parameters.AddWithValue("@pAPELLIDO1 ", primerApellido);
            command.Parameters.AddWithValue("@pAPELLIDO2 ", segundoApellido);
            command.Parameters.AddWithValue("@pCONTRASENA ", contrasena);
            command.Parameters.AddWithValue("@pTIPO ", tipoCliente);
            command.Parameters.AddWithValue("@pPRIVILEGIO ", privilegio);

            cnn.Open();
            command.ExecuteNonQuery();
            cnn.Close();

        }


        //verifica si el usuario exuste en el base
        public static Boolean login(string usuario, string contra)
        {
            bool encontrado = false;

            myConnection mc = new myConnection();
            SqlConnection cnn = mc.createConnection();
            SqlCommand command = mc.createCommand(cnn);

            command.CommandText = "SELECT NOMBRE,CONTRASENA,CEDULA,TIPO FROM CLIENTE";

            cnn.Open();

            SqlDataReader re = command.ExecuteReader();

            while (re.Read())
            {
                if (re["NOMBRE"].ToString().Equals(usuario) && re["CONTRASENA"].ToString().Equals(contra))
                {
                    encontrado = true;
                    nombreSeccionActual = usuario;
                    idSeccionActual = Convert.ToInt32(re["CEDULA"]);
                    tipoClienteSeccionActual = re["TIPO"].ToString();

                }
            }

            cnn.Close();
            return encontrado;
        }


        //retorna si es un cliente o un adm
        public static string getPrivilegio(string usuario, string contra)
        {
            
            string salida = null;

            myConnection mc = new myConnection();
            SqlConnection cnn = mc.createConnection();
            SqlCommand command = mc.createCommand(cnn);

            command.CommandText = "SELECT NOMBRE,CONTRASENA,PRIVILEGIO FROM CLIENTE";

            cnn.Open();

            SqlDataReader re = command.ExecuteReader();

            while (re.Read())
            {
                if (re["NOMBRE"].ToString().Equals(usuario) && re["CONTRASENA"].ToString().Equals(contra))
                {
                    salida = re["PRIVILEGIO"].ToString();
                }
            }

            cnn.Close();
            return salida;


        }

        //retorna un SqlDataAdapter con todos los clientes
        public static SqlDataAdapter verClientes()
        {
            myConnection myConnection = new myConnection();
            string consulta = "select * from CLIENTE";
            SqlConnection conexion = myConnection.createConnection();
            SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
            return da;

        }

    }
}
