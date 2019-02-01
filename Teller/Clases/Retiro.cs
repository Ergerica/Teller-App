using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teller.Clases
{
    //Clase hija que hereda de Transaccion
    public class Retiro : Transaccion
    {
        //Variable de instancia, objeto global de registro
        Registro registro = new Registro();

        public Retiro(long monto, Cuenta cuenta, string cedulaCliente, Cajero cajero)
        {
            this.Tipo = "Retiro";
            this.Monto = monto;
            this.Fecha = DateTime.Now;
            this.Cuenta = cuenta;
            this.CedulaCliente = cedulaCliente;
            this.CajeroDeTurno = cajero;
            this.ID = 0;

        }


        //Llama al metodo de hacer retiro de la clase Request(Que s eencarga de comunicarse con el integrador)
        public  bool retirar()
        {
            return Request.hacerRetiro(this);
        }

        //Llama al metodo registrar de la clase Registro, que se encarga de guardar en la base de datos local el retiro
        public int registrarRetiro()
        {
            return registro.registrarTransaccion(this);
        }

        
    }
}
