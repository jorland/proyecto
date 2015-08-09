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

namespace project
{
    [Table(Name = "[AEROLINEA_UAM].[dbo].[ASIENTO]")]
    class TablaAsientos
    {

        [Column(Name = "ID_ASIENTO", IsPrimaryKey = true)]
        public int ID_ASIENTO { get; set; }

        [Column]
        public int CONS_ASIENTO { get; set; }

        [Column]
        public int ID_AVION { get; set; }

        [Column]
        public string ESTADO { get; set; }

        [Column]
        public int ID_VUELO { get; set; }
    }
}
