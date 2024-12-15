using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class PlayerListForm : Form
    {
        public Client parentForm;
        public PlayerListForm(Client _parentForm)
        {
            InitializeComponent();
            this.parentForm = _parentForm;
        }
        public void UpdatePlayerList(string[] playerList)
        {
            Status1.Text = "Not Ready";
            Status2.Text = "Not Ready";
            Status3.Text = "Not Ready";
            Status4.Text = "Not Ready";
            try
            {
                string[] fea = playerList[2].Split('|');
                NamePlayer1.Text = fea[0];
                Status1.Text = fea[1];
                fea=playerList[3].Split('|');
                NamePlayer2.Text = fea[0];
                Status2.Text = fea[1];
                fea= playerList[4].Split('|');
                NamePlayer3.Text = fea[0];
                Status3.Text = fea[1];
                fea= playerList[5].Split('|');
                NamePlayer4.Text = fea[0];
                Status4.Text = fea[1];
            }
            catch
            {  }
        }
        private async void btn_Ready_Click(object sender, EventArgs e)
        {
            string message = $"READY\n{parentForm.roomId}\n{parentForm.playerName}\n{parentForm.playerIP}\n";
            parentForm.SendMessageToServer(message);
            await Task.Delay(200);
            btn_Ready.Enabled = false;
        }
    }
}
