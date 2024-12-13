namespace Server
{
    partial class Server
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
            txtip = new TextBox();
            txtmes = new RichTextBox();
            label1 = new Label();
            start = new Button();
            SuspendLayout();
            // 
            // txtip
            // 
            txtip.Location = new Point(56, 10);
            txtip.Name = "txtip";
            txtip.Size = new Size(100, 23);
            txtip.TabIndex = 0;
            txtip.Text = "8080";
            // 
            // txtmes
            // 
            txtmes.Dock = DockStyle.Bottom;
            txtmes.Location = new Point(0, 77);
            txtmes.Name = "txtmes";
            txtmes.Size = new Size(405, 285);
            txtmes.TabIndex = 1;
            txtmes.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 17);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 2;
            label1.Text = "PORT";
            // 
            // start
            // 
            start.Location = new Point(219, 17);
            start.Name = "start";
            start.Size = new Size(75, 23);
            start.TabIndex = 3;
            start.Text = "Start";
            start.UseVisualStyleBackColor = true;
            start.Click += start_Click;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 362);
            Controls.Add(start);
            Controls.Add(label1);
            Controls.Add(txtmes);
            Controls.Add(txtip);
            Name = "Server";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtip;
        private RichTextBox txtmes;
        private Label label1;
        private Button start;
    }
}
