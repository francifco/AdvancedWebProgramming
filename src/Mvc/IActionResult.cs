using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mvc
{
    public interface IActionResult
    {
        /// <summary>
        /// Get respond to the view with the MemoryStream.
        /// </summary>
        /// <returns>object: Stream data.</returns>
        object GetRespond();

        /// <summary>
        /// Return content type of the respond.
        /// </summary>
        /// <returns>string: Content type.</returns>
        string GetContentType();

        /// <summary>
        /// Return the status code of the respond.
        /// </summary>
        /// <returns>int: status code</returns>
        string GetStatusCode();
    }
}
