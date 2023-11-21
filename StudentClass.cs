using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System.Data;

namespace Proiect
{
     class StudentClass
    {
        DBconnect connect = new DBconnect();
        // functie care adauga studenti in baza de date

        public bool insertStudent(string n, string p, DateTime data, string telephone, string address, string gender, byte[] img)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `student`( `StudentNume`, `StudentSex`, `StudentPrenume`, `StudentTelefon`, `DataDeNastere`, `StudentAdresa`, `StudentPoza`) VALUES (@fn,@gn,@ln,@ph,@bd,@adr,@img)",connect.getconnection);
           
            //@fn,@gn,@ln,@ph,@bd,@adr,@img
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = n;
            command.Parameters.Add("@gn", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = p;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = telephone;
            command.Parameters.Add("@bd", MySqlDbType.Date).Value = data;
            command.Parameters.Add("@adr", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@img", MySqlDbType.Blob).Value = img;

            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }

        }
        // pentru a lua tabelul student
        public DataTable getStudentlist()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `student`", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
