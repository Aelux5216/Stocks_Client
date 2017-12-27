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
        }

        public void OnLoad(object sender, EventArgs e) //This method adds a socket to the client created below which after the form has loaded.
        {
            client.socket = new TcpClient();
            connect();
        }

        //Declare companies array
        public ArrayList CompaniesArray = new ArrayList(); 

        public string recieved;

        public string GetRecieved() //Public string getter and setter. 
        {
            return recieved;
        }

        public void SetRecieved(string inputRecieved)
        {
           recieved = inputRecieved;
        }

        public static string purchaseHistory { get; set; } //Public get/set string

        public void dgdUpdate()
        {
            Send("RequestDB");

            Read();

            Thread t = new Thread(() => Thread.Sleep(250)); //Sleep the thread to allow for the database processing.
            t.Start();
            t.Join();
            
            dgdDisplay.Rows.Clear();
            dgdDisplay.Refresh();
            dgdDisplay.ColumnCount = 5;
            dgdDisplay.RowCount = 15;
            dgdDisplay.Columns[0].HeaderCell.Value = "SYMBOL"; //Initialize settings for datagrid to make it appear more userfriendly. 
            dgdDisplay.Columns[1].HeaderCell.Value = "COMPANY";
            dgdDisplay.Columns[2].HeaderCell.Value = "PRICE";
            dgdDisplay.Columns[3].HeaderCell.Value = "QUANTITY";
            dgdDisplay.Columns[4].HeaderCell.Value = "STOCKS_OWNED"; 

            foreach (DataGridViewColumn d in dgdDisplay.Columns)
            {
                d.SortMode = DataGridViewColumnSortMode.NotSortable; //Disable column sort feature. 
            }

            dgdDisplay.CellBorderStyle = DataGridViewCellBorderStyle.None; //Remove cell borders.

            CompaniesArray.Clear(); //Clear the array ready to be re-populated.

            string symbol = "";
            string company = ""; //Initalize variables to default. 
            decimal price = 0;
            int quantity = 0;

            int i = 0; //Set counter to 0.

            List<string> split = GetRecieved().Split('$').ToList<string>(); //Split the database into a string array based on my delimiter.

            try
            {
                split.RemoveAt(0); //Remove column header variables and 60 if there is a blank entry but if not possible then carry on.
                split.RemoveAt(0);
                split.RemoveAt(0);
                split.RemoveAt(0);
                split.RemoveAt(60);
            }

            catch
            {

            }

            foreach (string v in split) //Loop over the strings in the array to set the values of each company. 
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
                    price = Convert.ToDecimal(v.Trim('\'')); //Convert the price into a 2 decimal place value.
                }

                if (i == 4)
                {
                    quantity = Convert.ToInt32(v.Trim('\'')); //Remove ' in case they are present.
                    Companies temp = new Companies(symbol, company, price, quantity); //Add values into a new company.
                    CompaniesArray.Add(temp); //Add the company into a company array.
                    symbol = "";
                    company = ""; //Set the values and counter back to default.
                    price = 0;
                    quantity = 0;
                    i = 0;
                }
            }

            int j = -1; //Set up counter for inserting into datagrid.

            foreach (Companies c in CompaniesArray)
            {
                j++;
                int k = -1; //Set up cell counter.

                foreach (string s in c.Display())
                {
                    k++;
                    dgdDisplay.Rows[j].Cells[k].Value = s;
                }
            }

            Login tempLogin = new Login(); //Create new instance of login to get ip address and username.
            string[] userDetails = Login.loginInfo.Split('$');

            Send("GetOwnedStocks" + "$" + userDetails[0]); //Send command with username.

            Read(); //Recieve result of command.

            Thread t2 = new Thread(() => Thread.Sleep(800)); //Sleep thread until SQL has been executed on the server side.
            t2.Start();
            t2.Join();

            List<string> splitOwnedStocks = GetRecieved().Split('$').ToList<string>(); //Put recieved string into a string array.

            splitOwnedStocks.RemoveAt(0); //Removing column stock.
            splitOwnedStocks.RemoveAt(15); //Remove blank entry.

            int l = -1;

            foreach (string item in splitOwnedStocks)
            {
                l++;
                dgdDisplay.Rows[l].Cells[4].Value = item; //Add into dgd under owned stocks column using counter which will be 0 during first iteration.
            }

            Send("GetPurchaseHistory" + "$" + userDetails[0]); //Send command with username.

            Read(); //Read the results.

            Thread t3 = new Thread(() => Thread.Sleep(500)); //Sleep thread while server processes SQL.
            t3.Start();
            t3.Join();
            
            purchaseHistory = GetRecieved(); //Set purchase history.

            Send("GetBalance" + "$" + userDetails[0] + "$" + txtBalance.Text.TrimStart('£')); //Send command and username with delimiter for the balance.

            Read(); //Read the results.

            Thread t4 = new Thread(() => Thread.Sleep(250)); //Sleep to allow for server processing.
            t4.Start();
            t4.Join();
            
            decimal splitBalance = Convert.ToDecimal(GetRecieved()); //Convert balance to 2 decimal places.

            string splitBalanceString = splitBalance.ToString("#####.00"); //Convert to string keeping to 2 decimal places even if it is a whole number.
            txtBalance.Text = "£" + splitBalanceString; //Add £ symbol to the front and set the textbox.

            grpAccount.Text = string.Format("Account:{0}", userDetails[0]); //Add username to account header.

            dgdDisplay.AutoResizeColumns(); //Resize columns so nothing is cut off.
        }

        public class ClientInfo //TCP client class.
        {
            public TcpClient socket = null;    //Initalize default tcpclient values.
            public NetworkStream stream = null;
            public const int bufferSize = 8192; //Buffer is this big due to purchase history strings.
            public byte[] buffer = new byte[bufferSize];
        }

        ClientInfo client = new ClientInfo(); //Create new instance of client class.

        public static Client savedClient { get; set; } //Save the instance and allow getting and setting.

        public void connect()
        {
            try
            {
                Login tempLogin = new Login();
                string[] userDetails = Login.loginInfo.Split('$'); //Try to connect to the server using the ip obtained from login page.

                client.socket.Connect(userDetails[1], 8000);
                client.stream = client.socket.GetStream(); //Get the current socket.

                dgdUpdate(); //Refresh the dgd.

                MessageBox.Show("Client connected successfully"); //Display message.
            }

            catch (Exception)
            {
                DialogResult dialogresult = MessageBox.Show("Client failed to connect" + Environment.NewLine + //If can't connect show messagebox to ask for reconnect.
                    "if you press cancel please use reconnect button to reconnect", "Failed to connect", MessageBoxButtons.RetryCancel);

                if (dialogresult == DialogResult.Retry)
                {
                    reconnect(); //Try to reconnect which only happens if the socket is null.
                }
                else if (dialogresult == DialogResult.Cancel)
                {

                }
            }
        }
        
        public void reconnect()
        {
            if (client.socket != null) //If socket is not null.
            {
                try
                {
                    Login tempLogin = new Login();
                    string[] userDetails = Login.loginInfo.Split('$'); //Connect.

                    client.socket = new TcpClient(); //Set socket to null first before reconnecting.

                    client.socket.Connect(userDetails[1], 8000);
                    client.stream = client.socket.GetStream();

                    MessageBox.Show("You have been re-connected successfully");
                }
                catch
                {
                    DialogResult dialogresult = MessageBox.Show("Client failed to reconnect" + Environment.NewLine + //If fails to connect display message.
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
                Login tempLogin = new Login(); //If socket is already null just connect.
                string[] userDetails = Login.loginInfo.Split('$'); 

                client.socket.Connect(userDetails[1], 8000);
                client.stream = client.socket.GetStream();

                MessageBox.Show("You have been connected successfully");
            }
        }

        public void Read()
        {
            try
            {
                var stream = client.socket.GetStream(); //Get the socket stream.
                client.stream.BeginRead(client.buffer, 0, client.buffer.Length, EndRead, client.buffer); //Send the data until length of buffer passing the process over to an async thread callback.
            }

            catch
            {
                reconnect(); //If this fails make sure client is connected to the server.
            }
        }

        public void EndRead(IAsyncResult result)
        {
           var stream = client.socket.GetStream(); //Get the stream as it is out of context now.
           int endBytes = stream.EndRead(result); //Find out how much data is left to read.

           var buffer = (byte[])result.AsyncState; //Create buffer based on the previous read method.
           string data = Encoding.UTF8.GetString(buffer, 0, endBytes); //Get the string from the data.
           SetRecieved(data); //Set the recieved string to the new data.
        }

        public void Send(string data)
        {
            var bytes = Encoding.UTF8.GetBytes(data); //Get the bytes of the input data.
            try
            {
                var stream = client.socket.GetStream(); //Get the socket stream.
                stream.BeginWrite(bytes, 0, bytes.Length, EndSend, bytes); //Begin writing data until the end of the amount of bytes while passing to async callback method.
            }

            catch
            {
                reconnect(); //If this fails make sure client is connected to the server.
            }
        }

        public void EndSend(IAsyncResult result)
        {
            var bytes = (byte[])result.AsyncState; //Get the info to bytes and finish sending.
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (client.socket.Connected)
            {
                dgdUpdate(); //Refresh view.
            }
            else
            {
                reconnect(); //Make sure client is connected.
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            Login tempLogin = new Login();
            string[] userDetails = Login.loginInfo.Split('$'); //Get username from login form instance.

            string command = "BuyStock";
            string symbol = dgdDisplay.CurrentRow.Cells[0].Value.ToString(); //Get variables including selected symbol.
            string username = userDetails[0];

            string data2 = command + "$" + symbol + "$" + username; //Setup buy stock command.

            Send(data2); //Send the command with data.

            Read(); //Read the results of the command.
            
            Thread t = new Thread(() => Thread.Sleep(500)); //Sleep the thread to wait for server to execute SQL.
            t.Start();
            t.Join();
            
            if (recieved == "Success")
            {
                MessageBox.Show("Stock purchased successfully"); //If command recieved is equal to success then update the datagrid.
                dgdUpdate();
            }

            else if (recieved == "NoFunds")
            {
                MessageBox.Show("You do not have enough money to buy this stock."); //Else show messagebox.
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
            string[] userDetails = Login.loginInfo.Split('$'); //Same as above

            string command = "SellStock";
            string symbol = dgdDisplay.CurrentRow.Cells[0].Value.ToString();
            string username = userDetails[0];

            string data2 = command + "$" + symbol + "$" + username;

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
            if (purchaseHistory == "None") //If recieved purchase history was command None then show messagebox.
            {
                MessageBox.Show("Please make sure you have purchased/sold a stock before trying to view your history.");
            }

            else
            {
                savedClient = this; //Save the instance of client form.
                this.Hide(); //Hide this form.
                var PurchaseHistory = new PurchaseHistory(); //Create an instance of purchase history form.
                PurchaseHistory.Closed += (f, args) => this.Close(); //Assign the close method to the new instance.
                PurchaseHistory.Show(); //Show the new form.
            }
        }
        
        private void btnReconnect_Click(object sender, EventArgs e)
        {
            reconnect(); //Run the reconnect method.
        }
		
		private void btnSignOut_Click(object sender, EventArgs e)
		{
			    client.socket = null; //Disconnect socket.
				this.Hide(); //Hide the client form.
                var Login1 = new Login(); //Create a new instance of login form.
                Login1.Closed += (f, args) => this.Close(); //Assign close method to the new instance. 
                Login1.Show(); //Show the new form.
		}
    }
}
