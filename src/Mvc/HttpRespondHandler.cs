using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using PHttp;
using Helper;

namespace Mvc
{
    /// <summary>
    /// Esta clase es la responsable de todas las respuestas hacia el "client"
    /// </summary>
    public class HttpRespondHandler
    {
        /// <summary>
        /// Contenedor de la configuracion del "server".
        /// </summary>
        PHttp.Configuration config;

        /// <summary>
        /// Constructor por defecto del "RespondHandler".
        /// </summary>
        /// <param name="conf">PHttp.Configuration: Configuracion del "server" </param>
        public HttpRespondHandler(PHttp.Configuration conf)
        {
            this.config = conf;
        }

        /// <summary>
        /// Este metodo responde al cliende deacuerdo al evento recibido.
        /// </summary>
        /// <param name="requestEvent">HttpRequestEventArgs: Evento del request.</param>
        /// <returns>HttpOutputStream: la respuesta del evento del argumento recibido</returns>
        public HttpOutputStream GetRespond(HttpRequestEventArgs requestEvent)
        {
            /// "path" del request.           
            string urlPath = requestEvent.Request.Path;
            byte[] data;
            MemoryStream stream;
            

            ///TODO: no siempre vendra un archivo en el request.
            ///validar esta parte.
            string fileName = Path.GetFileName(requestEvent.Request.Path);

            if (requestEvent.Request.Path.Equals("/"))
            {
                requestEvent.Response.ContentType = MimeHelper
                    .GetMimeType(Path.GetExtension(config.defaultDocument["index"]));
                requestEvent.Response.Status = "200";
                data = File.ReadAllBytes(config.defaultDocument["index"]);
                stream = new MemoryStream(data);
                return new HttpOutputStream(stream);
            }
            ///TODO: aqui va la logica de los request de los usuarios(dvelopers):
            ///TODO: hacer un handler controller que retorne: data o HttpOutputStream 
            /// 1 determinar de que site es que viene el path.
            /// 2 determinar que controller ejecutar.
            /// 3 determinar si es vistual el request.
            //  4 determinar que accion ejecuta el controller.
            ///
            else
            {
                string[] pathParts = urlPath.Split('/');



                requestEvent.Response.Status = "404";
                data = File.ReadAllBytes(config.defaultDocument["404"]);
                stream = new MemoryStream(data);
                return new HttpOutputStream(stream);
            }
            
        }
    }
}
