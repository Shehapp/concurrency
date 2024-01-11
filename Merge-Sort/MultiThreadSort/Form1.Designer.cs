namespace MultiThreadSort
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtArraySize = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdRandom = new System.Windows.Forms.RadioButton();
            this.rdDescending = new System.Windows.Forms.RadioButton();
            this.rdAscending = new System.Windows.Forms.RadioButton();
            this.txtSeqTime = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSeqRes = new System.Windows.Forms.TextBox();
            this.btnSeqRun = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMTRes = new System.Windows.Forms.TextBox();
            this.btMTRun = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMTTime = new System.Windows.Forms.TextBox();
            this.txtSpeedup = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.txtTestRes = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Array Size";
            // 
            // txtArraySize
            // 
            this.txtArraySize.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArraySize.Location = new System.Drawing.Point(181, 12);
            this.txtArraySize.Name = "txtArraySize";
            this.txtArraySize.Size = new System.Drawing.Size(193, 34);
            this.txtArraySize.TabIndex = 1;
            this.txtArraySize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdRandom);
            this.groupBox1.Controls.Add(this.rdDescending);
            this.groupBox1.Controls.Add(this.rdAscending);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(396, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 126);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Initialization ";
            // 
            // rdRandom
            // 
            this.rdRandom.AutoSize = true;
            this.rdRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdRandom.Location = new System.Drawing.Point(15, 86);
            this.rdRandom.Name = "rdRandom";
            this.rdRandom.Size = new System.Drawing.Size(106, 29);
            this.rdRandom.TabIndex = 2;
            this.rdRandom.TabStop = true;
            this.rdRandom.Text = "Random";
            this.rdRandom.UseVisualStyleBackColor = true;
            this.rdRandom.CheckedChanged += new System.EventHandler(this.rdRandom_CheckedChanged);
            // 
            // rdDescending
            // 
            this.rdDescending.AutoSize = true;
            this.rdDescending.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdDescending.Location = new System.Drawing.Point(15, 58);
            this.rdDescending.Name = "rdDescending";
            this.rdDescending.Size = new System.Drawing.Size(137, 29);
            this.rdDescending.TabIndex = 1;
            this.rdDescending.TabStop = true;
            this.rdDescending.Text = "Descending";
            this.rdDescending.UseVisualStyleBackColor = true;
            this.rdDescending.CheckedChanged += new System.EventHandler(this.rdDescending_CheckedChanged);
            // 
            // rdAscending
            // 
            this.rdAscending.AutoSize = true;
            this.rdAscending.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdAscending.Location = new System.Drawing.Point(15, 31);
            this.rdAscending.Name = "rdAscending";
            this.rdAscending.Size = new System.Drawing.Size(126, 29);
            this.rdAscending.TabIndex = 0;
            this.rdAscending.TabStop = true;
            this.rdAscending.Text = "Ascending";
            this.rdAscending.UseVisualStyleBackColor = true;
            this.rdAscending.CheckedChanged += new System.EventHandler(this.rdAscending_CheckedChanged);
            // 
            // txtSeqTime
            // 
            this.txtSeqTime.Enabled = false;
            this.txtSeqTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeqTime.Location = new System.Drawing.Point(31, 198);
            this.txtSeqTime.Name = "txtSeqTime";
            this.txtSeqTime.Size = new System.Drawing.Size(209, 34);
            this.txtSeqTime.TabIndex = 3;
            this.txtSeqTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtSeqRes);
            this.groupBox2.Controls.Add(this.btnSeqRun);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtSeqTime);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 240);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sequential Execution";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(103, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Result";
            // 
            // txtSeqRes
            // 
            this.txtSeqRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeqRes.ForeColor = System.Drawing.Color.Black;
            this.txtSeqRes.Location = new System.Drawing.Point(31, 131);
            this.txtSeqRes.Name = "txtSeqRes";
            this.txtSeqRes.Size = new System.Drawing.Size(209, 34);
            this.txtSeqRes.TabIndex = 7;
            this.txtSeqRes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSeqRun
            // 
            this.btnSeqRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeqRun.Location = new System.Drawing.Point(31, 35);
            this.btnSeqRun.Name = "btnSeqRun";
            this.btnSeqRun.Size = new System.Drawing.Size(209, 55);
            this.btnSeqRun.TabIndex = 6;
            this.btnSeqRun.Text = "Run";
            this.btnSeqRun.UseVisualStyleBackColor = true;
            this.btnSeqRun.Click += new System.EventHandler(this.btnSeqRun_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Time";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtMTRes);
            this.groupBox3.Controls.Add(this.btMTRun);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtMTTime);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(311, 164);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(276, 240);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MultiThread Execution";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(100, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Result";
            // 
            // txtMTRes
            // 
            this.txtMTRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMTRes.Location = new System.Drawing.Point(28, 131);
            this.txtMTRes.Name = "txtMTRes";
            this.txtMTRes.Size = new System.Drawing.Size(209, 34);
            this.txtMTRes.TabIndex = 9;
            this.txtMTRes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btMTRun
            // 
            this.btMTRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMTRun.Location = new System.Drawing.Point(28, 35);
            this.btMTRun.Name = "btMTRun";
            this.btMTRun.Size = new System.Drawing.Size(209, 55);
            this.btMTRun.TabIndex = 6;
            this.btMTRun.Text = "Run";
            this.btMTRun.UseVisualStyleBackColor = true;
            this.btMTRun.Click += new System.EventHandler(this.btMTRun_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Time";
            // 
            // txtMTTime
            // 
            this.txtMTTime.Enabled = false;
            this.txtMTTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMTTime.Location = new System.Drawing.Point(28, 198);
            this.txtMTTime.Name = "txtMTTime";
            this.txtMTTime.Size = new System.Drawing.Size(209, 34);
            this.txtMTTime.TabIndex = 3;
            this.txtMTTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSpeedup
            // 
            this.txtSpeedup.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpeedup.Location = new System.Drawing.Point(181, 104);
            this.txtSpeedup.Name = "txtSpeedup";
            this.txtSpeedup.ReadOnly = true;
            this.txtSpeedup.Size = new System.Drawing.Size(130, 34);
            this.txtSpeedup.TabIndex = 9;
            this.txtSpeedup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Speedup";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtTestRes);
            this.groupBox4.Controls.Add(this.btnTest);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(55, 410);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(482, 109);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Test Encapsulate/Extract Params";
            // 
            // btnTest
            // 
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.Location = new System.Drawing.Point(31, 35);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(209, 55);
            this.btnTest.TabIndex = 6;
            this.btnTest.Text = "TEST";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtTestRes
            // 
            this.txtTestRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestRes.ForeColor = System.Drawing.Color.Black;
            this.txtTestRes.Location = new System.Drawing.Point(256, 45);
            this.txtTestRes.Name = "txtTestRes";
            this.txtTestRes.Size = new System.Drawing.Size(199, 34);
            this.txtTestRes.TabIndex = 7;
            this.txtTestRes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 532);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.txtSpeedup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtArraySize);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtArraySize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdRandom;
        private System.Windows.Forms.RadioButton rdDescending;
        private System.Windows.Forms.RadioButton rdAscending;
        private System.Windows.Forms.TextBox txtSeqTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSeqRun;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btMTRun;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMTTime;
        private System.Windows.Forms.TextBox txtSpeedup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSeqRes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMTRes;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtTestRes;
        private System.Windows.Forms.Button btnTest;
    }
}

