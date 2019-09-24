using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;

namespace BACS380UDPServer
{
    public partial class frmServer : Form
    {
        public frmServer()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Receiver()
        {
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            Byte[] receivedBytes = new Byte[] { };
            string receivedString;

            UdpClient udpClient = new UdpClient(2222);

            while (true)
            {
                receivedBytes = udpClient.Receive(ref RemoteIpEndPoint);
                receivedString = Encoding.ASCII.GetString(receivedBytes);
                txtMessage.AppendText("IP: " + RemoteIpEndPoint.Address.ToString() + ":    ");
                txtMessage.AppendText(receivedString);
                txtMessage.AppendText(Environment.NewLine);
                txtMessage.Refresh();
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            Thread receivingThread = new Thread(Receiver);
            receivingThread.IsBackground = true;
            receivingThread.Start();
            btnStart.Enabled = false;
        }
    }
}
