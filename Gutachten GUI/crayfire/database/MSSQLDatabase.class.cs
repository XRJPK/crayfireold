using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using crayfire.database;
using System.Data.SqlClient;

namespace crayfire.database
{
    class MSSQLDatabase  : Database
    {

        protected SqlConnection connection = null;


        public MSSQLDatabase(string host, string user, string password, string database, int port, bool failsafeTest = false) : base(host, user, password, database, port, failsafeTest)
        {
        }
        ~MSSQLDatabase()
        {
            this.connection.Close();
        }
        public override void connect()
        {
            if (this.port == 0) this.port = 1443; // mysql default port
            try
            {
                this.connection = new SqlConnection("server=" + this.host + ";user=" + this.user + ";database=" + this.database + ";port=" + this.port + ";password=" + this.password + ";");
                this.connection.Open();
            }
            catch (SqlException e)
            {
                throw new DatabaseException("Connecting to MySQL server '" + this.host + "' failed:\n" + e.Message, this);
            }

        }

        public override void execute()
        {
            throw new NotImplementedException();
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
