using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

namespace Project_Nhom19
{
    public partial class Server : Form
    {
        private TcpListener serverListener;
        //private TcpServer server;
        private SqlConnection sqlConnection;
        private Dictionary<TcpClient, string> clientRooms = new Dictionary<TcpClient, string>(); // Lưu trữ phòng cho mỗi client
        string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=DataBaseQuizGame;Integrated Security=True;";
        string jsonFilePath =Path.GetFullPath("question.json");
        bool isServerRunning = false;
        int number_contestant = 4;
        public Server()
        {
            InitializeComponent();
            this.FormClosing += ServerForm_FormClosing;
        }
        private void Server_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                rtbLogs.AppendText("Connected to SQL Server database.\n");
            }
            catch (Exception ex)
            {
                rtbLogs.AppendText("Database connection error: " + ex.Message + "\n");
            }
        }//Kết nối đến sql server local
        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đóng server và xóa toàn bộ dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ClearAllData();
                sqlConnection?.Close();
                Stop.PerformClick();
            }
            else
            {
                return;
            }
        }//Đóng form server
        private void ClearAllData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    string[] tableNames = { "Player", "Room" };
                    foreach (var tableName in tableNames)
                    {
                        string deleteQuery = $"DELETE FROM {tableName}";
                        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Dữ liệu đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }//Xóa toàn bộ dữ liệu khi đóng
        private void btnStartServer_Click(object sender, EventArgs e)
        {
            serverListener = new TcpListener(IPAddress.Any, 8080);
            serverListener.Start();
            btnStartServer.Enabled = false; isServerRunning = true;
            rtbLogs.AppendText("Server started. Waiting for client connections...\n");
            serverListener.BeginAcceptTcpClient(new AsyncCallback(OnClientConnect), null);
            //Khi lắng nghe 1 server 
        }//Kích hoạt server để lắng nghe
        private void OnClientConnect(IAsyncResult ar)//Ghi nhận khi 1 client kết nối
        {
            try
            {
                TcpClient client = serverListener.EndAcceptTcpClient(ar);
                lock (clientRooms)
                {
                    clientRooms[client] = null; // Khởi tạo với phòng là null khi client mới kết nối
                }
                AppendLog("Client connected.");
                NetworkStream networkStream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];
                networkStream.BeginRead(buffer, 0, buffer.Length, OnDataReceived, new { client, buffer });
                serverListener.BeginAcceptTcpClient(new AsyncCallback(OnClientConnect), null);
            }
            catch { }
        }
        private void OnDataReceived(IAsyncResult ar)
        {
            var state = (dynamic)ar.AsyncState;
            TcpClient client = state.client;
            byte[] buffer = state.buffer;
            try
            {NetworkStream networkStream = client.GetStream();
                int bytesRead = networkStream.EndRead(ar);
                if (bytesRead > 0)
                {
                    string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    AppendLog("Received data: " + receivedData);

                    string[] dataParts = receivedData.Split('\n');
                    string controlBit = dataParts[0];
                    AppendLog(receivedData);
                    switch (controlBit)
                    {
                        case "JOINROOM":
                            AppendLog("HandleRoom\n");
                            HandleRoomRequest(dataParts, networkStream, client);
                            break;
                        case "READY":
                            AppendLog("Set ready\n");
                            UpdatePlayerStatus(dataParts, "Ready");
                            break;
                        case "NOTREA":// no in use
                            AppendLog("Set Not ready\n");
                            UpdatePlayerStatus(dataParts, "Not Ready");
                            break;
                        case "COMPL":
                            AppendLog("Set completed\n");
                            HandleCompletion(dataParts);
                            break;
                        case "ERC":
                            AppendLog("Delete \n");
                            HandleClientExit(dataParts, client);
                            break;
                        default:
                            AppendLog("Unknown control bit received.");
                            break;
                    }
                }
                networkStream.BeginRead(buffer, 0, buffer.Length, OnDataReceived, new { client, buffer });//Khi xử lý xong thì chờ để có thể xử lý các gói tin khác trong trường hợp phát sinh ngoại lệ bên client
            }
            catch (Exception ex)
            {
                AppendLog($"Error in data reception or processing: {ex.Message}");
                // HandleClientExit(new string[] { "ERC", "", "UnknownPlayer" }, client); // Gọi HandleClientExit nếu lỗi kết nối
            }
        }
        //Phân tích và xử lý 
        private async void HandleRoomRequest(string[] dataParts, NetworkStream networkStream, TcpClient client)
        {
            string roomId = dataParts[1];
            string playerName = dataParts[2];
            string playerIP = dataParts[3];
            string checkRoomQuery = "SELECT COUNT(*) FROM Room WHERE RoomID = @RoomID";

            using (SqlCommand checkCommand = new SqlCommand(checkRoomQuery, sqlConnection))
            {
                checkCommand.Parameters.AddWithValue("@RoomID", roomId);
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                int roomCount = (int)checkCommand.ExecuteScalar();
                string response;
                // Kiểm tra nếu đã có ít nhất một người dùng với cùng địa chỉ IP trong phòng
                string checkPlayerIPQuery = "SELECT COUNT(*) FROM Player WHERE PlayerIP = @PlayerIP AND RoomID = @RoomID";
                using (SqlCommand checkPlayerIPCommand = new SqlCommand(checkPlayerIPQuery, sqlConnection))
                {
                    checkPlayerIPCommand.Parameters.AddWithValue("@PlayerIP", playerIP);
                    checkPlayerIPCommand.Parameters.AddWithValue("@RoomID", roomId);
                    int existingPlayerCount = (int)checkPlayerIPCommand.ExecuteScalar();
                    if (existingPlayerCount >= 1)
                    {
                        // Nếu địa chỉ IP đã tồn tại, gửi gói tin 000 và kết thúc xử lý
                        response = "DENY\n";
                        byte[] responseData = Encoding.UTF8.GetBytes(response);
                        networkStream.Write(responseData, 0, responseData.Length);
                        AppendLog($"Player with IP '{playerIP}' already exists in Room '{roomId}'. Request denied.");
                        return;
                    }
                }
                // Kiểm tra nếu phòng đã có 4 người chơi trở lên
                string checkPlayerCountQuery = "SELECT COUNT(*) FROM Player WHERE RoomID = @RoomID";
                using (SqlCommand checkPlayerCountCommand = new SqlCommand(checkPlayerCountQuery, sqlConnection))
                {
                    checkPlayerCountCommand.Parameters.AddWithValue("@RoomID", roomId);

                    int playerCount = (int)checkPlayerCountCommand.ExecuteScalar();
                    if (playerCount >= 4)
                    {
                        // Nếu phòng đã có 4 người chơi trở lên, gửi gói tin 000 và kết thúc xử lý
                        response = "DENY\n";
                        byte[] responseData = Encoding.UTF8.GetBytes(response);
                        networkStream.Write(responseData, 0, responseData.Length);
                        AppendLog($"Room '{roomId}' is full. Request denied for player '{playerName}' with IP '{playerIP}'.");
                        return;
                    }
                }
                // Nếu phòng chưa tồn tại, tạo phòng mới
                if (roomCount == 0)
                {
                    string createRoomQuery = "INSERT INTO Room (RoomID) VALUES (@RoomID)";
                    using (SqlCommand createRoomCommand = new SqlCommand(createRoomQuery, sqlConnection))
                    {
                        createRoomCommand.Parameters.AddWithValue("@RoomID", roomId);
                        createRoomCommand.ExecuteNonQuery();
                    }
                    response = "ACCEPT\n";
                    AppendLog($"Room '{roomId}' created.");
                }
                else
                {
                    response = "ACCEPT\n";
                }
                // Thêm người chơi mới vào phòng
                string addPlayerQuery = "INSERT INTO Player (PlayerIP, RoomID, PlayerName, PlayerStatus) VALUES (@PlayerIP, @RoomID, @PlayerName, 'Not Ready')";
                using (SqlCommand addPlayerCommand = new SqlCommand(addPlayerQuery, sqlConnection))
                {
                    addPlayerCommand.Parameters.AddWithValue("@RoomID", roomId);
                    addPlayerCommand.Parameters.AddWithValue("@PlayerName", playerName);
                    addPlayerCommand.Parameters.AddWithValue("@PlayerIP", playerIP);
                    addPlayerCommand.ExecuteNonQuery();
                }
                lock (clientRooms)
                {
                    clientRooms[client] = roomId; // Lưu thông tin phòng của client
                }
                byte[] finalResponseData = Encoding.UTF8.GetBytes(response);
                networkStream.Write(finalResponseData, 0, finalResponseData.Length);
                await Task.Delay(500);
                SendPlayerListToRoomClients(roomId);
                AppendLog($"Room request processed for RoomID '{roomId}', Room Exists: {roomCount > 0}, Response: {response}");
            }
        }//Phương thức xử lý phòng
        private async void HandleClientExit(string[] dataParts, TcpClient client)
        {
            string roomId;
            lock (clientRooms)
            {
                if (!clientRooms.TryGetValue(client, out roomId) || roomId == null)
                {
                    return; // Không thể tìm thấy phòng của client
                }
                clientRooms.Remove(client); // Xóa client khỏi danh sách clientRooms
            }
            string playerName = dataParts[2];
            string PlayerIP = dataParts[3];

            // Xóa người chơi khỏi cơ sở dữ liệu
            string deletePlayerQuery = "DELETE FROM Player WHERE RoomID = @RoomID AND PlayerName = @PlayerName AND PlayerIP=@PlayerIP";
            using (SqlCommand command = new SqlCommand(deletePlayerQuery, sqlConnection))
            {
                command.Parameters.AddWithValue("@RoomID", roomId);
                command.Parameters.AddWithValue("@PlayerName", playerName);
                command.Parameters.AddWithValue("@PlayerIP", PlayerIP);
                command.ExecuteNonQuery();
            }
            //client.Close();

            // Gửi thông báo thoát đến các client trong phòng
            string exitMessage = $"EXIT\n{roomId}\n{playerName}\n{PlayerIP}";
            await BroadcastToRoomClientsAsync(roomId, exitMessage);

            AppendLog($"Client '{playerName}' đã thoát khỏi phòng '{roomId}'.");

            // Cập nhật danh sách người chơi cho tất cả các client trong phòng
            SendUpdatedPlayerList(roomId, PlayerIP);
        }//Xử lý khi người chơi thoát phòng
        private async void SendPlayerListToRoomClients(string roomId)
        {
            string query = "SELECT PlayerName, PlayerStatus FROM Player WHERE RoomID = @RoomID";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@RoomID", roomId);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    StringBuilder playerList = new StringBuilder("LIST\n");
                    playerList.Append(roomId + "\n");

                    while (reader.Read())
                    {
                        string playerName = reader.GetString(0);
                        string playerStatus = reader.GetString(1);
                        playerList.Append($"{playerName}|{playerStatus}\n");
                    }

                    await BroadcastToRoomClientsAsync(roomId, playerList.ToString());
                }
            }
        }//Gửi danh sách người chơi khi mới vào phòng
        private async void UpdatePlayerStatus(string[] dataParts, string status)
        {
            string roomId = dataParts[1];
            string playerName = dataParts[2];
            string playerIP = dataParts[3];
            string query = "UPDATE Player SET PlayerStatus = @Status WHERE PlayerName = @Name AND RoomID = @RoomID AND PlayerIP=@PlayerIP";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@Name", playerName);
                command.Parameters.AddWithValue("@RoomID", roomId);
                command.Parameters.AddWithValue("@PlayerIP", playerIP);
                command.ExecuteNonQuery();
                AppendLog("Player status updated: " + playerName + " - " + status + "\n");
                SendUpdatedPlayerList(roomId, "");
            }
            int readyCount = 0;
            string countQuery = "SELECT COUNT(*) FROM Player WHERE RoomID = @RoomID AND PlayerStatus = 'Ready'";
            using (SqlCommand countCommand = new SqlCommand(countQuery, sqlConnection))
            {
                countCommand.Parameters.AddWithValue("@RoomID", roomId);
                readyCount = (int)countCommand.ExecuteScalar(); // Trả về số lượng người chơi có trạng thái "Ready"
            }
            if (readyCount == number_contestant)
            {
                AppendLog("4 players are ready in room " + roomId + ". Proceeding with next action...\n");
                // Đọc nội dung từ tệp JSON chứa câu hỏi
                // Đường dẫn tới tệp JSON
                string jsonData = File.ReadAllText(jsonFilePath);
                string mess = $"QUES\n" + jsonData;
                await BroadcastToRoomClientsAsync(roomId, mess);
                await Task.Delay(300);
            }
        }//Chuyển trạng thái người chơi
        private async void SendUpdatedPlayerList(string roomId, string PlayerIP)
        {
            List<string> playerDetails = new List<string>();

            // Lấy danh sách người chơi và trạng thái của họ trong phòng từ cơ sở dữ liệu
            string selectPlayersQuery = "SELECT PlayerName, PlayerStatus FROM Player WHERE RoomID = @RoomID AND PlayerIP <> @PlayerIP";
            using (SqlCommand command = new SqlCommand(selectPlayersQuery, sqlConnection))
            {
                command.Parameters.AddWithValue("@RoomID", roomId);
                command.Parameters.AddWithValue("@PlayerIP", PlayerIP);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string playerName = reader["PlayerName"].ToString();
                        string playerStatus = reader["PlayerStatus"].ToString();
                        playerDetails.Add($"{playerName}|{playerStatus}");  // Kết hợp tên người chơi và trạng thái
                    }
                }
            }

            // Tạo thông báo danh sách người chơi với trạng thái và gửi đến các client
            string playerListMessage = $"LIST\n{roomId}\n{string.Join("\n", playerDetails)}\n";  // '\n' để mỗi người chơi là một dòng
            try
            {
                await BroadcastToRoomClientsAsync(roomId, playerListMessage);
            }
            catch (Exception ex)
            {
                AppendLog($"Error broadcasting player list: {ex.Message}");
            }
        }//Gửi lại danh sách người chơi
        private async void HandleCompletion(string[] dataParts)
        {
            string playerName = dataParts[1];
            string roomId = dataParts[2];
            int correctAnswers = int.Parse(dataParts[3]);
            int stack = int.Parse(dataParts[4]);
            int score = int.Parse(dataParts[5]);
            int time = int.Parse(dataParts[6]);
            string query =
           "UPDATE Player SET PlayerStatus = 'Completed', Corr_Num = @CorrectAnswers, Stack = @Stack, Score = @Score,Timestamps=@Timestamp WHERE PlayerName = @Name AND RoomID = @RoomID ";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@CorrectAnswers", correctAnswers);
                command.Parameters.AddWithValue("@Stack", stack);
                command.Parameters.AddWithValue("@Score", score);
                command.Parameters.AddWithValue("@Name", playerName);
                command.Parameters.AddWithValue("@RoomID", roomId);
                command.Parameters.AddWithValue("@Timestamp", time);
                command.ExecuteNonQuery();

                AppendLog("Completion status updated for player: " + playerName + "\n");
            }
            string countQuery = "SELECT COUNT(*) FROM Player WHERE RoomID = @RoomID AND PlayerStatus = 'Completed'";
            using (SqlCommand countCommand = new SqlCommand(countQuery, sqlConnection))
            {
                countCommand.Parameters.AddWithValue("@RoomID", roomId);
                int completedCount = (int)countCommand.ExecuteScalar();

                if (completedCount == number_contestant)
                {
                    // Lấy danh sách người chơi đã hoàn thành, sắp xếp theo điểm số
                    string resultQuery = "SELECT PlayerName, Score, Corr_Num, Stack, Timestamps FROM Player WHERE RoomID = @RoomID ORDER BY Score DESC, Corr_Num DESC, Stack DESC, Timestamps ASC";
                    List<string> playerResults = new List<string>();
                    using (SqlCommand resultCommand = new SqlCommand(resultQuery, sqlConnection))
                    {
                        resultCommand.Parameters.AddWithValue("@RoomID", roomId);
                        using (SqlDataReader reader = resultCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = reader["PlayerName"].ToString();
                                int resultScore = (int)reader["Score"];
                                int resultCorrectAnswers = (int)reader["Corr_Num"];
                                int resultStack = (int)reader["Stack"];
                                int timestamp = (int)reader["Timestamps"];
                                // Format lại chuỗi kết quả để gửi đi
                                playerResults.Add($"{name}|{resultScore}|{resultCorrectAnswers}|{resultStack}|{timestamp}");
                            }
                        }
                    }
                    string resultPacket = "RESULT\n" + string.Join("\n", playerResults);
                    await BroadcastToRoomClientsAsync(roomId, resultPacket);
                }
            }
        }//Khi có đủ người chơi thì tiến hành gửi câu hỏi
        private async Task BroadcastToRoomClientsAsync(string roomId, string message)
        {
            // Duyệt danh sách các client trong phòng một cách đồng bộ
            List<TcpClient> clientsToProcess = new List<TcpClient>();
            lock (clientRooms)
            {
                // Lọc các client theo phòng và thêm vào danh sách
                clientsToProcess = clientRooms
                    .Where(c => c.Value == roomId)
                    .Select(c => c.Key)
                    .ToList();
            }
            var disconnectedClients = new List<TcpClient>();

            // Duyệt các client và gửi thông điệp bất đồng bộ
            foreach (var client in clientsToProcess)
            {
                try
                {
                    if (client.Connected)
                    {
                        NetworkStream stream = client.GetStream();
                        byte[] buffer = Encoding.UTF8.GetBytes(message);
                        await stream.WriteAsync(buffer, 0, buffer.Length); // Gửi dữ liệu bất đồng bộ
                    }
                    /*else
                    {
                        disconnectedClients.Add(client);
                    }*/
                }
                catch
                {
                    // Nếu có lỗi trong quá trình gửi, thêm vào danh sách ngắt kết nối
                    disconnectedClients.Add(client);
                }
            }

            // Xử lý client đã ngắt kết nối sau khi gửi xong
            lock (clientRooms)
            {
                foreach (var disconnectedClient in disconnectedClients)
                {
                    clientRooms.Remove(disconnectedClient);
                    disconnectedClient.Close();
                }
            }
        }//Hàm để xử lý việc gửi danh sách cho toàn bộ người chơi
        private void AppendLog(string message)
        {
            rtbLogs.Invoke((MethodInvoker)delegate
            {
                rtbLogs.AppendText($"{DateTime.Now}: {message}\n");
                rtbLogs.ScrollToCaret();
            });
        }
        private void Stop_Click(object sender, EventArgs e)
        {
            if (serverListener != null)
            {
                // đặt cờ cho phép dừng server và đóng tcplistener
                serverListener.Stop();
                //serverlistener = null;
            }
            // Đóng các kết nối TcpClient

            lock (clientRooms)
            {
                foreach (var client in clientRooms.Keys)
                {
                    if (client.Connected)
                        client.Close();
                }
                clientRooms.Clear();
            }
            //this.server.Stop();
            // Cập nhật giao diện
            btnStartServer.Enabled = true;
            AppendLog("Server stopped.\n");
        }
    }
}
