using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc
{

    public abstract class FilterAttribute : Attribute
    {
        
    }

    /// <summary>
    /// This attribute is responsive for user-token authentication.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute: Attribute
    {

        /// <summary>
        /// Evaluate user-token.
        /// </summary>
        /// <param name="request">object: Request.</param>
        /// <returns>True: authorized, false: no authorized.</returns>
        public bool IsAuthorized(Request request, AuthorizationUser authUser)
        {
            string token = request.Headers["token"];
            AuthorizationUser generated = Session.GetUserAuthorised(token, authUser.SecretWord);

            if (generated.Password.Equals(authUser.Password) && generated.Username.Equals(authUser.Username))
            {
                return true;
            }

            return false;
        }
        
    }
}
