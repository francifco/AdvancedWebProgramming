using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc
{

    /// <summary>
    /// This class is the representation of request content.
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Controller name.
        /// </summary>
        string ControllerName { get; set; }
         
        /// <summary>
        /// Action name of the controller.
        /// </summary>
        List<string> ActionsName;

        /// <summary>
        /// Parameters of the request.
        /// </summary>
        List<string> Parameters;

        public Request()
        {
            ActionsName = new List<string>();
            Parameters = new List<string>();
        }

    }
}
