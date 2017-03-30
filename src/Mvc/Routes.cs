using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc
{

    /// <summary>
    /// contenedor de todas la rutas definidas por el usuario.
    /// </summary>
    public class Routes
    {

        /// <summary>
        /// Nombre del controllador en la ruta.
        /// </summary>
        public string controller { get; set; }

        /// <summary>
        /// Accion o metodo en la ruta. 
        /// </summary>
        public string action { get; set; }

        /// <summary>
        /// Parametro en la ruta. 
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Constructor defecto con parametros de la ruta
        /// </summary>
        /// <param name="con"></param>
        /// <param name="ac"></param>
        /// <param name="pa"></param>
        public Routes(string _con, string _ac, string _id = null)
        {
            this.controller = _con;
            this.action = _ac;
            this.id = _id;
        }

        /// <summary>
        /// Contructor por defecto.
        /// </summary>
        public Routes()
        {
           
        }

        /// <summary>
        /// Lista de rutas.
        /// </summary>
        public List<Routes> ListRoutes = new List<Routes>();

        /// <summary>
        /// Crea una lista con las rutas recibidas.
        /// </summary>
        /// <param name="route"></param>
        public void MapRoute(params Routes[] values)
        {


            if (values == null)
            {
                Console.WriteLine("Ruta no definida.");
                return;
            }
               

            foreach (Routes value in values)
            {
                if (string.IsNullOrEmpty(value.controller))
                {
                    Console.WriteLine("Controller no definido en la ruta.");
                    break;
                }

                if (string.IsNullOrEmpty(value.action))
                {
                    Console.WriteLine("Accion no definida en el ruta.");
                    break;
                }

                this.ListRoutes.Add(value);
            }
            
        }

    }
}
