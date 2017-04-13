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
    /// Clase responsable del la carga de la configuracion del 
    /// server usando el archivo: "config.json" 
    /// </summary>
    public class ConfigurationManager
    {
        /// <summary>
        /// Puerto por defecto del servidor.
        /// </summary>
        public int port;

        /// <summary>
        /// Diccionario con los "path" de los archivos .html 
        /// con los mensajes de errores que provee el framework.
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
        /// Determinante de que se cargo la configuracion.
        /// </summary>
        private bool ConfigLoaded = false;

        /// <summary>
        /// Carga todos los valores para la configuracion del server que estan en:
        /// el config.json.
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

            this.ConfigLoaded = true;
        }

        /// <summary>
        /// Busca un site deacuerdo po el "virtualPath"
        /// </summary>
        /// <param name="physicarPath">string: el "virtualPath" del site</param>
        /// <returns>El objeto site</returns>
        public Site GetSiteByVirtualPath(string virtualPath)
        {
            if (this.ConfigLoaded)
            {
                foreach (Site site in this.sites)
                {
                    if (site.virtualPath.ToLower().Equals(virtualPath.ToLower()))
                    {
                        return site;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Actualiza el archivo de configuracion inicial: "config.json" y
        /// vuelve a cargara la data. 
        /// </summary>
        public void UpdateConfigFile()
        {
            string rootpath = "../../../";
            string[] ingoreFolders = { "PHttp", "Mvc", "Franci_Framework", "packages", ".vs" };

            List<string> directoriesSites = GetDirectories(rootpath, ingoreFolders);
            List<string> directoriesFiles = new List<string>();

            for (int i = 0; i < directoriesSites.Count; i++)
            {
                if (directoriesSites[i].Contains("\\Views"))
                {
                    string[] dirFiles = Directory.GetFiles(directoriesSites[i]);
                    directoriesFiles.AddRange(RemoveSubString(dirFiles,"\\"));
                    break;
                }
                
            }


            //modificar el archivo .json

            //carga la configuracion inicial de nuevo.
           // Load();
        }

        /// <summary>
        /// Remueve de la lista el substring recibido
        /// </summary>
        /// <param name="dirFiles">string[]: Path con los archivos</param>
        /// <param name="SubString">string: string a remover</param>
        /// <returns></returns>
        private List<string> RemoveSubString(string[] dirFiles, string SubString)
        {
            List<string> NewdirFiles = new List<string>();

            for (int i = 0; i < dirFiles.Length; i++)
            {
                NewdirFiles.Add(dirFiles[i].Replace(SubString, "/"));
            }

            return NewdirFiles;
        }

        /// <summary>
        /// Obtiene los directorios
        /// </summary>
        /// <param name="path"></param>
        /// <param name="ingoreFolders"></param>
        /// <returns></returns>
        private static List<string> GetDirectories(string path, string[] ingoreFolders)
        {
            string searchPattern = "*";

            List<string> directories = GetDirectories(path, searchPattern);

            directories = RemoveDirectories(directories, ingoreFolders);

            for (var i = 0; i < directories.Count; i++)
                directories.AddRange(GetDirectories(directories[i], searchPattern));

            return directories;
        }

        /// <summary>
        /// Busca todos los directorios de los sites dentro del "path" especificado.
        /// </summary>
        /// <param name="path">string: "path" con el directorio donde buscar los folders</param>
        /// <param name="searchPattern">string: patron de busqueda</param>
        /// <returns>El listado de directorios de los sites</returns>
        private static List<string> GetDirectories(string path, string searchPattern)
        {
            try
            {
                return Directory.GetDirectories(path, searchPattern).ToList();
            }
            catch (UnauthorizedAccessException)
            {
                return new List<string>();
            }
        }

        /// <summary>
        /// Elimina los directorios recibidos 
        /// </summary>
        /// <param name="directory">List<string>: lista con los directorios</param>
        /// <param name="ingnoreFolders">List[]: Arreglo con los directorios a eliminar</param>
        /// <returns>El listado actualizado</returns>
        private static List<string> RemoveDirectories(List<string> directory, string[] ingnoreFolders)
        {
            for (int i = 0; i < ingnoreFolders.Length; i++)
            {
                for (int j = 0; j < directory.Count; j++)
                {
                    if (directory[j].Contains(ingnoreFolders[i]))
                    {
                        directory.Remove("../../../" + ingnoreFolders[i]);
                        break;
                    }
                }
            }

            return directory;
        }


    }
}
