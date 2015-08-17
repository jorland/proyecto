using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace project
{
    [Table(Name = "[AEROLINEA_UAM].[dbo].[VUELO]")]
    class tablaVuelo
    {

        [Column(Name = "ID_VUELO", IsPrimaryKey = true, DbType = "int NOT NULL", IsDbGenerated = false)]
        public int? ID_VUELO { get; set; }

        [Column(Name = "MILLAS")]
        public float MILLAS { get; set; }

       [Column(Name = "ORIGEN")]
        public string ORIGEN { get; set; }

        [Column(Name = "DESTINO")]
        public string DESTINO { get; set; }

        [Column(Name = "FECHA")]
        public string FECHA { get; set; }

        [Column(Name = "ID_TICKET")]
        public int? ID_TICKET { get; set; }

        [Column(Name = "ID_AVION")]
        public int? ID_AVION { get; set; }

        [Column(Name = "PRECIO_DOLARES")]
        public float? PRECIO_DOLARES { get; set; }
    }
}
