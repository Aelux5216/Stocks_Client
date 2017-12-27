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
            Client tempClient = new Client(); //Create new instance of client to get the static purchase history saved when the form ran.
            string[] PurchaseHistory = Client.purchaseHistory.Split('$');

            List<string> lstDesc = new List<string>();

            foreach (string item in PurchaseHistory)
            {
                {
                    lstDesc.Add(item); //For every string add it to a list. 
                }
            }

            lstDesc.Reverse(); //Reverse the history so that the most recent transation is first.

            foreach (string item in lstDesc)
            {
                lstDisplay.Items.Add(item); //Add to the list leaving a space inbetween for readability.
                lstDisplay.Items.Add("");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide(); //Hide this form.
            var client1 = Client.savedClient; //Set client1 equal to the saved client instance.
            client1.Show(); //Show the form.
        }
    }
}
