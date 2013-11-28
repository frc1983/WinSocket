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

        public void AddClient(String ipToSend, Int32 metric, String output, bool addedInServer = false)
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

                //Se o ip foi adicionado no server, atualiza a saida e a metrica
                if (addedInServer)
                {
                    itemInList.Metric = 1;
                    itemInList.Output = receivedItem.Output;
                }
                //Se a metrica do item que foi recebido é menor que o existente na tabela local, atualiza a tabela
                //e ver de quem recebeu IP
                else if (!receivedItem.IpToSend.Equals(itemInList.Output) && receivedItem.Metric + 1 < itemInList.Metric)
                {
                    itemInList.Metric = receivedItem.Metric + 1;
                    itemInList.Output = receivedItem.IpToSend;
                }
                //Se a saida do item recebido for igual ao ip da lista e a metrica menor, atualiza a metrica e a saida
                else if (receivedItem.Output.Equals(itemInList.IpToSend) && receivedItem.Metric + 1 < itemInList.Metric)
                {
                    itemInList.Metric = receivedItem.Metric + 1;
                    itemInList.Output = receivedItem.Output;
                }
                //Se o IP recebido é igual a saida do item de mesmo IP no server e a metrica é zero(IP LOCAL) ou a metrica eh MAXVALUE(Server desligado) atualiza a metrica na tabela
                else if (receivedItem.IpToSend.Equals(itemInList.Output) && 
                    (receivedItem.Metric.Equals(0) || receivedItem.Metric.Equals(Int16.MaxValue + 1) || receivedItem.Metric.Equals(Int16.MaxValue)))
                {
                    itemInList.Metric = receivedItem.Metric + 1;
                }
            }
        }

        //Desconecta o server setando MaxValue para o ip do server
        public void DisconnectServer(String ip)
        {
            //Desliga o Server colocando metrica MaxValue para ele
            RoutedItem item = clientList.Where(x => x.IpToSend.Equals(IPAddress.Parse(ip))).FirstOrDefault();
            item.Metric = Int16.MaxValue;
        }

        //Reconect o server setando 0 para o ip do server
        internal void RestartServer(String ip)
        {
            RoutedItem item = clientList.Where(x => x.IpToSend.Equals(IPAddress.Parse(ip))).FirstOrDefault();
            item.Metric = 0;
        }
    }
}
