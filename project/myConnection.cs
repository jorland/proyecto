using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace project
{
    class myConnection
    {
        public static string getConnection(){

            string sqlConnection="";
            SqlConnection cnn=null;

            try
            {
                sqlConnection = "Data Source = EQUIPo ;Initial catalog=AEROLINEA_UAM;Integrated Security=SSPI";
                cnn = new SqlConnection(sqlConnection);
                cnn.Open();
            }
            catch (Exception)
            {

                MessageBox.Show("Error al comunicarse con la base de datos");
                cnn.Close();
            }
            return sqlConnection;
            
        }
   
    }
}
