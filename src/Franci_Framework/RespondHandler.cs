using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using PHttp;
using PHttp.Application;

namespace Franci_Framework
{
    /// <summary>
    /// Esta clase es la responsable de todas las respuestas hacia el "client"
    /// </summary>
    public class RespondHandler
    {
        /// <summary>
        /// Contenedor de la configuracion del "server".
        /// </summary>
        ConfigurationManager configurationManager;

        Task<List<IPHttpApplication>> AllApps;

        /// <summary>
        /// Constructor por defecto del "RespondHandler".
        /// </summary>
        /// <param name="conf">PHttp.ConfigurationManager: Configuracion del "server" </param>
        public RespondHandler(ConfigurationManager conf, Task<List<IPHttpApplication>> allApps)
        {
            this.configurationManager = conf;
            this.AllApps = allApps;
        }

        /// <summary>
        /// Este metodo responde al cliende deacuerdo al evento recibido.
        /// </summary>
        /// <param name="requestEvent">HttpRequestEventArgs: Evento del request.</param>
        /// <returns>HttpOutputStream: la respuesta del evento del argumento recibido</returns>
        public HttpOutputStream GetRespond(HttpRequestEventArgs requestEvent)
        {
            /// arreglo con cada string del url path.
            string[] siteName = requestEvent.Request.Path.Replace("favicon.ico",string.Empty).Split('/');
            byte[] data;
            MemoryStream stream;
            
            ///TODO: no siempre vendra un archivo en el request.
            ///validar esta parte.
            //string fileName = Path.GetFileName(requestEvent.Request.Path);

            if (requestEvent.Request.Path.Equals("/"))
            {
                requestEvent.Response.ContentType = MimeTypeMap
                    .GetMimeType(Path.GetExtension(configurationManager.defaultDocument["index"]));
                requestEvent.Response.Status = "200";
                data = File.ReadAllBytes(configurationManager.defaultDocument["index"]);
                stream = new MemoryStream(data);
                return new HttpOutputStream(stream);
            }
            ///TODO: aqui va la logica de los request de los usuarios(dvelopers):
            /// 1 determinar de que site es que viene el path.
            /// 2 determinar que controller ejecutar.
            /// 3 determinar si es vistual el request.
            //  4 determinar que accion ejecuta el controller.
            ///
            else
            {
                //si el site no existe.
                if (!Exist(siteName[1]))
                {
                    requestEvent.Response.Status = "404";
                    data = File.ReadAllBytes(configurationManager.errorPages["404"]);
                    stream = new MemoryStream(data);
                    return new HttpOutputStream(stream);
                }
                else //si site existe, verificar si existe el controller.
                {
                    
                }
                
                return null;  //quitar eso
            }
        }

        /// <summary>
        /// Determina si existe un site.
        /// </summary>
        /// <param name="siteName">string: nombre del site</param>
        /// <returns>true: si existe el site, false: si o existe</returns>
        private bool Exist(string siteName)
        {
            foreach (Site site in configurationManager.sites)
            {
                if (siteName.ToLower().Equals(site.virtualPath.ToLower()))
                    return true;
            }
            return false;
        }

    }
}
