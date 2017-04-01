using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Contracts
{
    /// <summary>
    /// Contrato para el contenedor de todas la rutas definidas por el usuario.
    /// </summary>
    public interface IRoutes
    {
        /// <summary>
        /// Obtiene el patron de la ruta y genera las posibles rutas en la tabla de rutas.
        /// </summary>
        /// <param name="patterm">string: Definicion del patron de las rutas</param>
        void RegisterRoutesPattern(string patterm);
        
    }
}
