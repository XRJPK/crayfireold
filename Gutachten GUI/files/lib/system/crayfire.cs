#define ENABLE_BENCHMARK

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gutachten_GUI.files.lib.system.database;

namespace Gutachten_GUI.files.lib.system
{
    class crayfire
    {

        /**         * database object         * @var	\wcf\system\database\Database         */

        protected static Database dbObj = null;

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

            crayfire.dbObj = new MySQLDatabase(dbHost, dbUser, dbPassword, dbName, dbPort);
           // crayfire.dbObj = new MSSQLDatabase(dbHost, dbUser, dbPassword, dbName, dbPort);



        }

        /**         * Returns true if benchmarking is enabled, otherwise false.         * 
         * @return	boolean
         */

        public static bool benchmarkIsEnabled()
        {
            // benchmarking is enabled by default
            #if ENABLE_BENCHMARK
                return true;
            #else
                
            return false;
            #endif

        }

    }
}
