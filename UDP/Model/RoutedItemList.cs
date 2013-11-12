using System;
using System.Collections.Generic;
using System.Linq;
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

        public void AddClient(string ip, Int32 metric)
        {
            var item = new RoutedItem(ip, metric);

            if (!clientList.Any(x => x.Ip.Equals(item.Ip)))
                clientList.Add(item);
            else if (clientList.Any(x => x.Ip.Equals(item.Ip)))
            {
                //Existe o IP na tabel, entao confere a metrica e usa a menor
            }
        }

        public RoutedItem getClient(Int32 index)
        {
            return clientList.ElementAt(index);
        }
    }
}
