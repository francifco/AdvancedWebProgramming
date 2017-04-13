using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc;

namespace Mvc
{
    /// <summary>
    /// This class is responsible of all the routes defined by the user.
    /// </summary>
    public class Route
    {

        /// <summary>
        /// Parameters of route.
        /// </summary>
        public List<string> parameters { get; set; }

        /// <summary>
        /// Controller name of route.
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// Action name of route.
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// Pattern for all route.
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// Path of URL.
        /// </summary>
        public string UrlPath { get; set; }

        /// <summary>
        /// Method Http: httpGet, httpSet, httpPost, httpPut, etc.
        /// </summary>
        public string HttpMethod { get; set; }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="httpMethod">string: Name of  Method Action.</param>
        /// <param name="controllerName">string: Name of controller</param>
        /// <param name="action">string: Name of cation of the controller.</param>
        /// <param name="path">string: Physical path of the controller</param>
        public Route(string httpMethod, string controllerName, string action, string path)
        {
            this.UrlPath = path;
            this.HttpMethod = httpMethod;
            this.ControllerName = controllerName;
            this.ActionName = action;
        }

        /// This method register the pattern         
        public void RegisterRoutesPattern(string pattern)
        {
            this.Pattern = pattern;
        }
       
    }
}
