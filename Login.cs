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
            string username = txtUsername.Text; //Get the inputted username. 

            if (username.Contains("$") || username.Contains(" "))
            {
                MessageBox.Show("Username cannot contain spaces or the '$' symbol." + Environment.NewLine + "Please try again."); //If the username contains spaces or $(my delimiter).
            }

            else if (username == "" || username == " ")
            {
                MessageBox.Show("Username cannot be blank."); //If username is blank show messagebox.
            }

            else if (txtIpAddress.Text == "" || txtIpAddress.Text == " ")
            {
                MessageBox.Show("Ip address cannot be blank."); //If ip address is blank show messagebox.
            }

            else
            {
                try
                {
                    IPAddress Ipaddress = IPAddress.Parse(txtIpAddress.Text); //Check to see if the ip address entered is valid by trying to convert it.
                    loginInfo = username + "$" + Ipaddress.ToString(); //Set Login info variable to username and ip address.
                    this.Hide(); //Hide this form.
                    var client1 = new Client(); //Create a new instance of client form.
                    client1.Closed += (f, args) => this.Close(); //Assign the close method to the instance.
                    client1.Show(); //Show the new form.
                }
                
                catch (Exception)
                {
                    MessageBox.Show("Invalid ip address." + Environment.NewLine + //If the ip address can't be converted show a messagebox.
                        "Please make sure it is in the correct format.");
                }
            }
        }

        private void Login_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) //If enter is pressed activate button.
            {
                btnLogin.PerformClick();
            }
        }
    }
}
