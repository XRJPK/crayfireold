using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crayfire.data.database
{
    class DatabaseObject : IStorableObject
    {
        /**
        * database table for this object
        * @var	string
        */
        protected static string databaseTableName = "";
        /**
        * indicates if database table index is an identity column
        * @var	boolean
        */
        protected static bool databaseTableIndexIsIdentity = true;
        /**
        * name of the primary index column
        * @var	string
        */
        protected static string databaseTableIndexName = "";
        /**
        * sort field
        * @var	mixed
        */
        protected static string sortBy = "";
        /**
        * sort order
        * @var	mixed
        */
        protected static string sortOrder = "";
        /**
        * object data
        * @var	array
        */
        Dictionary<string, string> data = new Dictionary<string, string>();

        public DatabaseObject()
        {

        }
        public Dictionary<string, string> getData()
        {
            return this.data;
        }

        public static string getDatabaseTableAlias()
        {
            return databaseTableName;
        }

        public bool getDatabaseTableIndexIsIdentity()
        {
            return databaseTableIndexIsIdentity;
        }

        public string getDatabaseTableIndexName()
        {
            return databaseTableIndexName;
        }

        public string getDatabaseTableName()
        {
            return "crayfire_"+databaseTableName;
        }

        public string __get(string name)
        {
            if (!String.IsNullOrEmpty(this.data[name]))
            {
                return this.data[name];
            }
            else
            {
                return null;
            }
        }

        public bool __isset(string name)
        {
            return !String.IsNullOrEmpty(this.data[name]);
        }
    }
}
