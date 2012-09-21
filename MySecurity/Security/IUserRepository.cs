using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySecurity.Security
{
    public interface IUserRepository
    {
        ISitePrincipal GetByUserName(string userName);
        ISitePrincipal CreateUser(string userName, string password);
    }
}
