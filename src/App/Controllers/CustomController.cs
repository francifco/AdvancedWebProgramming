using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc;
using Newtonsoft.Json.Linq;

namespace App.Controllers
{
    public class CustomController : BaseController
    {
        /// <summary>
        /// This action send json object to the view.
        /// </summary>
        /// <returns>JObject: json content.</returns>
        [HttpGet]
        public ActionResult MessageJson()
        {
            string message = "Hola test.";
            
            return new ContentResult("200", message);
        }
    }
}
