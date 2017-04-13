using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Mvc
{
    /// <summary>
    /// This class of attributes for each action of the controllers.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class HttpMethod : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Method)]
    public class HttpPost : HttpMethod
    {

    }

    [AttributeUsage(AttributeTargets.Method)]
    public class HttpGet : HttpMethod
    {

    }

    [AttributeUsage(AttributeTargets.Method)]
    public class HttpPut : HttpMethod
    {

    }

    [AttributeUsage(AttributeTargets.Method)]
    public class HttpDelete : HttpMethod
    {

    }




}
