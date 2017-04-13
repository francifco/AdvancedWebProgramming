using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Mvc
{
    /// <summary>
    /// This class is responsible for showing a json data in a view.
    /// </summary>
    public class JsonResult: ActionResult
    {
        /// <summary>
        /// constructor with parameter: string: json.
        /// </summary>
        /// <param name="statusCode">int: Status Code of the respond.</param>
        /// <param name="jsonString">string: Json contain. </param>
        public JsonResult(string statusCode, string jsonString)
        {
            this.StatusCode = statusCode;
            this.StrData = jsonString;
            this.ContentType = "application/json";
        }

        /// <summary>
        /// constructor with parameter: Object: json.
        /// </summary>
        /// <param name="statusCode">int: Status Code of the respond.</param>
        /// <param name="jsonObject">object: Json contain. </param>
        public JsonResult(string statusCode, object jsonObject)
        {
            this.StatusCode = statusCode;
            ///probar esto
            this.StrData = jsonObject.ToString();
            this.ContentType = "application/json";
        }

        /// <summary>
        /// This method create a MemoryStream for the respond with json content.
        /// </summary>
        /// <returns>MemoryStream for the response with json content.</returns>
        public override MemoryStream GetRespond()
        {
            return new MemoryStream(Encoding.ASCII.GetBytes(this.StrData));
        }

        /// <summary>
        /// Returns the content type for the respond.
        /// </summary>
        /// <returns>string: the Content Type.</returns>
        public override string GetContentType()
        {
            return this.ContentType;
        }

        /// <summary>
        /// Returns the Status Code for the respond.
        /// </summary>
        /// <returns>int: The Status Code.</returns>
        public override string GetStatusCode()
        {
            return this.StatusCode;
        }

    }
}
