using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc
{
    /// <summary>
    /// This class is a representative class of a user in the application.
    /// </summary>
    public class AuthorizationUser
    {

       

        /// <summary>
        /// This property represents the user name of user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// This property represents the password of user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// This property represents the secret word for user token.
        /// </summary>
        public string SecretWord { get; set; }

        /// <summary>
        /// This Field represent the lifetime of the session with the token.
        /// </summary>
        public double ExpirationTime;

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="username">string: username</param>
        /// <param name="username">string: password </param>
        /// <param name="secretWord">string: secretWord</param>
        public AuthorizationUser(string username, string password, string secretWord)
        {
            this.Username = username;
            this.Password = password;
            this.SecretWord = secretWord;
        }

    }
}
