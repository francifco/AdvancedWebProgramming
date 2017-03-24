using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Reflection;
using PHttp.Application;


namespace PHttp
{
    public class Startup
    {
        /// <summary>
        /// This method load all dll files defined at a path on application.config  
        /// </summary>
        /// <param name="path">Sting: path of application.config</param>
        /// <returns>List of dll files</returns>
        public List<IPHttpApplication> LoadApps(string path)
        {
          
            DirectoryInfo info = new DirectoryInfo(path);
            var impl = new List<IPHttpApplication>();

            //make sure path aren't empty or null.
            if (string.IsNullOrEmpty(path)) { return impl; }

            //make sure directory exists
            if (!info.Exists) { return impl; }

            foreach (FileInfo file in info.GetFiles("*.dll")) //loop through all dll files in directory
            {
                Assembly currentAssembly = null;
                try
                {
                    var name = AssemblyName.GetAssemblyName(file.FullName);
                    currentAssembly = Assembly.Load(name);
                }
                catch (Exception ex)
                {
                    continue;
                }

                var types = currentAssembly.GetTypes();

                foreach (var type in types)
                {
                    if (type != typeof(IPHttpApplication) && typeof(IPHttpApplication).IsAssignableFrom(type))
                    {
                        impl.Add((IPHttpApplication)Activator.CreateInstance(type));
                    }
                }
                
            }

            return impl;
        }
    }
}
