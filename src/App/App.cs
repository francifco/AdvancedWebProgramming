using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc;

namespace App
{
    /// <summary>
    /// This Class define app route pattern.
    /// </summary>
    class App : PHttpAplication
    {
        public App() : base()
        {
            RegisterURLPatern("{controller}/{action}/{id}");
        }
        
    }
}
