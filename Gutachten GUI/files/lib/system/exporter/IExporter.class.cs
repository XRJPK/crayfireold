using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutachten_GUI.files.lib.system.exporter
{
    interface IExporter
    {
        /**
         * Sets database access data.
         * 
         * @param	string			databaseHost
         * @param	string			databaseUser
         * @param	string			databasePassword
         * @param	string			databaseName
         * @param	string			databasePrefix
         * @param	string			fileSystemPath
         * @param	array<string>	additionalData
         */
        void setData(string databaseHost, string databaseUser, string databasePassword, string databaseName, string databasePrefix, string fileSystemPath, string[] additionalData);

        /**
         * Initializes this exporter.
         */
        void init();

        /**
         * Counts the number of required loops for given type.
         * 
         * @param	string		$objectType
         * @return	integer
         */
         int countLoops(string objectType);

        /**
         * Runs the data export.
         * 
         * @param	string		$objectType
         * @param	integer		$loopCount
         */
        void exportData(string objectType, int loopCount = 0);

        /**
         * Validates database access.
         * 
         * @throws	lib\system\database\DatabaseException
         */
        void validateDatabaseAccess();

        /**
         * Validates given file system path. Returns false on failure.
         * 
         * @return	boolean
         */
        bool validateFileAccess();

        /**
         * Validates the selected data types. Returns false on failure.
         * 
         * @param	string[]		$selectedData
         * @return	boolean
         */
        bool validateSelectedData(string[] selectedData);

        /**
         * Returns the import worker queue.
         * 
         * @return	array<string>
         */
        string[] getQueue();

        /**
         * Returns the supported data types.
         * 
         * @return	array<string>
         */
        string[] getSupportedData();

        /**
         * Returns a default database table prefix.
         * 
         * @return	string
         */
        string getDefaultDatabasePrefix();
    }
}