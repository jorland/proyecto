using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

/////////////////////////////////////COMENTARIOS DEL CODIGO///////////////////////////////////////////
//Fecha de creacion: 27-06-2015                                                                     //   
//Creado por: Johana                                                                                //
//Descripcion: Clase base de tiquetes, retorno de variables,                                        //
//Fecha de Modificacion: 04-07-2015                                                                 //
//Modificado por: johana                                                                            //
//Descripcion: Store Procedure "PRDB_INGRESA_TIQUETE" para el ingreso de tiquetes                   //
//Fecha de Modificacion: 06-07-2015                                                                 //
//Modificado por: Jorland                                                                           //
//Descripcion: Select para a la base de datos en el metodo verTiquetes()                            //
//                                                                                                  //
//////////////////////////////////////////////////////////////////////////////////////////////////////

namespace project
{
    class tiquete
    {
        //Variables
        private string fecha;
        private int idCliente;

        //Metodo constructor que retorna las variables anteriores
        public tiquete(string fecha, int idCliente )
        {
            this.fecha=fecha;
            this.idCliente = idCliente;
        }

        public void ingresarTiquete(tiquete t)
        {
            //Instancia de la clase myConnection para utilizar la base de datos
            myConnection mc = new myConnection();
            SqlConnection cnn = mc.createConnection();
            SqlCommand command = mc.createCommand(cnn);

            //Utiliza el Store Procedure de ingreso de tiquetes
            command.CommandText = "PRDB_INGRESA_TIQUETE";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@pFechaVuelo ", t.fecha); //Campo de la BD del SP
            command.Parameters.AddWithValue("@pIdCliente", t.idCliente); //Campo de la BD del SP
            cnn.Open(); //Abre la conexion a la BD
            command.ExecuteNonQuery(); //Ejecuta la busqueda de la BD
            cnn.Close(); //Cierra la consulta a la BD
        }

        //Metodo para visualizar los tiquetes
        public static SqlDataAdapter verTiquetesCriterio(int id_cliente)
        {
            //Instancia de la clase myConnection para utilizar la base de datos
            myConnection myConnection = new myConnection(); 
            string consulta = string.Format("select * from TICKET where ID_CLIENTE = {0} ",id_cliente); //Se declara una variable de tipo String consulta que va a guardar un Select de SQL con la informacion de tiquete
            SqlConnection conexion = myConnection.createConnection(); //Guarda la conexion a la BD en el objeto "conexion"
            SqlDataAdapter da = new SqlDataAdapter(consulta, conexion); //Guarda el select y el objeto conexion en el objeto "da"
            
            return da; //Retorna el objeto da con la informacion del select y la conexion a la BD

        } //Fin de verTiquetes

    } //Fin de la Clase Tiquete
} //Fin del project
