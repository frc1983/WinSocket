using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using UDP.Model;
using System.Net;

namespace UDP
{
    public partial class Form1 : Form
    {
        private bool isRunning { get; set; }

        public Form1()
        {
            InitializeComponent();            
            startServer();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (isRunning)
            {
                if (Listener.RoutedItemList.clientList.Count > 0)
                {
                    for (var i = 0; i < Listener.RoutedItemList.clientList.Count; i++)
                    {
                        Thread.Sleep(1000);
                        Sender.Send(Listener.Serialize(Listener.RoutedItemList.clientList),
                            new IPEndPoint(
                                IPAddress.Parse(Listener.RoutedItemList.clientList.ElementAt(i).Ip.ToString()),
                                11000)
                        );
                    }
                }
            }
        }

        private void startServer()
        {
            if (!backgroundWorker1.IsBusy)
            {
                Listener.Start();
                Thread.Sleep(1000);
                backgroundWorker1.RunWorkerAsync();
                isRunning = true;
            }
            lblServerIP.Text = Listener.serverIP.Address.ToString() + " - Port: " + Listener.serverIP.Port.ToString();
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            isRunning = false;
            Listener.Close();
            backgroundWorker1.Dispose(); 
        }

        private void btnRestartServer_Click(object sender, EventArgs e)
        {
            startServer();
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtClientIP.Text))
            {
                Listener.RoutedItemList.AddClient(txtClientIP.Text, 0, txtClientIP.Text);
            }

            var bs = new BindingSource();
            bs.DataSource = Listener.RoutedItemList.clientList;
            dtgClientes.DataSource = bs;
        }
    }
}
