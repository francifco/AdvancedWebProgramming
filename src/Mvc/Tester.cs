using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PHttp.Application;

namespace Mvc
{
    public class Tester : IPHttpApplication
    {
        public event PreApplicationStartMethod PreApplicationStart;

        public event ApplicationStartMethod ApplicationStart;

              

        public string Start(string start)
        {
            return start;
        }

        public string ExecuteAction(string action)
        {
            return action;
        }
        
        public string Name => "APP1";
    }
}
