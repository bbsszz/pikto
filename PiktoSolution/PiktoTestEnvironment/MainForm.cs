using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pikto.RecognitionPath;
using Compression;
using Pikto.RecognitionPath.DiscretizationModule;

namespace PiktoTestEnvironment
{
	public partial class MainForm : Form
	{
		private ArrayImage inputImage;

		private IDiscretizer discretizer;

		private UnsafeBitmap inputBitmap;
		private Graphics inputGraphics;

		private UnsafeBitmap outputBitmap;
		private Graphics outputGraphics;

		private float scale;

		float inputScaleSquare;
		float outputScaleSquare;

		public MainForm()
		{
			InitializeComponent();
			PrepareViews();
			ChangeInput();
			ChangeOutput();
		}

		private void PrepareViews()
		{
			inputBitmap = new UnsafeBitmap(pInput.Width, pInput.Height);
			inputGraphics = Graphics.FromImage(inputBitmap.Bitmap);
			outputBitmap = new UnsafeBitmap(pOutput.Width, pOutput.Height);
			outputGraphics = Graphics.FromImage(outputBitmap.Bitmap);
		}

		private void ChangeInput()
		{
			ChangeInputImage();
		}

		private void ChangeInputImage()
		{
			int inputSize = (int)nInputSize.Value;
			ComputeInputScaleSquare();
			inputImage = new ArrayImage(inputSize);
			inputGraphics.Clear(Color.Black);
			RefreshInputView();
			UpdateScale();
		}

		private void ComputeInputScaleSquare()
		{
			inputScaleSquare = (float)pInput.Width / (float)nInputSize.Value;
		}

		private void ChangeOutput()
		{
			ChangeOutputImage();
			ChangeDiscretizationModule();
		}

		private void ChangeDiscretizationModule()
		{
			int outputSize = (int)nOutputSize.Value;
			discretizer = new DiscretizationModule(outputSize);
		}

		private void ChangeOutputImage()
		{
			int outputSize = (int)nOutputSize.Value;
			outputScaleSquare = (float)pOutput.Width / (float)nOutputSize.Value;
			outputGraphics.Clear(Color.Black);
			RefreshOutputView();
			UpdateScale();
		}

		private void RefreshView()
		{
			RefreshInputView();
			RefreshOutputView();
		}

		private void RefreshInputView()
		{
			pInput.Image = inputBitmap.Bitmap;
			pInput.Refresh();
		}

		private void RefreshOutputView()
		{
			pOutput.Image = outputBitmap.Bitmap;
			pOutput.Refresh();
		}

		private void UpdateScale()
		{
			float scale = (float)nInputSize.Value / (float)nOutputSize.Value;
		}

		private void pInput_MouseClick(object sender, MouseEventArgs e)
		{
			int cx = (int)((float)e.X / inputScaleSquare);
			int cy = (int)((float)e.Y / inputScaleSquare);
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				inputImage[cx, cy] = PixelMonoColorEnum.Black;
				inputGraphics.FillRectangle(Brushes.Black, (float)cx * inputScaleSquare, (float)cy * inputScaleSquare, inputScaleSquare, inputScaleSquare);
			}
			else
			{
				inputImage[cx, cy] = PixelMonoColorEnum.White;
				inputGraphics.FillRectangle(Brushes.White, (float)cx * inputScaleSquare, (float)cy * inputScaleSquare, inputScaleSquare, inputScaleSquare);
			}
			RefreshInputView();
		}

		private void bInputOK_Click(object sender, EventArgs e)
		{
			ChangeInput();
		}

		private void bOutputOK_Click(object sender, EventArgs e)
		{
			ChangeOutput();
		}

		private void bGo_Click(object sender, EventArgs e)
		{
			var output = discretizer.Discretize(inputImage);
			int outputSize = (int)nOutputSize.Value;
			outputGraphics.Clear(Color.Black);
			for (int y = 0; y < outputSize; ++y)
			{
				for (int x = 0; x < outputSize; ++x)
				{
					if (output[x, y] == 1)
					{
						outputGraphics.FillRectangle(Brushes.White, (float)x * outputScaleSquare, (float)y * outputScaleSquare, outputScaleSquare, outputScaleSquare);
					}
				}
			}
			RefreshOutputView();
		}

		private void bLoad_Click(object sender, EventArgs e)
		{
			if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				Bitmap bitmap = (Bitmap)Bitmap.FromFile(openDialog.FileName);
				LoadInputView(bitmap);
				RefreshInputView();
			}
		}

		private void LoadInputView(Bitmap bitmap)
		{
			int inSize = bitmap.Width;
			nInputSize.Value = inSize;
			ComputeInputScaleSquare();
			inputImage = new ArrayImage(inSize);
			UnsafeBitmap bmp = new UnsafeBitmap(bitmap);
			inputGraphics.Clear(Color.Black);
			bmp.LockBitmap();
			for (int y = 0; y < inSize; ++y)
			{
				for (int x = 0; x < inSize; ++x)
				{
					if (bmp.GetPixel(x, y).red < 50)
					{
						inputImage[x, y] = PixelMonoColorEnum.Black;
						inputGraphics.FillRectangle(Brushes.Black, (float)x * inputScaleSquare, (float)y * inputScaleSquare, inputScaleSquare, inputScaleSquare);
					}
					else
					{
						inputImage[x, y] = PixelMonoColorEnum.White;
						inputGraphics.FillRectangle(Brushes.White, (float)x * inputScaleSquare, (float)y * inputScaleSquare, inputScaleSquare, inputScaleSquare);
					}
				}
			}
			bmp.UnlockBitmap();
		}
	}
}
