using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Dialogue
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("服务正在初始化");
            Initialization init = new Initialization();
            Console.WriteLine("服务地址："+ init.host + "\r\n" +"服务端口：" + init.prot);
            IPAddress ip = IPAddress.Parse(init.host);
            IPEndPoint ipe = new IPEndPoint(ip,init.prot);
            Socket sSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sSocket.Bind(ipe);
            sSocket.Listen(0);
            Console.WriteLine("监听已经打开，请等待");
            //接收消息
            Socket serverSocket = sSocket.Accept();
            Console.WriteLine("连接已经建立");
            string recStr = "";
            byte[] recByte = new byte[4096];
            int bytes = serverSocket.Receive(recByte, recByte.Length, 0);
            recStr += Encoding.ASCII.GetString(recByte, 0, bytes);

            //发送消息
            Console.WriteLine("服务器端获得信息:{0}", recStr);
            string sendStr = "send to client :hello";
            byte[] sendByte = Encoding.ASCII.GetBytes(sendStr);
            serverSocket.Send(sendByte, sendByte.Length, 0);
            serverSocket.Close();
            sSocket.Close();
            Console.ReadKey();
        }
    }
}
