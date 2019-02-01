using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teller
{
   public class Cuenta
    {
        //Atributos de la cuenta
        public int id { get; set; }

        //un numero que represente el tipo de cuenta
        public int Tipo { get; set; }
        public int IdCliente { get; set; }
        public string CedulaCliente { get; set; }
        public long Balance { get; set; }
        public string Moneda { get; set; }
    }
}
