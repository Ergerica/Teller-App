using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Teller
{
    //Clase para hacer solicitudes a la base de datos local
    class Query
    {
        //metodo devuelve un objeto de la clase cajero en base al usuario
        public static Cajero getCajero(string user)
        {
            //Creacion de objeto de la clase que permite conectarse a la base de datos
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DENYS-ARTURO;Initial Catalog=TellerLocal;Integrated Security=True;Pooling=False");
            //metodo para abrir base de datos
            sqlConnection.Open();
           

            //primer parametro es el query, segundo parametro es el objeto de la conexion
            string comando = string.Format("select * from tblCajero where Usuario = '{0}'", user);
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);

            //objeto de la clase SqlDataReader, provee metodos para leer filas de una base de datos
            //ExecuteReader returns A SqlDataReader object.
            SqlDataReader dr = sqlCommand.ExecuteReader();

            //si el comando se ejecuto correctamente(Si se encontro el usuario)
            if (dr.Read())
            {
                int tipo = int.Parse(dr["tipo"].ToString());
                //Objeto cajero segun los datos recuperados de la base de datos
                Cajero cajero = new Cajero(dr["Nombre"].ToString(), dr["Apellido"].ToString(), dr["Usuario"].ToString(), tipo, dr["Password"].ToString());
                return cajero;

            }
           
            else
                return null;
          
        }

        //Devuelve un diccionario con la denominacion de cada papeleta disponible en la caja
        //La info se saca de la base de datos local
        public static Dictionary<int, int> getCash()
        {
            Dictionary<int, int> papeletas = new Dictionary<int, int>();

            //Creacion de objeto de la clase que permite conectarse a la base de datos
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DENYS-ARTURO;Initial Catalog=TellerLocal;Integrated Security=True;Pooling=False");
            //metodo para abrir base de datos
            sqlConnection.Open();
            //Console.WriteLine(sqlConnection.State);

            int id = 1;
            //primer parametro es el query, segundo parametro es el objeto de la conexion
            string comando = string.Format("select * from tblEfectivo where Id = '{0}'", id);
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);

            //objeto de la clase SqlDataReader, provee metodos para leer filas de una base de datos
            //ExecuteReader returns A SqlDataReader object.
            SqlDataReader dr = sqlCommand.ExecuteReader();

            //si el comando se ejecuto correctamente(Si se encontro el usuario)
            if (dr.Read())
            {
                //agrega cada uno de las cantidades de cada denominacion al diccionario
                papeletas.Add(1, Convert.ToInt16(dr["uno"]));
                papeletas.Add(5, Convert.ToInt16(dr["cinco"]));
                papeletas.Add(10, Convert.ToInt16(dr["diez"]));
                papeletas.Add(20, Convert.ToInt16(dr["veinte"]));
                papeletas.Add(25, Convert.ToInt16(dr["veintecinco"]));
                papeletas.Add(50, Convert.ToInt16(dr["cinquenta"]));
                papeletas.Add(100, Convert.ToInt16(dr["cien"]));
                papeletas.Add(200, Convert.ToInt16(dr["doscientos"]));
                papeletas.Add(500, Convert.ToInt16(dr["quinientos"]));
                papeletas.Add(1000, Convert.ToInt16(dr["mil"]));
                papeletas.Add(2000, Convert.ToInt16(dr["dosmill"]));
            }

            //si no se pudo leer la base de datos
            else
                return null;


            sqlConnection.Close();
            return papeletas;
        }


        
    }
}
