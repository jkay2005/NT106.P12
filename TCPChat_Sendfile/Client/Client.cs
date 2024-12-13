using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Client
{
    public partial class Client : Form
    {
        private TcpClient client;
        private NetworkStream stream;

        public Client()
        {
            InitializeComponent();
        }
        private void connect_Click(object sender, EventArgs e)
        {
            client = new TcpClient(txtip.Text, int.Parse(txtport.Text));
            stream = client.GetStream();
            Thread receiveThread = new Thread(ReceiveData);
            receiveThread.IsBackground = true;
            receiveThread.Start();
            Log("đã kết nối server");
        }
        private void Log(string message)
        {
            Invoke(new Action(() => listmes.AppendText(message + Environment.NewLine)));
        }

        private void ReceiveData()
        {
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
                    }
                    else if (header == "FILE") // File
                    {
                        string fileInfo = Encoding.UTF8.GetString(buffer, 4, bytesRead - 4);
                        string[] parts = fileInfo.Split(';');
                        string senderName = parts[0];
                        string fileName = parts[1];

                        Log($"{senderName} gửi file: {fileName}");

                        MemoryStream ms = new MemoryStream();
                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, bytesRead);
                            if (bytesRead < buffer.Length) break; // Cuối file
                        }

                        File.WriteAllBytes(Path.Combine("ReceivedFiles", fileName), ms.ToArray());
                        Log($"File saved: {fileName}");
                    }
                }
                catch
                {
                    Log("mất kết nối");
                    break;
                }
            }
        }

        private void sendmes_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;// Lấy tên người dùng
            string message = txtmes.Text;// Lấy nội dung tin nhắn
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(message))
            {
                Log("Tên hoặc tin nhắn không được để trống");
                return;
            }
            // Ghép tên và nội dung thành tin nhắn
            string fullmessage = $"{name}: {message}";
            byte[] data = Encoding.UTF8.GetBytes("TEXT" + fullmessage);
            stream.Write(data, 0, data.Length); // Gửi tin nhắn đến Server
            //Log("Bạn: " + message);// Hiển thị tin nhắn của chính mình
            txtmes.Clear();// Xóa hộp nhập tin nhắn
        }

        private void sendfile_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(ofd.FileName);
                string sendername = txtname.Text; // Lấy tên người gửi

                string header = "FILE" + sendername + ";" + fileName;// Gửi header "FILE" + <Tên người gửi> + ";" + <Tên file>
                byte[] headerBytes = Encoding.UTF8.GetBytes(header);
                stream.Write(headerBytes, 0, headerBytes.Length);

                byte[] fileData = File.ReadAllBytes(ofd.FileName);// Gửi nội dung file
                stream.Write(fileData, 0, fileData.Length);

                Log($"Đã gửi file: {fileName}");
            }
        }

    }
}
