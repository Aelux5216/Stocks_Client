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

namespace Stocks_Client
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public static string loginInfo { get; set; } //Realised i could use properties instead of writing it manually like i did on the client form.
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;

            if (username.Contains("$") || username.Contains(" "))
            {
                MessageBox.Show("Username cannot contain spaces or the '$' symbol." + Environment.NewLine + "Please try again.");
            }

            else
            {
                try
                {
                    IPAddress Ipaddress = IPAddress.Parse(txtIpAddress.Text);
                    loginInfo = username + "$" + Ipaddress.ToString();
                    this.Hide();
                    var client1 = new Client();
                    client1.Closed += (f, args) => this.Close();
                    client1.Show();
                }
                
                catch (Exception)
                {
                    MessageBox.Show("Invalid ip address." + Environment.NewLine +
                        "Please make sure it is in the correct format.");
                }
            }
        }
    }
}
