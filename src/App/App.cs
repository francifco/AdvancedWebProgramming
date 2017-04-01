using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc;

namespace App
{
    class App: PHttpAplication
    {
        void routes()
        {
            this.RegisterRouter("{controller}/{action}/{id}");
        }
        
    }
}
