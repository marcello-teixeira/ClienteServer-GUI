using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server_GUI
{
    public partial class Server : Form
    {
        Socket sock;
        Socket acc;
        byte[] Buffer;
        bool ThreadRunning = true;
        Thread ServerThread;
        Thread ClientThread;

        //
        // Server IP address
        //
        private string _localIP;
        public string LocalIP {
            get
            {
                return _localIP;
            }
            private set
            {
                if (string.IsNullOrEmpty(_localIP))
                {
                    foreach (var ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                    {
                        if (ip.AddressFamily == AddressFamily.InterNetwork)
                        {
                            _localIP = ip.ToString();
                            break;
                        }
                    }
                }
            }
        }

        //
        // Create a new socket
        //
        Socket Socket()
        {
            Socket sock = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            return sock;
        }

        public Server()
        {
            InitializeComponent();
            LocalIP = "";
        }
        //
        // When app to closed
        //
        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            ThreadRunning = false;

            if (ClientThread != null && ClientThread.IsAlive)
            {
                ClientThread.Join();
            }

            if (sock != null && sock.Connected)
            {
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
            }

            if (acc != null && acc.Connected)
            {
                acc.Shutdown(SocketShutdown.Both);
                acc.Close();
            }

            if (ServerThread != null && ServerThread.IsAlive)
            {
                ServerThread.Join();
            }
        }

        private void Server_Load(object sender, EventArgs e)
        {
        }

        //
        // Create a endpoint and await connection client 
        //
        private void ButtonListen_Click(object sender, EventArgs e)
        {
            sock = Socket();
            sock.Bind(new IPEndPoint(0, 8080));
            sock.Listen(10);

            // Show which IP server is running
            MessageBox.Show($"The server is running in {LocalIP}");

            ButtonListen.Enabled = false;

            ServerThread = new Thread(() =>
            {
                while (ThreadRunning)
                {
                    try
                    {
                        acc = sock.Accept();
                        MessageBox.Show("Connection successful");

                        ClientThread = new Thread(() =>
                        {
                            while (ThreadRunning)
                            {
                                try
                                {
                                    Buffer = new byte[acc.SendBufferSize];
                                    int bytesRec = acc.Receive(Buffer, 0, Buffer.Length, 0);

                                    if (bytesRec <= 0)
                                    {
                                        throw new SocketException();
                                    }

                                    string receivedText = Encoding.ASCII.GetString(Buffer, 0, bytesRec);

                                    TextReceived.Invoke((MethodInvoker)delegate
                                    {
                                        TextReceived.Items.Add(receivedText);
                                    });

                                }
                                catch
                                {
                                    MessageBox.Show("Client disconnect");
                                    acc.Shutdown(SocketShutdown.Both);
                                    acc.Close();
                                    break;
                                }
                            }
                        });
                        ClientThread.Start();
                    }
                    catch
                    {
                        MessageBox.Show("Error in connection client");
                    }
                }
            });
            ServerThread.Start();
        }

        //
        // Send data to the client
        //
        private void SendButton_Click(object sender, EventArgs e)
        { 
            if(acc != null && acc.Connected) {
                byte[] data = Encoding.Default.GetBytes(InputData.Text);
                acc.Send(data, 0, data.Length, 0);
            }
        }

        
    }
}
