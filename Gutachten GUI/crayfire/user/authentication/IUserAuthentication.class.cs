using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using crayfire.data.user;

//Every user authentication has to implement this interface.

namespace crayfire.system.user.authentication
{
    interface IUserAuthentication
    {

        IUserAuthentication getInstance();

        /**
         * Returns true if this authentication supports persistent logins.
         * 
         * @return	boolean
         */
        bool supportsPersistentLogins();

        /**
         * Stores the user access data for a persistent login.
         * 
         * @param	crayfire.data.user	user
         * @param	string			username
         * @param	string			password
         */
        void storeAccessData(User user, string username, string password);

        /**
         * Does a manual user login.
         * 
         * @param	string		$username
         * @param	string		$password
         * @param	string		$userClassname		class name of user class
         * @return	\crayfire\data\user\User
         */
         User loginManually(string username, string password, string userClassname = "crayfire.data.user.User");

        /**
         * Does a user login automatically.
         * 
         * @param	boolean		$persistent		true = persistent login
         * @param	string		$userClassname		class name of user class
         * @return	\wcf\data\user\User
         */
         User loginAutomatically(bool persistent = false, string userClassname = "crayfire.data.user.User");
    }
}
