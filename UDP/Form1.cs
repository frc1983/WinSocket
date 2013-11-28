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
        private int _sleep = 10000;

        public Form1()
        {
            InitializeComponent();            
            startServer();
        }

        //Envia as mensagens para cada item da lista de clientes
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (isRunning)
            {
                if (Listener.RoutedItemList.clientList.Count > 0)
                {
                    for (var i = 0; i < Listener.RoutedItemList.clientList.Count; i++)
                    {
                        Thread.Sleep(_sleep);
                        Sender.Send(Listener.Serialize(Listener.RoutedItemList.clientList),
                            new IPEndPoint(
                                IPAddress.Parse(Listener.RoutedItemList.clientList.ElementAt(i).IpToSend.ToString()),
                                11000)
                        );
                    }
                    BeginInvoke(new Action(() => refreshGrid()));
                }
            }
        }

        //Atualiza a grid de clients
        private void refreshGrid()
        {
            var bs = new BindingSource();
            bs.DataSource = Listener.RoutedItemList.clientList;
            dtgClientes.DataSource = bs;
        }

        //Inicia o servidor e inicia a thread que fica ouvindo mensagens
        private void startServer()
        {
            if (!backgroundWorker1.IsBusy)
            {
                Listener.Start();
                Thread.Sleep(_sleep);
                backgroundWorker1.RunWorkerAsync();
                isRunning = true;
            }
            lblServerIP.Text = Listener.serverIP.Address.ToString() + " - Port: " + Listener.serverIP.Port.ToString();
            Listener.RoutedItemList.AddClient(Listener.serverIP.Address.ToString(),-1, Listener.serverIP.Address.ToString(), true);
        }

        //Desconecta o servidor
        private void btnKill_Click(object sender, EventArgs e)
        {
            Listener.Close();
        }

        //Reconecta o servidor
        private void btnRestartServer_Click(object sender, EventArgs e)
        {
            Listener.Restart();
        }

        //Adiciona um client na lista local
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtClientIP.Text))
            {
                Listener.RoutedItemList.AddClient(txtClientIP.Text, 0, txtClientIP.Text, true);
                Listener.RoutedItemList.AddNeighbor(txtClientIP.Text);
            }
        }
    }
}
