using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Mvc
{
    /// <summary>
    /// clase para la decoracion para cada accion de los controllers.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class httpMethod : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Method)]
    public class httpPost : httpMethod
    {

    }

    [AttributeUsage(AttributeTargets.Method)]
    public class httpGet : httpMethod
    {

    }

    [AttributeUsage(AttributeTargets.Method)]
    public class httpPut : httpMethod
    {

    }

    [AttributeUsage(AttributeTargets.Method)]
    public class httpDelete : httpMethod
    {

    }




}
