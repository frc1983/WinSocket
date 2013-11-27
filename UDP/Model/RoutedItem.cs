using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace UDP.Model
{
    public class RoutedItem
    {
        public IPAddress IpToSend { get; set; }
        public Int32 Metric { get; set; }
        public IPAddress Output { get; set; }

        public RoutedItem(String ipToSend, Int32 metric, String output) 
        {
            IpToSend = IPAddress.Parse(ipToSend);
            Metric = metric;
            Output = IPAddress.Parse(output);
        }
    }
}
