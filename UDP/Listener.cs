﻿using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using UDP.Model;
using System.Collections.Generic;

namespace UDP
{
    public class Listener
    {
        private const int listenPort = 11000;
        public static UdpClient listener { get; set; }
        public static IPEndPoint serverIP { get; set; }
        public static RoutedItemList RoutedItemList;

        //Inicia o server e comeca a receber mensagens
        public static void Start()
        {
            RoutedItemList = new RoutedItemList();
            serverIP = getServerIpAddress();

            IPEndPoint gEP = new IPEndPoint(IPAddress.Any, listenPort);
            listener = new UdpClient(listenPort);

            try
            {
                Console.WriteLine("Ouvindo mensagens");
                listener.BeginReceive(new AsyncCallback(ReceiveCallback), serverIP);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }     
        }

        //Recebe a mensagem
        public static void ReceiveCallback(IAsyncResult ar)
        {
            try {
                var EP = getServerIpAddress();
                Byte[] receiveBytes = listener.EndReceive(ar, ref EP);
                string receiveString = Encoding.ASCII.GetString(receiveBytes);

                var receivedList = Deserialize(receiveString);
                foreach(RoutedItem receivedItem in receivedList){
                    RoutedItemList.AddClient(receivedItem.IpToSend.ToString(), receivedItem.Metric, receivedItem.Output.ToString());
                    Listener.RoutedItemList.AddNeighbor(receivedItem.Output.ToString());
                }

                Console.WriteLine("Received: {0}", receiveString);
                listener.BeginReceive(new AsyncCallback(ReceiveCallback), serverIP);
            }
            catch (ObjectDisposedException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Retorna o endereco IP do servidor para exibicao
        private static IPEndPoint getServerIpAddress()
        {
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            var EP = new IPEndPoint(ipAddress, listenPort);

            return EP;
        }

        //Desconecta o servidor
        public static void Close(){
            RoutedItemList.DisconnectServer(Listener.serverIP.Address.ToString());
        }

        //Serializa a os itens da lista de clientes para enviar
        internal static string Serialize(List<RoutedItem> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (RoutedItem item in list)
            {
                sb.Append("@");
                sb.Append(item.IpToSend.ToString());
                sb.Append("#");
                sb.Append(item.Metric.ToString());
                sb.Append("!");
                sb.Append(Listener.serverIP.Address.ToString());
            }

            return sb.ToString();
        }

        //Deserializa a mensagem e transforma em itens da lista de clientes
        internal static List<RoutedItem> Deserialize(string message)
        {
            List<RoutedItem> newList = new List<RoutedItem>();
            foreach (var routed in message.Split('@'))
            {
                if (!string.IsNullOrEmpty(routed))
                {
                    var col = routed.Split('#');
                    var col1 = col[1].Split('!');
                    //Deserializa em: destino, metrica e saida
                    newList.Add(new RoutedItem(col[0].ToString(), Convert.ToInt32(col1[0]), col1[1].ToString()));
                }
            }

            return newList;
        }

        //reinicia o servidor
        internal static void Restart()
        {
            RoutedItemList.RestartServer(Listener.serverIP.Address.ToString());
        }
    }
}
