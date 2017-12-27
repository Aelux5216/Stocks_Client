﻿using System;
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
        }

        public void OnLoad(object sender, EventArgs e)
        {
            client.socket = new TcpClient();
            connect();
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

        public static string purchaseHistory { get; set; }

        public void dgdUpdate()
        {
            Send("RequestDB");

            Read();

            Thread t = new Thread(() => Thread.Sleep(250));
            t.Start();
            t.Join();
            
            dgdDisplay.Rows.Clear();
            dgdDisplay.Refresh();
            dgdDisplay.ColumnCount = 5;
            dgdDisplay.RowCount = 15;
            dgdDisplay.Columns[0].HeaderCell.Value = "SYMBOL";
            dgdDisplay.Columns[1].HeaderCell.Value = "COMPANY";
            dgdDisplay.Columns[2].HeaderCell.Value = "PRICE";
            dgdDisplay.Columns[3].HeaderCell.Value = "QUANTITY";
            dgdDisplay.Columns[4].HeaderCell.Value = "STOCKS_OWNED"; 

            foreach (DataGridViewColumn d in dgdDisplay.Columns)
            {
                d.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgdDisplay.CellBorderStyle = DataGridViewCellBorderStyle.None;

            CompaniesArray.Clear();

            string symbol = "";
            string company = "";
            decimal price = 0;
            int quantity = 0;

            int i = 0;

            List<string> split = GetRecieved().Split('$').ToList<string>();

            try
            {
                split.RemoveAt(0);
                split.RemoveAt(0);
                split.RemoveAt(0);
                split.RemoveAt(0);
                split.RemoveAt(60);
            }

            catch
            {

            }

            foreach (string v in split)
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
                    price = Convert.ToDecimal(v.Trim('\''));
                }

                if (i == 4)
                {
                    quantity = Convert.ToInt32(v.Trim('\''));
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

            Login tempLogin = new Login();
            string[] userDetails = Login.loginInfo.Split('$');

            Send("GetOwnedStocks" + "$" + userDetails[0]);

            Read();

            Thread t2 = new Thread(() => Thread.Sleep(600));
            t2.Start();
            t2.Join();

            List<string> splitOwnedStocks = GetRecieved().Split('$').ToList<string>();

            splitOwnedStocks.RemoveAt(0);
            splitOwnedStocks.RemoveAt(15);

            int l = -1;

            foreach (string item in splitOwnedStocks)
            {
                l++;
                dgdDisplay.Rows[l].Cells[4].Value = item; //Add into dgd Properly
            }

            Send("GetPurchaseHistory" + "$" + userDetails[0]);

            Read();

            Thread t3 = new Thread(() => Thread.Sleep(500));
            t3.Start();
            t3.Join();
            
            purchaseHistory = GetRecieved();

            Send("GetBalance" + "$" + userDetails[0] + "$" + txtBalance.Text.TrimStart('£'));

            Read();

            Thread t4 = new Thread(() => Thread.Sleep(250));
            t4.Start();
            t4.Join();
            
            decimal splitBalance = Convert.ToDecimal(GetRecieved());

            string splitBalanceString = splitBalance.ToString("#####.00"); 
            txtBalance.Text = "£" + splitBalanceString;

            grpAccount.Text = string.Format("Account:{0}", userDetails[0]);

            //recieve clientinfo from server
            dgdDisplay.AutoResizeColumns();
        }

        public class ClientInfo
        {
            public TcpClient socket = null;
            public NetworkStream stream = null;
            public const int bufferSize = 8192;
            public byte[] buffer = new byte[bufferSize];
        }

        ClientInfo client = new ClientInfo();

        public static Client savedClient { get; set; }

        public void connect()
        {
            try
            {
                Login tempLogin = new Login();
                string[] userDetails = Login.loginInfo.Split('$');

                client.socket.Connect(userDetails[1], 8000);
                client.stream = client.socket.GetStream();

                dgdUpdate();

                MessageBox.Show("Client connected successfully");
            }

            catch (Exception)
            {
                DialogResult dialogresult = MessageBox.Show("Client failed to connect" + Environment.NewLine +
                    "if you press cancel please use reconnect button to reconnect", "Failed to connect", MessageBoxButtons.RetryCancel);

                if (dialogresult == DialogResult.Retry)
                {
                    reconnect();
                }
                else if (dialogresult == DialogResult.Cancel)
                {

                }
            }
        }

        public void stillConnected()
        {
            if (client.socket.Connected == false)
            {
                try
                {
                    Login tempLogin = new Login();
                    string[] userDetails = Login.loginInfo.Split('$');

                    client.socket.Connect(userDetails[1], 8000);
                    client.stream = client.socket.GetStream();

                    MessageBox.Show("Client was disconnected, you have been re-connected successfully");
                }
                catch (Exception)
                {
                    DialogResult dialogresult = MessageBox.Show("Client was disconnected and failed to reconnect" + Environment.NewLine +
                        "please try again.", "Failed to connect", MessageBoxButtons.RetryCancel);

                    if (dialogresult == DialogResult.Retry)
                    {
                        stillConnected();
                    }
                    else if (dialogresult == DialogResult.Cancel)
                    {

                    }
                }
            }
            else
            {
                
            }
        }


        public void reconnect()
        {
            if (client.socket != null)
            {
                try
                {
                    Login tempLogin = new Login();
                    string[] userDetails = Login.loginInfo.Split('$');

                    client.socket = new TcpClient();

                    client.socket.Connect(userDetails[1], 8000);
                    client.stream = client.socket.GetStream();

                    MessageBox.Show("You have been re-connected successfully");
                }
                catch
                {
                    DialogResult dialogresult = MessageBox.Show("Client failed to reconnect" + Environment.NewLine +
                        "please try again.", "Failed to connect", MessageBoxButtons.RetryCancel);

                    if (dialogresult == DialogResult.Retry)
                    {
                        reconnect();
                    }
                    else if (dialogresult == DialogResult.Cancel)
                    {

                    }
                }
            }

            else
            {
                Login tempLogin = new Login();
                string[] userDetails = Login.loginInfo.Split('$');

                client.socket.Connect(userDetails[1], 8000);
                client.stream = client.socket.GetStream();

                MessageBox.Show("You have been connected successfully");
            }
        }

        public void Read()
        {
            var stream = client.socket.GetStream();
            client.stream.BeginRead(client.buffer, 0, client.buffer.Length, EndRead, client.buffer);
        }

        public void EndRead(IAsyncResult result)
        {
           var stream = client.socket.GetStream();
           int endBytes = stream.EndRead(result);

           var buffer = (byte[])result.AsyncState;
           string data = Encoding.UTF8.GetString(buffer, 0, endBytes);
           SetRecieved(data);
        }

        public void Send(string data)
        {
            var bytes = Encoding.UTF8.GetBytes(data);
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
                stillConnected();
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            Login tempLogin = new Login();
            string[] userDetails = Login.loginInfo.Split('$');

            string command = "BuyStock";
            string symbol = dgdDisplay.CurrentRow.Cells[0].Value.ToString();
            string username = userDetails[0];

            string data2 = command + "$" + symbol + "$" + username;

            stillConnected();
            Send(data2);

            Read();
            
            Thread t = new Thread(() => Thread.Sleep(500));
            t.Start();
            t.Join();
            
            if (recieved == "Success")
            {
                MessageBox.Show("Stock purchased successfully");
                dgdUpdate();
            }

            else if (recieved == "NoFunds")
            {
                MessageBox.Show("You do not have enough money to buy this stock.");
            }

            else if (recieved == "NoCompanyStocksOwned")
            {
                MessageBox.Show("You do not own any stocks to sell with this company");
            }

            else
            {
                
            }
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            Login tempLogin = new Login();
            string[] userDetails = Login.loginInfo.Split('$');

            string command = "SellStock";
            string symbol = dgdDisplay.CurrentRow.Cells[0].Value.ToString();
            string username = userDetails[0];

            string data2 = command + "$" + symbol + "$" + username;

            stillConnected();
            Send(data2);

            Read();
            
            Thread t = new Thread(() => Thread.Sleep(500));
            t.Start();
            t.Join();

            if (recieved == "Success")
            {
                MessageBox.Show("Stock sold successfully");
                dgdUpdate();
            }

            else if (recieved == "NoOwnedStocks")
            {
                MessageBox.Show("You do not own any stocks to sell with this company");
            }

            else
            {

            }
        }

        private void btnPurchaseHistory_Click(object sender, EventArgs e)
        {
            if (purchaseHistory == "None")
            {
                MessageBox.Show("Please make sure you have purchased/sold a stock before trying to view your history.");
            }

            else
            {
                savedClient = this;
                this.Hide();
                var PurchaseHistory = new PurchaseHistory();
                PurchaseHistory.Closed += (f, args) => this.Close();
                PurchaseHistory.Show();
            }
        }
        
        private void btnReconnect_Click(object sender, EventArgs e)
        {
            reconnect();
        }
		
		private void btnSignOut_Click(object sender, EventArgs e)
		{
			    client.socket = null;
				this.Hide();
                var Login1 = new Login();
                Login1.Closed += (f, args) => this.Close();
                Login1.Show();
		}
    }
}