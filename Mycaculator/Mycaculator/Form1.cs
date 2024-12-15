using System;
using System.Windows.Forms;

namespace Mycaculator
{
    public partial class Form1 : Form
    {
        double data1, data2;
        double result = 0;
        string operation;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            manhinh.Text += "8";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            operation = "/";
            data1 = double.Parse(manhinh.Text);
            manhinh.Text = " ";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            manhinh.Text = " ";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            manhinh.Text = " ";
            result = 0;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try {
                data2= double.Parse(manhinh.Text);
                caculate(data1,data2,operation);
            }
            catch(Exception ex) {
                MessageBox.Show("ERROR");
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            manhinh.Text += "0";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            manhinh.Text += "1";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            manhinh.Text += "2";

        }

        private void button13_Click(object sender, EventArgs e)
        {
            manhinh.Text += "3";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            manhinh.Text += "4";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            manhinh.Text += "5";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            manhinh.Text += "6";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            manhinh.Text += "7";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            manhinh.Text += "9";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            manhinh.Text += ".";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            operation = "+";
            data1 =double.Parse(manhinh.Text);
            manhinh.Text = " ";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            operation = "-";
            data1 = double.Parse(manhinh.Text);
            manhinh.Text = " ";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            operation = "*";
            data1 = double.Parse(manhinh.Text);
            manhinh.Text = " ";
        }

        private void caculate(double x,double y, string z)
        {
            result = 0;
            switch (z)
            {
                case "+":
                    result = x + y;
                    break;

                case "-":
                    result = x - y;
                    break;

                case "*":
                    result = x * y;
                    break;

                case "/":
                    if (data2 == 0)
                    {
                        MessageBox.Show("KHONG THE CHIA CHO 0");
                        return;
                    }
                    else
                    {
                        result = x/y;
                    }
                    break;
            }

         manhinh.Text = result.ToString();
        }
    }

}
