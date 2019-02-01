using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teller.Clases;

namespace Teller
{
    //Clase que maneja las comunicaciones con el integrador y consume sus servicios
    class Request
    {
        //objeto de log4net para hacer logs
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static Cuenta getCuenta(int id)
        {
            //Instancia de la clase cuenta a devolver
            Cuenta cuenta = new Cuenta();


            try
            {
                //objeto cliente del webService
                Integrador.TellerServicesSoapClient requestCuenta = new Integrador.TellerServicesSoapClient();
                //instancia del objeto del servicio al recibido por el request
                Integrador.Cuenta cuentaRecibida = requestCuenta.getCuenta(id);


                //Si se encontro la cuenta
                if (cuentaRecibida != null)
                {
                    
                    //Asigna cada uno de los valores de la cuenta recibida a la cuenta output
                    cuenta.Balance = cuentaRecibida.balance;
                    cuenta.CedulaCliente = cuentaRecibida.cedulaCliente;
                    cuenta.id = cuentaRecibida.id;
                    cuenta.IdCliente = cuentaRecibida.idCliente;
                    cuenta.Moneda = cuentaRecibida.TipoMoneda;

                }

                //De lo contrario, debe devolver que la cuenta no existe
                else
                {
                    return null;
                }

            }

            //En caso de no tener internet(por ejemplo), entra aqui
            catch(Exception ex)
            {
                log.Fatal(ex.ToString());
                Debug.WriteLine(ex);
                return null;
            }
            
            

            return cuenta;

            
      
        }
        //Metodo devuelve una Instancia Cliente en base a la cedula
        public static Cliente getCliente(string cedula)
        {
            

            //objeto cliente para devolver
            Cliente cliente = new Cliente();
            

            try
            {
                //objeto SoapClient del webService
                Integrador.TellerServicesSoapClient requestCliente = new Integrador.TellerServicesSoapClient();
                //Instancia el objeto del servicio al recibido por el request
                Integrador.Cliente clienteRecibido = requestCliente.getCliente(cedula);

                if (clienteRecibido != null)
                {
                    //Recibe la imagen como un string base 64, y la convierte a un byte[] y luego a un Stream
                    string base64String = clienteRecibido.foto;
                    byte[] foto = Convert.FromBase64String(base64String);
                    var ms = new MemoryStream(foto);


                    //Iguala las propiedades de del objeto recibido del request al  objeto de la clase
                    //Cliente local
                    cliente.Nombre = clienteRecibido.nombre;
                    cliente.Apellido = clienteRecibido.apellido;
                    cliente.Cedula = clienteRecibido.cedula;
                    //Desde el stream a un objeto foto
                    cliente.FotoPerfil = Image.FromStream(ms);
                    cliente.FechaNacimiento = clienteRecibido.fechaNacimiento;
                    cliente.Nacionalidad = clienteRecibido.nacionalidad;
                }

                //Si el integrador no encontro el cliente
                else
                {
                    cliente = null;
                }

            }
            //Handlea una excepcion tirada por un metodo del Soapclient, devuelve null
            catch(Exception ex)
            {
                log.Fatal(ex.ToString());
                Debug.WriteLine(ex.ToString());
                return null;
            }

            return cliente;
           
        }

        //Metodo llama al integrador con la informacion de un deposito. Devuelve true or false dependiendo del exito o no
        public static bool hacerDeposito(Deposito deposito)
        {
            try
            {
                //objeto SoapClient del webService
                Integrador.TellerServicesSoapClient requestCliente = new Integrador.TellerServicesSoapClient();

                //Llama al metodo del integrador y guarda el resultado
                bool result = requestCliente.hacerDeposito(deposito.Monto, deposito.Cuenta.id, deposito.CedulaDepositante, deposito.Concepto);

                //Si el integrador no pudo hacer el deposito
                if (!result)
                    return false;
            }

            //Si hubo un error conectandose al integrador
            catch(Exception ex)
            {
                log.Fatal(ex.ToString());
                return false;
            }
            return true;
        }

        //Metodo llama al integrador con la informacion de un retiro. Devuelve true or false dependiendo del exito o no
        //Este metodose llama para confirmar un retiro(Luego de que se hayan hecho todas las validaciones)
        public static bool hacerRetiro(Retiro retiro)
        {
            
            try
            {
                //objeto cliente del webService
                Integrador.TellerServicesSoapClient requestCliente = new Integrador.TellerServicesSoapClient();
                bool result = requestCliente.hacerRetiro(retiro.Cuenta.id, retiro.Monto);

                //si por alguna razon el hay algun problema con el integrador, devuelve false
                if (!result)
                    return false;
            }
            //Si no se pudo hacer la conexion al integrador
            catch(Exception ex)
            {
                log.Fatal(ex.ToString());
                Debug.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }
    }
}
