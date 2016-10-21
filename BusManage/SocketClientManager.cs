using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BusManage
{
    public class SocketClientManager
    {
        private Socket _socket = null;
        private EndPoint _endPoint = null;
        private SocketInfo _socketInfo = null;
        private bool _isConnected = false;

        public delegate void OnConnectedHandler();
        public event OnConnectedHandler OnConnected;
        public event OnConnectedHandler OnFaildConnect;
        public delegate void OnReceiveMsgHandler();
        public event OnReceiveMsgHandler OnReceiveMsg;

        public String recMsg
        {
            get { return Encoding.Default.GetString(_socketInfo.buffer).TrimEnd('\0'); }
        }

        public SocketClientManager(string ip, int port)
        {
            IPAddress _ip = IPAddress.Parse(ip);
            _endPoint = new IPEndPoint(_ip, port);
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            _socket.BeginConnect(_endPoint, ConnectedCallback, _socket);
            _isConnected = true;
            Thread socketClient = new Thread(SocketClientReceive);
            socketClient.IsBackground = true;
            socketClient.Start();
        }

        public void ReStart()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Start();
        }

        private void SocketClientReceive()
        {
            while (_isConnected)
            {
                SocketInfo info = new SocketInfo();
                try
                {
                    while (!(_socket.Poll(1000 * 500, SelectMode.SelectWrite)))
                    { 
                        //
                    }
                    _socket.BeginReceive(info.buffer, 0, info.buffer.Length, SocketFlags.None, ReceiveCallback, info);
                }
                catch (SocketException ex)
                {
                    Console.WriteLine(ex.Message);
                    _isConnected = false;
                    if (this.OnFaildConnect != null) OnFaildConnect();
                }

                Thread.Sleep(100);
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            _socketInfo = ar.AsyncState as SocketInfo;
            if (this.OnReceiveMsg != null) OnReceiveMsg();
        }

        private void ConnectedCallback(IAsyncResult ar)
        {
            Socket socket = ar.AsyncState as Socket;
            if (socket.Connected)
            {
                if (this.OnConnected != null) OnConnected();
            }
            else
            {
                if (this.OnFaildConnect != null) OnFaildConnect();
            }
        }

        public void SendMsg(string msg)
        {
            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(msg);

                while (!(_socket.Poll(1000 * 500, SelectMode.SelectWrite)))
                {
                    //
                }

                _socket.Send(buffer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _isConnected = false;
                if (this.OnFaildConnect != null) OnFaildConnect();
            }
        }

        private class SocketInfo
        {
            public Socket socket = null;
            public byte[] buffer = null;

            public SocketInfo()
            {
                buffer = new byte[1024 * 4];
            }
        }
    }
}
