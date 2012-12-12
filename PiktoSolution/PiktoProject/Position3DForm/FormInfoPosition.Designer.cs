
using AForge.Math;
using AForge.Math.Geometry;
namespace Pikto.Position3DForm
{
    partial class FormInfoPosition
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
        public void setImagePoint( AForge.Point[] imagePoints){
            imagePoint1Box.Text = imagePoints[0].ToString();
            imagePoint2Box.Text = imagePoints[1].ToString();
            imagePoint3Box.Text = imagePoints[2].ToString();
            imagePoint4Box.Text = imagePoints[3].ToString();
        }
        public void setModelPoints(Vector3[] modelPoints) {
            modelPoint1xBox.Text = modelPoints[0].X.ToString();
            modelPoint1yBox.Text = modelPoints[0].Y.ToString(); 
            modelPoint1zBox.Text = modelPoints[0].Z.ToString();

            modelPoint2xBox.Text = modelPoints[1].X.ToString();
            modelPoint2yBox.Text = modelPoints[1].Y.ToString();
            modelPoint2zBox.Text = modelPoints[1].Z.ToString();

            modelPoint3xBox.Text = modelPoints[2].X.ToString();
            modelPoint3yBox.Text = modelPoints[2].Y.ToString();
            modelPoint3zBox.Text = modelPoints[2].Z.ToString();

            modelPoint4xBox.Text = modelPoints[3].X.ToString();
            modelPoint4yBox.Text = modelPoints[3].Y.ToString();
            modelPoint4zBox.Text = modelPoints[3].Z.ToString();
        
        }
        public void setTransformatinMatrix(Matrix4x4 m)
        {
            estimate00.Text = m.V00.ToString();
            estimate10.Text = m.V01.ToString();
            estimate20.Text = m.V01.ToString();
            estimate30.Text = m.V03.ToString();

            estimate01.Text = m.V10.ToString();
            estimate11.Text = m.V11.ToString();
            estimate21.Text = m.V12.ToString();
            estimate31.Text = m.V13.ToString();

            estimate02.Text = m.V20.ToString();
            estimate12.Text = m.V21.ToString();
            estimate22.Text = m.V22.ToString();
            estimate32.Text = m.V23.ToString();

            estimate03.Text = m.V30.ToString();
            estimate13.Text = m.V31.ToString();
            estimate23.Text = m.V32.ToString();
            estimate33.Text = m.V33.ToString();



        }
        public void setEstymationLabel (float   estimatedYaw, float estimatedPitch, float estimatedRoll)
        {
           estymatainLabel.Text= string.Format("Rotation: \n yaw(y)={0} \n pitch(x)={1} \n roll(z)={2})",
                estimatedYaw, estimatedPitch, estimatedRoll);
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imagePointsGroupBox = new System.Windows.Forms.GroupBox();
            this.imagePoint4ColorLabel = new System.Windows.Forms.Label();
            this.imagePoint3ColorLabel = new System.Windows.Forms.Label();
            this.imagePoint2ColorLabel = new System.Windows.Forms.Label();
            this.imagePoint1ColorLabel = new System.Windows.Forms.Label();
            this.imagePoint4Box = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.imagePoint3Box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.imagePoint2Box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imagePoint1Box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.modelPointsGroupBox = new System.Windows.Forms.GroupBox();
            this.modelPoint4zBox = new System.Windows.Forms.TextBox();
            this.modelPoint4yBox = new System.Windows.Forms.TextBox();
            this.modelPoint4xBox = new System.Windows.Forms.TextBox();
            this.modelPoint3zBox = new System.Windows.Forms.TextBox();
            this.modelPoint3yBox = new System.Windows.Forms.TextBox();
            this.modelPoint3xBox = new System.Windows.Forms.TextBox();
            this.modelPoint2zBox = new System.Windows.Forms.TextBox();
            this.modelPoint2yBox = new System.Windows.Forms.TextBox();
            this.modelPoint2xBox = new System.Windows.Forms.TextBox();
            this.modelPoint1zBox = new System.Windows.Forms.TextBox();
            this.modelPoint1yBox = new System.Windows.Forms.TextBox();
            this.modelPoint1xBox = new System.Windows.Forms.TextBox();
            this.modelPoint4Label = new System.Windows.Forms.Label();
            this.modelPoint1Label = new System.Windows.Forms.Label();
            this.modelPoint3Label = new System.Windows.Forms.Label();
            this.modelPoint2Label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.estimate03 = new System.Windows.Forms.TextBox();
            this.estimate02 = new System.Windows.Forms.TextBox();
            this.estimate01 = new System.Windows.Forms.TextBox();
            this.estimate00 = new System.Windows.Forms.TextBox();
            this.estimate33 = new System.Windows.Forms.TextBox();
            this.estimate23 = new System.Windows.Forms.TextBox();
            this.estimate13 = new System.Windows.Forms.TextBox();
            this.estimate32 = new System.Windows.Forms.TextBox();
            this.estimate22 = new System.Windows.Forms.TextBox();
            this.estimate12 = new System.Windows.Forms.TextBox();
            this.estimate31 = new System.Windows.Forms.TextBox();
            this.estimate21 = new System.Windows.Forms.TextBox();
            this.estimate11 = new System.Windows.Forms.TextBox();
            this.estimate30 = new System.Windows.Forms.TextBox();
            this.estimate20 = new System.Windows.Forms.TextBox();
            this.estimate10 = new System.Windows.Forms.TextBox();
            this.estymatainLabel = new System.Windows.Forms.Label();
            this.imagePointsGroupBox.SuspendLayout();
            this.modelPointsGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imagePointsGroupBox
            // 
            this.imagePointsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.imagePointsGroupBox.Controls.Add(this.imagePoint4ColorLabel);
            this.imagePointsGroupBox.Controls.Add(this.imagePoint3ColorLabel);
            this.imagePointsGroupBox.Controls.Add(this.imagePoint2ColorLabel);
            this.imagePointsGroupBox.Controls.Add(this.imagePoint1ColorLabel);
            this.imagePointsGroupBox.Controls.Add(this.imagePoint4Box);
            this.imagePointsGroupBox.Controls.Add(this.label4);
            this.imagePointsGroupBox.Controls.Add(this.imagePoint3Box);
            this.imagePointsGroupBox.Controls.Add(this.label3);
            this.imagePointsGroupBox.Controls.Add(this.imagePoint2Box);
            this.imagePointsGroupBox.Controls.Add(this.label2);
            this.imagePointsGroupBox.Controls.Add(this.imagePoint1Box);
            this.imagePointsGroupBox.Controls.Add(this.label1);
            this.imagePointsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.imagePointsGroupBox.Name = "imagePointsGroupBox";
            this.imagePointsGroupBox.Size = new System.Drawing.Size(146, 127);
            this.imagePointsGroupBox.TabIndex = 1;
            this.imagePointsGroupBox.TabStop = false;
            this.imagePointsGroupBox.Text = "Image coordinates (x, y)";
            // 
            // imagePoint4ColorLabel
            // 
            this.imagePoint4ColorLabel.BackColor = System.Drawing.Color.Black;
            this.imagePoint4ColorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagePoint4ColorLabel.Location = new System.Drawing.Point(55, 115);
            this.imagePoint4ColorLabel.Name = "imagePoint4ColorLabel";
            this.imagePoint4ColorLabel.Size = new System.Drawing.Size(75, 4);
            this.imagePoint4ColorLabel.TabIndex = 20;
            // 
            // imagePoint3ColorLabel
            // 
            this.imagePoint3ColorLabel.BackColor = System.Drawing.Color.Black;
            this.imagePoint3ColorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagePoint3ColorLabel.Location = new System.Drawing.Point(55, 90);
            this.imagePoint3ColorLabel.Name = "imagePoint3ColorLabel";
            this.imagePoint3ColorLabel.Size = new System.Drawing.Size(75, 4);
            this.imagePoint3ColorLabel.TabIndex = 19;
            // 
            // imagePoint2ColorLabel
            // 
            this.imagePoint2ColorLabel.BackColor = System.Drawing.Color.Black;
            this.imagePoint2ColorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagePoint2ColorLabel.Location = new System.Drawing.Point(55, 65);
            this.imagePoint2ColorLabel.Name = "imagePoint2ColorLabel";
            this.imagePoint2ColorLabel.Size = new System.Drawing.Size(75, 4);
            this.imagePoint2ColorLabel.TabIndex = 18;
            // 
            // imagePoint1ColorLabel
            // 
            this.imagePoint1ColorLabel.BackColor = System.Drawing.Color.Black;
            this.imagePoint1ColorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagePoint1ColorLabel.Location = new System.Drawing.Point(55, 40);
            this.imagePoint1ColorLabel.Name = "imagePoint1ColorLabel";
            this.imagePoint1ColorLabel.Size = new System.Drawing.Size(75, 4);
            this.imagePoint1ColorLabel.TabIndex = 17;
            // 
            // imagePoint4Box
            // 
            this.imagePoint4Box.Location = new System.Drawing.Point(55, 95);
            this.imagePoint4Box.Name = "imagePoint4Box";
            this.imagePoint4Box.ReadOnly = true;
            this.imagePoint4Box.Size = new System.Drawing.Size(75, 20);
            this.imagePoint4Box.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Point 4:";
            // 
            // imagePoint3Box
            // 
            this.imagePoint3Box.Location = new System.Drawing.Point(55, 70);
            this.imagePoint3Box.Name = "imagePoint3Box";
            this.imagePoint3Box.ReadOnly = true;
            this.imagePoint3Box.Size = new System.Drawing.Size(75, 20);
            this.imagePoint3Box.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Point 3:";
            // 
            // imagePoint2Box
            // 
            this.imagePoint2Box.Location = new System.Drawing.Point(55, 45);
            this.imagePoint2Box.Name = "imagePoint2Box";
            this.imagePoint2Box.ReadOnly = true;
            this.imagePoint2Box.Size = new System.Drawing.Size(75, 20);
            this.imagePoint2Box.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Point 2:";
            // 
            // imagePoint1Box
            // 
            this.imagePoint1Box.Location = new System.Drawing.Point(55, 20);
            this.imagePoint1Box.Name = "imagePoint1Box";
            this.imagePoint1Box.ReadOnly = true;
            this.imagePoint1Box.Size = new System.Drawing.Size(75, 20);
            this.imagePoint1Box.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Point 1:";
            // 
            // modelPointsGroupBox
            // 
            this.modelPointsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.modelPointsGroupBox.Controls.Add(this.modelPoint4zBox);
            this.modelPointsGroupBox.Controls.Add(this.modelPoint4yBox);
            this.modelPointsGroupBox.Controls.Add(this.modelPoint4xBox);
            this.modelPointsGroupBox.Controls.Add(this.modelPoint3zBox);
            this.modelPointsGroupBox.Controls.Add(this.modelPoint3yBox);
            this.modelPointsGroupBox.Controls.Add(this.modelPoint3xBox);
            this.modelPointsGroupBox.Controls.Add(this.modelPoint2zBox);
            this.modelPointsGroupBox.Controls.Add(this.modelPoint2yBox);
            this.modelPointsGroupBox.Controls.Add(this.modelPoint2xBox);
            this.modelPointsGroupBox.Controls.Add(this.modelPoint1zBox);
            this.modelPointsGroupBox.Controls.Add(this.modelPoint1yBox);
            this.modelPointsGroupBox.Controls.Add(this.modelPoint1xBox);
            this.modelPointsGroupBox.Controls.Add(this.modelPoint4Label);
            this.modelPointsGroupBox.Controls.Add(this.modelPoint1Label);
            this.modelPointsGroupBox.Controls.Add(this.modelPoint3Label);
            this.modelPointsGroupBox.Controls.Add(this.modelPoint2Label);
            this.modelPointsGroupBox.Location = new System.Drawing.Point(164, 12);
            this.modelPointsGroupBox.Name = "modelPointsGroupBox";
            this.modelPointsGroupBox.Size = new System.Drawing.Size(270, 127);
            this.modelPointsGroupBox.TabIndex = 2;
            this.modelPointsGroupBox.TabStop = false;
            this.modelPointsGroupBox.Text = "Model coordinates (x, y, z)";
            // 
            // modelPoint4zBox
            // 
            this.modelPoint4zBox.Location = new System.Drawing.Point(200, 95);
            this.modelPoint4zBox.Name = "modelPoint4zBox";
            this.modelPoint4zBox.Size = new System.Drawing.Size(60, 20);
            this.modelPoint4zBox.TabIndex = 15;
            this.modelPoint4zBox.Tag = "32";
            // 
            // modelPoint4yBox
            // 
            this.modelPoint4yBox.Location = new System.Drawing.Point(135, 95);
            this.modelPoint4yBox.Name = "modelPoint4yBox";
            this.modelPoint4yBox.Size = new System.Drawing.Size(60, 20);
            this.modelPoint4yBox.TabIndex = 14;
            this.modelPoint4yBox.Tag = "31";
            // 
            // modelPoint4xBox
            // 
            this.modelPoint4xBox.Location = new System.Drawing.Point(70, 95);
            this.modelPoint4xBox.Name = "modelPoint4xBox";
            this.modelPoint4xBox.Size = new System.Drawing.Size(60, 20);
            this.modelPoint4xBox.TabIndex = 13;
            this.modelPoint4xBox.Tag = "30";
            // 
            // modelPoint3zBox
            // 
            this.modelPoint3zBox.Location = new System.Drawing.Point(200, 70);
            this.modelPoint3zBox.Name = "modelPoint3zBox";
            this.modelPoint3zBox.Size = new System.Drawing.Size(60, 20);
            this.modelPoint3zBox.TabIndex = 11;
            this.modelPoint3zBox.Tag = "22";
            // 
            // modelPoint3yBox
            // 
            this.modelPoint3yBox.Location = new System.Drawing.Point(135, 70);
            this.modelPoint3yBox.Name = "modelPoint3yBox";
            this.modelPoint3yBox.Size = new System.Drawing.Size(60, 20);
            this.modelPoint3yBox.TabIndex = 10;
            this.modelPoint3yBox.Tag = "21";
            // 
            // modelPoint3xBox
            // 
            this.modelPoint3xBox.Location = new System.Drawing.Point(70, 70);
            this.modelPoint3xBox.Name = "modelPoint3xBox";
            this.modelPoint3xBox.Size = new System.Drawing.Size(60, 20);
            this.modelPoint3xBox.TabIndex = 9;
            this.modelPoint3xBox.Tag = "20";
            // 
            // modelPoint2zBox
            // 
            this.modelPoint2zBox.Location = new System.Drawing.Point(200, 45);
            this.modelPoint2zBox.Name = "modelPoint2zBox";
            this.modelPoint2zBox.Size = new System.Drawing.Size(60, 20);
            this.modelPoint2zBox.TabIndex = 7;
            this.modelPoint2zBox.Tag = "12";
            // 
            // modelPoint2yBox
            // 
            this.modelPoint2yBox.Location = new System.Drawing.Point(135, 45);
            this.modelPoint2yBox.Name = "modelPoint2yBox";
            this.modelPoint2yBox.Size = new System.Drawing.Size(60, 20);
            this.modelPoint2yBox.TabIndex = 6;
            this.modelPoint2yBox.Tag = "11";
            // 
            // modelPoint2xBox
            // 
            this.modelPoint2xBox.Location = new System.Drawing.Point(70, 45);
            this.modelPoint2xBox.Name = "modelPoint2xBox";
            this.modelPoint2xBox.Size = new System.Drawing.Size(60, 20);
            this.modelPoint2xBox.TabIndex = 5;
            this.modelPoint2xBox.Tag = "10";
            // 
            // modelPoint1zBox
            // 
            this.modelPoint1zBox.Location = new System.Drawing.Point(200, 20);
            this.modelPoint1zBox.Name = "modelPoint1zBox";
            this.modelPoint1zBox.Size = new System.Drawing.Size(60, 20);
            this.modelPoint1zBox.TabIndex = 3;
            this.modelPoint1zBox.Tag = "2";
            // 
            // modelPoint1yBox
            // 
            this.modelPoint1yBox.Location = new System.Drawing.Point(135, 20);
            this.modelPoint1yBox.Name = "modelPoint1yBox";
            this.modelPoint1yBox.Size = new System.Drawing.Size(60, 20);
            this.modelPoint1yBox.TabIndex = 2;
            this.modelPoint1yBox.Tag = "1";
            // 
            // modelPoint1xBox
            // 
            this.modelPoint1xBox.Location = new System.Drawing.Point(70, 20);
            this.modelPoint1xBox.Name = "modelPoint1xBox";
            this.modelPoint1xBox.Size = new System.Drawing.Size(60, 20);
            this.modelPoint1xBox.TabIndex = 1;
            this.modelPoint1xBox.Tag = "0";
            // 
            // modelPoint4Label
            // 
            this.modelPoint4Label.AutoSize = true;
            this.modelPoint4Label.Location = new System.Drawing.Point(10, 98);
            this.modelPoint4Label.Name = "modelPoint4Label";
            this.modelPoint4Label.Size = new System.Drawing.Size(43, 13);
            this.modelPoint4Label.TabIndex = 12;
            this.modelPoint4Label.Text = "Point 4:";
            // 
            // modelPoint1Label
            // 
            this.modelPoint1Label.AutoSize = true;
            this.modelPoint1Label.Location = new System.Drawing.Point(10, 23);
            this.modelPoint1Label.Name = "modelPoint1Label";
            this.modelPoint1Label.Size = new System.Drawing.Size(43, 13);
            this.modelPoint1Label.TabIndex = 0;
            this.modelPoint1Label.Text = "Point 1:";
            // 
            // modelPoint3Label
            // 
            this.modelPoint3Label.AutoSize = true;
            this.modelPoint3Label.Location = new System.Drawing.Point(10, 73);
            this.modelPoint3Label.Name = "modelPoint3Label";
            this.modelPoint3Label.Size = new System.Drawing.Size(43, 13);
            this.modelPoint3Label.TabIndex = 8;
            this.modelPoint3Label.Text = "Point 3:";
            // 
            // modelPoint2Label
            // 
            this.modelPoint2Label.AutoSize = true;
            this.modelPoint2Label.Location = new System.Drawing.Point(10, 48);
            this.modelPoint2Label.Name = "modelPoint2Label";
            this.modelPoint2Label.Size = new System.Drawing.Size(43, 13);
            this.modelPoint2Label.TabIndex = 4;
            this.modelPoint2Label.Text = "Point 2:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(440, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(65, 85);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Legend";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.Lime;
            this.label7.Location = new System.Drawing.Point(10, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Z axis";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(10, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Y axis";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(10, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "X axis";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.estimate03);
            this.groupBox2.Controls.Add(this.estimate02);
            this.groupBox2.Controls.Add(this.estimate01);
            this.groupBox2.Controls.Add(this.estimate00);
            this.groupBox2.Controls.Add(this.estimate33);
            this.groupBox2.Controls.Add(this.estimate23);
            this.groupBox2.Controls.Add(this.estimate13);
            this.groupBox2.Controls.Add(this.estimate32);
            this.groupBox2.Controls.Add(this.estimate22);
            this.groupBox2.Controls.Add(this.estimate12);
            this.groupBox2.Controls.Add(this.estimate31);
            this.groupBox2.Controls.Add(this.estimate21);
            this.groupBox2.Controls.Add(this.estimate11);
            this.groupBox2.Controls.Add(this.estimate30);
            this.groupBox2.Controls.Add(this.estimate20);
            this.groupBox2.Controls.Add(this.estimate10);
            this.groupBox2.Location = new System.Drawing.Point(12, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 127);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Estimated transformation";
            // 
            // estimate03
            // 
            this.estimate03.Location = new System.Drawing.Point(4, 95);
            this.estimate03.Name = "estimate03";
            this.estimate03.Size = new System.Drawing.Size(60, 20);
            this.estimate03.TabIndex = 18;
            this.estimate03.Tag = "0";
            // 
            // estimate02
            // 
            this.estimate02.Location = new System.Drawing.Point(4, 71);
            this.estimate02.Name = "estimate02";
            this.estimate02.Size = new System.Drawing.Size(60, 20);
            this.estimate02.TabIndex = 17;
            this.estimate02.Tag = "0";
            // 
            // estimate01
            // 
            this.estimate01.Location = new System.Drawing.Point(4, 45);
            this.estimate01.Name = "estimate01";
            this.estimate01.Size = new System.Drawing.Size(60, 20);
            this.estimate01.TabIndex = 16;
            this.estimate01.Tag = "0";
            // 
            // estimate00
            // 
            this.estimate00.Location = new System.Drawing.Point(4, 20);
            this.estimate00.Name = "estimate00";
            this.estimate00.Size = new System.Drawing.Size(60, 20);
            this.estimate00.TabIndex = 5;
            this.estimate00.Tag = "0";
            // 
            // estimate33
            // 
            this.estimate33.Location = new System.Drawing.Point(200, 95);
            this.estimate33.Name = "estimate33";
            this.estimate33.Size = new System.Drawing.Size(60, 20);
            this.estimate33.TabIndex = 15;
            this.estimate33.Tag = "32";
            // 
            // estimate23
            // 
            this.estimate23.Location = new System.Drawing.Point(135, 95);
            this.estimate23.Name = "estimate23";
            this.estimate23.Size = new System.Drawing.Size(60, 20);
            this.estimate23.TabIndex = 14;
            this.estimate23.Tag = "31";
            // 
            // estimate13
            // 
            this.estimate13.Location = new System.Drawing.Point(70, 95);
            this.estimate13.Name = "estimate13";
            this.estimate13.Size = new System.Drawing.Size(60, 20);
            this.estimate13.TabIndex = 13;
            this.estimate13.Tag = "30";
            // 
            // estimate32
            // 
            this.estimate32.Location = new System.Drawing.Point(200, 70);
            this.estimate32.Name = "estimate32";
            this.estimate32.Size = new System.Drawing.Size(60, 20);
            this.estimate32.TabIndex = 11;
            this.estimate32.Tag = "22";
            // 
            // estimate22
            // 
            this.estimate22.Location = new System.Drawing.Point(135, 70);
            this.estimate22.Name = "estimate22";
            this.estimate22.Size = new System.Drawing.Size(60, 20);
            this.estimate22.TabIndex = 10;
            this.estimate22.Tag = "21";
            // 
            // estimate12
            // 
            this.estimate12.Location = new System.Drawing.Point(70, 70);
            this.estimate12.Name = "estimate12";
            this.estimate12.Size = new System.Drawing.Size(60, 20);
            this.estimate12.TabIndex = 9;
            this.estimate12.Tag = "20";
            // 
            // estimate31
            // 
            this.estimate31.Location = new System.Drawing.Point(200, 45);
            this.estimate31.Name = "estimate31";
            this.estimate31.Size = new System.Drawing.Size(60, 20);
            this.estimate31.TabIndex = 7;
            this.estimate31.Tag = "12";
            // 
            // estimate21
            // 
            this.estimate21.Location = new System.Drawing.Point(135, 45);
            this.estimate21.Name = "estimate21";
            this.estimate21.Size = new System.Drawing.Size(60, 20);
            this.estimate21.TabIndex = 6;
            this.estimate21.Tag = "11";
            // 
            // estimate11
            // 
            this.estimate11.Location = new System.Drawing.Point(70, 45);
            this.estimate11.Name = "estimate11";
            this.estimate11.Size = new System.Drawing.Size(60, 20);
            this.estimate11.TabIndex = 5;
            this.estimate11.Tag = "10";
            // 
            // estimate30
            // 
            this.estimate30.Location = new System.Drawing.Point(200, 20);
            this.estimate30.Name = "estimate30";
            this.estimate30.Size = new System.Drawing.Size(60, 20);
            this.estimate30.TabIndex = 3;
            this.estimate30.Tag = "2";
            // 
            // estimate20
            // 
            this.estimate20.Location = new System.Drawing.Point(135, 20);
            this.estimate20.Name = "estimate20";
            this.estimate20.Size = new System.Drawing.Size(60, 20);
            this.estimate20.TabIndex = 2;
            this.estimate20.Tag = "1";
            // 
            // estimate10
            // 
            this.estimate10.Location = new System.Drawing.Point(70, 20);
            this.estimate10.Name = "estimate10";
            this.estimate10.Size = new System.Drawing.Size(60, 20);
            this.estimate10.TabIndex = 1;
            this.estimate10.Tag = "0";
            // 
            // estymatainLabel
            // 
            this.estymatainLabel.AutoSize = true;
            this.estymatainLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.estymatainLabel.Location = new System.Drawing.Point(278, 165);
            this.estymatainLabel.Name = "estymatainLabel";
            this.estymatainLabel.Size = new System.Drawing.Size(80, 13);
            this.estymatainLabel.TabIndex = 5;
            this.estymatainLabel.Text = "estimationLabel";
            // 
            // FormInfoPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 369);
            this.Controls.Add(this.estymatainLabel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.modelPointsGroupBox);
            this.Controls.Add(this.imagePointsGroupBox);
            this.Name = "FormInfoPosition";
            this.Text = "wor";
            this.imagePointsGroupBox.ResumeLayout(false);
            this.imagePointsGroupBox.PerformLayout();
            this.modelPointsGroupBox.ResumeLayout(false);
            this.modelPointsGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox imagePointsGroupBox;
        private System.Windows.Forms.Label imagePoint4ColorLabel;
        private System.Windows.Forms.Label imagePoint3ColorLabel;
        private System.Windows.Forms.Label imagePoint2ColorLabel;
        private System.Windows.Forms.Label imagePoint1ColorLabel;
        private System.Windows.Forms.TextBox imagePoint4Box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox imagePoint3Box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox imagePoint2Box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox imagePoint1Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox modelPointsGroupBox;
        private System.Windows.Forms.TextBox modelPoint4zBox;
        private System.Windows.Forms.TextBox modelPoint4yBox;
        private System.Windows.Forms.TextBox modelPoint4xBox;
        private System.Windows.Forms.TextBox modelPoint3zBox;
        private System.Windows.Forms.TextBox modelPoint3yBox;
        private System.Windows.Forms.TextBox modelPoint3xBox;
        private System.Windows.Forms.TextBox modelPoint2zBox;
        private System.Windows.Forms.TextBox modelPoint2yBox;
        private System.Windows.Forms.TextBox modelPoint2xBox;
        private System.Windows.Forms.TextBox modelPoint1zBox;
        private System.Windows.Forms.TextBox modelPoint1yBox;
        private System.Windows.Forms.TextBox modelPoint1xBox;
        private System.Windows.Forms.Label modelPoint4Label;
        private System.Windows.Forms.Label modelPoint1Label;
        private System.Windows.Forms.Label modelPoint3Label;
        private System.Windows.Forms.Label modelPoint2Label;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox estimate33;
        private System.Windows.Forms.TextBox estimate23;
        private System.Windows.Forms.TextBox estimate13;
        private System.Windows.Forms.TextBox estimate32;
        private System.Windows.Forms.TextBox estimate22;
        private System.Windows.Forms.TextBox estimate12;
        private System.Windows.Forms.TextBox estimate31;
        private System.Windows.Forms.TextBox estimate21;
        private System.Windows.Forms.TextBox estimate11;
        private System.Windows.Forms.TextBox estimate30;
        private System.Windows.Forms.TextBox estimate20;
        private System.Windows.Forms.TextBox estimate10;
        private System.Windows.Forms.TextBox estimate03;
        private System.Windows.Forms.TextBox estimate02;
        private System.Windows.Forms.TextBox estimate01;
        private System.Windows.Forms.TextBox estimate00;
        private System.Windows.Forms.Label estymatainLabel;
    }
}