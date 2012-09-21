using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MySecurity.Security
{
    public class UserRepository : IUserRepository
    {
        private List<ISitePrincipal> existingUsers;

        public UserRepository()
        {
            string[] adminRoles = { "Admin", "SuperUser", "User" };
            string[] bensRoles = { "SuperUser", "User" };

            this.existingUsers = new List<ISitePrincipal>
            {
                new SitePrincipal("Admin", BCrypt.Net.BCrypt.HashPassword("Admin", BCrypt.Net.BCrypt.GenerateSalt(12)), adminRoles),
                new SitePrincipal("Ben", BCrypt.Net.BCrypt.HashPassword("Ben", BCrypt.Net.BCrypt.GenerateSalt(12)), bensRoles),
            };
        }


        ISitePrincipal IUserRepository.GetByUserName(string userName)
        {
            return this.GetByUserName(userName);
        }

        ISitePrincipal IUserRepository.CreateUser(string userName, string password)
        {
            throw new NotImplementedException();
        }

        private ISitePrincipal GetByUserName(string userName)
        {
            return this.existingUsers.FirstOrDefault(u => u.Username == userName);
        }




    }

}