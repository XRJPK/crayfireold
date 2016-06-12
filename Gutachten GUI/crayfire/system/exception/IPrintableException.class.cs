using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crayfire.system.exception
{
    interface IPrintableException
    {
        /**
         * Prints this exception.
         * This method is called by WCF::handleException().
         */
         void show();
    }
}
