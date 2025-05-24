using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSimple2T1.Models
{
    public class Cuenta
    {

        //Se agregan cada uno de los atributos de la clase Cuenta
        //los cuales son los mismos atributos de la tabla Cuenta de la base de datos.

        public int CuentaId { get; set; }
        public string NumeroCuenta { get; set; }
        public decimal Saldo { get; set; }
        public bool Activa { get; set; } = true;
        public int ClienteId { get; set; }
        public Cliente cliente { get; set; }

    }
}
          
