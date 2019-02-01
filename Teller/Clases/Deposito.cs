using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teller.Clases;

namespace Teller
{
    //Esta clase representa una instancia particular de una transaccion: un deposito
    public class Deposito : Transaccion
    {
        //Variable de instancia, objeto de la clase registro para hacer el registro del deposito
        Registro registro = new Registro();
       
        //Atributos especificos del deposito(Aparte de los que hereda)
        public string CedulaDepositante { get; set; }
        public string Concepto { get; set; }
        

      //constructor
        public Deposito(long monto, Cuenta cuenta, string cedulaDepositante, string concepto, DateTime fecha, Cajero cajero, string cedulaCliente)
        {
            this.Cuenta = cuenta;
            this.CedulaDepositante = cedulaDepositante;
            this.Monto = monto;
            this.Concepto = concepto;
            this.Fecha = fecha;
            this.Tipo = "Deposito";
            this.CedulaCliente = cedulaCliente;
            this.CajeroDeTurno = cajero;
            this.ID = 0;


        }

        //Metodo llama al metodo "hacerDeposito" de la clase request, enviandole este objeto
        public bool Depositar()
        {
            //Le pasa el objeto deposito con toda la info al metodo de request
            bool result = Request.hacerDeposito(this);
            return result;
        }

        //Llama al metodo registrarTransaccion(Para registrar en base de datos local)
        public int registrarDeposito()
        {
            return registro.registrarTransaccion(this);
        }

        
    }

    
}
