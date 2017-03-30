using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc;

namespace ClientApp
{
    /// <summary>
    /// Site inicial de prueba para el uso del framework.
    /// </summary>
    class routes: Routes
    {
        /// <summary>
        /// 
        /// </summary>
        void DefineRoute()
        {
            

            this.MapRoute(
                     //"{controller}/{action}/{id}", // URL with parameters
                     new Routes (controller = "HomeController", action = "index", id = "" ),
                     new Routes (controller = "HomeController", action = "PrintHtml", id = "holaa"),
                     new Routes (controller = "HomeController", action = "TestError", id = "")
                );

            
        }

    }
}
