using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mvc
{
    /// <summary>
    /// This Class is responsible for displaying plain text in the view. 
    /// </summary>
    public class ContentResult: ActionResult
    {

        /// <summary>
        /// Constructor with parameter: Status code and text string.
        /// </summary>
        /// <param name="statusCode">int: Status Code.</param>
        /// <param name="strData">string: Text string.</param>
        public ContentResult(string statusCode, string strData)
        {
            this.StatusCode = statusCode;
            this.StrData = strData;
            this.ContentType = "text/plain";
        }

        /// <summary>
        /// This method create a MemoryStream for the respond with text content.
        /// </summary>
        /// <returns>MemoryStream: memory stream with text content.</returns>
        public override MemoryStream GetRespond()
        {
            return new MemoryStream(Encoding.ASCII.GetBytes(this.StrData));
        }

        /// <summary>
        /// This method returns the content type for the respond
        /// </summary>
        /// <returns>string: the Content type.</returns>
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
