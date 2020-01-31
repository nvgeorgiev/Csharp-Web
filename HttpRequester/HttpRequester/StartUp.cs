﻿namespace HttpRequester
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Sockets;
    using System.Text;
    using System.Text.RegularExpressions;
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
                byte[] requestBytes = new byte[1000000];
                int bytesRead = await networkStream.ReadAsync(requestBytes, 0, requestBytes.Length);
                string request = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);

                var sessionStore = new Dictionary<string, int>();
                var sid = Regex.Match(request, @"sid=[^\n]*\n").Value?.Replace("sid=", string.Empty).Trim();

                var newSid = Guid.NewGuid().ToString();
                var count = 0;

                if (sessionStore.ContainsKey(sid)
                {
                   sessionStore[sid]++; 
                   count = sessionStore[sid];
                }
                else
                {
                    sid = null;
                    sessionStore[newSid] = 1;
                    count = 1;
                }

                string responseText = @"<h1>" + sid + "</h1>" + "<h1>" + DateTime.UtcNow + "</h1>";

                string response = "HTTP/1.0 200 OK" + NewLine +
                                  "Server: SoftUniServer/1.0" + NewLine +
                                  "Content-Type: text/html" + NewLine +
                                  (string.IsNullOrWhiteSpace(sid) ? ("Set-Cookie: sid=" + newSid + NewLine) : sting.Empty) +
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