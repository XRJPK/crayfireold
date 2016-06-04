using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gutachten_GUI.files.lib.system.database;

namespace Gutachten_GUI.files.lib.system.database
{
    class MSSQLDatabase  : Database
    {

        public void connect()
        {
            if (this.port == 0) this.port = 1433; // mssql default port

        }



    }
}
