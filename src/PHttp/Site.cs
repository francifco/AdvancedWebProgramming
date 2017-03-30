using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PHttp
{
    /// <summary>
    /// Clase como contenedora de un site.
    /// </summary>
    public class Site
    {
        /// <summary>
        /// Nombre del site.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Path del directorio donde esta el site. 
        /// </summary>
        public string physicalPath { get; set; }

        /// <summary>
        /// Path vitual por defecto.
        /// </summary>
        public string virtualPath { get; set; }

        /// <summary>
        /// Si el directiorio esta activo o no.
        /// </summary>
        public bool directoryBrowsing = false;

        /// <summary>
        /// Diccionario de los documentos por defectos.
        /// </summary>
        public Dictionary<string, string> defaultDocument;

        /// <summary>
        ///Diccionario de los archivos .html con los errores por defectos.
        /// </summary>
        public Dictionary<string, string> errorPages;


        void load(string json)
        {

        }
    }
}
