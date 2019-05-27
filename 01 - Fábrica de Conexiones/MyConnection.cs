using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Necesitamos las diferentes definiciones de las 
// clases a utilizar para evitar definir nombres completos
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;

namespace _01___Fábrica_de_Conexiones
{
    // Un listado de posibles proveedores a utilizar
    public enum DataProvider { SQLServer, OLEDB, ODBC, None }

    class MyConnection
    {
        protected DataProvider dataProvider;

        // Constructor
        public MyConnection(DataProvider theDataProvider)
        {
            dataProvider = theDataProvider;
        }

        /*
         * Realiza una conexión a la base de datos basada
         * en la tecnología seleccionada.
         */
        public void Conectar()
        {
            switch (dataProvider)
            {
                case DataProvider.SQLServer:
                    MyConnectionSql myConnection = new MyConnectionSql(dataProvider);
                    break;
                case DataProvider.OLEDB:
                    MyConnectionOleDb myOtherConnection = new MyConnectionOleDb(dataProvider);
                    break;
                case DataProvider.ODBC:
                    break;
                case DataProvider.None:
                    Console.WriteLine("¡Tipo de conexión no disponible!");
                    break;
                default:
                    break;
            }

            /*
             * Muestra el tipo de conexión hacia la base de datos.
             */
            public void TipoDeConexion()
            {
                Console.WriteLine("Tu conexión es una {0}", dataProvider);
            }
        }
    }
}
