using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace bacs380ChatClient
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            UdpClient udpClient = new UdpClient();
            Byte[] sendBytes = new Byte[] { };
            sendBytes = Encoding.ASCII.GetBytes(txtMessage.Text);
            udpClient.Send(sendBytes, sendBytes.Length, txtIP.Text, int.Parse(txtPort.Text));
            udpClient.Close();
        }
    }
}
