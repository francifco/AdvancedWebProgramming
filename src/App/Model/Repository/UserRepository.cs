using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model.Repository
{
    /// <summary>
    /// This class is responsible for the user's repository
    /// </summary>
    public class UserRepository
    {
        /// <summary>
        /// Add a new user into data base.
        /// </summary>
        /// <param name="user">Object: User to add.</param>
        public void AddUser(user User)
        {
            pickurlEntities dbModel = new pickurlEntities();
            dbModel.users.Add(User);
            dbModel.SaveChanges();
            return;
        }

        /// <summary>
        /// verify is exist an username into data base.
        /// </summary>
        /// <param name="userName">string: User name.</param>
        /// <returns>True: If exist, false: not exist.</returns>
        public bool HasUser(string userName)
        {
            pickurlEntities dbModel = new pickurlEntities();

            user UserModel = dbModel.users.First(u => u.username == userName);

            if (string.IsNullOrEmpty(UserModel.username))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// This method get user information by user name.
        /// </summary>
        /// <param name="username">string: username.</param>
        public user GetIdByUsername(string username)
        {
            pickurlEntities dbModel = new pickurlEntities();
            user UserModel = dbModel.users.First(u => u.username == username); 
            return UserModel;
        }

        /// <summary>
        /// This method verify the username and password in data base.
        /// </summary>
        /// <param name="username">string: username.</param>
        /// <param name="password">string: password</param>
        /// <returns>object: user.</returns>
        public user Login(string username, string password)
        {
            pickurlEntities dbModel = new pickurlEntities();
                          
            user User = (from c in dbModel.users
                         where c.username == username && c.password == password
                         select c).FirstOrDefault();

            return User;
        }

        
    }
}
