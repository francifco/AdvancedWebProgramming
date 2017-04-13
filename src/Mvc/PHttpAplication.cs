﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PHttp.Application;
using System.IO;
using System.Reflection;
using PHttp;

namespace Mvc
{

    /// <summary>
    /// Delegate for the Pre-Application Start event.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="method"></param>
    /// <returns></returns>
    public delegate string PreApplicationStartMethod(string physicalPath);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="method"></param>
    /// <returns></returns>
    public delegate string ApplicationStartMethod(string physicalPath);

    /// <summary>
    /// Class responsible for loaded applications.
    /// </summary>
    public class PHttpAplication : IPHttpApplication
    {

        public event PreApplicationStartMethod PreApplicationStart;

        public event ApplicationStartMethod ApplicationStart;

        public List<Route> Routes;

        public string URLPattern{get; set;}

        public Site AppSite;

        /// <summary>
        /// Container of all the routes available from the apps.
        /// </summary>
        public Dictionary<string, string> RoutesAvailable;


        /// <summary>
        /// Default Constructor.
        /// </summary>
        public PHttpAplication()
        {
            Routes = new List<Route>();
        }


        /// <summary>
        /// Return the actual Site Instanced.
        /// </summary>
        /// <returns>Site: The site that was loaded.</returns>
        public Site GetSite()
        {
            return this.AppSite;
        }

        /// <summary>
        /// Creates all possible routes according to the defined route pattern.
        /// </summary>
        public void GenerateAllRoutes()
        {
            // var app = Startup.LoadApp(AppSite.physicalPath);

            //string defaultPattern = "{controller}/{action}/{id}";
            string URLPath = "";
            BaseController baseController = new BaseController();
            DirectoryInfo directoryInfo = new DirectoryInfo(AppSite.physicalPath);
            FileInfo[] fileInfo = directoryInfo.GetFiles("*.dll");

            foreach (FileInfo fi in fileInfo)
            {
                Assembly assembly = Assembly.LoadFrom(fi.FullName);

                foreach (var type in assembly.GetTypes())
                {
                    if (type != typeof(BaseController) && typeof(BaseController).IsAssignableFrom(type))
                    {
                        string controller="";
                        string controllerName = "";
                        baseController = (BaseController)Activator.CreateInstance(type);
                        controllerName = baseController.GetType().Name;

                        if (controllerName.Contains("Controller"))
                        {
                            controller += "/" + controllerName.Replace("Controller", "").ToLower();
                        }
                        else {
                            controller += "/" + controllerName.ToLower();
                        }
                        
                        foreach (MethodInfo method in baseController.GetType().GetMethods())
                        {
                            
                            URLPath += controller + "/" + method.Name.ToLower();
                            object[] attributes = method.GetCustomAttributes(true);

                            foreach (var attribute in attributes)
                            {
                                if (attribute.GetType().IsSubclassOf(typeof(HttpMethod)))
                                {
                                    string httpMethod = attribute.GetType().Name;
                                    httpMethod = httpMethod.ToUpper().Replace("HTTP", "");

                                    Route route = new Route(httpMethod, controllerName, method.Name, URLPath);
                                    Routes.Add(route);
                                    URLPath = "";
                                }

                            }
                        }

                    }

                }
            }
        }

        /// <summary>
        /// Execute action of Request. 
        /// </summary>
        /// <param name="ActionRequest">Dictionary: Request action to execute.</param>
        /// <returns>Object: Action with to precessed.</returns>
        public object ExecuteAction(Dictionary<string, object> RequestAction)
        {
            if (Routes == null)
            {

                return "500";
            }
            else {

                foreach (Route route in Routes)
                {
                    if (route.UrlPath == RequestAction["URLPath"].ToString())
                    {   
                        ///si no hay metodo definido, aceptarlocomo si fuera un Get por defecto
                      //if (route.ControllerName != RequestAction["HttpMethod"].ToString())
                      //  {
                      //      return "500";
                      //  }
                        
                     //   else {
                            BaseController baseController = new BaseController();
                            DirectoryInfo directoryInfo = new DirectoryInfo(AppSite.physicalPath);
                            FileInfo[] fileInfo = directoryInfo.GetFiles("*.dll");

                            foreach (FileInfo fi in fileInfo)
                            {
                                Assembly assembly = Assembly.LoadFrom(fi.FullName);

                                foreach (var type in assembly.GetTypes())
                                {
                                    if (type != typeof(BaseController) && typeof(BaseController).IsAssignableFrom(type))
                                    {
                                        baseController = (BaseController)Activator.CreateInstance(type);
                                        baseController.Route = route;
                                        baseController.PhysicalPath = AppSite.physicalPath;

                                        if (baseController.GetType().Name == route.ControllerName)
                                        {
                                            MethodInfo method = baseController.GetType().GetMethod(route.ActionName);
                                            ActionResult result = (ActionResult)method.Invoke(baseController, new object[] { });
                                            return result;
                                        }

                                    }
                                }
                            }

                      //  }
                    }

                }
            }

            
                return null;
        }

        /// <summary>
        /// Generate all Possibles URL defined on every class 
        /// that Inherited from the class: PHttpApplication.  
        /// </summary>
        /// <param name="site">Site: object site that contains all information. 
        /// about an active site.
        /// </param>
        public void Init(Site site)
        {
            this.AppSite = site;

            GenerateAllRoutes();
        }

        /// <summary>
        /// this method register a Url path pattern. 
        /// </summary>
        /// <param name="pattern"></param>
        public void RegisterURLPatern(string pattern)
        {
            this.URLPattern = pattern; 
        }



    }

}

