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
        /// This action send json object to the view.
        /// </summary>
        /// <returns>JObject: json content.</returns>
        [HttpGet]
        public ActionResult MessageJson()
        {
            string json = @"{ 'Name': 'Bad Boys',
                              'ReleaseDate': '1995-4-7T00:00:00',
                              'Genres': [
                                'Action',
                                'Comedy'
                              ]
                            }";

            JObject jObject = new JObject(json);

            return new JsonResult("200", jObject);
        }


        /// <summary>
        /// This action send a string with json format to the view.
        /// </summary>
        /// <returns>JObject: json content.</returns>
        [HttpGet]
        public ActionResult MessageStrJson()
        {
            string StrJson = @"{ 'Name': 'Bad Boys',
                              'ReleaseDate': '1995-4-7T00:00:00',
                              'Genres': [
                                'Action',
                                'Comedy'
                              ]
                            }";

            return new JsonResult("200", StrJson);
        }

        /// <summary>
        /// This action send text without format to the view.
        /// </summary>
        /// <returns>String: text.</returns>
        [HttpGet]
        public ActionResult MessageConten()
        {
            string message = "Hi this is text.";

            return new ContentResult("200", message);
        }


        /// <summary>
        /// This action create a view Dynamically with text sanded.
        /// </summary>
        /// <returns>JObject: json content.</returns>
  /*      public ActionResult MessageView()
        {
            string message = "hola es un test.";

            return new View(message);
        }
*/
    }
}
