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

            //Se o ip nao esta na lista, adiciona com a métrica que chega + 1
            //if (!IPAddress.Parse(ip).Equals(Listener.serverIP.Address))
            //{
                if (!clientList.Any(x => x.Ip.Equals(item.Ip)))
                {
                    item.Metric = item.Metric + 1;
                    clientList.Add(item);
                }
                else if (clientList.Any(x => x.Ip.Equals(item.Ip)))
                {
                    //Existe o IP na tabela, entao confere a metrica e usa a menor
                    RoutedItem itemInList = clientList.Where(x => x.Ip.Equals(item.Ip)).FirstOrDefault();

                    //Se a metrica do item que foi recebido é menor que o existente na tabela local, atualiza a tabela
                    //e ver de quem recebeu IP
                    if (!item.Ip.Equals(itemInList.Output) && item.Metric < itemInList.Metric)
                    {
                        itemInList.Metric = item.Metric;
                    }
                }
            //}
        }

        public RoutedItem getClient(Int32 index)
        {
            return clientList.ElementAt(index);
        }
    }
}
