using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc;


namespace App
{
    /// <summary>
    /// This controller is for user management.
    /// </summary>
    public class UserController : BaseController
    {

        /// <summary>
        /// Action of Register an user.
        /// </summary>
        /// <returns>Object: Respond with json content.</returns>
        [HttpPost]
        public ActionResult RegisterUser()
        {
            object respond;

            if (Request.Params.Count < 6)
            {
                respond = new { error = "400", message = "Please complete all fields." };
                return new JsonResult("400", respond);
            }

            string password = (string)Request.Params["password"];
            string confirpassword = (string)Request.Params["confPassword"];

            if (!password.Equals(confirpassword))
            {
                respond = new { error = "400", message = "Password and confirm password must be the same." };
                return new JsonResult("400", respond);
            }


            Model.user user = new Model.user();
            Model.Repository.UserRepository userRepository = new Model.Repository.UserRepository();

            user.firstName = (string)Request.Params["firstName"];
            user.lastName = (string)Request.Params["lastName"];
            user.username = (string)Request.Params["username"];
            user.password = (string)Request.Params["password"];
            user.nationality = (string)Request.Params["nationality"];


            if (userRepository.HasUser(user.username))
            {
                respond = new { error = "400", message = "This user already exists." };
                return new JsonResult("400", respond);
            }

            userRepository.AddUser(user);

            string secretWord = "secretFco";
            string tokenGenerated = Session.GenerateToken(user.username, user.password, secretWord);

            string strRespond = @"{ ""auth-token"":" + tokenGenerated + ","
               + "username" + ":" + user.username + ", "
               + "secret-key" + ":" + secretWord + "}";

            return new JsonResult("200", strRespond);

        }


        /// <summary>
        /// This action logIn an user.
        /// </summary>
        /// <returns>Object: respond.</returns>
        [HttpPost]
        public ActionResult LogIn()
        {

            object respond;

            if (Request.Params.Count < 2)
            {
                respond = new { error = "400", message = "Please complete all fields." };
                return new JsonResult("400", respond);
            }

            Model.Repository.UserRepository userRepository = new Model.Repository.UserRepository();

            Model.user user = userRepository.Login((string)Request.Params["username"],
                (string)Request.Params["password"]);

            if (user != null)
            {
                string secretWord = "secretFco";
                string tokenGenerated = Session.GenerateToken(user.username, user.password, secretWord);

                string strRespond = @"{ ""auth-token"":" + tokenGenerated + ","
                   + "username" + ":" + user.username + ", "
                   + "secret-key" + ":" + secretWord + "}";

                return new JsonResult("200", strRespond);
            }
            else
            {
                respond = new { error = "401", message = "Passwod or Username incorrect." };
                return new JsonResult("401", respond);
            }
        }

        /// <summary>
        /// This action sends a string with json format.
        /// </summary>
        /// <returns>string: json content.</returns>
        [HttpGet]
        public ActionResult MessageStrJson()
        {
            string StrJson = @"{ ""name"":""John"", ""age"":31, ""city"":""New York"" }";

            return new JsonResult("200", StrJson);
        }

   
        // for test the view.

        /// <summary>
        /// This action create a view Dynamically with text sent.
        /// </summary>
        /// <returns>View with Data.</returns>
        [HttpGet]
        public ActionResult MessageCustomView()
        {
            object Object = new { tittle = "Custom", message = "This is a Message from Custom view." };

            return View("200", Object, "custom");
        }



    }
}
