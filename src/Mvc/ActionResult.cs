using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Mvc
{
    /// <summary>
    /// This class is the father class to identify and return Different respond in the 
    /// view. "JSON content", "Text content" and "Dynamical HTML view".
    /// </summary>
    public abstract class ActionResult: IActionResult
    {

        /// <summary>
        /// This field Represents the content type.
        /// </summary>
        public string ContentType;

        /// <summary>
        /// Name of the view to show. 
        /// </summary>
        public string ViewName;

        /// <summary>
        /// This filed represents the respond status code. 
        /// </summary>
        public string StatusCode;

        /// <summary>
        /// This field is the Data string.
        /// </summary>
        public string StrData;

        /// <summary>
        /// This field is the content of the data for the respond. 
        /// </summary>
        public byte[] Data;

        /// <summary>
        /// Get respond to the view with the MemoryStream.
        /// </summary>
        /// <returns>MemoryStream: Stream data.</returns>
        abstract public MemoryStream GetRespond();

        /// <summary>
        /// Return content type of the respond.
        /// </summary>
        /// <returns>string: Content type.</returns>
        abstract public string GetContentType();

        /// <summary>
        /// Return the status code of the respond.
        /// </summary>
        /// <returns>int: status code</returns>
        abstract public string GetStatusCode();
        
    }
}
