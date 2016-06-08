using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gutachten_GUI.files.lib.system;
using Gutachten_GUI.files.lib.system.database;

namespace Gutachten_GUI.files.lib.system.database.statement
{
    class PreparedStatement
    {
        /**
         * database object
         * @var	\lib\system\database\Database
         */
        protected Database database = null;
	
	/**
	 * SQL query parameters
	 * @var	array
	 */
	protected string[] parameters;

        /**
         * pdo statement object
         * @var	\PDOStatement
         */
        protected string statement = "";
	
	/**
	 * SQL query
	 * @var	string
	 */
	protected string query = "";
	
	/**
	 * Creates a new PreparedStatement object.
	 * 
	 * @param	\wcf\system\database\Database	$database
	 * @param	\PDOStatement			$pdoStatement
	 * @param	string				$query		SQL query
	 */
	public void PreparedStatement(Database database, string statement, string query = "")
        {
		this.database = database;
		this.statement = statement;
		this.query = query;
        }

        /**
         * Delegates inaccessible methods calls to the decorated object.
         * 
         * @param	string		$name
         * @param	array		$arguments
         * @return	mixed
         */
        public void __call(string name, string[] arguments)
        {
            if (!method_exists(this.pdoStatement, name))
            {
                throw new SystemException("unknown method '"+name+"'");
            }

            try
            {
                return call_user_func_array(array(this.pdoStatement, name), arguments);
            }
            catch (Exception e) {
                throw new DatabaseException("Could not handle prepared statement: "+e.getMessage(), this.database, this);
            }
            }

    /**
	 * Executes a prepared statement.
	 * 
	 * @param	array		$parameters
	 */
    public void execute(string[] parameters)
        {
		this.parameters = parameters;
		this.database.incrementQueryCount();
            /*
            * Benchmark is not using now
             * 
            try
            {
                if (crayfire.benchmarkIsEnabled()) Benchmark::getInstance()->start($this->query, Benchmark::TYPE_SQL_QUERY);

                if (empty($parameters)) $this->pdoStatement->execute();
			else $this->pdoStatement->execute($parameters);

                if (WCF::benchmarkIsEnabled()) Benchmark::getInstance()->stop();
            }
            catch (\PDOException $e) {
                if (WCF::benchmarkIsEnabled()) Benchmark::getInstance()->stop();

                throw new DatabaseException('Could not execute prepared statement: '.$e->getMessage(), $this->database, $this);
            }
            */
            }



        /**
         * Fetches the next row from a result set in an array.
         * 
         * @param	integer		$type		fetch type
         * @return	mixed
         */
        public function fetchArray(type = null)
        {
            // get fetch style
            if ($type == null) type = \PDO::FETCH_ASSOC;

            return this.fetch($type);
        }

        /**
         * Fetches the next row from a result set in an array.
         * Closes the 'cursor' afterwards to free up the connection
         * for new queries.
         * Note: It is not possible to fetch further rows after calling
         * this method!
         * 
         * @param	integer		$type		fetch type
         * @return	mixed
         * @see		\wcf\system\database\statement\PreparedStatement::fetchArray()
         */
        public function fetchSingleRow(type = null)
        {
		row = this.fetchArray($type);
		this.closeCursor();

            return row;
        }

        /**
         * Returns the specified column of the next row of a result set.
         * Closes the 'cursor' afterwards to free up the connection
         * for new queries.
         * Note: It is not possible to fetch further rows after calling
         * this method!
         * 
         * @param	integer		$columnNumber
         * @return	mixed
         * @see		\PDOStatement::fetchColumn()
         */
        public object fetchSingleColumn(int columnNumber = 0)
        {
		column = this.fetchColumn(columnNumber);
		this.closeCursor();

            return column;
        }

        /**
         * Fetches the next row from a result set in a database object.
         * 
         * @param	string			$className
         * @return	\wcf\data\DatabaseObject
         */
        public Database fetchObject(string className)
        {
		$row = $this->fetchArray();
            if ($row !== false) {
                return new $className(null, $row);
            }

            return null;
        }

        /**
         * Fetches the all rows from a result set into database objects.
         * 
         * @param	string			$className
         * @return	array<\wcf\data\DatabaseObject>
         */
        public Database fetchObjects(string className)
        {
		objects = array();
            while ($object = $this->fetchObject($className)) {
			$objects[] = $object;
            }

            return objects;
        }

        /**
         * Counts number of affected rows by the last sql statement (INSERT, UPDATE or DELETE).
         * 
         * @return	integer		number of affected rows
         */
        public int getAffectedRows()
        {
            try
            {
                return this.statement.rowCount();
            }
            catch (Exception e) {
                throw new DatabaseException("Can not fetch affected rows: "+e.getMessage(), this);
            }
            }

    /**
	 * Returns the number of the last error.
	 * 
	 * @return	integer
	 */
    public int getErrorNumber()
        {
            if ($this->pdoStatement !== null) return $this->pdoStatement->errorCode();

            return 0;
        }

        /**
         * Returns the description of the last error.
         * 
         * @return	string
         */
        public string getErrorDesc()
        {
            if (this.statement != null) {
			errorInfoArray = this.statement.errorInfo();
                if (isset($errorInfoArray[2])) return errorInfoArray[2];
            }

            return "";
        }

        /**
         * Returns the SQL query of this statement.
         * 
         * @return	string
         */
        public string getSQLQuery()
        {
            return this.query;
        }

        /**
         * Returns the SQL query parameters of this statement.
         * 
         * @return	array
         */
        public string[] getSQLParameters()
        {
            return this.parameters;
        }
    }
}
