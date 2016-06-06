using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Gutachten_GUI.files.lib.system.database
{
    class MySQLDatabase  : Database
    {

        protected  MySqlConnection connection = null;

        public MySQLDatabase(string host, string user, string password, string database, int port, bool failsafeTest = false) : base(host, user, password, database, port, failsafeTest)
        {
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
