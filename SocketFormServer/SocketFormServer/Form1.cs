using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace SocketFormServer
{
    public partial class Server : Form
    {
        public static string data = null;
        public static IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
        public static IPEndPoint remoteEP = new IPEndPoint(ipAddress, 8888);
        public static Socket _socketServer = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        

        public Server()
        {
            InitializeComponent();
            _socketServer.Bind(remoteEP);
            _socketServer.Listen(30);
        }
        private void RecMsg()
        {
            Socket handler;
            handler = _socketServer.Accept();
            data = "Someone connected to the server";
            MsgChat();
            Invoke(new MethodInvoker(StartThread));
            var random = new Random();
            while (true)
            {
                data = null;
                byte[] bytes = new byte[1024];
                try
                {
                    
                    while (true)
                    {
                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (data.IndexOf("<EOF>") > -1)
                        {
                            data = data.Remove(data.Length - 1);
                            data = data.Remove(data.Length - 1);
                            data = data.Remove(data.Length - 1);
                            data = data.Remove(data.Length - 1);
                            data = data.Remove(data.Length - 1);
                            MsgChat();
                            Console.WriteLine(data);
                            if (data.ToLower().Contains("numero random"))
                            {
                                data = random.Next().ToString();
                                EditTxtBoxSend(handler);
                            }
                            else if (data.ToLower().Contains("un dado"))
                            {
                                data = random.Next(1, 7).ToString();
                                EditTxtBoxSend(handler);
                            }
                            else if (data.ToLower().Contains("due dadi"))
                            {
                                data = random.Next(1, 7).ToString() + " " + random.Next(1, 7).ToString();
                                EditTxtBoxSend(handler);
                            }else if (data.ToLower().Contains("calcolatrice"))
                            {
                                string[] splitData = data.Split(' ');
                                if (splitData.Length > 2)
                                {
                                    switch (splitData[2])
                                    {
                                        case "+":
                                            data = (float.Parse(splitData[1]) + float.Parse(splitData[3])).ToString();
                                            break;
                                        case "-":
                                            data = (float.Parse(splitData[1]) - float.Parse(splitData[3])).ToString();
                                            break;
                                        case "*":
                                            data = (float.Parse(splitData[1]) * float.Parse(splitData[3])).ToString();
                                            break;
                                        case "/":
                                            data = (float.Parse(splitData[1]) / float.Parse(splitData[3])).ToString();
                                            break;
                                        default:
                                            data = "Devi usare la seguente struttura: 'Calcolatrice x + y'";
                                            break;
                                    }
                                }else
                                    data = "Devi usare la seguente struttura: 'Calcolatrice x + y'";
                                EditTxtBoxSend(handler);
                            }
                            else if (data.ToLower().Contains("lancio moneta"))
                            {
                                int r = random.Next(0, 2);
                                if (r == 0) data = "testa";
                                else data = "croce";
                                EditTxtBoxSend(handler);
                            }else if(data.ToLower().Contains("pi greco"))
                            {
                                
                                double pi = 3.14159265358979;
                                char[] piC = pi.ToString().ToCharArray();
                                string[] splitData = data.Split(' ');
                                Int32.TryParse(splitData[2], out int num);
                                if (num > 15) data = "Il massimo di cifre è 15!";
                                else if (num == 0) data = "Il minimo di cifre è 1!";
                                else
                                {
                                    if (splitData.Length == 3)
                                    {
                                        data = "";
                                        for (int n = 0; n < num + 1; ++n)
                                            data += piC[n].ToString();
                                    }
                                    else
                                        data = "Devi usare la seguente struttura: 'Pi Greco [numero di cifre]";
                                }
                                EditTxtBoxSend(handler);
                            }
                            break;
                        }
                    }
                }
                catch (Exception e) { Console.Write(e); }
            }
            
        }
        private void EditTxtBoxSend(Socket handler)
        {
            byte[] msg = Encoding.ASCII.GetBytes(data + "<EOF>");

            int bytesSent = handler.Send(msg);
            data = txtBoxSend.Text;
            Console.WriteLine(data);
            MsgChat();

        }
        private void MsgChat()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(MsgChat));
            else
                txtBoxChat.AppendText(Environment.NewLine + data);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _socketServer.Shutdown(SocketShutdown.Both);
                _socketServer.Close();
            }catch(Exception ex) { Console.Write(ex); };
            Environment.Exit(0);

        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            if (btnNewConnection.Text == "Avvia Server")
            {
                data = "Waiting for connection...";
                MsgChat();
                btnNewConnection.Text = "Spegni Server";
                StartThread();
                
            }
            else
            {
                _socketServer.Shutdown(SocketShutdown.Both);
                _socketServer.Close();
            }
        }
        private void StartThread()
        {
            Thread _recMsg = new Thread(RecMsg);
            _recMsg.Start();
        }

        private void txtBoxSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Send.PerformClick();
            }
        }
    }
}
