using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Data.Linq.Mapping;


/////////////////////////////////////COMENTARIOS DEL CODIGO///////////////////////////////////////////
//Fecha de creacion: 27-06-2015                                                                     //   
//Creado por: jorland                                                                                //
//Descripcion: metodos verClientes,inactivarCliente,guardarCliente,ingresar millas,login,privilegio    //
//Fecha de Modificacion: 04-07-2015                                                                 //
//Modificado por: jorland                                                                            //
// Descripcion: modificaciones de codigo en los metodos para hacerlos mas generales
//Fecha de creacion: 7-08-2015                                                                      
//Creado por: jorland                                                                                
//Descripcion: integracion linq 
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

        private DataContext dataContext = new DataContext(myConnection.getConnection());

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
        public static IQueryable<tablaCliente> verClientes(string condicion)
        {

            DataContext dataContext = new DataContext(myConnection.getConnection());
            var tabla = dataContext.GetTable<tablaCliente>();

            var clientes = from c in tabla
                           where c.CEDULA.Equals(condicion) || c.NOMBRE.Equals(condicion)
                           select c;

            return clientes;
        }

        //inactiva cliente con criterios
        public static void inactivarCliente(int id,string estado)
        {

            DataContext dataContext = new DataContext(myConnection.getConnection());
            var tabla = dataContext.GetTable<tablaCliente>();

            var cliente = from c in tabla
                          where c.ID_CLIENTE.Equals(id)
                          select c;

            foreach (var c in cliente)
            {
                c.CONDICION = estado;
            }

            dataContext.SubmitChanges();

        }

        //le suma millas al usuario
        public static void agregarMillas(int millas,int idCliente)
        {

            DataContext dataContext = new DataContext(myConnection.getConnection());
            var tabla = dataContext.GetTable<tablaCliente>();

            var cliente = from c in tabla
                          where c.ID_CLIENTE.Equals(idCliente)
                          select c;

            foreach (var c in cliente)
            {
                c.MILLAS += millas;
            }

            dataContext.SubmitChanges();

        }


        //guarda el cliete en la base de datos
        public  void guardarCliente()
        {
            var tabla = dataContext.GetTable<tablaCliente>();
            tablaCliente nuevo = new tablaCliente {CEDULA=this.cedula,NOMBRE=this.nombre,APELLIDO1=this.primerApellido,APELLIDO2=this.segundoApellido,CONTRASENA=this.contrasena,TIPO=this.tipoCliente,PRIVILEGIO=this.privilegio,CONDICION="activo",MILLAS=0};
            tabla.InsertOnSubmit(nuevo);
            dataContext.SubmitChanges();
        }


        //verifica si el usuario existe en el base
        public static Boolean login(string usuario, string contra)
        {
            bool encontrado = false;


            DataContext dataContext = new DataContext(myConnection.getConnection());
            var tabla = dataContext.GetTable<tablaCliente>();

            var buscar = from c in tabla
                         where c.NOMBRE.Equals(usuario) && c.CONTRASENA.Equals(contra)
                         select c;

            foreach (var cuenta in buscar)
	{
        encontrado = true;
        nombreSeccionActual = cuenta.NOMBRE;
        idSeccionActual = cuenta.ID_CLIENTE;
        tipoClienteSeccionActual = cuenta.PRIVILEGIO;
		 
	}

            return encontrado;
        }


        //retorna si es un cliente o un adm
        public static string getPrivilegio(string usuario, string contra)
        {
            
            string salida = null;

            DataContext dataContext = new DataContext(myConnection.getConnection());
            var tabla = dataContext.GetTable<tablaCliente>();

            var cliente = from c in tabla
                          where c.NOMBRE.Equals(usuario) && c.CONTRASENA.Equals(contra)
                          select c;

            foreach (var c in cliente)
            {
                salida = c.PRIVILEGIO;
            }

            return salida;


        }

        public static Boolean estaInactivo(string usuario, string contra)
        {

            bool condicion = false;


            DataContext dataContext = new DataContext(myConnection.getConnection());
            var tabla = dataContext.GetTable<tablaCliente>();

            var buscar = from c in tabla
                         where c.NOMBRE.Equals(usuario) && c.CONTRASENA.Equals(contra)
                         select c;

            foreach (var cuenta in buscar)
            {
                if (cuenta.CONDICION.Equals("inactivo"))
                {
                    condicion = true; 
                }

            }

            return condicion;

        }

        public  Boolean clienteDuplicado(){
            Boolean salida = false;
            var tabla = dataContext.GetTable<tablaCliente>();
            var clientes = from c in tabla
                           where c.CEDULA.Equals(this.cedula)
                           select new {ced = c.CEDULA };
            foreach (var item in clientes)
            {
                salida = true;
            }
            return salida;
        }

        //retorna un SqlDataAdapter con todos los clientes
        public static IQueryable<tablaCliente> verClientes()
        {

            DataContext dataContext = new DataContext(myConnection.getConnection());
            var tabla = dataContext.GetTable<tablaCliente>();
            var clientes = from c in tabla
                           select c;
            return clientes;


        }

    }
}
