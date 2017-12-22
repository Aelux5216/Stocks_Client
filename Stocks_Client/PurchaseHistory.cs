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
            dgdDisplay.Rows.Clear();
            dgdDisplay.Refresh();
            dgdDisplay.ColumnCount = 2;
            dgdDisplay.Columns[0].HeaderCell.Value = "Time of action";
            dgdDisplay.Columns[1].HeaderCell.Value = "Action taken";

            foreach (DataGridViewColumn d in dgdDisplay.Columns)
            {
                d.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgdDisplay.CellBorderStyle = DataGridViewCellBorderStyle.None;

            Client tempClient = new Client();
            string[] PurchaseHistory = Client.purchaseHistory.Split('$');

            int i = 0;

            string time,description;
            List<string> lstTime = new List<string>();
            List<string> lstDesc = new List<string>();

            foreach (string item in PurchaseHistory)
            {
                i++;
                if(i == 1)
                {
                    time = item;
                    lstTime.Add(item);
                }
                if(i == 2)
                {
                    description = item;
                    lstDesc.Add(item);
                }
            }

            int j = -1;

            foreach (string item in lstTime)
            {
                j++;
                dgdDisplay.RowCount = dgdDisplay.RowCount + 1;
                dgdDisplay.Rows[j].Cells[0].Value = item;
            }

            int k = -1;

            foreach (string item in lstDesc)
            {
                k++;
                dgdDisplay.RowCount = dgdDisplay.RowCount + 1;
                dgdDisplay.Rows[k].Cells[1].Value = item;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var client1 = new Client();
            client1.Closed += (f, args) => this.Close();
            client1.Show();
        }
    }
}
