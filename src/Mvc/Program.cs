using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PHttp;
using System.IO;
using System.Diagnostics;
using System.Configuration;


namespace Mvc
{
    class Program
    {
        /// <summary>
        /// Main del servidor.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {       
            /// Objeto para configuracion de el servidor.
            PHttp.Configuration conf = new PHttp.Configuration();

            /// Carga la configuracion inicial del server. 
            conf.Load();

            // Objeto manejador del las respuestas de los requesters.
            HttpRespondHandler resHandler = new HttpRespondHandler(conf);

            using (var server = new HttpServer(conf.port))
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
