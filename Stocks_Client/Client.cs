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
using System.Collections;

namespace Stocks_Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            connection();
            stockView();
        }

        //Declare companies array
        public ArrayList CompaniesArray = new ArrayList();

        public string recieved;

        public string GetRecieved()
        {
            return recieved;
        }

        public void SetRecieved(string inputRecieved)
        {
            recieved = inputRecieved;
        }

        public class ClientInfo
        {
            public TcpClient socket = null;
            public NetworkStream stream = null;
            public const int bufferSize = 1024;
            public byte[] buffer = new byte[bufferSize];
        }

        ClientInfo client = new ClientInfo();

        public static class Closer
        {
            public static bool flag = false;
        }

        public void connection()
        {
            if (client == null)
            {
                try
                {
                    client.socket.Connect("127.0.0.1", 8000);
                    client.stream = client.socket.GetStream();

                }
                catch (Exception)
                {
                    MessageBox.Show("Client failed to connect");
                }
            }
            else
            {
                
            }
        }

        public void Read()
        {
            var buffer = new byte[1024];
            var stream = client.socket.GetStream();
            stream.BeginRead(buffer, 0, buffer.Length, EndRead, buffer);
        }

        public void EndRead(IAsyncResult result)
        {
            var buffer = (byte[])result.AsyncState;
            var stream = client.socket.GetStream();
            var endBytes = stream.EndRead(result);
            string data = Encoding.ASCII.GetString(buffer, 0, endBytes);
            SetRecieved(data);
        }

        public void Send(string data)
        {
            var bytes = Encoding.ASCII.GetBytes(data);
            var stream = client.socket.GetStream();
            stream.BeginWrite(bytes, 0, bytes.Length, EndSend, bytes);
        }

        public void EndSend(IAsyncResult result)
        {
            var bytes = (byte[])result.AsyncState;
        }

        public void stockView()
        {
            Send("RequestDB");

            Read();

            string data = GetRecieved();

            //Split data into one row per company class

            //dgdDisplay.DefaultCellStyle.ForeColor = Color.Black;
            //dgdDisplay.Enabled = true;


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
