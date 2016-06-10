using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using crayfire.exception;

namespace crayfire.database
{
    /**
     * TO-DO 
     *  - public void show()  überschreibt die SystemException.show ? 
     *  - Wieso ist die DatabaseException der database zugeornet? und nicht der exception? 
     */
    class DatabaseException : exception.SystemException
    {
    /**
	 * error number
	 * @var	integer
	 */
    protected int errorNumber = 0;
	
	/**
	 * error description
	 * @var	string
	 */
	protected string errorDesc = null;
	
	/**
	 * sql version number
	 * @var	string
	 */
	protected string sqlVersion = null;
	
	/**
	 * sql type
	 * @var	string
	 */
	protected string DBType = null;
	
	/**
	 * database object
	 * @var	\lib\system\database\Database
	 */
	protected Database db = null;
	
	
	/**
	 * SQL query if prepare() failed
	 * @var	string
	 */
	protected string sqlQuery = null;
	
	/**
	 * Creates a new DatabaseException.
	 * 
	 * @param	string							                    $message		    error message
	 * @param	\lib\system\database\Database				        $db			        affected db object
	 * @param	\lib\system\database\statement\PreparedStatement	$preparedStatement	affected prepared statement
	 * @param	string							                    $sqlQuery		    SQL query if prepare() failed
	 */
	public DatabaseException(string message, Database db, string sqlQuery = null)
    {
		this.db = db;
		this.DBType = db.getDBType();
		this.sqlQuery = sqlQuery;

		this.errorNumber = this.db.getErrorNumber();
		this.errorDesc = this.db.getErrorDesc();

        // new exception.SystemException(message, this.errorNumber);
    }

    /**
	 * Returns the error number of this exception.
	 * 
	 * @return	integer
	 */
    public int getErrorNumber()
    {
        return this.errorNumber;
    }

    /**
	 * Returns the error description of this exception.
	 * 
	 * @return	string
	 */
    public string getErrorDesc()
    {
        return this.errorDesc;
    }

    /**
	 * Returns the current sql version of the database.
	 * 
	 * @return	string
	 */
    public string getSQLVersion()
    {
        if (this.sqlVersion == null) {
            try
            {
				this.sqlVersion = this.db.getVersion();
            }
            catch (DatabaseException) {
				this.sqlVersion = "unknown";
            }
            }

            return this.sqlVersion;
        }

    /**
	 * Returns the sql type of the active database.
	 * 
	 * @return	string
	 */
    public string getDBType()
    {
        return this.DBType;
    }

    /**
	 * Prints the error page.
	 */
    public void show()
    {
		this.information+="sql type: "+this.getDBType()+"\r\n";
		this.information+="sql error: "+this.getErrorDesc()+"\r\n";
        this.information+="sql error number: "+this.getErrorNumber() + "\r\n";
        this.information+="sql version: "+this.getSQLVersion() + "\r\n";

			this.information+= "sql query: "+this.sqlQuery + "\r\n";

            System.Windows.MessageBox.Show(this.information);
            show(); 
    }
}
}
