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
            client.socket = new TcpClient();
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
            if (recieved == "")
            {
                recieved = inputRecieved;
            }
            else
            {
                recieved = recieved + inputRecieved;
            }
        }

        public void dgdUpdate()
        {
            recieved = "";

            Send("RequestDB");

            Read();

            Thread t = new Thread(() => Thread.Sleep(2));
            t.Start();
            t.Join();

            dgdDisplay.Rows.Clear();
            dgdDisplay.Refresh();
            dgdDisplay.ColumnCount = 5;
            dgdDisplay.RowCount = 15;
            dgdDisplay.CurrentCell = null;
            dgdDisplay.Columns[0].HeaderCell.Value = "SYMBOL";
            dgdDisplay.Columns[1].HeaderCell.Value = "COMPANY";
            dgdDisplay.Columns[2].HeaderCell.Value = "PRICE";
            dgdDisplay.Columns[3].HeaderCell.Value = "QUANTITY";
            dgdDisplay.Columns[4].HeaderCell.Value = "STOCKS_OWNED"; //Think how to do this better as client id will be needed and will need to be stored on server 
                                                                     //And intergrated with purchase history
            foreach (DataGridViewColumn d in dgdDisplay.Columns)
            {
                d.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgdDisplay.CellBorderStyle = DataGridViewCellBorderStyle.None;

            CompaniesArray.Clear();

            string symbol = "";
            string company = "";
            decimal price = 0;
            decimal quantity = 0;

            int i = 0;

            List<string> split = new List<string>(); 
            
            split = recieved.Split('$').ToList<string>();

            try
            {
                split.RemoveAt(60);
            }

            catch
            {

            }

            foreach (var v in split)
            {
                i++;

                if (i == 1)
                {
                    symbol = v;
                }

                if (i == 2)
                {
                    company = v;
                }

                if (i == 3)
                {
                    price = Convert.ToDecimal(v);
                }

                if (i == 4)
                {
                    quantity = Convert.ToDecimal(v);
                    Companies temp = new Companies(symbol, company, price, quantity);
                    CompaniesArray.Add(temp);
                    symbol = "";
                    company = "";
                    price = 0;
                    quantity = 0;
                    i = 0;
                }
            }

            int j = -1;

            foreach (Companies c in CompaniesArray)
            {
                j++;
                int k = -1;

                foreach (string s in c.Display())
                {
                    k++;
                    dgdDisplay.Rows[j].Cells[k].Value = s;
                }
            }

            dgdDisplay.AutoResizeColumns();
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
            if (client.socket.Connected == false)
            {
                try
                {
                    client.socket.Connect("127.0.0.1", 8000);
                    client.stream = client.socket.GetStream();

                    dgdUpdate();
                    dgdUpdate();//Temp fix for broken connection handling

                    MessageBox.Show("Client connected successfully");
                }
                catch (Exception)
                {
                    DialogResult dialogresult = MessageBox.Show("Client failed to connect" + Environment.NewLine + 
                        "if you press cancel please use reconnect button to reconnect","Failed to connect",MessageBoxButtons.RetryCancel);

                    if(dialogresult == DialogResult.Retry)
                    {
                        connection();
                    }
                    else if(dialogresult == DialogResult.Cancel)
                    {

                    }
                }
            }
            else
            {
                
            }
        }

        public void Read()
        {
            while (client.stream.DataAvailable)
            {
                client.stream.BeginRead(client.buffer, 0, client.buffer.Length, EndRead, client.buffer);
            }
        }

        public void EndRead(IAsyncResult result)
        {
            var stream = client.socket.GetStream();
            int endBytes = stream.EndRead(result);

            var buffer = (byte[])result.AsyncState;
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


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (client.socket.Connected)
            {
                dgdUpdate();
            }
            else
            {
                connection();
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            string row = dgdDisplay.SelectedRows.ToString();
            string command = "Buy";
            string symbol = row.Substring(0, 3);
            string data = command + symbol;
            Send(data);

            Read();

            if(recieved == "Success")
            {
                //Add 1 in correct cell
                //Update purchase history
                //Update view
                MessageBox.Show("Stock purchased successfully");
            }

            else if (recieved == "Fail")
            {
                MessageBox.Show("Stock purchase failed please try again");
            }
        }

        private void btnSell_Click(object sender, EventArgs e)
        {

        }

        private void btnPurchaseHistory_Click(object sender, EventArgs e)
        {

        }
        
        private void btnReconnect_Click(object sender, EventArgs e)
        {
            connection();
        }
    }
}
