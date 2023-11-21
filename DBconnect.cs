using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Proiect
{
    /*
     * Conectez aplicatia mea de mysql 
     */
    class DBconnect
    {
        MySqlConnection connect = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=studentdb");
       

        public MySqlConnection getconnection
        {
            get {
            return connect;
            }
        }
        // functie care deschide conexiunea
        public void openConnect()
        {
            if(connect.State==System.Data.ConnectionState.Closed)
            {
                connect.Open();
            }
        }

        // functie care inchide conexiunea
        public void closeConnect()
        {
            if (connect.State == System.Data.ConnectionState.Open)
            {
                connect.Close();
            }
        }
    }
}
