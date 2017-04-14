using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc
{
    /// <summary>
    ///  This class contains contextual information about the request context.
    /// </summary>
    public class HttpContext
    {
        /// <summary>
        /// Context of site.
        /// </summary>
        public Site Site;

        /// <summary>
        /// Represents Configuration of server.
        /// </summary>
        ConfigurationManager Configuration;

        /// <summary>
        /// Default Constructor;
        /// </summary>
        public HttpContext()
        {
            Site = new Site();
            Configuration = new ConfigurationManager();
        }


    }
}
