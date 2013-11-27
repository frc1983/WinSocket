using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace UDP.Model
{
    public class RoutedItemList
    {
        public List<RoutedItem> clientList;

        public RoutedItemList()
        {
            clientList = new List<RoutedItem>();
        }

        public void AddClient(String ip, Int32 metric, String output)
        {
            RoutedItem item = new RoutedItem(ip, metric, output);

            //Se nao tem o IP destino na lista do server - cadastra
            if (!clientList.Any(x => x.Ip.Equals(item.Ip)))
            {
                item.Metric = item.Metric + 1;
                clientList.Add(item);
            }
                //Se tem o IP destino
            else if (clientList.Any(x => x.Ip.Equals(item.Ip)))
            {
                //Existe o IP na tabela, entao confere a metrica e usa a menor
                RoutedItem itemInList = clientList.Where(x => x.Ip.Equals(item.Ip)).FirstOrDefault();

                //Se a metrica do item que foi recebido é menor que o existente na tabela local, atualiza a tabela
                //e ver de quem recebeu IP
                if (item.Metric + 1 < itemInList.Metric && !item.Ip.Equals(Listener.serverIP.Address))
                {
                    itemInList.Metric = item.Metric + 1;
                    itemInList.Output = item.Ip;
                }
                else if (item.Metric.Equals(Int16.MaxValue) && !item.Ip.Equals(Listener.serverIP.Address))
                {
                    itemInList.Metric = Int16.MaxValue;
                }
                else if (item.Metric.Equals(Int16.MaxValue))
                {
                    itemInList.Metric = Int16.MaxValue;
                }
            }
        }

        public void DisconnectServer(String ip)
        {
            RoutedItem item = clientList.Where(x => x.Ip.Equals(IPAddress.Parse(ip))).FirstOrDefault();
            item.Metric = Int16.MaxValue;
        }
        
        internal void RestartServer(String ip)
        {
            RoutedItem item = clientList.Where(x => x.Ip.Equals(IPAddress.Parse(ip))).FirstOrDefault();
            item.Metric = 0;
        }
    }
}
