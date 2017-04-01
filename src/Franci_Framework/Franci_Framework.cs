using System;
using System.Diagnostics;
using PHttp;
using PHttp.Application;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Franci_Framework
{
    class Franci_Framework
    {
        /// <summary>
        /// Main del servidor.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /// Objeto para configuracion de el servidor.
            ConfigurationManager configurationManager = new ConfigurationManager();
            Startup httpStart = new Startup();
            Task<List<IPHttpApplication>> allApps = null;

            /// Carga la configuracion inicial del server. 
            configurationManager.PreApplicationStartMethod();

            ///carga cada applicacion del framework asincronicamente.
            foreach (Site site in configurationManager.sites)
            {
                allApps = httpStart.LoadApps(site.physicalPath);
            }

            if (allApps == null)
            {
                Console.WriteLine("No app loaded. Verify physical path of any site added.");
            }
            else
            {

                // manejador para las respuestas de cada "requests".
                RespondHandler resHandler = new RespondHandler(configurationManager, allApps);

                using (var server = new HttpServer(configurationManager.port))
                {
                    //Las nuevas peticiones se señalan a través de este evento "RequestReceived"
                    server.RequestReceived += (s, e) =>
                    {
                        // La respuesta se escriben en "e.Response.OutputStream".
                        e.Response.OutputStream = resHandler.GetRespond(e);
                    };

                    /// Se inician los servicios del "server". 
                    server.Start();

                    /// Informaciones del inicio del server en la consola. 
                    Process.Start(String.Format("http://{0}/", server.EndPoint));
                    Console.WriteLine("Running on: {0}", server.EndPoint);
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();

                    /// Cuando el HttpServer está "disposed", todas las conexiones abiertas
                    /// se cierran automáticamente.
                }
            }
            
        }
    }
}
