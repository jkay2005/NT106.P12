using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace Client
{
    public partial class Client : Form
    { private bool isFormOpened = false;
        private bool isconnectserver = false;
        private TcpClient client;
        private NetworkStream networkStream;
        public string roomId { get; set; }
        public string playerName { get; set; }
        public string playerIP { get; set; }
        PlayerListForm plf;
        bool isRoomCreated = false;
        ContestRoom room;
        ResultBoard scoreBoard;
        
        public Client()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Client_FormClosing);
           // rtbLogs.BackColor = Color.FromArgb(0, 255, 255, 255); 
        }
        private bool IsLoopbackIP(string ipAddress)
        {
            try
            {
                IPAddress ip = IPAddress.Parse(ipAddress);
                byte[] bytes = ip.GetAddressBytes();
                return bytes[0] == 127; // Kiểm tra nếu IP thuộc vùng loopback
            }
            catch (FormatException)
            {
                throw new FormatException("Định dạng IP không hợp lệ");
            }
        }
        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Gửi gói tin ERC thông báo client thoát
            if (client != null && client.Connected)
            {
                string exitMessage = $"ERC\n{roomId}\n{playerName}\n{playerIP}\n";
                SendMessageToServer(exitMessage);
                Thread.Sleep(500);  // Đợi để đảm bảo gói tin được gửi
            }
            // Đóng kết nối với server
            client?.Close();
        }//Thông báo thoát phòng
        public async void SendMessageToServer(string message)
        {
            try
            {
                if (client != null && client.Connected)
                {
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    await networkStream.WriteAsync(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending message to server: " + ex.Message);
            }
        }// hàm Gửi cho server gói tin 
        private async void btn_Server_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtServerIP.Text))
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ IP.");
                    return;
                }
                string serverIP = txtServerIP.Text.Trim();
                if (!IsLoopbackIP(serverIP))
                {
                    MessageBox.Show("Địa chỉ IP không hợp lệ, chỉ được nhập IP trong vùng loopback (127.0.0.0 - 127.255.255.255).");
                    return;
                }
                client = new TcpClient(serverIP, 8080);
                networkStream = client.GetStream();
                AppendLog("Đã kết nối đến server.");
                btn_Server_Connect.Hide();
                isconnectserver = true;

                // Bắt đầu nhận dữ liệu từ server trên một luồng khác không chặn giao diện người dùng
                await Task.Run(() => ReceiveDataFromServer());
            }
            catch (Exception ex)
            {
                AppendLog("Lỗi kết nối: " + ex.Message);
            }
        }// Yêu cầu kết nối 
        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if(isconnectserver==false) { MessageBox.Show("Chưa kết nối đến server"); return; }
            if (string.IsNullOrEmpty(txtPlayerName.Text) || string.IsNullOrEmpty(txtRoomId.Text))
            {
                MessageBox.Show("Vui lòng nhập tên người chơi và mã phòng.");
                return;
            }
            
            // Lưu thông tin người chơi
            playerName = txtPlayerName.Text.Trim();
            roomId = txtRoomId.Text.Trim();
            playerIP = txtServerIP.Text.Trim();
            // Gửi yêu cầu tạo phòng
            string requestData = $"JOINROOM\n{roomId}\n{playerName}\n{playerIP}";
            try
            {
                byte[] dataToSend = Encoding.UTF8.GetBytes(requestData);
                await networkStream.WriteAsync(dataToSend, 0, dataToSend.Length);
                AppendLog("Đã gửi yêu cầu tạo phòng.");

                // Đọc phản hồi từ server
                byte[] responseBuffer = new byte[client.ReceiveBufferSize];
                int bytesRead = await networkStream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
                string serverResponse = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);
                ProcessServerResponse(serverResponse);
                btnConnect.Hide();
              //  while (client.Connected) { await Task.Run(() => ReceiveDataFromServer()); }
            }
            catch (Exception ex)
            {
                AppendLog("Lỗi khi gửi dữ liệu: " + ex.Message);
            }
        }//Gửi gói tin yêu cầu gia nhập phòng
        private async Task ReceiveDataFromServer()
        {
            try
            {
                byte[] buffer = new byte[client.ReceiveBufferSize];
                while (client.Connected)
                {
                    int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;  // Ngắt kết nối nếu không nhận được dữ liệu

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    AppendLog("Server: " + (message.StartsWith("QUES")?"Ques_No_Show":(message.StartsWith("RESULT")?"Result_no_show":message)));

                    // Xử lý phản hồi từ server trên luồng giao diện
                    this.Invoke(new Action(() => ProcessServerResponse(message)));
                }
            }
            catch (Exception ex)
            {
                AppendLog("Lỗi khi nhận dữ liệu từ server: " + ex.Message);
            }
        }// Đọc các gói tin của server gửi đến 
        private async void ProcessServerResponse(string response)
        {
            string[] responseParts = response.Split(new string[] { "\n" }, 2, StringSplitOptions.None);
            string controlBit = responseParts[0];
            switch (controlBit)
            {
                case "ACCEPT":
                    AppendLog("Phòng đã được tạo thành công.");
                    isRoomCreated = true; // Đánh dấu đã nhận gói tin ACCEPT
                    break;
                case "DENY":
                    AppendLog("Có người trùng với IP của bạn vừa nhập để nhận dạng");
                    break;
                case "LIST":
                    // Đảm bảo chỉ mở form sau khi nhận được gói ACCEPT và chỉ mở một lần
                    if (isRoomCreated && !isFormOpened)
                    {
                        isFormOpened = true;
                        await Task.Delay(500);
                        plf = new PlayerListForm(this);  // Khởi tạo form PlayerListForm mới
                        plf.Show();
                    }
                    // Cập nhật danh sách người chơi trong form
                    plf?.UpdatePlayerList(response.Split('\n'));
                    break;
                case "QUES":
                    // Kiểm tra phần tử thứ hai có chứa nội dung JSON hợp lệ không
                    if (responseParts.Length > 1)
                    {
                        AppendLog("Questions provided!");
                        try
                        {
                            string jsonData = responseParts[1];
                            var questions = JsonConvert.DeserializeObject<List<Question>>(jsonData);
                            // Mở form câu hỏi và tải câu hỏi
                            room = new ContestRoom(this);
                            room.Show();
                            room?.Load_Question(questions); // Gọi Load_Question của form con với danh sách câu hỏi
                        }
                        catch (JsonException ex)
                        {
                            AppendLog("Lỗi khi phân tích JSON: " + ex.Message);
                        }
                    }
                    break;
                case "RESULT":
                    scoreBoard=new ResultBoard(this);
                    scoreBoard.Show();
                    scoreBoard?.UpdateResult(response.Split('\n'));
                    break;
                default:
                    AppendLog($"{controlBit} Phản hồi không xác định từ server.\n");
                    AppendLog(response);
                    break;
            }
        }//Xử lý hành động cho các gói tin
        private void AppendLog(string message)
        {
            if (rtbLogs.InvokeRequired)
                rtbLogs.Invoke(new Action<string>(AppendLog), message);
            else
                rtbLogs.AppendText(message + Environment.NewLine);
        }
    }
}
