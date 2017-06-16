using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace DialogueClient
{
    public partial class Form1 : Form
    {
        int port = int.Parse(ConfigurationManager.AppSettings["prot"]);//服务器端口
        string host = ConfigurationManager.AppSettings["host"];//服务器端ip地址
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public Form1()
        {
            InitializeComponent();
            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);
            TextWrite("正在连接");
            clientSocket.Connect(ipe);
            TextWrite("连接成功");
        }
        private void Init()
        {
            //发送消息
            string sendStr = "send to server : hello,ni hao";
            byte[] sendBytes = Encoding.ASCII.GetBytes(sendStr);
            clientSocket.Send(sendBytes);
            //接收消息
            string recStr = "";
            byte[] recBytes = new byte[4096];
            int bytes = clientSocket.Receive(recBytes, recBytes.Length, 0);
            recStr += Encoding.ASCII.GetString(recBytes, 0, bytes);
            TextWrite(recStr);
            clientSocket.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public void TextWrite(string t)
        {
            textBox1.Text += t + "\r\n";
        }
    }
}
