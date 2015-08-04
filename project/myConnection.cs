using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace project
{
    class myConnection
    {
        //static myConnection mc = new myConnection();
        private string sqlConnection = "Data Source = EQUIPO ;Initial catalog=AEROLINEA_UAM;Integrated Security=SSPI";

        //public static SqlConnection  getConnection(){
        //    SqlConnection cnn = mc.createConnection();
        //    return cnn;
        //}

        //public static SqlCommand getCommand()
        //{
        //    SqlCommand command = mc.createCommand(getConnection());
        //    return command;
        //}


        public SqlConnection createConnection()
        {
            SqlConnection connection = new SqlConnection(sqlConnection);
            return connection;
        }

        public SqlCommand createCommand(SqlConnection cnn)
        {
            SqlCommand sqlcommand = new SqlCommand(sqlConnection,cnn);
            return sqlcommand;
        }
    }
}
