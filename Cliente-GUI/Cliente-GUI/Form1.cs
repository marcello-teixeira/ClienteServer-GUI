using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Cliente_GUI
{
    public partial class Form1 : Form
    {

        Socket sck;

        Socket Socket()
        {
            Socket sock = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            return sock;
        }
        public Form1()
        {
            InitializeComponent();
            sck = Socket();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPEndPoint IPremote = new(IPAddress.Parse(textBox1.Text), 8080);

            try
            {
                sck.Connect(IPremote);
                button1.Text = "Deconectar";
            }
            catch
            {
                MessageBox.Show("Conexão interrompida");
                sck.Close();
            }

            new Thread(delegate ()
            {
                while (true)
                {
                    byte[] receivedBuffer = new byte[sck.SendBufferSize];
                    sck.Receive(receivedBuffer, 0, receivedBuffer.Length, 0);
                    listBox1.Items.Add(Encoding.ASCII.GetString(receivedBuffer));

                }

            }).Start();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.ASCII.GetBytes(textBox2.Text);
            sck.Send(data, 0, data.Length, 0);
        }
    }
}
