using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using crayfire.data.user;

namespace crayfire.system.user.authentication
{
    class AbstractUserAuthentication : IUserAuthentication
    {
        public IUserAuthentication getInstance(){
            throw new NotImplementedException();
        }

        public User loginAutomatically(bool persistent = false, string userClassname = "crayfire.data.user.User")
        {
            throw new NotImplementedException();
        }

        public User loginManually(string username, string password, string userClassname = "crayfire.data.user.User")
        {
            throw new NotImplementedException();
        }

        public void storeAccessData(User user, string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool supportsPersistentLogins()
        {
            throw new NotImplementedException();
        }
    }
}
