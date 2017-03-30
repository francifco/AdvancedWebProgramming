using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PHttp;

namespace Helper
{
    /// <summary>
    /// Clase para validaciones en los sites.
    /// </summary>
    public class SitesHelper
    {

        /// <summary>
        /// Evalua si existe un site actualmente.
        /// </summary>
        /// <param name="siteName">string: nombre del site.</param>
        /// <returns>true: si existe, false: si no existe</returns>
        bool ExistSite(string siteName)
        {
            // llama a la configuracion del sistema para cagar los sites
            Configuration conf = new Configuration();
            conf.Load();

            foreach (Site site in conf.sites)
            {
                if (siteName.Contains(site.virtualPath))
                    return true;
            }

            return false;
        }

    }
}
