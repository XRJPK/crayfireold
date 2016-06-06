using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutachten_GUI.files.lib.system.exception
{
    class SystemException : Exception
    {

        /**
         * error description
         * @var	string
         */
        protected string description = "";
	
	    /**
	     * additional information
	    * @var	string
	    */
	    protected string information = "";



         public SystemException(string message = "", int code = 0, string description = "", Exception e=null)
        {
         
        }
    }
}
