using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ART1Paint
{
	public partial class ART1PaintForm : Form, IMainForm, IPatternInput
	{
		private Graphics patternGraphics;

		public ART1PaintForm()
		{
			InitializeComponent();
			InitializeForm();
		}

		private void InitializeForm()
		{
			Bitmap patternBitmap = new Bitmap(pbInput.Width, pbInput.Height);
			patternGraphics = Graphics.FromImage(patternBitmap);
			pbInput.Image = patternBitmap;
			pbInput.Refresh();
		}

		public event MouseEventHandler PatternMouseDown
		{
			add { pbInput.MouseDown += value; }
			remove { pbInput.MouseDown -= value; }
		}

		public event MouseEventHandler PatternMouseUp
		{
			add { pbInput.MouseUp += value; }
			remove { pbInput.MouseUp -= value; }
		}

		public event MouseEventHandler PatternMouseMove
		{
			add { pbInput.MouseMove += value; }
			remove { pbInput.MouseMove -= value; }
		}

		public event EventHandler PresentClicked
		{
			add { bPresent.Click += value; }
			remove { bPresent.Click -= value; }
		}

		public SizeF InputSize
		{
			get { return pbInput.Size; }
		}

		public void DrawRectangle(PointColour colour, float x, float y, float width, float height)
		{
			patternGraphics.FillRectangle(colour == PointColour.Black ? Brushes.Black : Brushes.White, x, y, width, height);
			//pbInput.Refresh(); // too slow
		}

		public void Clear(PointColour colour)
		{
			patternGraphics.Clear(colour == PointColour.Black ? Color.Black : Color.White);
			pbInput.Refresh();
		}

		public void RefreshView()
		{
			pbInput.Refresh();
		}

		public event EventHandler NewClicked
		{
			add { bNew.Click += value; }
			remove { bNew.Click += value; }
		}

		public event EventHandler ClearClicked
		{
			add { bClear.Click += value; }
			remove { bClear.Click -= value; }
		}

		public event EventHandler LoadClicked
		{
			add { bLoad.Click += value; }
			remove { bLoad.Click -= value; }
		}

		public float Vigilance
		{
			get { return (float)nVigilance.Value; }
		}


		public int ClustersCount
		{
			get { return pClusters.Controls.Count; }
		}

		public void SelectCluster(int cluster, Pattern pattern)
		{
			if (cluster >= ClustersCount)
			{
				AddNewCluster(pattern);
			}
			else
			{
				SelectExistingCluster(cluster);
			}
		}

		private void AddNewCluster(Pattern pattern)
		{
			UnsafeBitmap bitmap = new UnsafeBitmap(pattern.Size.Width, pattern.Size.Height);
			PixelData black = new PixelData() { red = 0, green = 0, blue = 0 };
			PixelData white = new PixelData() { red = 255, green = 255, blue = 255 };
			bitmap.LockBitmap();
			for (int j = 0; j < pattern.Size.Height; ++j)
			{
				for (int i = 0; i < pattern.Size.Width; ++i)
				{
					bitmap.SetPixel(i, j, pattern[i, j] == PointColour.Black ? black : white);
				}
			}
			bitmap.UnlockBitmap();
			PictureBox newCluster = new PictureBox();
			newCluster.Image = bitmap.Bitmap;
			newCluster.Refresh();
			pClusters.Controls.Add(newCluster);
			pbWinner.Image = bitmap.Bitmap;
			pbWinner.Refresh();
		}

		private void SelectExistingCluster(int cluster)
		{
			PictureBox component = pClusters.Controls[cluster] as PictureBox;
			pbWinner.Image = component.Image;
			pbWinner.Refresh();
		}


		public void ClearRememberedPatterns()
		{
			pClusters.Controls.Clear();
			pbWinner.Image = null;
			pbWinner.Refresh();
		}
	}
}
