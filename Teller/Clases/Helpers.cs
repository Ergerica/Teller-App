using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teller.Clases
{
    //Clase que contiene metodos de ayuda y que no son especificos de ninguna operacion
    public class Helpers
    {
        //Vacia todos los objetos TextBoxes de un form
        public static void clearTextBoxes(Form form)
        {
            foreach (Control control in form.Controls)
                if (control is TextBox)
                    (control as TextBox).Clear();
        }

        //Implementacion de un algoritmo greedy para devolver cuanto se debe devolver de cada denominacion de papeleta en base
        //a las papeletas disponibles en caja y el monto a devolver
        public static Dictionary<int,int> ReturnMoney(long monto, Dictionary<int,int> papeletasDisponibles)
        {

            List<int[]> cash = new List<int[]>();
            Dictionary<int, int> cantidadDevolver = new Dictionary<int, int>();
            cantidadDevolver[1] = 0;
            cantidadDevolver[5] = 0;
            cantidadDevolver[10] = 0;
            cantidadDevolver[20] = 0;
            cantidadDevolver[25] = 0;
            cantidadDevolver[50] = 0;
            cantidadDevolver[100] = 0;
            cantidadDevolver[200] = 0;
            cantidadDevolver[500] = 0;
            cantidadDevolver[1000] = 0;
            cantidadDevolver[2000] = 0;

            
            

            while (monto >= 2000 && papeletasDisponibles[2000] >= 1)
            {
                cantidadDevolver[2000]++;
                papeletasDisponibles[2000]--;
                monto -= 2000;
            }
            while (monto >= 1000 && papeletasDisponibles[1000] >= 1)
            {
                cantidadDevolver[1000]++;
                papeletasDisponibles[1000]--;
                monto -= 1000;
            }
            while (monto >= 500 && papeletasDisponibles[500] >= 1)
            {
                cantidadDevolver[500]++;
                monto -= 500;
                papeletasDisponibles[500]--;
            }
            while (monto >= 200 && papeletasDisponibles[200] >= 1)
            {
                cantidadDevolver[200]++;
                monto -= 200;
                papeletasDisponibles[200]--;
            }
            while (monto >= 100 && papeletasDisponibles[100] >= 1)
            {

                cantidadDevolver[100]++;
                monto -= 100;
                papeletasDisponibles[100]--;

            }
            while (monto >= 50 && papeletasDisponibles[50] >= 1)
            {
                cantidadDevolver[50]++;
                monto -= 50;
                papeletasDisponibles[50]--;
            }
            while (monto >= 25 && papeletasDisponibles[25] >= 1)
            {
                cantidadDevolver[25]++;
                monto -= 25;
                papeletasDisponibles[25]--;
            }
            while (monto >= 20 && papeletasDisponibles[20] >= 1)
            {
                cantidadDevolver[20]++;
                monto = monto % 20;
                papeletasDisponibles[20]--;
            }
            while (monto >= 10 && papeletasDisponibles[10] >= 1)
            {
                cantidadDevolver[10]++;
                monto -= 10;
                papeletasDisponibles[10]--;
            }
            while (monto >= 5 && papeletasDisponibles[5] >= 1)
            {
                cantidadDevolver[5]++;
                monto -= 5;
                papeletasDisponibles[5]--;
            }
            while (monto >= 1 && papeletasDisponibles[1] >= 1)
            {
                cantidadDevolver[1]++;
                monto -= 1;
                papeletasDisponibles[1]--;
            }
            
            foreach (int key  in cantidadDevolver.Keys.ToList())
            {
                //Como es cantidad que se va a quitar de la caja, se registra como negativo
                cantidadDevolver[key] = cantidadDevolver[key] * (-1);

            }
            return cantidadDevolver;
        }

        //Devuelve el el numero en letra. Este metodo se llama para hacer registros en la base de datos
        public static string  numberToText(int numero)
        {
            string  letra = "";

            switch(numero)
            {
                case 1:
                    letra = "uno";
                    break;
                case 5:
                    letra = "cinco";
                    break;
                case 10:
                    letra = "diez";
                    break;
                case 20:
                    letra = "veinte";
                    break;
                case 25:
                    letra = "veintecinco";
                    break;
                case 50:
                    letra = "cinquenta";
                    break;
                case 100:
                    letra = "cien";
                    break;
                case 200:
                    letra = "doscientos";
                    break;
                case 500:
                    letra = "quinientos";
                    break;
                case 1000:
                    letra = "mil";
                    break;
                case 2000:
                    letra = "dosmill";
                    break;

            }
            return letra;
        }
    }
}
