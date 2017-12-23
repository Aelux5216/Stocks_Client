using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stocks_Client
{
    public partial class PurchaseHistory : Form
    {
        public PurchaseHistory()
        {
            InitializeComponent();
        }
        
        private void OnLoad(object sender, EventArgs e)
        {
            Client tempClient = new Client();
            string[] PurchaseHistory = Client.purchaseHistory.Split('$');

            List<string> lstDesc = new List<string>();

            foreach (string item in PurchaseHistory)
            {
                {
                    lstDesc.Add(item);
                }
            }

            lstDesc.Reverse(); 

            foreach (string item in lstDesc)
            {
                lstDisplay.Items.Add(item);
                lstDisplay.Items.Add("");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var client1 = Client.savedClient;
            client1.Show();
        }
    }
}
