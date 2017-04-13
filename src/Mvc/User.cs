using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc
{
    /// <summary>
    /// clase respresentante de un usuario en la aplicacion.
    /// </summary>
    public class User
    {
        /// <summary>
        /// "Field" del nombre de usuario.
        /// </summary>
        string UserName { get; set; }

        /// <summary>
        /// "Field': clave del usuario.
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// "Field': token del usuario.
        /// </summary>
        string token { get; set; }
    }
}
