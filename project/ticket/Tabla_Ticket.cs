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
    [Table(Name = "[AEROLINEA_UAM].[dbo].[TICKET]")]
    class Tabla_Ticket
    {
        [Column(Name = "ID_TICKET", IsPrimaryKey = true, DbType = "Int NOT NULL", IsDbGenerated = true)]
        public int ID_TICKET { set; get; }

        [Column(Name = "FEC_VUELO", DbType = "varchar NULL")]
        public string FEC_VUELO { set; get; }

        [Column(Name = "FEC_COMPRA", DbType = "varchar NULL")]
        public string FEC_COMPRA { set; get; }

        [Column(Name = "ID_CLIENTE", DbType = "int NULL")]
        public int ID_CLIENTE { set; get; }
    }
}
