using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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
            try
            {
                this.connection = new MySqlConnection("server=" + this.host + ";user=" + this.user + ";database=" + this.database + ";port=" + this.port + ";password=" + this.password + ";");
                this.connection.Open();
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
            throw new NotImplementedException();
        }

        public override int getErrorNumber()
        {
            throw new NotImplementedException();
        }

        public override string getVersion()
        {
            throw new NotImplementedException();
        }
    }
}
