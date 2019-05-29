using System;

// Agregar los namespaces para la conexión con SQL Server
using System.Data;
using System.Data.SqlClient;

namespace _01___Fábrica_de_Conexiones
{
    class MyConnectionSql : MyConnection
    {
        public MyConnectionSql(DataProvider theDataProvider) : base(theDataProvider)
        {
            // Utilizando un ConnectionString para realizar la conexión
            // con el servidor SQL Server
            SqlConnection connectionString = new SqlConnection(@"server = (local)\sqlexpress; integrated security = true;");

            try
            {
                // Abrir la conexión
                connectionString.Open();

                // Detalles de la conexión
                this.DetallesConexion(connectionString);
            }
            catch (SqlException e)
            {
                // Desplegar el mensaje de error
                Console.WriteLine("Error: {0} {1}", e.Message, e.StackTrace); ;
            }
            finally
            {
                // Cerrar la conexión
                connectionString.Close();
                Console.WriteLine("Conexión finalizada");
            }
        }

        protected void DetallesConexion(SqlConnection connectionString)
        {
            Console.WriteLine("Conexión establecida");
            Console.WriteLine("\tConnection string: {0}", connectionString.ConnectionString);
            Console.WriteLine("\tBase de datos: {0}", connectionString.Database);
            Console.WriteLine("\tFuente de datos: {0}", connectionString.DataSource);
            Console.WriteLine("\tVersión del servidor: {0}", connectionString.ServerVersion);
            Console.WriteLine("\tEstado: {0}", connectionString.State);
            Console.WriteLine("\tId estación de trabajo: {0}", connectionString.WorkstationId);
        }
    }
}