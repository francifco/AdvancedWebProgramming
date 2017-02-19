using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibraries
{
    class main
    {

        public static int Main(String[] args)
        {
            //server Sync..
           // ServerSync serverSync = new ServerSync();

            //server Async..
            ServerAsync serverAsync = new ServerAsync();

            //serverSync.startSyncServer("localhost", 8082);

            serverAsync.startAsyncServer("localhost", 8082);

            return 0;
        }
    }
}
