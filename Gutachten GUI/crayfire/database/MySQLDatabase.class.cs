using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;
using crayfire.exception;

namespace crayfire.database
{
    class MySQLDatabase  : Database
    {

        protected  MySqlConnection connection = null;

        public MySQLDatabase(string host, string user, string password, string database, int port, bool failsafeTest = false) : base(host, user, password, database, port, failsafeTest)
        {
            this.host = host;
            this.port = port;
            this.user = user;
            this.password = password;
            this.database = database;
            this.failsafeTest = failsafeTest;
            // connect database
            this.connect();
        }

        ~MySQLDatabase()
        {
            this.connection.Close();
        }

        public override void connect()
        {
            if (this.port == 0) this.port = 3306; // mysql default port
                this.connection = new MySqlConnection("server=" + this.host + ";user=" + this.user + ";database=" + this.database + ";port=" + this.port + ";password=" + this.password + ";");
            try
            {
                this.connection.Open();
                //create a MySQL connection with a query string
                MySqlConnection connection = new MySqlConnection("server=localhost;database=cs;uid=root;password=abcdaaa");

                //open the connection
                connection.Open();
            }
            catch (MySqlException e)
            {
                throw new DatabaseException("Connecting to MySQL server '"+this.host+"' failed:\n"+e.Message, this);
            }

        }

        public override void execute()
        {
            
        }

        public override string getErrorDesc()
        {
            return "xx";        }

        public override int getErrorNumber()
        {
            return 0;
        }

        public override string getVersion()
        {
            throw new NotImplementedException();
        }
    }
}
