﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace PlanesGame.Network.NetworkCore
{
    public class Server : Network
    {
        public new Socket Socket { get; set; }
        public new NetworkStream Stream { get; set; }
        private TcpListener _tcpListener;
        private TcpClient _tcpClient;

        public override void StartService()
        {
            _tcpListener = new TcpListener(IPAddress.Any,Common.IpEndPoint.Port);
            var thread = new Thread(ServerService) {IsBackground = true};
            thread.Start();
        }

        private void ServerService()
        {
            _tcpListener.Start();
            _tcpClient = _tcpListener.AcceptTcpClient();
            try
            {
                Stream = _tcpClient.GetStream();
                var buffer = new byte[1024];
                var commandInterpreter = new CommandInterpreter();
                var connectValidation = true;
                while (true)
                {
                    if (connectValidation)
                    {
                        Common.GameBoardController.ConnectionEstablished();
                        connectValidation = false;
                    }


                    var streamReader = new StreamReader(Stream);
                    var receivedMessage = streamReader.ReadLine();

                    if (commandInterpreter.ExecuteCommand(receivedMessage))
                    {
                        break;
                    }
                }
                Stream.Close();
                _tcpListener.Stop();
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Connection Error: " + exception.Message);
            }

        }

        public override ConnType ConnectionType { get { return ConnType.Server; } }

        public override void SendData(DataType dataType, string data = "")
        {
            try
            {
                var streamWriter = new StreamWriter(Stream);
                streamWriter.WriteLine((int)dataType + " " + data);
                streamWriter.Flush();
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Something went wrong:" + e.Message);
            }
        }
    }
}