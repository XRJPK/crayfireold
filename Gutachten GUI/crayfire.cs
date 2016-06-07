#define ENABLE_BENCHMARK

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using crayfire.database;

namespace crayfire
{
    class crayfire
    {

        /**         * database object         * @var	\lib\system\database\Database         */

        protected static Database dbObj = null;

        public crayfire()
        {

            this.initDB();
        }

        protected void initDB()
        {
            // get configuration
            string dbHost = "srv02.getpoint.de";
            string dbUser = "Gutachten";
            string dbPassword = "dyzVSB29!";
            string dbName = "KfzGutachten";
            int dbPort = 0;

            // create database connection

            crayfire.dbObj = new MySQLDatabase(dbHost, dbUser, dbPassword, dbName, dbPort);
           // crayfire.dbObj = new MSSQLDatabase(dbHost, dbUser, dbPassword, dbName, dbPort);

        }

        /**         * Returns the database object.
         * 
         * @return	\lib\system\database\Database
         */

        public static  Database getDB()
        {
            return crayfire.dbObj;
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
