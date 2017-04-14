using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PHttp;

namespace Mvc
{
    /// <summary>
    /// This class is the father class for all controllers.
    /// </summary>
    public class BaseController
    {

        /// <summary>
        /// Physical Path of Application.
        /// </summary>
        public string AppPhysicalPath { get; set; }

        /// <summary>
        /// Controller Name.
        /// </summary>
        string ControllerName { get; set; }

        /// <summary>
        /// This property represents all requests received by controller.
        /// </summary>
        Request request;

        /// <summary>
        /// This Property is the context of the server to controllers.
        /// </summary>
        public HttpContext httpContext { get; set; }

        /// <summary>
        /// This property provides route management within the controller context.
        /// </summary>
        public Route Route { get; set; }

        /// <summary>
        /// This property handles the session dictionary.
        /// </summary>
        public Dictionary<string, string> Session { get; set; }

        /// <summary>
        /// This property is for the handling of the authentication 
        /// with the server.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BaseController() { }

        
        /// <summary>
        /// Send a json object.
        /// </summary>
        /// <param name="statusCode">string: status code.</param>
        /// <param name="strJsonObject">string: json string.</param>
        /// <returns>MemoryStream for the response with json content.</returns>
        public ActionResult JsonResult(string statusCode, string strJsonObject)
        {
            return new JsonResult(statusCode, strJsonObject);
        }

        /// <summary>
        /// Show a Dynamic view with content received.
        /// </summary>
        /// <param name="statusCode">string: Status code of request.</param>
        /// <param name="data">string: Data send to the view.</param>
        /// <param name="customView">string: Custom view name. If no send vie name, show default view.</param>
        /// <returns>A view with data received.</returns>
        public ActionResult View(string statusCode, object Object, string customView = "")
        {
            string controllerName = Route.ControllerName.ToLower();

            if (controllerName.Contains("controller"))
            {
                controllerName = controllerName.Replace("controller", "");
            }
            
            return new View(statusCode, Object, controllerName, AppPhysicalPath, customView);
        }


    }

    
}
