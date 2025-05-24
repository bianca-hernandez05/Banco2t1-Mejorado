using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSimple2T1.Models
{
    public class Cliente
    {
        //Se agregan cada uno de los atributos de la clase Cliente
        //los cuales son los mismos atributos de la tabla Cliente de la base de datos.
        
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public List<Cuenta> Cuentas { get; set; } = new List<Cuenta>();
    }
}
