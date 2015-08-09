using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Linq.Mapping;
using System.Data.Linq.SqlClient;
using System.Data.Linq;

//NO BORRAR HASTA QUE SE REALICEN PRUEBAS PARA VALIDAR QUE ESTE FUNCIONANDO DE ACUERDO AL CODIGO ANTERIOR
/////////////////////////////////////COMENTARIOS DEL CODIGO///////////////////////////////////////////
//Fecha de creacion: 20-06-2015                                                                     //   
//Creado por: Everson                                                                               //
//Descripcion: Clase base de vuelos variables, retorno de variables,                                //
//Fecha de Modificacion: 27-06-2015                                                                 //
//Modificado por: Everson                                                                           //
//Descripcion: Store Procedure PRDB_OBT_CANTIDAD_ASIENTOS_DISPONIBLES, PRDB_NUEVO_VUELO             //
//Fecha de Modificacion: 28-06-2015                                                                 //
//Modificado por: Everson                                                                           //
//Descripcion: Consultas a la base de datos verVuelos para refrescar y completar el datagridview    //
//Fecha de Modificacion: 07-07-2015                                                                 //
//Modificado por: jorland                                                                           //
//Descripcion: editado metodo agregarVuelo                                                          //
//Fecha de creacion: 08-08-2015                                                                     //   
//Creado por: Everson                                                                               //
//Descripcion: se mapeo las columnas por medio de LINQ, se modificaron los metodos cambiando los    //
//SP por la nueva logica                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////

namespace project
{
    [Table(Name = "[AEROLINEA_UAM].[dbo].[VUELO]")]
    class Vuelo
    {

        [Column(Name = "ID_VUELO", IsPrimaryKey = true)]
        public int ID_VUELO { get; set; }

        [Column]
        public float MILLAS { get; set; }

        [Column]
        public string ORIGEN { get; set; }

        [Column]
        public string DESTINO { get; set; }

        [Column]
        public string FECHA { get; set; }

        [Column]
        public int ID_TICKET { get; set; }

        [Column]
        public int ID_AVION { get; set; }

        [Column]
        public float PRECIO_DOLARES { get; set; }

        ////Variables
        //private int idVuelo;
        //private int idAvion;
        //private int millas;
        //private string origen;
        //private string destino;
        //private string fechaVuelo;
        //private float precioDolares;

        //public int IdVuelo
        //{
        //    get { return idVuelo; }
        //    set { this.idVuelo = value; }
        //}

        //public int Millas
        //{
        //    get { return millas; }
        //    set { this.millas = value; }
        //}

        //public string Origen
        //{
        //    get { return origen; }
        //    set { origen = value; }
        //}

        //public string Destino
        //{
        //    get { return destino; }
        //    set { destino = value; }
        //}

        //public string FechaVuelo
        //{
        //    get { return fechaVuelo; }
        //    set { this.fechaVuelo = value; }
        //}

        ////Constructor por defecto cuyo caso el objeto será iniciado con los valores predeterminados por el sistema
        //public Vuelo() { }

        ////Constructor que retorno las variables
        //public Vuelo(int vidVuelo, int vidAvion, int vmillas, string vorigen, string vdestino, string vfechaVuelo, float precioDolares)
        //{
        //    this.idVuelo = vidVuelo;
        //    this.idAvion = vidAvion;
        //    this.millas = vmillas;
        //    this.origen = vorigen;
        //    this.destino = vdestino;
        //    this.fechaVuelo = vfechaVuelo;
        //    this.precioDolares = precioDolares;

        //}

        //Metodo para obtener los asientos
        public static int cantAsientos(int id)
        {
            //int cant = 0;

            ////Instancia de la clase myConnection para utilizar la base de datos
            //myConnection myConnection = new myConnection();
            //SqlConnection conexion = myConnection.createConnection();
            //SqlCommand comando = myConnection.createCommand(conexion);
            ////Lectura de la BD
            //SqlDataReader dr;

            ////Utiliza el SP
            //comando.CommandText = "PRDB_OBT_CANTIDAD_ASIENTOS_DISPONIBLES";
            //comando.CommandType = CommandType.StoredProcedure;
            //comando.Parameters.AddWithValue("@pIDVUELO", id);

            DataContext dc = new DataContext(myConnection.getConnection());
            var cantidadAsientos =
            from asiento in dc.GetTable<TablaAsientos>()
            where asiento.ESTADO.Equals("D") && asiento.ID_VUELO.Equals(id)
            select asiento;

            return cantidadAsientos.Count();

            ////Abre la conexion con la BD
            //conexion.Open();

            ////Lee datos en BD
            //dr = comando.ExecuteReader();

            ////Lee los asientos y retorna el valor
            //if (dr.Read())
            //{
            //    cant = Convert.ToInt32(dr.GetValue(0));
            //}

            ////Cierra la conexion
            //conexion.Close();

            ////retorna el valor de los asientos en la variable cant
            //return cant;
        }//Fin de cantAsientos

        //Metodo de retorna los vuelos por medio de una sentencia de sql
        public static IQueryable<Vuelo> verVuelos()
        {
            ////Instancia de la clase myConnection para utilizar la base de datos
            //myConnection myConnection = new myConnection();
            //string consulta = "select * from VUELO"; //Ingresa el select de la base de datos a una variable de tipo string
            //SqlConnection conexion = myConnection.createConnection(); //Crea la connexion a la BD
            //SqlDataAdapter da = new SqlDataAdapter(consulta, conexion); //Transfiere los datos
            //return da; //retorna la variable llena al string

            DataContext dc = new DataContext(myConnection.getConnection());
            var verTodos =
            from vuelo in dc.GetTable<Vuelo>()
            select vuelo;

            return verTodos;
        }//Fin de verVuelos

        //Metodo para realizar la conexion y la sentencia de SQL
        public static IQueryable<Vuelo> verVuelos(string pais)
        {
            ////Instancia de la clase myConnection para utilizar la base de datos
            //myConnection myConnection = new myConnection();
            //string consulta = String.Format("select * from VUELO WHERE DESTINO = '{0}'", pais); //Ingresa el select de la base de datos a una variable de tipo string con los nombres del pais
            //SqlConnection conexion = myConnection.createConnection(); //Crea la connexion a la BD
            //SqlDataAdapter da = new SqlDataAdapter(consulta, conexion); //Transfiere los datos
            //return da; //retorna la variable llena al string

            DataContext dc = new DataContext(myConnection.getConnection());
            var ver =
            from vuelo in dc.GetTable<Vuelo>()
            where vuelo.DESTINO.Equals(pais)
            select vuelo;

            return ver;

        }


        //Metodo para la comunicacion con la BD y llamar al SP
        public static void Agregar(int idvuelo, string origen, string destino, float millas, string fecha, int idavion, float precioDolar)
        {
            DataContext dc = new DataContext(myConnection.getConnection());
            var Customers = dc.GetTable<Vuelo>();

            var insert = dc.GetTable<Vuelo>();

            Vuelo newInsert = new Vuelo { ID_VUELO = idvuelo, ORIGEN = origen, DESTINO = destino, MILLAS = millas, FECHA = fecha, ID_AVION = idavion, PRECIO_DOLARES = precioDolar };
            insert.InsertOnSubmit(newInsert);
            dc.SubmitChanges();

        }//Fin de agregar vuelo
    } //Fin de la clase Vuelo
} //Fin del Proyecto