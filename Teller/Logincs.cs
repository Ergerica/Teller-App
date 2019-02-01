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
    //Maneja el Form de Login, el primer form que se abre
    public partial class Logincs : Form
    {
        //Variables de instancia, globales de la clase. 
        Principal ingreso;
        Cajero cajero;

        public Logincs()
        {
            InitializeComponent();
        }

        //Cuando se presiona el boton de ingresar
        private void btnIngresar_Click(object sender, EventArgs e)
        {

            string usuario = textUser.Text;
            string password = textPassword.Text;

            //Si los campos estan vacios
            if(usuario.Equals("") || password.Equals(""))
                labelDatosErroneos.Visible = true; 

            else
            {
                //Hace la busqueda en la base de datos local del cajero
                cajero = Query.getCajero(usuario);
                
                //si no se encontro el usuario
                if(cajero == null)
                    labelDatosErroneos.Visible = true;

                //verifica que se haya introducido la contrasena de manera correcta
                else if (cajero.Password.Equals(password))
                {
                    //Abre el form principal y le pasa el objeto del cajero de turno
                    ingreso = new Principal(cajero);
                    ingreso.Show();
                    this.Hide();

                }
                else
                    labelDatosErroneos.Visible = true;
            }
           

        }

        //Cuando este form es cerrado, se termina la apicacion
        private void Logincs_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
