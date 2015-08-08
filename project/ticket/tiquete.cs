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
//Creado por: Johana                                                                                //
//Descripcion: Clase base de tiquetes, retorno de variables,                                        //
//Fecha de Modificacion: 04-07-2015                                                                 //
//Modificado por: johana                                                                            //
//Descripcion: Store Procedure "PRDB_INGRESA_TIQUETE" para el ingreso de tiquetes                   //
//Fecha de Modificacion: 06-07-2015                                                                 //
//Modificado por: Jorland                                                                           //
//Descripcion: Select para a la base de datos en el metodo verTiquetes()                            //
//Fecha de Modificacion: 08/08/2015                                                                 //
//Modificado por: Johana y Allan                                                                    //
//Descripcion: Eliminacion de SP y cambio a uso de Linq                                             //
//                                                                                                  //
//////////////////////////////////////////////////////////////////////////////////////////////////////

namespace project
{
    class tiquete
    {
        //Variables
        private string fecha;
        private int idCliente;

        static DataContext DC = new DataContext(myConnection.getConnection());

        //Metodo constructor que retorna las variables anteriores
        public tiquete(string fecha, int idCliente )
        {
            this.fecha=fecha;
            this.idCliente = idCliente;
        }

        public void ingresarTiquete(tiquete t)
        {
                       
            //Utiliza Linq para el ingreso de nuevos ticketes*/

            var newTicket = DC.GetTable<Tabla_Ticket>();//Variable newTicket que almacena la Tabla Tiquete
            Tabla_Ticket tckt = new Tabla_Ticket();//variable tckt nueva instancia de la clase Tabla_Ticket

            tckt.FEC_VUELO = t.fecha;//Asigna al prooperty FEC_VUELO de la clase Tabla_Ticket el valor de la fecha del tiquete
            tckt.FEC_COMPRA = DateTime.Now.ToString();//Asigna al prooperty FEC_COMPRA de la clase Tabla_Ticket el valor de la fecha del sistema
            tckt.ID_CLIENTE = t.idCliente;//Asigna al prooperty ID_CLIENTE de la clase Tabla_Ticket el valor de la fecha del idCliente

            newTicket.InsertOnSubmit(tckt);//Inserta los valores en la Base de Datos
            DC.SubmitChanges();//Realiza el commita de la Base de Datos.

        }

        //Metodo para visualizar los tiquetes
        public static IQueryable<Tabla_Ticket> verTiquetesCriterio(int id_cliente)
        {

            var consTicket = DC.GetTable<Tabla_Ticket>();//Variable newTicket que almacena la Tabla Tiquete

            var query = from Tik in consTicket
                        where Tik.ID_CLIENTE.Equals(id_cliente)
                        //Selecciona todos los datos de la tabla Tabla_Ticket donde el ID_Cliente sea igual al Id_cliente enviado por parametros
                        //Y almacena el valor en la variable query
                        select Tik;


            return query; //Retorna el resultado de la consulta, para mostrarlo en el datagrid.

        } //Fin de verTiquetes

    } //Fin de la Clase Tiquete
} //Fin del project
