using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc;
using Newtonsoft.Json.Linq;

namespace App
{
    /// <summary>
    /// Controller for test
    /// </summary>
    public class HomeController : BaseController
    {

        /// <summary>
        /// This action send a string with json format.
        /// </summary>
        /// <returns>string: json content.</returns>
        [HttpGet]
        public ActionResult MessageStrJson()
        {
            string StrJson = @"{ ""name"":""John"", ""age"":31, ""city"":""New York"" }";

            return new JsonResult("200", StrJson);
        }

        /// <summary>
        /// This action send object to the view.
        /// </summary>
        /// <returns>JObject: json content.</returns>
        [HttpGet]
        public ActionResult MessageObjectJson()
        {
            object objectJson = new { name = "John", age = "31", city = "New York" };


            return new JsonResult("200", objectJson);
        }

        /// <summary>
        /// This action send text without format.
        /// </summary>
        /// <returns>String: text.</returns>
        [HttpGet]
        public ActionResult MessageContent()
        {
            string message = "Hi this is text.";

            return new ContentResult("200", message);
        }

        /// <summary>
        /// This action create a view Dynamically with text sanded.
        /// </summary>
        /// <returns>JObject: json content.</returns>
        [HttpGet]
        public ActionResult MessageView()
        {
            object Object = new { tittle = "Home", message = "This is a Message from Home view" };
            
            return View("200", Object);
        }

    }
}
