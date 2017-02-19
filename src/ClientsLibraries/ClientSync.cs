using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace ClientsLibraries
{
    /// <summary>
    /// Ref: https://dzone.com/articles/synchronous-client-server
    /// </summary>
    public class ClientSync
    {
        // data buffer for incoming data 


        public void StartClientSync(string host, int port)
        {
            // data buffer for incoming data 
            byte[] bytes = new byte[1024];

            // connect to a Remote device 
            try
            {
                // Establish the remote end point for the socket 
                IPHostEntry ipHost = Dns.Resolve(host);
                IPAddress ipAddr = ipHost.AddressList[0];
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

                Socket sender = new Socket(AddressFamily.InterNetwork,
                                  SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint.

                sender.Connect(ipEndPoint);

                Console.WriteLine("Socket connected to {0}",
                sender.RemoteEndPoint.ToString());

                

                byte[] msg = Encoding.ASCII.GetBytes("This is a test with client sync <exit>");

                // Send the data through the socket 
                int bytesSent = sender.Send(msg);

                // Receive the response from the remote device 
                int bytesRec = sender.Receive(bytes);

                // print the response from the remote device 
                Console.WriteLine("\nClient Sync:");
                Console.WriteLine("The Server says : {0}",
                            Encoding.ASCII.GetString(bytes, 0, bytesRec));

              
                // Release the socket 
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();

            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
            }
        }

      
    }
}
