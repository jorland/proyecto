using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace project.avion
{
     [Table(Name = "[AEROLINEA_UAM].[dbo].[AVION]")]

    class tablaAvion
    {//Creado por Jose Murillo
         //08-08-2015
         //Mapp de la tabla Avion

        [Column(Name="ID_AVION",IsPrimaryKey=true)]
        public int ID_AVION { get; set; }

        [Column(Name="NOMBRE_AVION")]
        public string NOMBRE_AVION { get; set; }

        [Column(Name="ID_VUELO")]
        public int ID_VUELO { get; set; }

        [Column(Name = "ESTADO")]
        public int ESTADO { get; set; }

    }
}
