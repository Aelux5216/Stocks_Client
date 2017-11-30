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

namespace Math_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        Socket client;

        public delegate void setTextCallback(string text);

        public void setText(string text)
        {
            if (this.txtLog.InvokeRequired)
            {
                // Different thread, use Invoke.
                setTextCallback d = new setTextCallback(FinishSetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                // Same thread, no Invoke.
                this.txtLog.Text = this.txtLog.Text + text;

            }
        }

        private void FinishSetText(string text)
        {
            this.txtLog.Text = this.txtLog.Text + text;
        }

        // State object for receiving data from remote device.  
        public class StateObject
        {
            // Client socket.  
            public Socket workSocket = null;
            // Size of receive buffer.  
            public const int BufferSize = 256;
            // Receive buffer.  
            public byte[] buffer = new byte[BufferSize];
            // Received data string.  
            public StringBuilder sb = new StringBuilder(); 
        }

        public class AsyncClient
        {
            private Action<string> setText;


            public AsyncClient(Action<string> setText)
            {
                this.setText = setText;
            }

            // The port number for the remote device.  
            private const int port = 8080;

            // ManualResetEvent instances signal completion.  
            private static ManualResetEvent connectDone =
                new ManualResetEvent(false);
            private static ManualResetEvent sendDone =
                new ManualResetEvent(false);
            private static ManualResetEvent receiveDone =
                new ManualResetEvent(false);

            public static String response { get; set; }

            public string getData()
            {
                return response;
            }

            public Socket StartClient()
            {
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                // Create a TCP/IP socket.  
                Socket client = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect to a remote device.  
                try
                {
                    // Establish the remote endpoint for the socket.  
                      
                    IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
                    
                    // Connect to the remote endpoint.  
                    client.BeginConnect(remoteEP,
                        new AsyncCallback(ConnectCallback), client);
                    connectDone.WaitOne();

                    // Release the socket.  
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();

                    return client;
                }
                catch (Exception e)
                {

                    setText(e.ToString()); 
                    return client;
                }
            }

            public void ConnectCallback(IAsyncResult ar)
            {
                try
                {
                    // Retrieve the socket from the state object.  
                    Socket client = (Socket)ar.AsyncState;

                    // Complete the connection.  
                    client.EndConnect(ar);

                    setText(string.Format("Socket connected to {0}",
                        client.RemoteEndPoint.ToString()));

                    // Signal that the connection has been made.  
                    connectDone.Set();
                }
                catch (Exception e)
                {
                    setText(e.ToString());
                }
            }

            public void Receive(Socket client)
            {
                try
                {
                    // Create the state object.  
                    StateObject state = new StateObject();
                    state.workSocket = client;

                    // Begin receiving the data from the remote device.  
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                catch (Exception e)
                {
                    setText(e.ToString());
                }
            }

            public void ReceiveCallback(IAsyncResult ar)
            {
                try
                {
                    // Retrieve the state object and the client socket   
                    // from the asynchronous state object.  
                    StateObject state = (StateObject)ar.AsyncState;
                    Socket client = state.workSocket;

                    // Read data from the remote device.  
                    int bytesRead = client.EndReceive(ar);

                    if (bytesRead > 0)
                    {
                        // There might be more data, so store the data received so far.  
                        state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                        // Get the rest of the data.  
                        client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                            new AsyncCallback(ReceiveCallback), state);
                    }
                    else
                    {
                        // All the data has arrived; put it in response.  
                        if (state.sb.Length > 1)
                        {
                           response = state.sb.ToString();
                        }
                        // Signal that all bytes have been received.  
                        receiveDone.Set();
                    }
                }
                catch (Exception e)
                {
                    setText(e.ToString());
                }
            }

            public void Send(Socket client, String data)
            {
                // Convert the string data to byte data using ASCII encoding.  
                byte[] byteData = Encoding.ASCII.GetBytes(data);

                // Begin sending the data to the remote device.  
                client.BeginSend(byteData, 0, byteData.Length, 0,
                    new AsyncCallback(SendCallback), client);
            }

            public void SendCallback(IAsyncResult ar)
            {
                try
                {
                    // Retrieve the socket from the state object.  
                    Socket client = (Socket)ar.AsyncState;

                    // Complete sending the data to the remote device.  
                    int bytesSent = client.EndSend(ar);

                    setText(string.Format("Sent {0} bytes to server.", bytesSent));

                    // Signal that all bytes have been sent.  
                    sendDone.Set();
                }
                catch (Exception e)
                {
                    setText(e.ToString());
                }
            }
        }


        public void Message()
        {
            var ac = new AsyncClient(setText);

            string command = cmbCommand.SelectedItem.ToString();
            string message = "";
            string data = "";

            if (command == "Message")
            {
                message = txtInput.Text;
                data = command + message;

                ac.Send(client, data);
                ac.Receive(client);
                txtLog.Text = txtLog.Text + ac.getData();
            }
        }

        public void btnSend_Click(object sender, EventArgs e)
        {
            if (client == null)
            {
                var ac = new AsyncClient(setText);
                client = ac.StartClient();

                Message();
            }
            else
            {
                Message();
            }
        }
    }
}
