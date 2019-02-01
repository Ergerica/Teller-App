using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using Teller.Clases;

namespace Teller
{
    //Maneja el form de deposito de efectivo
    public partial class DepositoEfectivo : Form
    {
        //Objeto del cajero de turno, se va pasando de form en form y se inicializa con el constructor
        Cajero cajeroDeTurno;
        Cuenta cuenta;
        Dictionary<int, int> papeletas;

        //constructor, asigna el cajero de turno al recibido por el form principal
        public DepositoEfectivo(Cajero cajero)
        {
            InitializeComponent();
            cajeroDeTurno = cajero;
        }

       //Cuando el boton de verificar deposito es clikeado
        private async void btnDeposito_Click(object sender, EventArgs e)
        {
            //at the beginning, nothing is missing
            bool missing = false;

            //Makes sure all warning labels are not visible
            labelCantidadErronea.Visible = false;
            labelAcumuladoErroneo.Visible = false;
            labelDatosFaltantes.Visible = false;
            labelDepositoExitoso.Visible = false;
            labelDepositoProblema.Visible = false;
            labelCedulaErronea.Visible = false;

            long tempParse;

            //if nothing has been written
            if (textCedula.Text.Equals("") || textCantidad.Text.Equals("") || textCuenta.Text.Equals(""))
            {
                labelDatosFaltantes.Visible = true;
                missing = true;
            }
                

            //verifica que campos sean numericos
            if(!missing)
            {
                missing = false;
                
                if (!Int64.TryParse(textCuenta.Text, out  tempParse))
                {
                    labelCuentaErronea.Visible = true;
                    missing = true;
                }
                    
                if (!Int64.TryParse(textCedula.Text, out  tempParse))
                {
                    labelCedulaErronea.Visible = true;
                    missing = true;
                }
                    
                if ((!Int64.TryParse(textCantidad.Text, out tempParse)))
                {
                    labelCantidadErronea.Visible = true;
                    missing = true;
                }
                    
            }

            //diccionario para colocar la cantidad de papeletas de cada tipo
            papeletas = new Dictionary<int, int>();
            //si no falta nada
            if (!missing)
            {
                missing = false;
                papeletas.Add(1, Convert.ToInt16(papeletasTabla.Rows[0].Cells[0].Value));
                papeletas.Add(5, Convert.ToInt16(papeletasTabla.Rows[0].Cells[1].Value));
                papeletas.Add(10, Convert.ToInt16(papeletasTabla.Rows[0].Cells[2].Value));
                papeletas.Add(20, Convert.ToInt16(papeletasTabla.Rows[0].Cells[3].Value));
                papeletas.Add(25, Convert.ToInt16(papeletasTabla.Rows[0].Cells[4].Value));
                papeletas.Add(50, Convert.ToInt16(papeletasTabla.Rows[0].Cells[5].Value));
                papeletas.Add(100, Convert.ToInt16(papeletasTabla.Rows[0].Cells[6].Value));
                papeletas.Add(200, Convert.ToInt16(papeletasTabla.Rows[0].Cells[7].Value));
                papeletas.Add(500, Convert.ToInt16(papeletasTabla.Rows[0].Cells[8].Value));
                papeletas.Add(1000, Convert.ToInt16(papeletasTabla.Rows[0].Cells[9].Value));
                papeletas.Add(2000, Convert.ToInt16(papeletasTabla.Rows[0].Cells[10].Value));

                
                //total  de papeletas, acumulador
                int acumuladoPapeleta = 0;
                foreach (KeyValuePair<int, int> i in papeletas)
                {
                    acumuladoPapeleta += i.Value * (i.Key);  
                }

                //si la cantidad de papeletas no coincide con cantidad introducida
                if (acumuladoPapeleta != Convert.ToInt16(textCantidad.Text))
                {
                    labelAcumuladoErroneo.Visible = true;
                    missing = true;
                }
            }

            //si llego a este punto y no hay nada faltante y todo concuerda, se procede a hacer el deposito
            if(!missing)
            {
                //Starts loading
                loadingPic.Visible = true;

                //Atributos del objeto 
                long monto = Convert.ToInt64(textCantidad.Text);
                int cuentaId = Convert.ToInt16(textCuenta.Text);
                string cedula = textCedula.Text;
                string concepto = textConcepto.Text;

                //Primero objeto cuenta, hace llamada asincrona
                cuenta = await getCuentaAsync(cuentaId);

                //si la cuenta no existe
                if(cuenta == null)
                {
                    labelCuentaErronea.Visible = true;
                }
                else
                {

                    //Shows info about the account 
                    //Sets heading visible
                    labelInfoCuentaHeading.Visible = true;
                    labelBalanceFija.Visible = true;
                    labelMonedaFija.Visible = true;
                    labelTipoCuentaFijo.Visible = true;
                    labelCedulaPropietarioFijo.Visible = true;


                    labelMoneda.Text = cuenta.Moneda;
                    labelMoneda.Visible = true;
                    
                    labelBalance.Text = "RD$"+Convert.ToString(cuenta.Balance);
                    labelBalance.Visible = true;
                    labelCedulaPropietario.Text = cuenta.CedulaCliente;
                    labelCedulaPropietario.Visible = true;
                    labelTipoCuenta.Text = Convert.ToString(cuenta.Tipo);
                    labelTipoCuenta.Visible = true;

                    //Boton para terminar el deposito, ya que se verifico que todo esta correcto
                    btnTerminarDeposito.Visible = true;
                }

                //Se termina el loading
                loadingPic.Visible = false;

            }

        }

        //Metodo asincrono para hacer el deposito(Conectandose al integrador)
        static async Task<bool> DepositarAsync(Deposito deposito)
        {
            var myTask = Task.Run(() => deposito.Depositar());
           
            bool result = await myTask;

            return result;
        }

        //Metodo asincrono para hacer el request de una cuenta
        static async Task<Cuenta> getCuentaAsync(int id)
        {
            var myTask = Task.Run(() => Request.getCuenta(id));
            Cuenta cuenta = await myTask;
            return cuenta;

        }

        //Cuando el boton "Terminar deposito" es clickeado
        private async void btnTerminarDeposito_Click(object sender, EventArgs e)
        {
            //Retrieves the info about the deposito
            long monto = Convert.ToInt64(textCantidad.Text);
            int cuentaId = Convert.ToInt16(textCuenta.Text);
            string cedula = textCedula.Text;
            string concepto = textConcepto.Text;

            //Deposito instance
            Deposito deposito = new Deposito(monto, cuenta, cedula, concepto, DateTime.Now, cajeroDeTurno, cuenta.CedulaCliente);

            loadingPic2.Visible = true;
            //Result, hecho de manera "asincrona", doesnt stop the UI from executing
            //We need this so that the loading picture doesnt freeze
            //El await hace que este metodo deje de ejecutarse hasta que DepositarAsync termine de ejecutar
            //Mientras DepositarAsync se ejecuta, el control se le devuelve al metodo que llamo(En este caso, la UI)
            bool result = await DepositarAsync(deposito);



            //no se pudo completar el deposito
            if (!result)
            {
                labelDepositoProblema.Visible = true;
            }

            //El deposito se pudo hacer con exito
            else
            {
                labelDepositoExitoso.Visible = true;


                //Registrar deposito en base de datos local
                deposito.ID = deposito.registrarDeposito();


                //Registrar cambios en tabla de efectivo
                Dictionary<int, int> papeletasDisponibles = Query.getCash();
                Registro registro = new Registro();
                registro.registerCash(papeletas, papeletasDisponibles);


                //Ocultar este form
                this.Hide();
                //Mostrar el recibo del deposito
                ReciboDepositoForm reciboForm = new ReciboDepositoForm(deposito,cuenta);
                reciboForm.Show();
            }
        }
    }
}
