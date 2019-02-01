using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teller
{
    //Maneja el form Cliente(El de la busqueda del cliente)
    public partial class ClienteForm : Form
    {
        
        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void StringArgReturningVoidDelegate(string text, Label label);
        delegate void StringArgReturningVoidDelegateVisibility(PictureBox label, bool value);
        delegate void StringArgReturningVoidDelegateLabelVisibility(Label label, bool value);
        delegate void StringArgReturningVoidDelegatePictureResource(PictureBox label, Image image);

        public ClienteForm()
        {
            InitializeComponent();
        }

          //Cuando el boton "Buscar Cliente" es clickeado
        private void buscarClienteBtn_Click(object sender, EventArgs e)
        {
            //Pone el label de info falso
            errorClienteLabel.Visible = false;
            
            //Retrieves la cedula escrita por el usuario
            string cedula = cedulaTextBox.Text.ToString();
     
            //Comienza el loading
            loadingPic.Visible = true;
            loadingPic.Refresh();

            //Comienza el thread para hacer el request del cliente
            Thread requestThread = new Thread(buscarCliente);
            requestThread.Start(cedula);
            

        }

        //Llama al la clase Request para obtener un cliente en base a la cedula
        void buscarCliente(object cedula)
        {
            //objeto cliente devuelto por el metodo de request
            Cliente cliente = Request.getCliente((string)cedula);

            //Si encontro al cliente
            if (cliente != null)
            {
                //Pone la info en el label y la pone visible
                string info = cliente.Nombre + " " + cliente.Apellido;
                SetText(cliente.Nombre + " " + cliente.Apellido, nombreclienteLabel);
                SetText(Convert.ToString(cliente.FechaNacimiento.Date.ToString("d")), fechaNacimientoLabel);
                SetText(cliente.Nacionalidad, nacionalidadLabel);

                setVisibility(fechaNacimientoFijaLabel, true);
                setVisibility(nombreClienteFijoLabel, true);
                setVisibility(nacionalidadFijaLabel, true);

                setImage(pictureBoxFotoCliente, cliente.FotoPerfil);
                setVisibility(pictureBoxFotoCliente, true);

            }
            else
            {
                SetText("Cliente no encontrado", errorClienteLabel);
            }

            //termina el loading
            setVisibility(loadingPic, false);
        }

        //Metodo para modificar un objeto en un thread que no es en el que fre creado
        private void setVisibility(PictureBox label, bool value)
        {
            if (label.InvokeRequired)
            {
                //Se necesita esto, es parte del patron, los Delegate estan declarados como variables globales, y estan relacionados
                //a los parametros de este metodo
                StringArgReturningVoidDelegateVisibility d = new StringArgReturningVoidDelegateVisibility(setVisibility);
                this.Invoke(d, new object[] { label, value });
            }
            else
            {
                label.Visible = value;
            }
        }

        //Metodo para modificar un objeto en un thread que no es en el que fue creado
        private void setVisibility(Label label, bool value)
        {
            if (label.InvokeRequired)
            {
                //Se necesita esto, es parte del patron, los Delegate estan declarados como variables globales, y estan relacionados
                //a los parametros de este metodo
                StringArgReturningVoidDelegateLabelVisibility d = new StringArgReturningVoidDelegateLabelVisibility(setVisibility);
                this.Invoke(d, new object[] { label, value });
            }
            else
            {
                label.Visible = value;
            }
        }

        //Coloca una imagen en el PictureBox
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

        //Coloca el texto a un textBox
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

    }
}
