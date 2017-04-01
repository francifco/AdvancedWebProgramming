using System;
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

    public delegate string PreApplicationStartMethod(Type type, string method);
    public delegate string ApplicationStartMethod(Type type, string method);

    /// <summary>
    /// Clase responsable del manejo de los dll cargados.
    /// </summary>
    public class PHttpAplication: IPHttpApplication
    {

        public event PreApplicationStartMethod PreApplicationStart;

        public event ApplicationStartMethod ApplicationStart;

        private string RoutePattern { get; set; }

        /// <summary>
        /// Contenedor de todas la rutas disponibles de la apps.
        /// </summary>
        private Dictionary<string, string> RoutesAvailable;
          

        /// <summary>
        /// Definicion el patron de la ruta por defecto. 
        /// </summary>
        /// <param name="pattern"></param>
        public void RegisterRouter(string pattern)
        {
            this.RoutePattern = pattern;
        }

        /// <summary>
        /// Crea todas las posibles rutas deacuerdo al patron definido de las rutas.
        /// </summary>
        private void GeneratePosibleRoutes()
        {
            return;
        }
        
        public object ExecuteAction(string action)
        {
            return null;
        }
    }
}
