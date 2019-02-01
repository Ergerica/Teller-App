using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Teller.Clases
{
    //Clase para registrar transacciones en la base de datos local
    class Registro
    {
        //Objeto de log4net para realizar los logs
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //Este metodo devuelve un int con el id de transaccion para mostrarlo en el comprobante
        public int registrarTransaccion(Transaccion trans)
        {
            SqlConnection sqlConnection;
            SqlCommand sqlCommandInsert;
            SqlCommand sqlCommandSelect;
            int id;

            try
            {
                //Creacion de objeto de la clase que permite conectarse a la base de datos
                sqlConnection = new SqlConnection(@"Data Source=DENYS-ARTURO;Initial Catalog=TellerLocal;Integrated Security=True;Pooling=False");
                //metodo para abrir base de datos
                sqlConnection.Open();

                //Comando para insertar el registro
                //primer parametro es el query, segundo parametro es el objeto de la conexion
                string comando = "INSERT INTO tblTransacciones (tipo, monto, cedula, cuentaId, fecha, descripcion, Cajero)" +
                    " VALUES (@tipo,@monto, @cedula, @cuentaId, @fecha, @descripcion, @Cajero)";
                sqlCommandInsert = new SqlCommand(comando, sqlConnection);


                //anade los parametros del query
                sqlCommandInsert.Parameters.AddWithValue("@tipo", trans.Tipo);
                sqlCommandInsert.Parameters.AddWithValue("@monto", trans.Monto);
                sqlCommandInsert.Parameters.AddWithValue("@cedula", trans.CedulaCliente);
                sqlCommandInsert.Parameters.AddWithValue("@cuentaId", trans.Cuenta.id);
                sqlCommandInsert.Parameters.AddWithValue("@fecha", trans.Fecha);
                if(trans.Tipo == "Deposito")
                    sqlCommandInsert.Parameters.AddWithValue("@descripcion", "Deposito de efectivo");
                else
                    sqlCommandInsert.Parameters.AddWithValue("@descripcion", "Retiro de efectivo");


                sqlCommandInsert.Parameters.AddWithValue("@Cajero", trans.CajeroDeTurno.Nombre + " " + trans.CajeroDeTurno.Apellido);



                //Inserta en la base de datos
                sqlCommandInsert.ExecuteNonQuery();

            }

            catch(Exception ex)
            {
                log.Fatal(ex.ToString());
                //el 0 es que no se pudo insertar
                return 0;
            }

            try
            {
                //Comando para seleccionar el ultimo registro en la tabla
                string command = "SELECT TOP 1 * FROM tblTransacciones ORDER BY ID DESC";
                sqlCommandSelect = new SqlCommand(command, sqlConnection);

                //objeto de la clase SqlDataReader, provee metodos para leer filas de una base de datos
                //ExecuteReader returns A SqlDataReader object.
                SqlDataReader dr = sqlCommandSelect.ExecuteReader();

                //si el comando se ejecuto correctamente(Si se encontro el usuario)
                if (dr.Read())
                {
                    id = int.Parse(dr["id"].ToString());
                    
                }
                else
                {
                    //el -1 es que no se pudo seleccionar
                    return -1;
                }



            }
            catch(Exception ex)
            {
                log.Fatal(ex.ToString());
                return -1;
            }

            sqlConnection.Close();
            return id;
 
        }




    
        //Este metodo modifica la base de datos local con las papeletas retiradas
        public void registerCash(Dictionary<int,int> papeletasRetiradas, Dictionary<int,int> papeletasDisponibles)
        {
            //Creacion de objeto de la clase que permite conectarse a la base de datos
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DENYS-ARTURO;Initial Catalog=TellerLocal;Integrated Security=True;Pooling=False");
            //metodo para abrir base de datos
            sqlConnection.Open();

            int id = 1;

            foreach(KeyValuePair<int, int> i in papeletasRetiradas)
                if (i.Value != 0)
                {
                    
                    string comando =  "UPDATE tblEfectivo SET "+ Helpers.numberToText(i.Key)+" = @cantidad WHERE Id = @id";
                    SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
                    int cantidadRestante;
                    
                    if (i.Value > 0)
                        cantidadRestante = papeletasDisponibles[i.Key] + i.Value;
                    //No logro descifrar por que se le quita 1 de mas, asi que le sumo uno para compensar
                    else
                        cantidadRestante = papeletasDisponibles[i.Key] + i.Value + 1;

                    sqlCommand.Parameters.AddWithValue("@cantidad", cantidadRestante);
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    sqlCommand.ExecuteNonQuery();

                }
            
            
            
            


            
        }
    }
}
