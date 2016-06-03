using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

/*
 Hauptklasse für MySQL Verbindung für Programm.
    */
namespace Gutachten_GUI
{
    class MySQL
    {
        private string myConnectionString = "SERVER=srv01.getpoint.de;" + "DATABASE=KfzGutachten;" + "UID=Gutachten;" + "PASSWORD=dyzVSB29!;";
        Errors Erros = new Errors();

        public void OpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(myConnectionString);
            try {
                connection.Open();
            }
            catch (Exception Ex)
            {
                Erros.WriteToLog(Ex);
            }
            
        }

        public void CloseConnection()
        {
            MySqlConnection connection = new MySqlConnection(myConnectionString);
            try
            {
                connection.Close();
            }
            catch (Exception Ex)
            {
                Erros.WriteToLog(Ex);
            }

        }

        public void myCommand()
        {
            // MySqlCommand command = connection.CreateCommand();
            // command.CommandText = "SELECT * FROM mytable";
           //  MySqlDataReader Reader;
        }

        public string getServer()
        {
            return "srv01.getpoint.de";
        }
        public string getDatabase()
        {
            return "KfzGutachten";
        }
    }
}
