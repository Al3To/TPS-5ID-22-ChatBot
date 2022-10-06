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

namespace SocketFormServer
{
    public partial class Form1 : Form
    {
        public static string data = null;
        public static IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
        public static IPEndPoint remoteEP = new IPEndPoint(ipAddress, 8888);
        public static Socket _socketServer = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        public static Socket handler;

        public Form1()
        {
            InitializeComponent();
            _socketServer.Bind(remoteEP);
            _socketServer.Listen(10);
        }
        private void RecMsg()
        {
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
                                Invoke(new MethodInvoker(EditTxtBoxSend));
                            }else if (data.ToLower().Contains("un dado"))
                            {
                                data = random.Next(1, 7).ToString();
                                Invoke(new MethodInvoker(EditTxtBoxSend));
                            }
                            else if (data.ToLower().Contains("due dadi"))
                            {
                                data = random.Next(1, 7).ToString() + " " + random.Next(1, 7).ToString();
                                Invoke(new MethodInvoker(EditTxtBoxSend));
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
                                Invoke(new MethodInvoker(EditTxtBoxSend));
                            }
                            break;
                        }
                    }
                }
                catch (Exception e) { Console.Write(e); }
            }
            
        }
        private void EditTxtBoxSend()
        {
            txtBoxSend.Text = "";
            txtBoxSend.Text = data;
            btn_Send.PerformClick();
        }
        private void MsgChat()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(MsgChat));
            else
                txtBoxChat.AppendText(Environment.NewLine + data);
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            
            byte[] msg = Encoding.ASCII.GetBytes(txtBoxSend.Text + "<EOF>");
            
            int bytesSent = handler.Send(msg);
            data = txtBoxSend.Text;
            MsgChat();
            
            txtBoxSend.Text = "";
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }catch(Exception ex) { };
            Environment.Exit(0);

        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            data = "Waiting for connection...";
            MsgChat();
            handler = _socketServer.Accept();
            data = "Someone connected to the server";
            MsgChat();
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
