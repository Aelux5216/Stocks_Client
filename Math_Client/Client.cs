using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Math_Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            connection();  
        }

public class ClientInfo
        {
            public TcpClient socket = null;
            public NetworkStream stream = null;
            public const int bufferSize = 1024;
            public byte[] buffer = new byte[bufferSize];
        }

        public class Protocol
        {
            /************************************************************************************************************************************************************/
            /*  The protocol i will be using is: [size of command 7 bytes][command][size of stock 4 bytes][stock][size of data 60 bytes][data] */
            /***********************************************************************************************************************************************************/
            public string command;
            public string stock;
            public string dataString;
            public Int32 commandSize;
            public Int32 stockSize;
            public Int32 stockSizeArray = 4;
            public Int32 commandSizeArray = 7;
            public Int32 dataSizeArray = 60;
        }

        public static class Closer
        {
            public static bool flag = false;
        }

        public ClientInfo connection()
        {
            ClientInfo client = new ClientInfo();
            client.socket = new TcpClient();
            if (client != null)
            {
                try
                {
                    client.socket.Connect("127.0.0.1", 8000);
                    client.stream = client.socket.GetStream();
                    return client;
                }
                catch (Exception)
                {
                    MessageBox.Show("Client failed to connect");
                    return client;
                }
            }
            else
            {
                return client;
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {

        }

        private void btnSell_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnPurchaseHistory_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientInfo client = connection();

            string message = "Buy This is a test";
            byte[] messageSend = System.Text.Encoding.ASCII.GetBytes(message);
            client.stream.WriteAsync(messageSend, 0, messageSend.Length);

            while(client.stream.DataAvailable)
            {
                client.stream.Read(client.buffer, 0, client.buffer.Length);
            }

            byte[] confirmed = new byte[500];
            client.stream.Read(confirmed, 0, confirmed.Length);
            string thing = System.Text.Encoding.ASCII.GetString(confirmed);
            textBox2.Text = thing;

            return;
        }
    }
}
