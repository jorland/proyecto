using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace project
{
    class avion
    {
       //ever se la come
        //Jorland se la come tetaRules!!!
        //prueba 0003 vamso almorzar!!!
        private string nombre;
        private int cantAsientos;

        public avion(string nombre,int cantAsientos)
        {
            
            this.nombre = nombre;
            this.cantAsientos = cantAsientos;

        }

        public int CantAsientos
        {
            get { return cantAsientos; }
            set { cantAsientos = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public static SqlDataAdapter verAvionesCriterio(string criterio)
        {
            myConnection myConnection = new myConnection();
            string consulta = String.Format("select * from AVION where NOMBRE_AVION = '{0}' OR ID_AVION = {1}", criterio, Convert.ToInt32(criterio));
            SqlConnection conexion = myConnection.createConnection();
            SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
            return da;
        }

        public static SqlDataAdapter verAsientos()
        {
            myConnection myConnection = new myConnection();
            string consulta = "select * from ASIENTO";
            SqlConnection conexion = myConnection.createConnection();
            SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
            return da;

        }

        public static SqlDataAdapter verAsientosCriterio(int idAvion)
        {
            myConnection myConnection = new myConnection();
            string consulta = String.Format("SELECT * FROM ASIENTO WHERE ID_AVION = {0}",idAvion);
            SqlConnection conexion = myConnection.createConnection();
            SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
            return da;

        }

       

        public static SqlDataAdapter verAviones()
        {
            myConnection myConnection = new myConnection();
            string consulta = "select * from AVION";
            SqlConnection conexion = myConnection.createConnection();
            SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
            return da;

        }

        public static void guardarAvion(avion avion)
        {
            myConnection myConnection = new myConnection();
            SqlConnection conexion = myConnection.createConnection();
            SqlCommand comando = myConnection.createCommand(conexion);

            
                comando.CommandText = "PRDB_INGRESA_NUEVO_AVION";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@pID_AVION", avion.ultimoAvion());//envia por parametro el ultimo Id aumentado en 1
                comando.Parameters.AddWithValue("@pNOMBRE_AVION", avion.nombre);//envia por parametro el nombre capturado en el text
                comando.Parameters.AddWithValue("@pCANT_ASIENTOS", avion.cantAsientos);//envia por parametro la cant de asientos capturado en el text
              
                conexion.Open();//abre 
                comando.ExecuteNonQuery();
                conexion.Close();

        }

            public static int ultimoAvion(){
                myConnection myConnection = new myConnection();
                SqlConnection conexion = myConnection.createConnection();
                SqlCommand comando = myConnection.createCommand(conexion);
                SqlDataReader dr;
                int ultimoId;
                comando.CommandText = "OBT_ULTIMO_AVION_INGRESADO";
                comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();// abre conexion para leer el ultimo Id de avion
                dr=comando.ExecuteReader();

                if (dr.Read())
	            {
		            ultimoId = Convert.ToInt32(dr.GetValue(0))+1;
	            }else
	                {
                        ultimoId = 1;
	                }
                conexion.Close();


                return ultimoId;

            }

            public static void eliminarAvion(int id)
            {
                myConnection myConnection = new myConnection();
                SqlConnection conexion = myConnection.createConnection();
                SqlCommand comando = myConnection.createCommand(conexion);
                SqlDataReader dr;

                comando.CommandText = "PRDB_ELIMINAR_AVION";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@pid_Avion", id);
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }

            public static void inactivarAsiento(int idAsiento)
            {
                myConnection myConnection = new myConnection();
                SqlConnection conexion = myConnection.createConnection();
                SqlCommand comando = myConnection.createCommand(conexion);
                SqlDataReader dr;

                comando.CommandText = "PRDB_N_ASIENTO";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@pID_ASIENTO", idAsiento);
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }

            public static void reservarAsiento(int idAsiento)
            {
                myConnection myConnection = new myConnection();
                SqlConnection conexion = myConnection.createConnection();
                SqlCommand comando = myConnection.createCommand(conexion);
                SqlDataReader dr;

                comando.CommandText = "PRDB_R_ASIENTO";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@pID_ASIENTO", idAsiento);
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }

            public static void cambiarEstado(int id)
            {
                myConnection myConnection = new myConnection();
                SqlConnection conexion = myConnection.createConnection();
                SqlCommand comando = myConnection.createCommand(conexion);
                SqlDataReader dr;
                comando.CommandText = "PRDB_CAMBIO_ESTADO_AVION";
                comando.CommandType = CommandType.StoredProcedure;
                if (estadoAvion(id) == "D")
                {

                    comando.Parameters.AddWithValue("@pID_AVION", id);
                    comando.Parameters.AddWithValue("@pESTADO", "N");
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
                else
                {
                    comando.Parameters.AddWithValue("@pID_AVION", id);
                    comando.Parameters.AddWithValue("@pESTADO", "D");
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            //nuevo
            public static string estadoAvion(int id)
            {
                myConnection myConnection = new myConnection();
                SqlConnection conexion = myConnection.createConnection();
                SqlCommand comando = myConnection.createCommand(conexion);
                SqlDataReader dr;

                comando.CommandText = "PRDB_OBT_ESTADO_AVION";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@pID_AVION", id);
                conexion.Open();
                dr = comando.ExecuteReader();
                string estado = "N";
                if (dr.Read())
                {
                    estado = Convert.ToString(dr.GetValue(0));
                }

                conexion.Close();

                return estado;
            }

        
       

    }
}
