using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crayfire.data
{
    interface IStorableObject
    {
        /**
        * Returns the value of a object data variable with the given name.
        * 
        * @param	string		$name
        * @return	mixed
        */
        string __get(string name);

        /**
        * Determines if the object data variable with the given name is set and
        * is not NULL.
        * 
        * @param	string		$name
        * @return	boolean
        */
        bool __isset(string name);

        /**
        * Returns the value of all object data variables.
        * 
        * @deprecated	This method was introduced for a function in AJAXProxy that is deprecated.
        * @return	array		array<value>
        */
        string[] getData();

        /**
         * Returns the name of the database table.
         * 
         * @return	string
         */
        string getDatabaseTableName();

        /**
         * Returns the alias of the database table.
         * 
         * @return	string
         */
        string getDatabaseTableAlias();

        /**
         * Returns true if database table index is an identity column.
         * 
         * @return	boolean
         */
        bool getDatabaseTableIndexIsIdentity();

        /**
         * Returns the name of the database table index.
         * 
         * @return	string
         */
        string getDatabaseTableIndexName();
    }
}
