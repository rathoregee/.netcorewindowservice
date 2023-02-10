using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace G2V.client.datasync.service.tests.Integration
{
    public class UnitTest1
    {
        void AddServer(IPAddress ip, int port)
        {
            var t = Task.Factory.StartNew(async () =>
            {
                var ipEndPoint = new IPEndPoint(ip, port);

                using TcpClient client = new();
                await client.ConnectAsync(ipEndPoint);
                await using NetworkStream stream = client.GetStream();

                var buffer = new byte[1_024];
                int received = await stream.ReadAsync(buffer);

                var message = Encoding.UTF8.GetString(buffer, 0, received);
                Debug.WriteLine($"{port} Message received: \"{message}\"");

            });
            t.Wait();

        }

        void Add()
        {
            Task.Run(() =>
            {
                try
                {
                           /* Initializes the Listener */
                    TcpListener myList = new TcpListener(IPAddress.Loopback, 8001);

                    /* Start Listeneting at the specified port */
                    myList.Start();

                    Debug.WriteLine("The server is running at port 8001...");
                    Debug.WriteLine("The local End point is  :" + myList.LocalEndpoint);
                    Debug.WriteLine("Waiting for a connection.....");

                    Socket s = myList.AcceptSocket();
                    Debug.WriteLine("Connection accepted from " + s.RemoteEndPoint);

                    byte[] b = new byte[100];
                    int k = s.Receive(b);
                    Debug.WriteLine("Recieved...");
                    for (int i = 0; i < k; i++)
                        Debug.Write(Convert.ToChar(b[i]));

                    ASCIIEncoding asen = new ASCIIEncoding();
                    s.Send(asen.GetBytes("The string was recieved by the server."));
                    Debug.WriteLine("\nSent Acknowledgement");
                    /* clean up */
                    s.Close();
                    myList.Stop();

                }
                catch (Exception e)
                {
                    Debug.WriteLine("Error..... " + e.StackTrace);
                }


            });             
        }

        void AddCient(IPAddress ip, int port, string message)
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();
                Debug.WriteLine("Connecting.....");

                tcpclnt.Connect(IPAddress.Loopback, 8001); // use the ipaddress as in the server program

                Debug.WriteLine("Connected");
                Debug.WriteLine("Enter the string to be transmitted : ");

                String str = "kamrna";
                Stream stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);
                Debug.WriteLine("Transmitting.....");

                stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[1024];
                int k = stm.Read(bb, 0, 1024);

                for (int i = 0; i < k; i++)
                    Debug.WriteLine(Convert.ToChar(bb[i]));

                tcpclnt.Close();
            }

            catch (Exception e)
            {
                Debug.WriteLine("Error..... " + e.StackTrace);
            }
        }

        [Fact]
        public void Test()
        {          
            //AddServer(IPAddress.Parse("192.168.161.1"), 8001);
            Add();
            // AddServer(IPAddress.Parse("192.168.161.1"), 8002);
            Thread.Sleep(15000);
            AddCient(IPAddress.Parse("192.168.161.1"), 8001,"Client one data");


        }
    }
}