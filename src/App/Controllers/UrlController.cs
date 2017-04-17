using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc;
using System.Net;
using System.IO;

namespace App.Controllers
{
    /// <summary>
    /// This controller is for Url management.
    /// </summary>
    public class UrlController: BaseController
    {

        /// <summary>
        /// This action is for creation of shorted url.
        /// </summary>
        /// <returns>string: a Shorted Url.</returns>
        [Authorize]
        [HttpGet]
        public ActionResult GetURL()
        {
            string LargeUrl = (string)Request.Params["url"];
            string ShortedUrl = Helpers.GoogleUrlShortnerApi.Shorten(LargeUrl);

            object respond = new { shorted = ShortedUrl }; 

            return new JsonResult("200", respond);
        }
    }
}
