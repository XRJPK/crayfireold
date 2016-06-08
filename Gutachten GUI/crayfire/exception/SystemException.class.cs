using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crayfire.exception
{
    class SystemException : LoggedException, IPrintableException
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



         public SystemException(string message = "", int code = 0, string description = "", Exception e = null)
        {
         
        }

        public void show()
        {
            throw new NotImplementedException();
        }
    }
}
