using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gutachten_GUI.files.lib.system.database;

namespace Gutachten_GUI.files.lib.system.exporter
{
    public abstract class AbstractExporter : IExporter
    {
        /**
         * additional data
         * @var	array
         */
        public string[] additionalData = array();

        /**
         * database host name
         * @var	string
         */
        protected string databaseHost = "";
	
	/**
	 * database username
	 * @var	string
	 */
	protected string databaseUser = "";
	
	/**
	 * database password
	 * @var	string
	 */
	protected string databasePassword = "";
	
	/**
	 * database name
	 * @var	string
	 */
	protected string databaseName = "";
	
	/**
	 * table prefix
	 * @var	string
	 */
	protected string databasePrefix = "";
	
	/**
	 * file system path
	 * @var	string
	 */
	protected string fileSystemPath = "";
	
	/**
	 * database connection
	 * @var	\lib\system\database\Database
	 */
	protected Database database = null;
	
	/**
	 * object type => method names
	 * @var	array
	 */
	protected object methods = array();

        /**
         * limits for items per run
         * @var	array<integer>
         */
        protected int[] limits = array();

        /**
         * default limit for items per run
         * @var	integer
         */
        protected int defaultLimit = 1000;
	
	/**
	 * selected import data
	 * @var	array
	 */
	protected string selectedData = array();

        /**
         * @see	\lib\system\exporter\IExporter::setData()
         */
        public void setData(string databaseHost, string databaseUser, string databasePassword, string databaseName, string databasePrefix, string fileSystemPath, string[] additionalData)
        {
		this.databaseHost = databaseHost;
		this.databaseUser = databaseUser;
		this.databasePassword = databasePassword;
		this.databaseName = databaseName;
		this.databasePrefix = databasePrefix;
		//this.fileSystemPath = (fileSystemPath  !="" ? FileUtil::addTrailingSlash(fileSystemPath) : "");
		this.additionalData = additionalData;
        }

        /**
         * @see	\lib\system\exporter\IExporter::init()
         */
        public init()
        {
		protected string host = base.databaseHost;
		protected int port = 0;
            if(preg_match('~^([0-9.]+):([0-9]{1,5})$~', host, matches))
            {
			// simple check, does not care for valid ip addresses
			host = matches[1];
			port = matches[2];
            }
		
		this.database = new MySQLDatabase(string host, this.databaseUser, this.databasePassword, this.databaseName, port);
        }

        /**
         * @see	\lib\system\exporter\IExporter::validateDatabaseAccess()
         */
        public void validateDatabaseAccess()
        {
		this.init();
        }

        /**
         * @see	\lib\system\exporter\IExporter::getDefaultDatabasePrefix()
         */
        public string getDefaultDatabasePrefix()
        {
            return "";
        }

        /**
         * @see	\lib\system\exporter\IExporter::countLoops()
         */
        public function countLoops($objectType)
        {
            if (!isset($this->methods[$objectType]) || !method_exists($this, 'count'.$this->methods[$objectType]))
            {
                throw new SystemException("unknown object type '".$objectType."' given");
            }
		
		$count = call_user_func(array($this, 'count'.$this->methods[$objectType]));
		$limit = (isset($this->limits[$objectType]) ? $this->limits[$objectType] : $this->defaultLimit);
            return ceil($count / $limit);
        }

        /**
         * @see	\wcf\system\exporter\IExporter::exportData()
         */
        public function exportData($objectType, $loopCount = 0)
        {
            if (!isset($this->methods[$objectType]) || !method_exists($this, 'export'.$this->methods[$objectType]))
            {
                throw new SystemException("unknown object type '".$objectType."' given");
            }
		
		$limit = (isset($this->limits[$objectType]) ? $this->limits[$objectType] : $this->defaultLimit);
            call_user_func(array($this, 'export'.$this->methods[$objectType]), $loopCount * $limit, $limit);
        }

        /**
         * @see	\wcf\system\exporter\IExporter::validateSelectedData()
         */
        public function validateSelectedData(array $selectedData)
        {
		$this->selectedData = $selectedData;

            if (!count($this->selectedData))
            {
                return false;
            }
		
		$supportedData = $this->getSupportedData();
            foreach ($this->selectedData as $name) {
                if (isset($supportedData[$name])) break;

                foreach ($supportedData as $key => $data) {
                    if (in_array($name, $data))
                    {
                        if (!in_array($key, $selectedData)) return false;

                        break 2;
                    }
                }

                return false;
            }

            return true;
        }

        /**
         * Gets the max value of a specific column.
         * 
         * @param	string		$tableName
         * @param	string		$columnName
         * @return	integer
         */
        protected int __getMaxID(string tableName,string columnName)
        {
		sql = "SELECT	MAX("+columnName+") AS maxID FROM "+tableName;
    		statement = this.database.prepareStatement(sql);
		statement.execute();
		$row = $statement->fetchArray();
            if ($row !== false) return $row['maxID'];
            return 0;
        }
    }
}
