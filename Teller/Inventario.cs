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
    //Maneja el form que muestra el formulario, el estado actual de efectivo de la caja
    public partial class Inventario : Form
    {
        Dictionary<int, int> papeletasDisponible;
        public Inventario()
        {
            InitializeComponent();
            //Cuantas papeletas hay en caja
            papeletasDisponible = Query.getCash();

            //Coloca el texto de cada denominacion de papeleta
            cantidad1Label.Text = Convert.ToString(papeletasDisponible[1]);
            cantidad5Label.Text = Convert.ToString(papeletasDisponible[5]);
            cantidad10Label.Text = Convert.ToString(papeletasDisponible[10]);
            cantidad20Label.Text = Convert.ToString(papeletasDisponible[20]);
            cantidad25Label.Text = Convert.ToString(papeletasDisponible[25]);
            cantidad50Label.Text = Convert.ToString(papeletasDisponible[50]);
            cantidad100Label.Text = Convert.ToString(papeletasDisponible[100]);
            cantidad200Label.Text = Convert.ToString(papeletasDisponible[200]);
            cantidad500Label.Text = Convert.ToString(papeletasDisponible[500]);
            cantidad1000Label.Text = Convert.ToString(papeletasDisponible[1000]);
            cantidad2000Label.Text = Convert.ToString(papeletasDisponible[2000]);



        }

        
    }
}
