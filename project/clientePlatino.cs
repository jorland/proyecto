using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class clientePlatino:cliente
    {
        public clientePlatino(string cedula, string nombre, string primerApellido, string segundoApellido, string contrasena, string tipoCliente, string privilegio) : base(cedula, nombre, primerApellido, segundoApellido, contrasena, tipoCliente, privilegio) { } 
    }
}
