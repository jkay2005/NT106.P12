using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public partial class Server : Form
    {
        private TcpListener listener;
        private List<TcpClient> listclient = new List<TcpClient>();
        public Server()
        {
            InitializeComponent();
        }
        private void Log(string message)
        {
            Invoke(new Action(() => txtmes.AppendText(message + Environment.NewLine)));
        }
        private void start_Click(object sender, EventArgs e) { 
            start.Enabled = false;
            Thread listenThread = new Thread(ListenForClients);
            listenThread.IsBackground = true;
            listenThread.Start();
            Log("Server started!");
        }

        private void ListenForClients()
        {
            listener = new TcpListener(IPAddress.Any, 8080);
            listener.Start();
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                listclient.Add(client);
                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.IsBackground = true;
                clientThread.Start();
                Log("Đã kết nối client.");
            }
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[4096];

            while (true)
            {
                try
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string header = Encoding.UTF8.GetString(buffer, 0, 4);
                    if (header == "TEXT") // Tin nhắn văn bản
                    {
                        string fullMessage = Encoding.UTF8.GetString(buffer, 4, bytesRead - 4);
                        Log(fullMessage);
                        Broadcast(buffer, bytesRead);
                    }
                    else if (header == "FILE") // File
                    {
                        string fileInfo = Encoding.UTF8.GetString(buffer, 4, bytesRead - 4);
                        string[] parts = fileInfo.Split(';');
                        string senderName = parts[0];
                        string fileName = parts[1];

                        Log($"{senderName} gửi file: {fileName}");

                        // Nhận nội dung file
                        MemoryStream ms = new MemoryStream();
                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, bytesRead);
                            if (bytesRead < buffer.Length) break; // Cuối file
                        }

                        File.WriteAllBytes(Path.Combine("file đã nhận", fileName), ms.ToArray());
                        Log($"File saved: {fileName}");

                        // Phát lại file kèm tên người gửi
                        string broadcastHeader = "FILE" + senderName + ";" + fileName;
                        byte[] broadcastHeaderBytes = Encoding.UTF8.GetBytes(broadcastHeader);
                        Broadcast(broadcastHeaderBytes, broadcastHeaderBytes.Length);

                        byte[] fileData = ms.ToArray();
                        Broadcast(fileData, fileData.Length);
                    }
                }
                catch
                {
                    break;
                }
            }
        }

        private void Broadcast(byte[] data, int bytesRead)
        {
            foreach (var client in listclient)
            {
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, bytesRead);
            }
        }

    }
}
