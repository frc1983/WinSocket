using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDP
{
    class Sender
    {
        //Envia a mensagem para o Ip(endpoint) passado
        public static void Send(string args, IPEndPoint endPoint)
        {
            Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            string text_to_send = args;
            byte[] send_buffer = Encoding.ASCII.GetBytes(text_to_send);

            try
            {
                if (!IPAddress.Equals(endPoint.Address, Listener.serverIP.Address) &&
                    Listener.RoutedItemList.neighboring.Any(x => IPAddress.Equals(endPoint.Address, x)))
                {
                    Console.WriteLine("enviando para: {0} port: {1}", endPoint.Address, endPoint.Port);
                    sending_socket.SendTo(send_buffer, endPoint);
                }
            }
            catch (Exception send_exception)
            {
                Console.WriteLine(" Exception {0}", send_exception.Message);
            }
        }
    }
}
