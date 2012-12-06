namespace PiktoTestEnvironment
{
	partial class MainForm
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
			this.pInput = new System.Windows.Forms.PictureBox();
			this.nInputSize = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.nOutputSize = new System.Windows.Forms.NumericUpDown();
			this.pOutput = new System.Windows.Forms.PictureBox();
			this.bGo = new System.Windows.Forms.Button();
			this.bInputOK = new System.Windows.Forms.Button();
			this.bOutputOK = new System.Windows.Forms.Button();
			this.bLoad = new System.Windows.Forms.Button();
			this.openDialog = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.pInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nInputSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nOutputSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pOutput)).BeginInit();
			this.SuspendLayout();
			// 
			// pInput
			// 
			this.pInput.Location = new System.Drawing.Point(12, 12);
			this.pInput.Name = "pInput";
			this.pInput.Size = new System.Drawing.Size(375, 375);
			this.pInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pInput.TabIndex = 0;
			this.pInput.TabStop = false;
			this.pInput.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pInput_MouseClick);
			// 
			// nInputSize
			// 
			this.nInputSize.Location = new System.Drawing.Point(160, 393);
			this.nInputSize.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.nInputSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nInputSize.Name = "nInputSize";
			this.nInputSize.Size = new System.Drawing.Size(85, 20);
			this.nInputSize.TabIndex = 1;
			this.nInputSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(102, 395);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Input size";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(475, 395);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Output size";
			// 
			// nOutputSize
			// 
			this.nOutputSize.Location = new System.Drawing.Point(541, 393);
			this.nOutputSize.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.nOutputSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nOutputSize.Name = "nOutputSize";
			this.nOutputSize.Size = new System.Drawing.Size(85, 20);
			this.nOutputSize.TabIndex = 4;
			this.nOutputSize.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			// 
			// pOutput
			// 
			this.pOutput.Location = new System.Drawing.Point(393, 12);
			this.pOutput.Name = "pOutput";
			this.pOutput.Size = new System.Drawing.Size(375, 375);
			this.pOutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pOutput.TabIndex = 3;
			this.pOutput.TabStop = false;
			// 
			// bGo
			// 
			this.bGo.Location = new System.Drawing.Point(590, 436);
			this.bGo.Name = "bGo";
			this.bGo.Size = new System.Drawing.Size(75, 23);
			this.bGo.TabIndex = 6;
			this.bGo.Text = "Go";
			this.bGo.UseVisualStyleBackColor = true;
			this.bGo.Click += new System.EventHandler(this.bGo_Click);
			// 
			// bInputOK
			// 
			this.bInputOK.Location = new System.Drawing.Point(251, 390);
			this.bInputOK.Name = "bInputOK";
			this.bInputOK.Size = new System.Drawing.Size(33, 23);
			this.bInputOK.TabIndex = 7;
			this.bInputOK.Text = "OK";
			this.bInputOK.UseVisualStyleBackColor = true;
			this.bInputOK.Click += new System.EventHandler(this.bInputOK_Click);
			// 
			// bOutputOK
			// 
			this.bOutputOK.Location = new System.Drawing.Point(632, 390);
			this.bOutputOK.Name = "bOutputOK";
			this.bOutputOK.Size = new System.Drawing.Size(33, 23);
			this.bOutputOK.TabIndex = 8;
			this.bOutputOK.Text = "OK";
			this.bOutputOK.UseVisualStyleBackColor = true;
			this.bOutputOK.Click += new System.EventHandler(this.bOutputOK_Click);
			// 
			// bLoad
			// 
			this.bLoad.Location = new System.Drawing.Point(12, 436);
			this.bLoad.Name = "bLoad";
			this.bLoad.Size = new System.Drawing.Size(75, 23);
			this.bLoad.TabIndex = 9;
			this.bLoad.Text = "Load";
			this.bLoad.UseVisualStyleBackColor = true;
			this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(777, 476);
			this.Controls.Add(this.bLoad);
			this.Controls.Add(this.bOutputOK);
			this.Controls.Add(this.bInputOK);
			this.Controls.Add(this.bGo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.nOutputSize);
			this.Controls.Add(this.pOutput);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.nInputSize);
			this.Controls.Add(this.pInput);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			((System.ComponentModel.ISupportInitialize)(this.pInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nInputSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nOutputSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pOutput)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pInput;
		private System.Windows.Forms.NumericUpDown nInputSize;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown nOutputSize;
		private System.Windows.Forms.PictureBox pOutput;
		private System.Windows.Forms.Button bGo;
		private System.Windows.Forms.Button bInputOK;
		private System.Windows.Forms.Button bOutputOK;
		private System.Windows.Forms.Button bLoad;
		private System.Windows.Forms.OpenFileDialog openDialog;
	}
}

