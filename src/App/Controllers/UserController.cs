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
        /// For authorize user.
        /// </summary>
        AuthorizationUser authorizationUser;


        ///TODO: hacer que esta palabra se guarde en el archivo de configuracion del site.
        /// <summary>
        /// Secret word.
        /// </summary>
        string secretWord = "secretFco";

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


            Model.Entities.User user = new Model.Entities.User();
            Model.Repository.UserRepository userRepository = new Model.Repository.UserRepository();

            user.firstName = (string)Request.Params["firstName"];
            user.lastName = (string)Request.Params["lastName"];
            user.username = (string)Request.Params["username"];
            user.password = (string)Request.Params["password"];
            user.nationality = (string)Request.Params["nationality"];


            if (userRepository.HasUser(user.username))
            {
                respond = new { error = "400", message = "This username already exists." };
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
        /// This action show the register view.
        /// </summary>
        /// <returns>Object: View.</returns>
        [HttpGet]
        public ActionResult Register()
        {
            object Object = new { tittle = "Register MvcUser", message = "Welcome to Pick Url." };

            return View("200", Object, "register");
        }


        /// <summary>
        /// This action show the index view.
        /// </summary>
        /// <returns>Object: View.</returns>
        [HttpGet]
        public ActionResult Index()
        {
            object Object = new { option = "Login", tittle = "Pick Url", message = "Welcome to Pick Url." };

            return View("200", Object, "index");
        }

        /// <summary>
        /// This action show the login view.
        /// </summary>
        /// <returns>Object: View.</returns>
        [HttpGet]
        public ActionResult Login()
        {
            object Object = new { option = "Login", tittle = "Login user", message = "Login user" };

            return View("200", Object, "login");
        }

        /// <summary>
        /// This action logIn an user.
        /// </summary>
        /// <returns>Object: respond.</returns>
        [HttpPost]
        public ActionResult LogInUser()
        {
            object respond;
            string pass = (string)Request.Params["password"];
            string username = (string)Request.Params["username"];

            if (string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(username))
            {

                respond = new
                {
                    tittle = "Login user",
                    message = "Login user",
                    option = "Login",
                    errorMessage = "Please complete all fields."
                };

                return View("401", respond, "login");
            }

            Model.Repository.UserRepository userRepository = new Model.Repository.UserRepository();
            Model.Entities.User user = userRepository.Login(username, pass);

            if (!string.IsNullOrEmpty(user.username))
            {
                
                string tokenGenerated = Session.GenerateToken(user.username, user.password, secretWord);
                authorizationUser = new AuthorizationUser(user.username, user.password, secretWord);

                respond = new {
                    tittle = "Pick Url",
                    token = tokenGenerated,
                    option = "Sign Out",
                    message = "Welcome to Pick Url.",
                    userLogged = user.firstName
                };

                return View("200", respond, "index");
                
            }
            else
            {
                respond = new {
                    tittle = "Login user",
                    message = "Login user",
                    option = "Login",
                    errorMessage = "Passwod or Username incorrect." };

                return View("401", respond, "login");
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
