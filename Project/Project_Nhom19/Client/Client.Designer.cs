namespace Client
{
    partial class Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.txtRoomId = new System.Windows.Forms.TextBox();
            this.IDPlayer = new System.Windows.Forms.Label();
            this.RoomID = new System.Windows.Forms.Label();
            this.rtbLogs = new System.Windows.Forms.RichTextBox();
            this.btn_Server_Connect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(116, 178);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Send";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(116, 89);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(119, 23);
            this.txtPlayerName.TabIndex = 1;
            // 
            // txtRoomId
            // 
            this.txtRoomId.Location = new System.Drawing.Point(116, 134);
            this.txtRoomId.Name = "txtRoomId";
            this.txtRoomId.Size = new System.Drawing.Size(119, 23);
            this.txtRoomId.TabIndex = 2;
            // 
            // IDPlayer
            // 
            this.IDPlayer.AutoSize = true;
            this.IDPlayer.BackColor = System.Drawing.Color.Transparent;
            this.IDPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.IDPlayer.ForeColor = System.Drawing.Color.White;
            this.IDPlayer.Location = new System.Drawing.Point(49, 95);
            this.IDPlayer.Name = "IDPlayer";
            this.IDPlayer.Size = new System.Drawing.Size(48, 17);
            this.IDPlayer.TabIndex = 3;
            this.IDPlayer.Text = "Player";
            // 
            // RoomID
            // 
            this.RoomID.AutoSize = true;
            this.RoomID.BackColor = System.Drawing.Color.Transparent;
            this.RoomID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.RoomID.ForeColor = System.Drawing.Color.White;
            this.RoomID.Location = new System.Drawing.Point(49, 140);
            this.RoomID.Name = "RoomID";
            this.RoomID.Size = new System.Drawing.Size(62, 17);
            this.RoomID.TabIndex = 4;
            this.RoomID.Text = "Room ID";
            // 
            // rtbLogs
            // 
            this.rtbLogs.ForeColor = System.Drawing.Color.Black;
            this.rtbLogs.Location = new System.Drawing.Point(36, 207);
            this.rtbLogs.Name = "rtbLogs";
            this.rtbLogs.Size = new System.Drawing.Size(402, 260);
            this.rtbLogs.TabIndex = 5;
            this.rtbLogs.Text = "";
            // 
            // btn_Server_Connect
            // 
            this.btn_Server_Connect.Location = new System.Drawing.Point(314, 140);
            this.btn_Server_Connect.Name = "btn_Server_Connect";
            this.btn_Server_Connect.Size = new System.Drawing.Size(74, 34);
            this.btn_Server_Connect.TabIndex = 6;
            this.btn_Server_Connect.Text = "Connect";
            this.btn_Server_Connect.UseVisualStyleBackColor = true;
            this.btn_Server_Connect.Click += new System.EventHandler(this.btn_Server_Connect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(253, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "IPClient";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(314, 111);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(113, 23);
            this.txtServerIP.TabIndex = 7;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(568, 542);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServerIP);
            this.Controls.Add(this.btn_Server_Connect);
            this.Controls.Add(this.rtbLogs);
            this.Controls.Add(this.RoomID);
            this.Controls.Add(this.IDPlayer);
            this.Controls.Add(this.txtRoomId);
            this.Controls.Add(this.txtPlayerName);
            this.Controls.Add(this.btnConnect);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Client";
            this.Text = "JoinRoom";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.TextBox txtRoomId;
        private System.Windows.Forms.Label IDPlayer;
        private System.Windows.Forms.Label RoomID;
        private System.Windows.Forms.RichTextBox rtbLogs;
        private System.Windows.Forms.Button btn_Server_Connect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServerIP;
    }
}

