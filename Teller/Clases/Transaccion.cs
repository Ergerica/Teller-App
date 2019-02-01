using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teller
{
    //Clase madre transaccion
    public class Transaccion
    {
        //Atributos en comun entre las transacciones
        public string Tipo { get; set; }
        public long Monto { get; set; }
        public DateTime Fecha { get; set; }
        public Cuenta Cuenta { get; set; }
        public string CedulaCliente { get; set; }
        public Cajero CajeroDeTurno { get; set; }
        public int ID { get; set; }
        
    }
}
