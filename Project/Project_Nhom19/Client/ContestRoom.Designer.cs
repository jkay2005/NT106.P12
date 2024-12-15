namespace Client
{
    partial class ContestRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContestRoom));
            this.ShowQuestion = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Next = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DHead = new System.Windows.Forms.Label();
            this.BHead = new System.Windows.Forms.Label();
            this.AnsD = new System.Windows.Forms.RadioButton();
            this.AnsA = new System.Windows.Forms.RadioButton();
            this.CHead = new System.Windows.Forms.Label();
            this.AHead = new System.Windows.Forms.Label();
            this.AnsC = new System.Windows.Forms.RadioButton();
            this.AnsB = new System.Windows.Forms.RadioButton();
            this.pointtext = new System.Windows.Forms.Label();
            this.timerLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.StackLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShowQuestion
            // 
            this.ShowQuestion.AutoSize = true;
            this.ShowQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowQuestion.ForeColor = System.Drawing.Color.White;
            this.ShowQuestion.Location = new System.Drawing.Point(3, 0);
            this.ShowQuestion.Name = "ShowQuestion";
            this.ShowQuestion.Size = new System.Drawing.Size(0, 22);
            this.ShowQuestion.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.ShowQuestion);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(192, 120);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(446, 88);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // Next
            // 
            this.Next.BackColor = System.Drawing.Color.DimGray;
            this.Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Next.ForeColor = System.Drawing.Color.White;
            this.Next.Location = new System.Drawing.Point(666, 30);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(85, 46);
            this.Next.TabIndex = 10;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = false;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.DHead);
            this.groupBox1.Controls.Add(this.BHead);
            this.groupBox1.Controls.Add(this.AnsD);
            this.groupBox1.Controls.Add(this.AnsA);
            this.groupBox1.Controls.Add(this.CHead);
            this.groupBox1.Controls.Add(this.AHead);
            this.groupBox1.Controls.Add(this.AnsC);
            this.groupBox1.Controls.Add(this.AnsB);
            this.groupBox1.Location = new System.Drawing.Point(45, 260);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(684, 182);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // DHead
            // 
            this.DHead.AutoSize = true;
            this.DHead.BackColor = System.Drawing.Color.Transparent;
            this.DHead.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DHead.ForeColor = System.Drawing.Color.White;
            this.DHead.Location = new System.Drawing.Point(364, 128);
            this.DHead.Name = "DHead";
            this.DHead.Size = new System.Drawing.Size(23, 21);
            this.DHead.TabIndex = 25;
            this.DHead.Text = "D";
            // 
            // BHead
            // 
            this.BHead.AutoSize = true;
            this.BHead.BackColor = System.Drawing.Color.Transparent;
            this.BHead.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BHead.ForeColor = System.Drawing.Color.White;
            this.BHead.Location = new System.Drawing.Point(364, 33);
            this.BHead.Name = "BHead";
            this.BHead.Size = new System.Drawing.Size(23, 21);
            this.BHead.TabIndex = 21;
            this.BHead.Text = "B";
            // 
            // AnsD
            // 
            this.AnsD.AutoSize = true;
            this.AnsD.BackColor = System.Drawing.Color.Transparent;
            this.AnsD.ForeColor = System.Drawing.Color.White;
            this.AnsD.Location = new System.Drawing.Point(391, 129);
            this.AnsD.Name = "AnsD";
            this.AnsD.Size = new System.Drawing.Size(17, 16);
            this.AnsD.TabIndex = 24;
            this.AnsD.TabStop = true;
            this.AnsD.UseVisualStyleBackColor = false;
            // 
            // AnsA
            // 
            this.AnsA.AutoSize = true;
            this.AnsA.BackColor = System.Drawing.Color.Transparent;
            this.AnsA.ForeColor = System.Drawing.Color.White;
            this.AnsA.Location = new System.Drawing.Point(49, 34);
            this.AnsA.Name = "AnsA";
            this.AnsA.Size = new System.Drawing.Size(17, 16);
            this.AnsA.TabIndex = 18;
            this.AnsA.TabStop = true;
            this.AnsA.UseVisualStyleBackColor = false;
            // 
            // CHead
            // 
            this.CHead.AutoSize = true;
            this.CHead.BackColor = System.Drawing.Color.Transparent;
            this.CHead.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHead.ForeColor = System.Drawing.Color.White;
            this.CHead.Location = new System.Drawing.Point(22, 127);
            this.CHead.Name = "CHead";
            this.CHead.Size = new System.Drawing.Size(23, 21);
            this.CHead.TabIndex = 23;
            this.CHead.Text = "C";
            // 
            // AHead
            // 
            this.AHead.AutoSize = true;
            this.AHead.BackColor = System.Drawing.Color.Transparent;
            this.AHead.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AHead.ForeColor = System.Drawing.Color.White;
            this.AHead.Location = new System.Drawing.Point(22, 31);
            this.AHead.Name = "AHead";
            this.AHead.Size = new System.Drawing.Size(23, 21);
            this.AHead.TabIndex = 19;
            this.AHead.Text = "A";
            // 
            // AnsC
            // 
            this.AnsC.AutoSize = true;
            this.AnsC.BackColor = System.Drawing.Color.Transparent;
            this.AnsC.ForeColor = System.Drawing.Color.White;
            this.AnsC.Location = new System.Drawing.Point(49, 129);
            this.AnsC.Name = "AnsC";
            this.AnsC.Size = new System.Drawing.Size(17, 16);
            this.AnsC.TabIndex = 22;
            this.AnsC.TabStop = true;
            this.AnsC.UseVisualStyleBackColor = false;
            // 
            // AnsB
            // 
            this.AnsB.AutoSize = true;
            this.AnsB.BackColor = System.Drawing.Color.Transparent;
            this.AnsB.ForeColor = System.Drawing.Color.White;
            this.AnsB.Location = new System.Drawing.Point(391, 35);
            this.AnsB.Name = "AnsB";
            this.AnsB.Size = new System.Drawing.Size(17, 16);
            this.AnsB.TabIndex = 20;
            this.AnsB.TabStop = true;
            this.AnsB.UseVisualStyleBackColor = false;
            // 
            // pointtext
            // 
            this.pointtext.AutoSize = true;
            this.pointtext.BackColor = System.Drawing.Color.Transparent;
            this.pointtext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointtext.ForeColor = System.Drawing.Color.White;
            this.pointtext.Location = new System.Drawing.Point(74, 51);
            this.pointtext.Name = "pointtext";
            this.pointtext.Size = new System.Drawing.Size(23, 25);
            this.pointtext.TabIndex = 12;
            this.pointtext.Text = "0";
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.BackColor = System.Drawing.Color.Transparent;
            this.timerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.ForeColor = System.Drawing.Color.White;
            this.timerLabel.Location = new System.Drawing.Point(166, 20);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(51, 25);
            this.timerLabel.TabIndex = 13;
            this.timerLabel.Text = "0:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "Time Remaining:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Point:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "Stack:";
            // 
            // StackLabel
            // 
            this.StackLabel.AutoSize = true;
            this.StackLabel.BackColor = System.Drawing.Color.Transparent;
            this.StackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StackLabel.ForeColor = System.Drawing.Color.White;
            this.StackLabel.Location = new System.Drawing.Point(74, 80);
            this.StackLabel.Name = "StackLabel";
            this.StackLabel.Size = new System.Drawing.Size(23, 25);
            this.StackLabel.TabIndex = 17;
            this.StackLabel.Text = "0";
            // 
            // ContestRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(775, 524);
            this.Controls.Add(this.StackLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.pointtext);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ContestRoom";
            this.Text = "ContestRoom";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ShowQuestion;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label DHead;
        private System.Windows.Forms.Label BHead;
        private System.Windows.Forms.RadioButton AnsD;
        private System.Windows.Forms.RadioButton AnsA;
        private System.Windows.Forms.Label CHead;
        private System.Windows.Forms.Label AHead;
        private System.Windows.Forms.RadioButton AnsC;
        private System.Windows.Forms.RadioButton AnsB;
        private System.Windows.Forms.Label pointtext;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label StackLabel;
    }
}