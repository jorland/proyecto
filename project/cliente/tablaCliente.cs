using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace project
{
    [Table(Name = "AEROLINEA_UAM.dbo.CLIENTE")]
    class tablaCliente
    {
        [Column(Name = "ID_CLIENTE",IsPrimaryKey=true,DbType="int NOT NULL",IsDbGenerated=true)]
        public int ID_CLIENTE { get; set; }
        [Column]
        public string CEDULA { get; set; }
        [Column]
        public string NOMBRE { get; set; }
        [Column]
        public string APELLIDO1 { get; set; }
        [Column]
        public string CONTRASENA { get; set; }
        [Column]
        public string TIPO { get; set; }
        [Column]
        public string CONDICION { get; set; }
        [Column]
        public int MILLAS { get; set; }
        [Column]
        public string PRIVILEGIO { get; set; }
        [Column]
        public string APELLIDO2 { get; set; }
        [Column]
        public int ID_TICKET { get; set; }

    }
}
