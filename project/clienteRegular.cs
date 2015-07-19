using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class clienteRegular:cliente
    {
        public clienteRegular(string cedula, string nombre, string primerApellido, string segundoApellido, string contrasena, string tipoCliente, string privilegio) : base(cedula, nombre, primerApellido, segundoApellido, contrasena, tipoCliente, privilegio) { } 

    }
}
