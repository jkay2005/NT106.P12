using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
namespace Client
{
    public partial class ContestRoom : Form
    {
        public Question recvquiz { get; private set; }
        private Client clientForm;
        private List<Question> questionsList;
        private Timer quizTimer;
        private int remainingTime;
        private int index = 0;
        private int stack = 0;
        private int maxStack = 0;
        private int Point = 0;
        private int PointEachQues = 50;
        private const int quizDuration = 180; // Duration of the quiz in seconds
        private int Corr_num = 0;
        private int timeleft;
        private int incorr_num = 0;
        public ContestRoom(Client _clientForm)
        {
            InitializeComponent();
            this.clientForm = _clientForm;
            questionsList = new List<Question>();

            // Initialize Timer
            quizTimer = new Timer();
            quizTimer.Interval = 1000; // 1 second intervals
            quizTimer.Tick += QuizTimer_Tick;
        }
        public void Load_Question(List<Question> questions)
        {
            if (questions == null || questions.Count == 0)
            {
                MessageBox.Show("Không có câu hỏi nào để hiển thị.");
                return;
            }
            questionsList = new List<Question>(questions);
            index = 0;
            remainingTime = quizDuration;
            DisplayQuestion(index);
            // Start Timer
            quizTimer.Start();
            UpdateTimerDisplay();
        }
        private void DisplayQuestion(int index)
        {
            if (index >= 0 && index < questionsList.Count)
            {
                ShowQuestion.Text = questionsList[index].Showquestion;
                AnsA.Text = questionsList[index].choiceA;
                AnsB.Text = questionsList[index].choiceB;
                AnsC.Text = questionsList[index].choiceC;
                AnsD.Text = questionsList[index].choiceD;
            }
        }
        private void Next_Click(object sender, EventArgs e)
        {
            if (!AnsA.Checked && !AnsB.Checked && !AnsC.Checked && !AnsD.Checked)
            {
                MessageBox.Show("Chưa chọn đáp án ");
                return;
            }
            Calculate(questionsList[index]);

            index++;
            if (index < questionsList.Count)
            {
                DisplayQuestion(index);
            }
            else
            {
                // End of questions
                Next.Click -= Next_Click;
                Next.Click += complete_btn_click;
                Next.Text = "Done";
            }
        }
        private string GetUserAnswer()
        {
            if (AnsA.Checked) return "A";
            if (AnsB.Checked) return "B";
            if (AnsC.Checked) return "C";
            if (AnsD.Checked) return "D";
            return null;
        }
        private void Calculate(Question a)
        {
            if (GetUserAnswer() == a.answer) // Nếu trả lời đúng
            {
                Corr_num++;
                // Tính điểm và cộng dồn stack
                Point += (int)(PointEachQues * (1 + stack * 0.1));
                stack++;
                StackLabel.Text = stack.ToString();// Cộng 1 vào stack khi trả lời đúng
            }
            else // Nếu trả lời sai
            {
                incorr_num++;
                if (stack > maxStack)
                {
                    maxStack = stack; // Gán maxStack bằng giá trị stack nếu stack lớn hơn maxStack
                }

                stack = 0;
                StackLabel.Text = stack.ToString();// Reset stack về 0 sau khi trả lời sai
            }

            // Cập nhật giao diện với điểm số và maxStack
            pointtext.Text = Point.ToString();
            reset_choice(); // Reset lựa chọn của người chơi
        }
        private void QuizTimer_Tick(object sender, EventArgs e)
        {
            remainingTime--;

            if (remainingTime <= 0)
            {
                // Time's up
                quizTimer.Stop();
                MessageBox.Show("Time's up! Completing the quiz.");
                complete_btn_click(sender, e);
            }
            else
            {
                UpdateTimerDisplay();
            }
        }
        private void UpdateTimerDisplay()
        {
            // Display remaining time in minutes and seconds format (e.g., "03:45")
            int minutes = remainingTime / 60;
            int seconds = remainingTime % 60;
            timerLabel.Text = $"{minutes:D2}:{seconds:D2}"; // Format as "MM:SS"
        }
        private void reset_choice()
        {
            AnsA.Checked= false;
            AnsB.Checked= false;
            AnsC.Checked= false;
            AnsD.Checked= false;
        }
        private void complete_btn_click(object sender, EventArgs e)
        {   if (incorr_num == 0) { if (stack > maxStack) maxStack = stack; }
            quizTimer.Stop();
            timeleft = quizDuration - remainingTime;// Stop the timer when the quiz is completed
            MessageBox.Show($"Quiz completed! Your score: {Point},Num Correct;{Corr_num}, Num of stack: {maxStack}");
            string mess = $"COMPL\n{clientForm.playerName}\n{clientForm.roomId}\n{Corr_num}\n{maxStack}\n{Point}\n{timeleft}\n";
            clientForm.SendMessageToServer(mess);
        }
    }
}
