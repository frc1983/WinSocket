using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System.Threading;

namespace WinSocket
{
    public partial class Form1 : Form
    {
        public void SetLabel(string newText)
        {
            Invoke(new Action(() => lblServerStatus.Text = newText));
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }

        private void btnSendData_Click(object sender, EventArgs e)
        {
            AsynchronousClient.StartClient(this);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            AsynchronousSocketListener.StartListening(this);
        }

        private void btnCloseServer_Click(object sender, EventArgs e)
        {
            AsynchronousSocketListener.StopListening(this);
        }
    }
}
