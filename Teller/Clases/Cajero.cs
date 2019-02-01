using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teller
{
    
    public class Cajero
    {
       
    
        enum tipoCajero { cajero = 1, supervisor = 2 };
        
        //Propiedades autoimplementadas, no hay que crear el private field y luego la propiedad
        //Son los 2 en uno
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Usuario { get; set; }
        public int Tipo { get; set; }
        public string Password { get; set; }

        //constructor
        public Cajero(string nombre, string apellido, string usuario, int tipo, string password)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Usuario = usuario;
            this.Tipo = tipo;
            this.Password = password;
        
        }
    }
}
