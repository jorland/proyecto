using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class moneda
    {
        private static Double dolar = 570;
        private static Double colones = 570;

        public Double Dolares
        {
            get { return dolar; }
            set { dolar = value; }
        }


        public Double Colones
        {
            get { return colones; }
            set { colones = value; }
        }

        public static Double colonesToDollars(Double colones)
        {
            return colones / dolar;
        }

        public static Double dollarsTocolones(Double colones)
        {
            return colones * dolar;
        }


    }
}
