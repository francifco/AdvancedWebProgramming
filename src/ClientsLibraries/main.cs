using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClientsLibraries
{
    class main
    {
        public static int Main(String[] args)
        {
            ClientAsync cliAsyc = new ClientAsync();
            ClientSync cliSync = new ClientSync();

            //show client Async
            //cliAsyc.StartClientAsync("localhost", 8082);

            //show client sync
            cliSync.StartClientSync("localhost", 8082);

            Console.WriteLine("\n press any key to exit...");
            Console.ReadKey();

            return 0;
        }
    }
}
