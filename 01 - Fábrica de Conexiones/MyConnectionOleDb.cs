using System;
// Namespaces necesarios para realizar la conexión OleDB
using System.Data;
using System.Data.OleDb;

namespace _01___Fábrica_de_Conexiones
{
    class MyConnectionOleDb : MyConnection
    {
        // Constructor
        public MyConnectionOleDb(DataProvider theDataProvider) : base(theDataProvider)
        {
            // Crear la cadena de conexión
            OleDbConnection connectionString = new OleDbConnection(@"provider = sqloledb;
                data source = (local)\sqlexpress; integrated security = sspi;");

            try
            {
                // Establecer la conexión
                connectionString.Open();
                Console.WriteLine("Conexión establecida");

                // Detalles de la conexión
                this.DetallesConexion(connectionString);
            }
            catch (OleDbException e)
            {
                // Desplegar el error en la conexión
                Console.WriteLine("Error: {0} {1}", e.Message, e.StackTrace);
            }
            finally
            {
                // Cerrar la conexión
                connectionString.Close();
            }
        }

        protected void DetallesConexion(OleDbConnection connectionString)
        {
            Console.WriteLine("Conexión establecida");
            Console.WriteLine("\tConnection string: {0}", connectionString.ConnectionString);
            Console.WriteLine("\tBase de datos: {0}", connectionString.Database);
            Console.WriteLine("\tFuente de datos: {0}", connectionString.DataSource);
            Console.WriteLine("\tVersión del servidor: {0}", connectionString.ServerVersion);
            Console.WriteLine("\tEstado: {0}", connectionString.State);
        }
    }
}