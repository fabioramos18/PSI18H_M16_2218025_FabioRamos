using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace PSI18H_M16_2218025_FabioRamos
{
    class MDB
    {
        // DataBase ---------------------------------------
         MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root; password=root; database=mydb");

        //---------------------------------------------------


        public MySqlConnection getConnection()
        {
                return connection;
        }



        //iniciar conexão
        public void openConnection()
        {

            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

        }


        //terminar conexão
        public void closeConnection()
        {

            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }

        }

        //returnar conexão

        public MySqlConnection GetConnection()
        { 
            return connection;
        }


    }
}
