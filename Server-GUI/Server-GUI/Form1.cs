using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server_GUI
{
    public partial class Form1 : Form
    {
        Socket sock;
        Socket acc;
        byte[] Buffer;

        Socket Socket()
        {
            Socket sock = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            return sock;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sock = Socket();
            sock.Bind(new IPEndPoint(0, 8080));
            sock.Listen(10);
            MessageBox.Show("Escutando...");

            new Thread(delegate ()
            {

                acc = sock.Accept();
                MessageBox.Show("Conexão estável");
                sock.Close();




                while (true)
                {
                    try
                    {
                        Buffer = new byte[acc.SendBufferSize];
                        int bytesRec = acc.Receive(Buffer, 0, Buffer.Length, 0);

                        if (bytesRec <= 0)
                        {
                            throw new SocketException();
                        }

                        listBox1.Items.Add(Encoding.ASCII.GetString(Buffer));

                    }
                    catch
                    {
                        MessageBox.Show("Disconectado");
                        acc.Close();
                        break;
                    }

                }
                Application.Exit();
            }).Start();




        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.Default.GetBytes(textBox1.Text);
            acc.Send(data, 0, data.Length, 0);


        }

        
    }
}
