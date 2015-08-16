using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace project
{
    [Table(Name = "[AEROLINEA_UAM].[dbo].[PAIS]")]
    class tablaPaises
    {
        [Column(Name = "COD_PAIS", IsPrimaryKey = true)]
        public int COD_PAIS { get; set; }
        [Column]
        public string DESCRIPCION { get; set; }
    }
}
