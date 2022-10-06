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

namespace SocketFormClient
{
    public partial class Form1 : Form
    {
        public static string data = null;
        public static IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
        IPEndPoint remoteEP = new IPEndPoint(ipAddress, 8888);
        Socket _socketClient = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        
        public Form1()
        {
            InitializeComponent();
            
        }
        

        private void btnConnect_Click(object sender, EventArgs e)
        {
            
            _socketClient.Connect(remoteEP);
            data = "Connected to server";
            MsgChat();
            Thread _recMsg = new Thread(RecMsg);
            _recMsg.Start();
        }
        private void RecMsg()
        {
            while (true)
            {
                data = null;  
                byte[] bytes = new byte[1024];
                try
                {
                    while (true)
                    {
                        int bytesRec = _socketClient.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (data.IndexOf("<EOF>") > -1)
                        {
                            data = data.Remove(data.Length - 1);
                            data = data.Remove(data.Length - 1);
                            data = data.Remove(data.Length - 1);
                            data = data.Remove(data.Length - 1);
                            data = data.Remove(data.Length - 1);

                            MsgChat();
                            break;
                        }
                    }
                }
                catch(Exception e) { Console.Write(e); }
                
            }
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
            int bytesSent = _socketClient.Send(msg);
            data = txtBoxSend.Text;
            MsgChat();
            txtBoxSend.Text = "";
            data = null;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _socketClient.Shutdown(SocketShutdown.Both);
                _socketClient.Close();
            }catch(Exception ex){ }
            Environment.Exit(0);
        }

        private void txtBoxSend_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btn_Send.PerformClick();
            }
        }

        private void comboBoxSelections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSelections.SelectedIndex >= 0)
                txtBoxSend.Text = comboBoxSelections.SelectedItem.ToString();
            comboBoxSelections.SelectedIndex = -1;
        }
    }
}
