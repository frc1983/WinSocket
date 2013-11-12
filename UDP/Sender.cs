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
        public static void Send(string args, IPEndPoint endPoint, bool done = false)
        {
            Boolean exception_thrown = false;
            Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            string text_to_send = args;
            byte[] send_buffer = Encoding.ASCII.GetBytes(text_to_send);

            Console.WriteLine("sending to address: {0} port: {1}", endPoint.Address, endPoint.Port);
            try
            {
                sending_socket.SendTo(send_buffer, endPoint);
            }
            catch (Exception send_exception)
            {
                exception_thrown = true;
                Console.WriteLine(" Exception {0}", send_exception.Message);
            }
            if (exception_thrown == false)
            {
                Console.WriteLine("Message has been sent to the broadcast address");
            }
            else
            {
                exception_thrown = false;
                Console.WriteLine("The exception indicates the message was not sent.");
            }
        } // end of main()
    }
}
