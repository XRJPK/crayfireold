using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutachten_GUI.files.lib.system.database
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
    }
}
