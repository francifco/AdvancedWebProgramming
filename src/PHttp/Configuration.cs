using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;


namespace PHttp
{
    /// <summary>
    /// Clase responsable del la carga de la configuracion del server.  
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// Puerto por defecto del servidor.
        /// </summary>
        public int port;

        /// <summary>
        /// Diccionario de los path de los archivos .html 
        /// con los errores por defectos del server.
        /// </summary>
        public Dictionary<string, string> errorPages;

        /// <summary>
        /// Diccionario de los documentos o archivos por defectos.
        /// </summary>
        public Dictionary<string, string> defaultDocument;

        /// <summary>
        /// listado de los sites actuales en el server.
        /// </summary>
        public List<Site> sites;

        /// <summary>
        /// Carga todos los valores para la configuracion del server.
        /// </summary>
        public void Load()
        {

            JObject jsonConfigFile = JObject.Parse(File.ReadAllText(@"../../../PHttp/config.json"));

            this.port = (int)jsonConfigFile["port"];
                        
            this.errorPages = JsonConvert.DeserializeObject
                <Dictionary<string, string>>(jsonConfigFile["errorPages"].ToString());

            this.defaultDocument = JsonConvert.DeserializeObject
                <Dictionary<string, string>>(jsonConfigFile["defaultDocument"].ToString());

            this.sites = JsonConvert.DeserializeObject<List<Site>>(jsonConfigFile["sites"].ToString());
            
        }
    }
}
