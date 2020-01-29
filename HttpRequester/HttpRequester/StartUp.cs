﻿namespace HttpRequester
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static async Task Main()
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80);
            tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                Task.Run(() => ProcessClientAsync(tcpClient));
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            }
        }

        private static async Task ProcessClientAsync(TcpClient tcpClient)
        {
            const string NewLine = "\r\n";

            using (NetworkStream networkStream = tcpClient.GetStream())
            {
                // TODO: Use buffer
                byte[] requestBytes = new byte[1000000];
                int bytesRead = await networkStream.ReadAsync(requestBytes, 0, requestBytes.Length);
                string request = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);

                string responseText = @"<form action='/Account/Login' method='post'>
                                                    <input type=date name='date' />
                                                    <input type=text name='username' />
                                                    <input type=password name='password' />
                                                    <input type=submit value='Login' />
                                            </form>" + "<h1>" + DateTime.UtcNow + "</h1>";

                string response = "HTTP/1.0 200 OK" + NewLine +
                                  "Server: SoftUniServer/1.0" + NewLine +
                                  "Content-Type: text/html" + NewLine +
                                  "Content-Length: " + responseText.Length + NewLine +
                                  NewLine +
                                  responseText;

                byte[] responseBytes = Encoding.UTF8.GetBytes(response);

                await networkStream.WriteAsync(responseBytes, 0, responseBytes.Length);

                Console.WriteLine(request);
                Console.WriteLine(new string('=', 60));
            }
        }
    }
}