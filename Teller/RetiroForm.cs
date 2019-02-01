using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Teller.Clases;


namespace Teller
{
    public partial class RetiroForm : Form
    {

        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void StringArgReturningVoidDelegate(string text, Label label);
        delegate void StringArgReturningVoidDelegatePicVisibility(PictureBox label, bool value);
        delegate void StringArgReturningVoidDelegateLabelVisibility(Label label, bool value);
        delegate void StringArgReturningVoidDelegateBtnVisibility(Button label, bool value);
        delegate void StringArgReturningVoidDelegatePictureResource(PictureBox label, Image image);

        Cajero cajeroDeTurno;
        Cuenta cuenta;
        Cliente cliente;
        Dictionary<int, int> papeletasDisponibles;
        Dictionary<int, int> papeletasDevolver;

        public RetiroForm(Cajero cajeroDeTurno)
        {
            InitializeComponent();
            this.cajeroDeTurno = cajeroDeTurno;
        }

        private void btnVerificarRetiro_Click(object sender, EventArgs e)
        {
            bool missing = false;
            Label[] labelsDatosErroneos = { labelCedulaErroneaRetiro, labelCuentaErroneaRetiro, labelCantidadErronea, balanceNoSuficienteLabel, personaNoAutorizadaLabel, problemaRetiroLabel };

            //se asegura que los labels de erronea esten no visibles
            for (int i = 0; i < labelsDatosErroneos.Length; i++)
                labelsDatosErroneos[i].Visible = false;

            terminarRetirobtn.Visible = false;

            if (textCedulaRetiro.Text.Equals("") || textCantidadRetiro.Equals("") ||
                textCuentaRetiro.Equals(""))
                labelDatosFaltantesRetiro.Visible = true;

            //verifica que la cuenta, cantidad y cedula sean numericos
            Int64 tempParse;
            if (!Int64.TryParse(textCedulaRetiro.Text, out tempParse))
            {
                labelCedulaErroneaRetiro.Visible = true;
                missing = true;
            }
                
            if (!Int64.TryParse(textCuentaRetiro.Text, out tempParse))
            {
                labelCuentaErroneaRetiro.Visible = true;
                missing = true;
            }
                
            if (!Int64.TryParse(textCantidadRetiro.Text, out tempParse))
            {
                labelCantidadErronea.Visible = true;
                missing = true;
            }

            
            //si todo esta llenado correctamente
            if(!missing)
            {
                
            
                loadingPic.Visible = true;


                //comienza el thread en background 
                Thread requestThread = new Thread(() => {
                    verificarRetiro(); }
                );
                requestThread.Start();
            }
 
        }

        private void verificarRetiro()
        {
            string cedula = textCedulaRetiro.Text;
            long cantidad = (long)Convert.ToUInt64(textCantidadRetiro.Text);

            


            //si el integrador no encuentra la cuenta, devuelve un objeto nulo
            cuenta = Request.getCuenta(Convert.ToInt32(textCuentaRetiro.Text));
            cliente = Request.getCliente(cedula);

            if (cuenta == null)
            {
                setLabelVisibility(labelCuentaErroneaRetiro, true);
                setPicVisibility(loadingPic, false);
            }
            else if(cliente == null)
            {
                setLabelVisibility(labelCedulaErroneaRetiro, true);
                setPicVisibility(loadingPic, false);
            }
            else
            {
                //Las condiciones de estos ifs se deben remplazar por los codigos de error que devolvera el backend
                //si la cedula ingresada no es igual a la de la cuenta recibida
                if (cuenta.CedulaCliente != cedula)
                {
                    setLabelVisibility(personaNoAutorizadaLabel, true);
                    setPicVisibility(loadingPic, false);
                }

                //si la cuenta no tiene balance disponible
                else if (cuenta.Balance < cantidad)
                {
                    setLabelVisibility(balanceNoSuficienteLabel, true);
                    setPicVisibility(loadingPic, false);
                }

                //si todo esta bien, se confirma el retiro 
                else
                {
                    setPicVisibility(loadingPic, false);
                    setBtnVisibility(terminarRetirobtn, true);

                    SetText(cliente.Nombre + " " + cliente.Apellido, nombreclienteLabel);
                    SetText(Convert.ToString(cliente.FechaNacimiento.Date.ToString("d")), fechaNacimientoLabel);
                    SetText(cliente.Nacionalidad, nacionalidadLabel);

                    setLabelVisibility(fechaNacimientoFijaLabel, true);
                    setLabelVisibility(nombreClienteFijoLabel, true);
                    setLabelVisibility(nacionalidadFijaLabel, true);
                    setLabelVisibility(infoClienteHeadingLabel, true);

                    setImage(pictureBoxFotoCliente, cliente.FotoPerfil);
                    setPicVisibility(pictureBoxFotoCliente, true);


                    //Cantidad de billetes disponibles
                    papeletasDisponibles = Query.getCash();

                    //Cantidad que la cajera debe devolver de cada uno, en base 
                    papeletasDevolver = Helpers.ReturnMoney(Convert.ToInt64(textCantidadRetiro.Text), papeletasDisponibles);

                    //Muestra la distribucion de efectivo
                    mostrarPapeletas(papeletasDevolver);
                    setPicVisibility(pictureBox1, true);
                    setPicVisibility(pictureBox2000, true);
                    setLabelVisibility(devueltaHeadingLabel, true);



                }
            }
        }

        public void mostrarPapeletas(Dictionary<int,int> papeletas)
        {
            //Por cada papeleta, pone su foto y cantidad visible  

            //1
            SetText(Convert.ToString(Math.Abs(papeletas[1])), cantidad1Label);
            setPicVisibility(pictureBox1, true);

            //5
            SetText(Convert.ToString(Math.Abs(papeletas[5])), cantidad5Label);
            setPicVisibility(pictureBox5, true);

            //10
            SetText(Convert.ToString(Math.Abs(papeletas[10])), cantidad10Label);
            setPicVisibility(pictureBox10, true);

            //20
            SetText(Convert.ToString(Math.Abs(papeletas[20])), cantidad20Label);
            setPicVisibility(pictureBox20, true);

            //25
            SetText(Convert.ToString(Math.Abs(papeletas[25])), cantidad25Label);
            setPicVisibility(pictureBox25, true);

            //50
            SetText(Convert.ToString(Math.Abs(papeletas[50])), cantidad50Label);
            setPicVisibility(pictureBox50, true);

            //100
            SetText(Convert.ToString(Math.Abs(papeletas[100])), cantidad100Label);
            setPicVisibility(pictureBox100, true);

            //200
            SetText(Convert.ToString(Math.Abs(papeletas[200])), cantidad200Label);
            setPicVisibility(pictureBox200, true);

            //500
            SetText(Convert.ToString(Math.Abs(papeletas[500])), cantidad500Label);
            setPicVisibility(pictureBox500, true);

            //1000
            SetText(Convert.ToString(Math.Abs(papeletas[1000])), cantidad1000Label);
            setPicVisibility(pictureBox1000, true);

            //2000
            SetText(Convert.ToString(Math.Abs(papeletas[2000])), cantidad2000Label);
            setPicVisibility(pictureBox2000, true);


        }

       

        private async void terminarRetirobtn_Click(object sender, EventArgs e)
        {
            loadingPic2.Visible = true;

           
            Retiro retiro = new Retiro(Convert.ToInt64(textCantidadRetiro.Text), cuenta, textCedulaRetiro.Text, cajeroDeTurno);
            bool result = await RetirarAsync(retiro);



            if(!result)
            {
                problemaRetiroLabel.Visible = true;
                loadingPic2.Visible = false;

            }


            else
            {
                btnVerificarRetiro.Visible = false;
                terminarRetirobtn.Visible = false;
                exitoRetiroLabel.Visible = true;
                loadingPic2.Visible = false;


                
                int idRetiro = retiro.registrarRetiro();
                retiro.ID = idRetiro;
               


                //Vacia los textBoxes y refresca el form
                Helpers.clearTextBoxes(this);
                InitializeComponent();
                Refresh();

                //Afecta la base de datos local de registro de efectivo, "hace el cuadre"
                Registro registro = new Registro();
                registro.registerCash(papeletasDevolver, papeletasDisponibles);

                //Debe abrir el reporte de la actual transaccion
                this.Hide();
                ReciboRetiroForm reciboForm = new ReciboRetiroForm(retiro, cuenta);
                reciboForm.Show();
            }

            

            
        }

        public async Task<bool> RetirarAsync(Retiro retiro)
        {
            var myTask = Task.Run(() => retiro.retirar());

            bool result = await myTask;

            return result;
        }



        

        private void setPicVisibility(PictureBox label, bool value)
        {
            if (label.InvokeRequired)
            {
                StringArgReturningVoidDelegatePicVisibility d = new StringArgReturningVoidDelegatePicVisibility(setPicVisibility);
                this.Invoke(d, new object[] { label, value });
            }
            else
            {
                label.Visible = value;
            }
        }

        private void setLabelVisibility(Label label, bool value)
        {
            if (label.InvokeRequired)
            {
                StringArgReturningVoidDelegateLabelVisibility d = new StringArgReturningVoidDelegateLabelVisibility(setLabelVisibility);
                this.Invoke(d, new object[] { label, value });
            }
            else
            {
                label.Visible = value;
            }
        }

        private void setBtnVisibility(Button label, bool value)
        {
            if (label.InvokeRequired)
            {
                StringArgReturningVoidDelegateBtnVisibility d = new StringArgReturningVoidDelegateBtnVisibility(setBtnVisibility);
                this.Invoke(d, new object[] { label, value });
            }
            else
            {
                label.Visible = value;
            }
        }

        private void SetText(string text, Label label)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (label.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(SetText);
                this.Invoke(d, new object[] { text, label });
            }
            else
            {
                label.Text = text;
                label.Visible = true;
            }
        }

        private void setImage(PictureBox label, Image image)
        {
            if (label.InvokeRequired)
            {
                //Se necesita esto, es parte del patron, los Delegate estan declarados como variables globales, y estan relacionados
                //a los parametros de este metodo
                StringArgReturningVoidDelegatePictureResource d = new StringArgReturningVoidDelegatePictureResource(setImage);
                this.Invoke(d, new object[] { label, image });
            }
            else
            {
                label.Image = image;
            }
        }
    }
}
