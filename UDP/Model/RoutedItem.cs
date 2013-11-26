using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace UDP.Model
{
    public class RoutedItem
    {
        public IPAddress Ip { get; set; }
        public Int32 Metric { get; set; }
        public IPAddress Output { get; set; }

        public RoutedItem(String ip, Int32 metric, String output) 
        {
            Ip = IPAddress.Parse(ip);
            Metric = metric;
            Output = IPAddress.Parse(output);
        }
    }
}
