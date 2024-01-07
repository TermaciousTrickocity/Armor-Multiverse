namespace Armor_Multiverse
{
    partial class ArmorMultiverse
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
            this.connectButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.loopTimeTextbox = new System.Windows.Forms.TextBox();
            this.connectionTextbox = new System.Windows.Forms.TextBox();
            this.percentageTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.amountTotalTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.currentPatternTextbox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.elapsedTimeTextbox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.resumeRevertTextbox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(12, 6);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(90, 34);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(352, 6);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(90, 34);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Loop time: ";
            // 
            // loopTimeTextbox
            // 
            this.loopTimeTextbox.Location = new System.Drawing.Point(122, 37);
            this.loopTimeTextbox.Name = "loopTimeTextbox";
            this.loopTimeTextbox.ReadOnly = true;
            this.loopTimeTextbox.Size = new System.Drawing.Size(286, 20);
            this.loopTimeTextbox.TabIndex = 5;
            this.loopTimeTextbox.Text = "...";
            // 
            // connectionTextbox
            // 
            this.connectionTextbox.Location = new System.Drawing.Point(108, 14);
            this.connectionTextbox.Name = "connectionTextbox";
            this.connectionTextbox.ReadOnly = true;
            this.connectionTextbox.Size = new System.Drawing.Size(142, 20);
            this.connectionTextbox.TabIndex = 6;
            this.connectionTextbox.Text = "(not connected)";
            // 
            // percentageTextbox
            // 
            this.percentageTextbox.Location = new System.Drawing.Point(122, 89);
            this.percentageTextbox.Name = "percentageTextbox";
            this.percentageTextbox.ReadOnly = true;
            this.percentageTextbox.Size = new System.Drawing.Size(286, 20);
            this.percentageTextbox.TabIndex = 7;
            this.percentageTextbox.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Percentage: ";
            // 
            // amountTotalTextbox
            // 
            this.amountTotalTextbox.Location = new System.Drawing.Point(122, 115);
            this.amountTotalTextbox.Name = "amountTotalTextbox";
            this.amountTotalTextbox.ReadOnly = true;
            this.amountTotalTextbox.Size = new System.Drawing.Size(286, 20);
            this.amountTotalTextbox.TabIndex = 9;
            this.amountTotalTextbox.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Amount: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Current pattern: ";
            // 
            // currentPatternTextbox
            // 
            this.currentPatternTextbox.Location = new System.Drawing.Point(122, 13);
            this.currentPatternTextbox.Name = "currentPatternTextbox";
            this.currentPatternTextbox.ReadOnly = true;
            this.currentPatternTextbox.Size = new System.Drawing.Size(286, 20);
            this.currentPatternTextbox.TabIndex = 12;
            this.currentPatternTextbox.Text = "...";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.elapsedTimeTextbox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.currentPatternTextbox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.loopTimeTextbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.percentageTextbox);
            this.groupBox1.Controls.Add(this.amountTotalTextbox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 152);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistics";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Total elapsed time: ";
            // 
            // elapsedTimeTextbox
            // 
            this.elapsedTimeTextbox.Location = new System.Drawing.Point(122, 63);
            this.elapsedTimeTextbox.Name = "elapsedTimeTextbox";
            this.elapsedTimeTextbox.ReadOnly = true;
            this.elapsedTimeTextbox.Size = new System.Drawing.Size(286, 20);
            this.elapsedTimeTextbox.TabIndex = 13;
            this.elapsedTimeTextbox.Text = "...";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.resumeRevertTextbox);
            this.groupBox2.Location = new System.Drawing.Point(12, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 69);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resume/Revert";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(361, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "(If this is changed to a number \'>= 1\' it\'ll jump to that corresponding pattern) " +
    "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Processed amount resume:  ";
            // 
            // resumeRevertTextbox
            // 
            this.resumeRevertTextbox.Location = new System.Drawing.Point(153, 19);
            this.resumeRevertTextbox.Name = "resumeRevertTextbox";
            this.resumeRevertTextbox.Size = new System.Drawing.Size(255, 20);
            this.resumeRevertTextbox.TabIndex = 15;
            this.resumeRevertTextbox.Text = "0";
            this.resumeRevertTextbox.TextChanged += new System.EventHandler(this.resumeRevertTextbox_TextChanged);
            // 
            // ArmorMultiverse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 284);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.connectionTextbox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.connectButton);
            this.Name = "ArmorMultiverse";
            this.Text = "Armor Multiverse";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox loopTimeTextbox;
        private System.Windows.Forms.TextBox connectionTextbox;
        private System.Windows.Forms.TextBox percentageTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox amountTotalTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox currentPatternTextbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox elapsedTimeTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox resumeRevertTextbox;
        private System.Windows.Forms.Label label7;
    }
}

