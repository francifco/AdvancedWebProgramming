using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHttp.Application
{

    public delegate string PreApplicationStartMethod(Type type, string method);
    public delegate string ApplicationStartMethod(Type type, string method);

    public interface IPHttpApplication
    {
        string Name { get; }

        event PreApplicationStartMethod PreApplicationStart;
        event ApplicationStartMethod ApplicationStart;
        
        #region Methods
        string Start(string start);
        string ExecuteAction(string action);
        #endregion

    }
}
