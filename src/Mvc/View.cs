using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandlebarsDotNet;

namespace Mvc
{
    /// <summary>
    /// Class responsible for displaying an html view.
    /// </summary>
    public class View : ActionResult
    {

        /// <summary>
        /// Data to send to the view.
        /// </summary>
        object Data;

        /// <summary>
        /// Name of the controller.
        /// </summary>
        string PhysicalPath;

        /// <summary>
        /// Container of specific view name.
        /// </summary>
        string CustomView;

        /// <summary>
        /// Name of the controller;
        /// </summary>
        string ControllerName;

        /// <summary>
        /// Constructor with parameters, start the view with the specified view.
        /// </summary>
        /// <param name="controllerName">string: Name of the controller.</param>
        /// <param name="data">object: data to sent to the view.</param>
        /// <param name="statusCode">string: Status code of view.</param>
        /// <param name="physicalPath">string: App physical path.</param>
        /// <param name="customView">string: Name of custom view, if exist.</param>
        public View(string statusCode, object data, string controllerName, string physicalPath, string customView)
        {
            this.StatusCode = statusCode;
            this.Data = data;
            this.PhysicalPath = physicalPath;
            this.CustomView = customView;
            this.ControllerName = controllerName;
            this.ContentType = "text/html";
        }

        /// <summary>
        /// Get respond to the view with the MemoryStream. 
        /// </summary>
        /// <returns>MemoryStream: Stream data.</returns>
        public override MemoryStream GetRespond()
        {
            string defaultViewPath = this.PhysicalPath + "/Views/" + this.ControllerName;
            string customViewPath = this.PhysicalPath + "/Views/" + this.CustomView;
            byte[] dataDynamicView = null;

            customViewPath += ".html";
            defaultViewPath += ".html";

            if (!string.IsNullOrEmpty(customViewPath) && File.Exists(customViewPath))
            {
                dataDynamicView = File.ReadAllBytes(customViewPath);
            }
            else
            {
                if (File.Exists(defaultViewPath))
                {
                    dataDynamicView = File.ReadAllBytes(defaultViewPath);
                }
                else
                {
                    /// TODO: hacer algo si no existe el view.
                }

            }

            var template = Handlebars.Compile(Encoding.Default.GetString(dataDynamicView));
            var result = template(this.Data);
            return new MemoryStream(Encoding.ASCII.GetBytes(result));
        }

        /// <summary>
        /// Return the GetContent Type. 
        /// </summary>
        /// <returns>string: Content Type</returns>
        public override string GetContentType()
        {
            return this.ContentType;
        }

        /// <summary>
        /// Return the status code. 
        /// </summary>
        /// <returns>int: Status Code.</returns>
        public override string GetStatusCode()
        {
            return this.StatusCode;
        }

    }
}
