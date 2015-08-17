using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Data.Linq.Mapping;


namespace project
{
    class avion
    {

        public static DataContext dc = new DataContext(myConnection.getConnection());
        
        public static IQueryable<tablaAvion> verAvionesCriterio(int criterio)
        {
            //DataContext dc = new DataContext(myConnection.getConnection());
            var verAvionesCriterio = dc.GetTable<tablaAvion>();
            var ver = from a in verAvionesCriterio
                      where a.ID_AVION.Equals(criterio)
                      select a;

            return ver;
        }

        public static IQueryable<TablaAsientos> verAsientos()
        {
            DataContext dc = new DataContext(myConnection.getConnection());
            var tabla = dc.GetTable<TablaAsientos>();
            var asientos = from a in tabla
                            select a;

            return asientos;

        }

        public static IQueryable<tablaAvion> verAsientosCriterio(int idAvion)
        {
            DataContext dc = new DataContext(myConnection.getConnection());
            var verAvionesCriterio = dc.GetTable<tablaAvion>();
            var ver = from a in verAvionesCriterio
                      where a.ID_AVION.Equals(idAvion)
                      select a;
            return ver;

        }
              

        public static IQueryable<tablaAvion> verAviones()
        {
            DataContext dc = new DataContext(myConnection.getConnection());
            var verAviones = dc.GetTable<tablaAvion>();
            var ver = from a in verAviones
                      select a;
            return ver;

        }

        public static void guardarAvion(string NOMBRE_AVION, int asientos)
        {
            DataContext dc = new DataContext(myConnection.getConnection());
            var table = dc.GetTable<tablaAvion>();
            tablaAvion nuevo = new tablaAvion {NOMBRE_AVION=NOMBRE_AVION,ESTADO="D"};
            table.InsertOnSubmit(nuevo);
            dc.SubmitChanges();
            crearAsientos(asientos);

        }

        public static void crearAsientos(int nAsientos){
             DataContext dc = new DataContext(myConnection.getConnection());
             var table = dc.GetTable<TablaAsientos>();

            for (int i = 0; i < nAsientos; i++)
			{
			   TablaAsientos asiento = new TablaAsientos{CONS_ASIENTO=i,ESTADO="D",ID_AVION=ultimoAvion()};
                table.InsertOnSubmit(asiento);
                dc.SubmitChanges();
			}

        }

            public static int ultimoAvion(){

                int id = 0;

                var table = dc.GetTable<tablaAvion>();

                var avion = (from a in table
                              orderby a.ID_AVION descending
                              select a.ID_AVION).Take(1);

                foreach (var a in avion)
                {
                    if (a.Equals(0))
                    {
                        id = 1;
                    }
                    else
                    {
                        id = a;
                    }
                }

                return id;
            }

            public static void eliminarAvion(int id)
            {
                //DataContext dc = new DataContext(myConnection.getConnection());
                var elimina = dc.GetTable<tablaAvion>();
                var aviones = from a in elimina
                              where a.ID_AVION.Equals(id)
                              select a;
                foreach (var item in aviones)
                {
                    elimina.DeleteOnSubmit(item);
                    dc.SubmitChanges();
                }
                         

            }

            public static void inactivarAsiento(int idAsiento)
            {

                var tabla = dc.GetTable<TablaAsientos>();
                var asientos = from a in tabla
                              where a.ID_ASIENTO.Equals(idAsiento)
                              select a;

                foreach (var a in asientos)
                {
                    a.ESTADO = "N";
                    
                }

            }

            public static void reservarAsiento(int idAsiento)
            {
                var tabla = dc.GetTable<TablaAsientos>();
                var asientos = from a in tabla
                               where a.ID_ASIENTO.Equals(idAsiento)
                               select a;

                foreach (var a in asientos)
                {
                    a.ESTADO = "R";

                }
            }

            public static void cambiarEstado(int id)
            {
                var tabla = dc.GetTable<tablaAvion>();
                var aviones = from a in tabla
                            where a.ID_AVION.Equals(id)
                            select a;

                foreach (var avion in aviones)
                {
                    if (avion.ESTADO.Equals("D"))
                    {
                        avion.ESTADO = "N";
                    }
                    else
                    {
                        avion.ESTADO = "D";
                    }
                }
            }
            //nuevo
            public static string estadoAvion(int id)
            {
                string estado = "";

                var tabla = dc.GetTable<tablaAvion>();
                var avion = from a in tabla
                            where a.ID_AVION.Equals(id)
                            select a.ESTADO;

                foreach (var item in avion)
                {
                    estado = item;
                }
                return estado;
            }

        
       

    }
}