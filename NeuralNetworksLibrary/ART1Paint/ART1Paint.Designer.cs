namespace ART1Paint
{
	partial class ART1PaintForm
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
			this.pbInput = new System.Windows.Forms.PictureBox();
			this.pClusters = new System.Windows.Forms.FlowLayoutPanel();
			this.bPresent = new System.Windows.Forms.Button();
			this.pbWinner = new System.Windows.Forms.PictureBox();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pbInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbWinner)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// pbInput
			// 
			this.pbInput.Location = new System.Drawing.Point(12, 12);
			this.pbInput.Name = "pbInput";
			this.pbInput.Size = new System.Drawing.Size(500, 500);
			this.pbInput.TabIndex = 0;
			this.pbInput.TabStop = false;
			// 
			// pClusters
			// 
			this.pClusters.AutoScroll = true;
			this.pClusters.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.pClusters.Location = new System.Drawing.Point(518, 12);
			this.pClusters.Name = "pClusters";
			this.pClusters.Size = new System.Drawing.Size(100, 500);
			this.pClusters.TabIndex = 2;
			// 
			// bPresent
			// 
			this.bPresent.Location = new System.Drawing.Point(624, 12);
			this.bPresent.Name = "bPresent";
			this.bPresent.Size = new System.Drawing.Size(75, 23);
			this.bPresent.TabIndex = 3;
			this.bPresent.Text = "Present";
			this.bPresent.UseVisualStyleBackColor = true;
			// 
			// pbWinner
			// 
			this.pbWinner.Location = new System.Drawing.Point(624, 41);
			this.pbWinner.Name = "pbWinner";
			this.pbWinner.Size = new System.Drawing.Size(100, 100);
			this.pbWinner.TabIndex = 4;
			this.pbWinner.TabStop = false;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.DecimalPlaces = 2;
			this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numericUpDown1.Location = new System.Drawing.Point(648, 220);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(51, 20);
			this.numericUpDown1.TabIndex = 5;
			this.numericUpDown1.Value = new decimal(new int[] {
            7,
            0,
            0,
            65536});
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(624, 191);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 6;
			this.button1.Text = "New network";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(624, 222);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(13, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "ρ";
			// 
			// ART1PaintForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(734, 524);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.pbWinner);
			this.Controls.Add(this.bPresent);
			this.Controls.Add(this.pClusters);
			this.Controls.Add(this.pbInput);
			this.Name = "ART1PaintForm";
			this.Text = "ART1 Paint";
			((System.ComponentModel.ISupportInitialize)(this.pbInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbWinner)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.PictureBox pbInput;
		internal System.Windows.Forms.FlowLayoutPanel pClusters;
		internal System.Windows.Forms.Button bPresent;
		internal System.Windows.Forms.PictureBox pbWinner;
		internal System.Windows.Forms.NumericUpDown numericUpDown1;
		internal System.Windows.Forms.Button button1;
		internal System.Windows.Forms.Label label1;

	}
}

