using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teller
{
    public partial class Principal : Form
    {
        Logincs login;
        Cajero cajeroDeTurno;

        

        public Principal(Cajero cajero)
        {
            InitializeComponent();
            //Form a pantalla completa
            this.WindowState = FormWindowState.Maximized;
            //Asigna el cajero de turno
            this.cajeroDeTurno = cajero;
            this.labelCajeroTurno.Text = "Cajero de turno: "+cajero.Nombre +" " + cajero.Apellido;
            
            //Event Handler para que cuando el form se cierre, se abra el de login
            this.FormClosed += new FormClosedEventHandler(Principalcs_FormClosing);

        }

        
        //Este metodo abre cada form interno
        public void abrirFormCont(object formAbrir)
        {
            //Si ya hay un form interno, lo quita 
            if (this.panelContenido.Controls.Count > 0)
                this.panelContenido.Controls.RemoveAt(0);

            //objeto de formulario
            Form form = formAbrir as Form;
            //no es un form de nivel superior
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            //Anade el form interno al panel
            this.panelContenido.Controls.Add(form);
            this.panelContenido.Tag = form;
            form.Show();

        }
        
        //Cada uno de los siguientes metodos abren el form interno correspondiente

        private void btnDeposito_Click(object sender, EventArgs e)
        {
            abrirFormCont(new DepositoEfectivo(cajeroDeTurno));

        }

        private void btnDepositoEfectivo_Click(object sender, EventArgs e)
        {
            abrirFormCont(new DepositoEfectivo(cajeroDeTurno));
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            login = new Logincs();
            this.Hide();
            login.Show();

        }

        private void btnRetiro_Click(object sender, EventArgs e)
        {
            abrirFormCont(new RetiroForm(this.cajeroDeTurno));
        }

        private void clienteBtn_Click(object sender, EventArgs e)
        {
            abrirFormCont(new ClienteForm());
        }

        private void btnTransacciones_Click(object sender, EventArgs e)
        {
            abrirFormCont(new ReporteTransaccionesForm());
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            abrirFormCont(new Inventario());
        }

        //Cuando este form es cerrado, se termina la apicacion
        private void Principalcs_FormClosing(object sender, FormClosedEventArgs e)
        {
            login = new Logincs();
            this.Hide();
            login.Show();

        }
    }
}
