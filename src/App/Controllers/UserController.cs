using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc;
using System.IO;
using System.Text.RegularExpressions;


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

                respond = new
                {
                    tittle = "Pick Url",
                    message = "Welcome to Pick Url",
                    errorMessage = "Please complete all fields."
                };

                return View("401", respond, "register");
            }

            string password = (string)Request.Params["password"];
            string confirpassword = (string)Request.Params["confPassword"];

            if (!password.Equals(confirpassword))
            {
                
                respond = new
                {
                    tittle = "Pick Url",
                    message = "Welcome to Pick Url",
                    errorMessage = "Password and confirm password must be the same.."
                };

                return View("401", respond, "register");
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
                
                respond = new
                {
                    tittle = "Pick Url",
                    message = "Welcome to Pick Url",
                    errorMessage = "This username already exists.."
                };

                return View("400", respond, "register");
            }

            userRepository.AddUser(user);

            respond = new
            {
                tittle = "Pick Url",
                option = "Sign Out",
                message = "Welcome to Pick Url.",
                userLogged = user.firstName
            };

            return View("200", respond, "index");
        }

        /// <summary>
        /// This action show the register view.
        /// </summary>
        /// <returns>Object: View.</returns>
        [HttpGet]
        public ActionResult Register()
        {
            object Object = new { tittle = "Pick Url", message = "Welcome to Pick Url." };

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
                    idUser = user.id,
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


        /// <summary>
        /// This action is for creation of shorted url.
        /// </summary>
        /// <returns>string: a Shorted Url.</returns>
        //[Authorize]
        [HttpGet]
        public ActionResult GetURL()
        {
           
            string shortUrl = Path.GetRandomFileName();
            shortUrl = shortUrl.Replace(".", "");
            shortUrl = Request.QueryParams["Host"] + "/app/url/click/" + shortUrl;

            Model.Repository.UrlRepository urlRepo = new Model.Repository.UrlRepository();

            Model.Entities.Url url = new Model.Entities.Url();

            url.LargeUrl = Request.Params["url"];
            url.ShortenedURL = shortUrl;

            url.userId = Request.Params["idUser"];
            string token = Request.Params["token"];

            url.clicks = 0;

            urlRepo.AddUrl(url);

            object respond = new
            {
                tittle = "Pick Url",
                url = shortUrl,
                option = "Sign Out",
                message = "Welcome to Pick Url."
            };
            
            return View("401", respond, "index");
        }


        [HttpPost]
        public void click()
        {
            var referer = Request.QueryParams["Referer"];
            var location = Request.QueryParams["REMOTE_ADDR"];
            var agent = Request.QueryParams["HTTP_USER_AGENT"];
            var platform = Regex.Match(Request.QueryParams["HTTP_USER_AGENT"], @"\(([^)]*)\)").Groups[1].Value;
            platform = platform.Split(';')[0];
            var shortUrl = Request.QueryParams["Host"] + Request.QueryParams["URL"];

            if (agent.Contains("Firefox/") && !agent.Contains("Seamonkey/"))
            {
                agent = "Firefox";
            }
            else if (agent.Contains("Seamonkey/"))
            {
                agent = "Seamonkey";
            }
            else if (agent.Contains("Chrome/") && !agent.Contains("Chromium/") && !agent.Contains("Edge/"))
            {
                agent = "Chrome";
            }
            else if (agent.Contains("Edge/"))
            {
                agent = "Edge";
            }
            else if (agent.Contains("Chromium/"))
            {
                agent = "Chromium";
            }
            else if (agent.Contains("Safari/") && !agent.Contains("Chromium/") && !agent.Contains("Chrome/"))
            {
                agent = "Safari";
            }
            else if (agent.Contains("OPR/") || agent.Contains("Opera/"))
            {
                agent = "Opera";
            }
            else if (agent.Contains("MSIE") || agent.Contains("Trident/"))
            {
                agent = "Internet Explorer";
            }
 

        }



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
