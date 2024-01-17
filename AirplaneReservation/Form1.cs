using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace AirplaneReservation
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox lstPlane1;
		private System.Windows.Forms.ListBox lstPlane2;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.ListBox lstInside;
		private System.Windows.Forms.ListBox lstOutside1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lstPlane1 = new System.Windows.Forms.ListBox();
			this.lstPlane2 = new System.Windows.Forms.ListBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.lstInside = new System.Windows.Forms.ListBox();
			this.lstOutside1 = new System.Windows.Forms.ListBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.SuspendLayout();
			// 
			// lstPlane1
			// 
			this.lstPlane1.Location = new System.Drawing.Point(224, 32);
			this.lstPlane1.Name = "lstPlane1";
			this.lstPlane1.Size = new System.Drawing.Size(72, 173);
			this.lstPlane1.TabIndex = 0;
			// 
			// lstPlane2
			// 
			this.lstPlane2.Location = new System.Drawing.Point(320, 32);
			this.lstPlane2.Name = "lstPlane2";
			this.lstPlane2.Size = new System.Drawing.Size(80, 173);
			this.lstPlane2.TabIndex = 1;
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(64, 352);
			this.btnStart.Name = "btnStart";
			this.btnStart.TabIndex = 2;
			this.btnStart.Text = "Start";
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnStop
			// 
			this.btnStop.Location = new System.Drawing.Point(232, 352);
			this.btnStop.Name = "btnStop";
			this.btnStop.TabIndex = 3;
			this.btnStop.Text = "Stop";
			// 
			// lstInside
			// 
			this.lstInside.Location = new System.Drawing.Point(112, 32);
			this.lstInside.Name = "lstInside";
			this.lstInside.Size = new System.Drawing.Size(72, 264);
			this.lstInside.TabIndex = 4;
			// 
			// lstOutside1
			// 
			this.lstOutside1.Location = new System.Drawing.Point(8, 16);
			this.lstOutside1.Name = "lstOutside1";
			this.lstOutside1.Size = new System.Drawing.Size(72, 303);
			this.lstOutside1.TabIndex = 6;
			// 
			// listBox1
			// 
			this.listBox1.Location = new System.Drawing.Point(8, 16);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(72, 290);
			this.listBox1.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(88, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(336, 312);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Max = 20";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(536, 398);
			this.Controls.Add(this.lstOutside1);
			this.Controls.Add(this.lstInside);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.lstPlane2);
			this.Controls.Add(this.lstPlane1);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form2());
		}

		private void btnStart_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
