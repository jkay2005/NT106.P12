namespace Client
{
    partial class Client
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label label2;
            txtip = new TextBox();
            txtport = new TextBox();
            txtmes = new RichTextBox();
            sendmes = new Button();
            sendfile = new Button();
            listmes = new RichTextBox();
            label1 = new Label();
            connect = new Button();
            openFileDialog1 = new OpenFileDialog();
            txtname = new TextBox();
            label3 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(211, 36);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 8;
            label2.Text = "PORT";
            // 
            // txtip
            // 
            txtip.Location = new Point(77, 32);
            txtip.Name = "txtip";
            txtip.Size = new Size(100, 23);
            txtip.TabIndex = 0;
            // 
            // txtport
            // 
            txtport.Location = new Point(257, 32);
            txtport.Name = "txtport";
            txtport.Size = new Size(100, 23);
            txtport.TabIndex = 1;
            // 
            // txtmes
            // 
            txtmes.Location = new Point(30, 287);
            txtmes.Name = "txtmes";
            txtmes.Size = new Size(451, 96);
            txtmes.TabIndex = 2;
            txtmes.Text = "";
            // 
            // sendmes
            // 
            sendmes.Location = new Point(568, 296);
            sendmes.Name = "sendmes";
            sendmes.Size = new Size(75, 23);
            sendmes.TabIndex = 4;
            sendmes.Text = "SEND MES";
            sendmes.UseVisualStyleBackColor = true;
            sendmes.Click += sendmes_Click;
            // 
            // sendfile
            // 
            sendfile.Location = new Point(568, 342);
            sendfile.Name = "sendfile";
            sendfile.Size = new Size(75, 23);
            sendfile.TabIndex = 5;
            sendfile.Text = "SEND FILE";
            sendfile.UseVisualStyleBackColor = true;
            sendfile.Click += sendfile_Click;
            // 
            // listmes
            // 
            listmes.Location = new Point(40, 70);
            listmes.Name = "listmes";
            listmes.Size = new Size(748, 188);
            listmes.TabIndex = 6;
            listmes.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 32);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 7;
            label1.Text = "IP";
            // 
            // connect
            // 
            connect.Location = new Point(674, 28);
            connect.Name = "connect";
            connect.Size = new Size(75, 23);
            connect.TabIndex = 9;
            connect.Text = "CONNECT";
            connect.UseVisualStyleBackColor = true;
            connect.Click += connect_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "ofd";
            // 
            // txtname
            // 
            txtname.Location = new Point(486, 33);
            txtname.Name = "txtname";
            txtname.Size = new Size(100, 23);
            txtname.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(418, 36);
            label3.Name = "label3";
            label3.Size = new Size(25, 15);
            label3.TabIndex = 11;
            label3.Text = "Tên";
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(txtname);
            Controls.Add(connect);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listmes);
            Controls.Add(sendfile);
            Controls.Add(sendmes);
            Controls.Add(txtmes);
            Controls.Add(txtport);
            Controls.Add(txtip);
            Name = "Client";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtip;
        private TextBox txtport;
        private RichTextBox txtmes;
        private Button sendmes;
        private Button sendfile;
        private RichTextBox listmes;
        private Label label1;
        private Label label2;
        private Button connect;
        private OpenFileDialog openFileDialog1;
        private TextBox txtname;
        private Label label3;
    }
}
