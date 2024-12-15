using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageListOpener
{
    public partial class Form1 : Form
    {
        private bool IsLinkButtonClickedFirst = false;
        public Form1()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)// có thể dùng để nhập key từ bàn phím
        {
            switch (keyData)
            {
                case (Keys.Up):
                    button2.PerformClick();
                    return true;
                case Keys.Down:
                    button3.PerformClick();
                    return true;
                case Keys.Left:
                    button2.PerformClick();
                    return true;
                case Keys.Right:
                    button3.PerformClick();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsLinkButtonClickedFirst == true)
            {
                list_Of_Images.SelectedIndex = 0;
            }
            else MessageBox.Show("Complete <Link > first!", " Notification ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IsLinkButtonClickedFirst == true)
            {
                if (list_Of_Images.SelectedIndex == 0) { list_Of_Images.SelectedIndex = list_Of_Images.Items.Count - 1; }
                else
                    list_Of_Images.SelectedIndex = list_Of_Images.SelectedIndex - 1;
            }
            else MessageBox.Show("Complete <Link > first!", " Notification ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (IsLinkButtonClickedFirst == true)
            {
                if (list_Of_Images.SelectedIndex == list_Of_Images.Items.Count - 1) { list_Of_Images.SelectedIndex = 0; }
                else
                    list_Of_Images.SelectedIndex = list_Of_Images.SelectedIndex + 1;
            }
            else MessageBox.Show("Complete <Link > first!", " Notification ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (IsLinkButtonClickedFirst == true)
            {
                list_Of_Images.SelectedIndex = list_Of_Images.Items.Count - 1;
            }
            else MessageBox.Show("Complete <Link > first!", " Notification ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CurrentLink.Clear();
            list_Of_Images.Items.Clear();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                CurrentLink.Text = fbd.SelectedPath;
                IsLinkButtonClickedFirst = true;
            }
            else return;


            foreach (string listfile in Directory.GetFiles(fbd.SelectedPath))
            {
                FileInfo fi = new FileInfo(listfile);
                if (fi.Extension.Equals(".png") || fi.Extension.Equals(".jpg"))
                    list_Of_Images.Items.Add(listfile);
            }
            if (list_Of_Images.Items.Count >= 1)
            {
                list_Of_Images.SelectedIndex = 0;
            }
            else
            {

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
                if (IsLinkButtonClickedFirst == true)
                {
                    PhanTu.Text = list_Of_Images.SelectedIndex.ToString();
                    TongPT.Text = list_Of_Images.Items.Count.ToString();
                }
                else MessageBox.Show("Complete <Link > first!", " Notification ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }

        private void list_Of_Images_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayScreen.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                if (DisplayScreen.Image != null)
                {
                    DisplayScreen.Image.Dispose();
                }
                DisplayScreen.Image = Image.FromFile(list_Of_Images.SelectedItem.ToString());
            }
            catch (Exception noti)
            {
                MessageBox.Show(noti.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
