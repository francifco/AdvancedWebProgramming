using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc.Contracts;

namespace Mvc
{
    /// <summary>
    /// Contenedor de todas la rutas definidas por el usuario.
    /// </summary>
    public class Router : IRoutes
    {
        string Pattern { get; set; }

        public void RegisterRoutesPattern(string pattern)
        {
            this.Pattern = pattern;
        }

    }
}
