namespace ImageListOpener
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.DisplayScreen = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PhanTu = new System.Windows.Forms.RichTextBox();
            this.TongPT = new System.Windows.Forms.RichTextBox();
            this.list_Of_Images = new System.Windows.Forms.ListBox();
            this.CurrentLink = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(122, 431);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "<<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(248, 431);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(416, 431);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = ">";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(547, 431);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = ">>";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(843, 475);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 83);
            this.button5.TabIndex = 5;
            this.button5.Text = "Link";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(972, 475);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 83);
            this.button6.TabIndex = 6;
            this.button6.Text = "Check";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // DisplayScreen
            // 
            this.DisplayScreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DisplayScreen.Location = new System.Drawing.Point(12, 0);
            this.DisplayScreen.Name = "DisplayScreen";
            this.DisplayScreen.Size = new System.Drawing.Size(801, 425);
            this.DisplayScreen.TabIndex = 7;
            this.DisplayScreen.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(819, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "PictureIndex";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(951, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "NumOf_Picture";
            // 
            // PhanTu
            // 
            this.PhanTu.Location = new System.Drawing.Point(822, 72);
            this.PhanTu.Name = "PhanTu";
            this.PhanTu.ReadOnly = true;
            this.PhanTu.Size = new System.Drawing.Size(96, 150);
            this.PhanTu.TabIndex = 10;
            this.PhanTu.Text = "";
            // 
            // TongPT
            // 
            this.TongPT.Location = new System.Drawing.Point(954, 72);
            this.TongPT.Name = "TongPT";
            this.TongPT.ReadOnly = true;
            this.TongPT.Size = new System.Drawing.Size(96, 150);
            this.TongPT.TabIndex = 11;
            this.TongPT.Text = "";
            // 
            // list_Of_Images
            // 
            this.list_Of_Images.FormattingEnabled = true;
            this.list_Of_Images.ItemHeight = 16;
            this.list_Of_Images.Location = new System.Drawing.Point(12, 474);
            this.list_Of_Images.Name = "list_Of_Images";
            this.list_Of_Images.Size = new System.Drawing.Size(801, 84);
            this.list_Of_Images.TabIndex = 12;
            this.list_Of_Images.SelectedIndexChanged += new System.EventHandler(this.list_Of_Images_SelectedIndexChanged);
            // 
            // CurrentLink
            // 
            this.CurrentLink.Location = new System.Drawing.Point(12, 588);
            this.CurrentLink.Name = "CurrentLink";
            this.CurrentLink.Size = new System.Drawing.Size(801, 22);
            this.CurrentLink.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 633);
            this.Controls.Add(this.CurrentLink);
            this.Controls.Add(this.list_Of_Images);
            this.Controls.Add(this.TongPT);
            this.Controls.Add(this.PhanTu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DisplayScreen);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImageOpener";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DisplayScreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.PictureBox DisplayScreen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox PhanTu;
        private System.Windows.Forms.RichTextBox TongPT;
        private System.Windows.Forms.ListBox list_Of_Images;
        private System.Windows.Forms.TextBox CurrentLink;
    }
}

