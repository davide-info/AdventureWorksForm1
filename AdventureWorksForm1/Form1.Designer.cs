
namespace AdventureWorksForm1
{
	partial class Form1
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.idTxt = new System.Windows.Forms.TextBox();
			this.nameTxt = new System.Windows.Forms.TextBox();
			this.costRateTxt = new System.Windows.Forms.TextBox();
			this.availabilyTxt = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.updateTxt = new System.Windows.Forms.Button();
			this.deleteTxt = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(500, 72);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 25;
			this.dataGridView1.Size = new System.Drawing.Size(240, 232);
			this.dataGridView1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "Location id";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "Name";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 94);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 15);
			this.label3.TabIndex = 3;
			this.label3.Text = "Cost Rate";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 128);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(62, 15);
			this.label4.TabIndex = 4;
			this.label4.Text = "Availabilty";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(101, 157);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);
			this.dateTimePicker1.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(13, 163);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(82, 15);
			this.label5.TabIndex = 6;
			this.label5.Text = "Modified Date";
			// 
			// idTxt
			// 
			this.idTxt.Location = new System.Drawing.Point(92, 23);
			this.idTxt.Name = "idTxt";
			this.idTxt.Size = new System.Drawing.Size(100, 23);
			this.idTxt.TabIndex = 7;
			// 
			// nameTxt
			// 
			this.nameTxt.Location = new System.Drawing.Point(78, 58);
			this.nameTxt.Name = "nameTxt";
			this.nameTxt.Size = new System.Drawing.Size(100, 23);
			this.nameTxt.TabIndex = 8;
			// 
			// costRateTxt
			// 
			this.costRateTxt.Location = new System.Drawing.Point(78, 94);
			this.costRateTxt.Name = "costRateTxt";
			this.costRateTxt.Size = new System.Drawing.Size(100, 23);
			this.costRateTxt.TabIndex = 9;
			// 
			// availabilyTxt
			// 
			this.availabilyTxt.Location = new System.Drawing.Point(78, 123);
			this.availabilyTxt.Name = "availabilyTxt";
			this.availabilyTxt.Size = new System.Drawing.Size(100, 23);
			this.availabilyTxt.TabIndex = 10;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(4, 200);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(125, 38);
			this.button1.TabIndex = 11;
			this.button1.Text = "AGGIORNA LOCATION";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// updateTxt
			// 
			this.updateTxt.Location = new System.Drawing.Point(154, 200);
			this.updateTxt.Name = "updateTxt";
			this.updateTxt.Size = new System.Drawing.Size(111, 38);
			this.updateTxt.TabIndex = 12;
			this.updateTxt.Text = "INSERISCI LOCATION";
			this.updateTxt.UseVisualStyleBackColor = true;
			this.updateTxt.Click += new System.EventHandler(this.button2_Click);
			// 
			// deleteTxt
			// 
			this.deleteTxt.Location = new System.Drawing.Point(283, 199);
			this.deleteTxt.Name = "deleteTxt";
			this.deleteTxt.Size = new System.Drawing.Size(75, 23);
			this.deleteTxt.TabIndex = 13;
			this.deleteTxt.Text = "ELIMINA LOCATION";
			this.deleteTxt.UseVisualStyleBackColor = true;
			this.deleteTxt.Click += new System.EventHandler(this.button3_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.deleteTxt);
			this.Controls.Add(this.updateTxt);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.availabilyTxt);
			this.Controls.Add(this.costRateTxt);
			this.Controls.Add(this.nameTxt);
			this.Controls.Add(this.idTxt);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridView1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox idTxt;
		private System.Windows.Forms.TextBox nameTxt;
		private System.Windows.Forms.TextBox costRateTxt;
		private System.Windows.Forms.TextBox availabilyTxt;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button updateTxt;
		private System.Windows.Forms.Button deleteTxt;
	}
}

