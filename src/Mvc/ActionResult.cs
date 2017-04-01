using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Mvc
{
    /// <summary>
    /// Esta clase es la responsable de identificar retornar distintos resultados como
    /// "JSON content", "Text content" y "HTML view"
    /// </summary>
    public class ActionResult
    {
        string extencion;
        byte[] data;

        public ActionResult ExecuteResult(string urlPath)
        {
            

            return null;
        }

        /// <summary>
        /// Determina si el path es virtual. 
        /// </summary>
        /// <param name="path">string: path del "request".</param>
        /// <returns>true: si existe el archivo, False: si no existe.</returns>
        bool IsNotVitualPath(string path)
        {
            ///revisar esta parte.
            return (File.Exists(path));
        }


        

    }
}
