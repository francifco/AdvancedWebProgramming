using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc
{
    /// <summary>
    /// clase encargada de las vistas en el html deacuerdo a la data recibida:
    /// json, html, etc.
    /// </summary>
    public class ViewEngine: ActionResult
    {
        ViewEngine View()
        {
            return this;
        }
    }
}
