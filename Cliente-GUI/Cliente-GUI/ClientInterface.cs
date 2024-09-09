using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Cliente_GUI
{
    public partial class Client : Form
    {

        Socket sck;
        bool ThreadRunning = true;

        //
        // Create a new socket
        //
        Socket Socket()
        {
            Socket sock = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            return sock;
        }
        public Client()
        {
            InitializeComponent();
            sck = Socket();
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            ThreadRunning = false;

            if (sck.Connected)
            {
                sck.Close();
            }
        }

        //
        // Connect and disconnect the exchange messages with the server
        //
        private void ConnectButton_Click(object sender, EventArgs e)
        {
           
            if(sck.Connected)
            {
                sck.Shutdown(SocketShutdown.Both);
                sck.Close();
                sck = Socket();
            }

            try
            {
                IPEndPoint IPremote = new(IPAddress.Parse(InputIP.Text), 8080);
                sck.Connect(IPremote);
                ConnectButton.Text = "Disconnect";
            }
            catch
            {
                MessageBox.Show("Connection failed, possibly IP invalid");
            }

            //
            // Thread to check exchange messages
            //
            new Thread(delegate ()
            {
                while (ThreadRunning)
                {
                    try
                    {
                        byte[] receivedBuffer = new byte[sck.SendBufferSize];
                        int bytesRec =  sck.Receive(receivedBuffer, 0, receivedBuffer.Length, 0);
                        string receivedText = Encoding.ASCII.GetString(receivedBuffer, 0, bytesRec);

                        TextReceived.Invoke((MethodInvoker)delegate
                        {
                            TextReceived.Items.Add(receivedText);
                        });
                    } catch
                    {
                        break;
                    }
                }
            }).Start();
            
        }

        //
        // Send data to the server
        //
        private void SendButton_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.ASCII.GetBytes(InputData.Text);
            sck.Send(data, 0, data.Length, 0);
        }
    }
}
