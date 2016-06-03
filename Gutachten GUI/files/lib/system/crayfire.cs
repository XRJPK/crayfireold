using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutachten_GUI.files.lib.system
{
    class crayfire
    {
        public crayfire()
        {

            this.initDB();
        }

        protected void initDB()
        {
            // get configuration

            string dbHost = "";
            string dbUser = "";
            string dbPassword = "";
            string dbName = "";
            int dbPort = 0;

            // create database connection

            crayfire.dbObj = new $dbClass($dbHost, $dbUser, $dbPassword, $dbName, $dbPort);



        }
    }
}
