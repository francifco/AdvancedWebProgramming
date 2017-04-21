using System;
using System.Diagnostics;
using PHttp.Application;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mvc;
using PHttp;

namespace Franci_Framework
{
    /// <summary>
    /// This class is the main of the framework. 
    /// </summary>
    class Franci_Framework
    {
        /// <summary>
        /// Main Console server.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /// Object for server configuration.
            ConfigurationManager configurationManager = new ConfigurationManager();

            /// object for startup all apps.
            Startup startup = new Startup();

            /// Task of List of all apps.
            Task<List<IPHttpApplication>> AsyncAllApps = null;

            /// Load the server configuration.
            configurationManager.Load();
            
            /// Load all active apps from configuration loaded.
            foreach (Site site in configurationManager.sites)
            {
                AsyncAllApps = startup.LoadApps(site.physicalPath);

                foreach (IPHttpApplication app in AsyncAllApps.Result)
                {
                    //  Init app and Generate all routes according pattern defined 
                    // in every app.
                    app.Init(site);
                }
            }

            if (AsyncAllApps == null)
            {
                Console.WriteLine("Not Apps loaded. Verify physical path of any site added into config.json");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }
            
            /// This object is the handler of the respond.
            RespondHandler ResHandler = new RespondHandler(configurationManager, AsyncAllApps);
                  

            using (var server = new HttpServer(configurationManager.port))
            {
                
                server.RequestReceived += (s, e) =>
                {
                    e.Response.OutputStream = ResHandler.GetRespond(e);
                };

                // The server are started.
                server.Start();

                //Information about the start of the server in the console. 
                //Process.Start(String.Format("http://{0}/", server.EndPoint));
                //Console.WriteLine("Running on: {0}", server.EndPoint);
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();

                /// When the HttpServer is "disposed", all open connections
               /// are closed automatically.
            }
        }
    }
}
