using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHttp.Application
{

    public delegate string PreApplicationStartMethod(Type type, string method);
    public delegate string ApplicationStartMethod(Type type, string method);

    /// <summary>
    /// Contrato para la clase responble del manejo de los dll cargados.
    /// </summary>
    public interface IPHttpApplication
    {

        event PreApplicationStartMethod PreApplicationStart;

        event ApplicationStartMethod ApplicationStart;

        string RoutePattern { get; set; }

     
        /// <summary>
        /// Asigna el patron del router establecido por defecto.
        /// </summary>
        /// <param name="pattern">string: patron definido</param>
        void RegisterRouter(string pattern);

        /// <summary>
        /// Carga y combiana todas la rutas disponibles deacuerdo a los 
        /// "controllers" y sus acciones.
        /// </summary>
        /// <returns>"Dictionary<string, string>:" diccionario con todas la rutas 
        /// disponibles
        /// </returns>
        void GeneratePosibleRoutes();

        /// <summary>
        /// Ejecuta la accion del controller. 
        /// </summary>
        /// <param name="action">string: nombre de la accion o metodo a ejecutar</param>
        /// <returns>Object: obejeto con la accion ejecutada</returns>
        object ExecuteAction(string action);

    }
}
