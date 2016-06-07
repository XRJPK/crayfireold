using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crayfire.database
{
    abstract class Database
    {

        /**
         * sql server hostname
         * @var	string
         */
        protected string host = "";
	
       	/**
    	 * sql server post
    	 * @var	integer
	     */
	    protected int port = 0;

        /**
         * sql server login name
         * @var	string
         */
        protected string user = "";

        /**
         * sql server login password
         * @var	string
         */
        protected string password = "";
	
    	/**
	     * database name
	    * @var	string
	    */
	    protected string database = "";


        /**
         * enables failsafe connection
         * @var	boolean
         */
        protected bool failsafeTest = false;
	
    	/**
    	 * number of executed queries
    	 * @var	integer
    	 */
    	protected int queryCount = 0;


        /**
         * Creates a Dabatase Object.
         * 
         * @param	string		$host			SQL database server host address
         * @param	string		$user			SQL database server username
         * @param	string		$password		SQL database server password
         * @param	string		$database		SQL database server database name
         * @param	integer		$port			SQL database server port
         */
        public Database(string host, string user, string password, string database, int port, bool failsafeTest = false)
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

        /**
         * Connects to database server.
         */
        abstract public void connect();


        /**
         * Gets the current database type.
         * 
         * @return	string
         */
        public string getDBType()
        {
            //return nameof(Database);
            return this.GetType().Name;
        }

        /**
         * Gets the sql version.
         * 
         * @return	string
         */
        abstract public string getVersion();
        /**
         * execute the sql query.
         * 
         */
        abstract public void execute();

        /**
         * Returns the number of the last error.
         * 
         * @return	integer
         */
        abstract public int getErrorNumber();

        /**
         * Returns the description of the last error.
         * 
         * @return	string
         */
        abstract public string getErrorDesc();

        /**
         * Increments the query counter by one.
         */
        public void incrementQueryCount()
        {
		this.queryCount++;
        }



    }
}
