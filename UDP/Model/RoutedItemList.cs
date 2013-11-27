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
        public List<IPAddress> neighboring
;

        public RoutedItemList()
        {
            clientList = new List<RoutedItem>();
            neighboring = new List<IPAddress>();
        }

        public void AddNeighbor(String ip)
        {
            if (!neighboring.Any(x => x.Equals(IPAddress.Parse(ip))))
            {
                neighboring.Add(IPAddress.Parse(ip));
            }
        }

        public void AddClient(String ipToSend, Int32 metric, String output)
        {
            RoutedItem receivedItem = new RoutedItem(ipToSend, metric, output);

            //Se nao tem o IP destino na lista do server - cadastra
            if (!clientList.Any(x => x.IpToSend.Equals(receivedItem.IpToSend)))
            {
                receivedItem.Metric = receivedItem.Metric + 1;
                clientList.Add(receivedItem);
            }
            //Se tem o IP destino, entao confere a metrica e usa a menor
            else if (clientList.Any(x => x.IpToSend.Equals(receivedItem.IpToSend)))
            {
                //Item que existe na tabela local
                RoutedItem itemInList = clientList.Where(x => x.IpToSend.Equals(receivedItem.IpToSend)).FirstOrDefault();

                //Se a metrica do item que foi recebido é menor que o existente na tabela local, atualiza a tabela
                //e ver de quem recebeu IP
                if (!receivedItem.IpToSend.Equals(itemInList.Output))
                {
                    itemInList.Metric = receivedItem.Metric + 1;
                    //itemInList.Output = receivedItem.IpToSend;
                }
                else if (receivedItem.IpToSend.Equals(itemInList.Output) && (receivedItem.Metric.Equals(0) || receivedItem.Metric.Equals(Int16.MaxValue + 1) || receivedItem.Metric.Equals(Int16.MaxValue)))
                {
                    itemInList.Metric = receivedItem.Metric + 1;
                }
            }
        }

        public void DisconnectServer(String ip)
        {
            //Desliga o Server colocando metrica MaxValue para ele
            RoutedItem item = clientList.Where(x => x.IpToSend.Equals(IPAddress.Parse(ip))).FirstOrDefault();
            item.Metric = Int16.MaxValue;
        }
        
        internal void RestartServer(String ip)
        {
            //Reinicia o Server colocando metrica 0 para ele
            RoutedItem item = clientList.Where(x => x.IpToSend.Equals(IPAddress.Parse(ip))).FirstOrDefault();
            item.Metric = 0;
        }
    }
}
