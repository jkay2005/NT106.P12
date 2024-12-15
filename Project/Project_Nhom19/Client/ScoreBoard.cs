using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ResultBoard : Form
    {
        public Client parentForm;
        public ResultBoard(Client _parentForm)
        {
            InitializeComponent();
            this.parentForm = _parentForm;
        }
        public void UpdateResult(string[] result)
        {
            try
            {
                string[] res = result[1].Split('|');
                NamePlayer1.Text = res[0];
                ScorePlayer1.Text = res[1];
                Corr_Num1.Text = res[2];
                Stack1.Text = res[3];
                Time1.Text = res[4];

                res = result[2].Split('|');
                NamePlayer2.Text = res[0];
                ScorePlayer2.Text = res[1]; 
                Corr_Num2.Text = res[2];
                Stack2.Text = res[3];  
                Time2.Text = res[4];

                res= result[3].Split('|');
                NamePlayer3.Text = res[0];
                ScorePlayer3.Text = res[1];
                Corr_Num3.Text = res[2];
                Stack3.Text = res[3];
                Time3.Text = res[4];

                res = result[4].Split('|');
                NamePlayer4.Text = res[0];
                ScorePlayer4.Text = res[1];
                Corr_Num4.Text = res[2];
                Stack4.Text = res[3];
                Time4.Text = res[4];
            }
            catch
            { }
        }
    }
}
