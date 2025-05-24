using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSimple2T1.Models
{
    public class Transaccion
    {

        //Se agregan cada uno de los atributos de la clase Transaccion
        //los cuales son los mismos atributos de la tabla Transacciones de la base de datos.

        public int TransaccionId { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Descripcion { get; set; }
        public int ? CuentaOrigenId { get; set; }
        public int ? CuentaDestinoId { get; set; }

    }
}
