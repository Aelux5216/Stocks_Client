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

namespace Stocks_Client
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

        public static class Closer
        {
            public static bool flag = false;
        }

        public ClientInfo connection()
        {
            ClientInfo client = new ClientInfo();
            client.socket = new TcpClient();
            if (client == null)
            {
                try
                {
                    client.socket.Connect("127.0.0.1", 8000);
                    client.stream = client.socket.GetStream();
                    //dgdDisplay.
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

        public string recieved(string data)
        {
            return data;
        }

        public void Read()
        {
            ClientInfo client = connection();
            var buffer = new byte[1024];
            var stream = client.socket.GetStream();
            stream.BeginRead(buffer, 0, buffer.Length, EndRead, buffer);
        }

        public void EndRead(IAsyncResult result)
        {
            ClientInfo client = connection();
            var buffer = (byte[])result.AsyncState;
            var stream = client.socket.GetStream();
            var endBytes = stream.EndRead(result);
            string data = Encoding.ASCII.GetString(buffer, 0, endBytes);
            recieved(data);
        }

        public void Send(string data)
        {
            ClientInfo client = connection();
            var bytes = Encoding.ASCII.GetBytes(data);
            var stream = client.socket.GetStream();
            stream.BeginWrite(bytes, 0, bytes.Length, EndSend, bytes);
        }

        public void EndSend(IAsyncResult result)
        {
            var bytes = (byte[])result.AsyncState;
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
    }
}
