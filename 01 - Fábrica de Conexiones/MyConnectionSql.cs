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
            SqlConnection connectionString = new SqlConnection(@"server = (local)\sqlexpress;");
        }
    }
}