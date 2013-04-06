using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ART1Paint
{
	class ART1PaintPresenter
	{
		private const int PATTERN_SIZE = 50;

		private IMainForm mainForm;
		private PatternInputPresenter patternInputPresenter;
		private OpenFileDialog openDialog;

		public ART1PaintPresenter(IMainForm mainForm, PatternInputPresenter patternInputPresenter, OpenFileDialog openDialog)
		{
			this.mainForm = mainForm;
			this.patternInputPresenter = patternInputPresenter;
			this.openDialog = openDialog;

			patternInputPresenter.PatternPresented += new EventHandler<PatternEventArgs>(patternInputPresenter_PatternPresented);
			mainForm.NewClicked += new EventHandler(mainForm_NewClicked);
			mainForm.ClearClicked += new EventHandler(mainForm_ClearClicked);
			mainForm.LoadClicked += new EventHandler(mainForm_LoadClicked);
		}

		private void patternInputPresenter_PatternPresented(object sender, PatternEventArgs e)
		{
			mainForm.SelectCluster(e.Cluster, e.Pattern);
		}

		private void mainForm_NewClicked(object sender, EventArgs e)
		{
			patternInputPresenter.Renew(PATTERN_SIZE, PATTERN_SIZE, mainForm.Vigilance);
			mainForm.ClearRememberedPatterns();
		}

		private void mainForm_ClearClicked(object sender, EventArgs e)
		{
			patternInputPresenter.ClearPattern();
		}

		private void mainForm_LoadClicked(object sender, EventArgs e)
		{
			if (openDialog.ShowDialog() == DialogResult.OK)
			{
				Bitmap bitmap = Bitmap.FromFile(openDialog.FileName) as Bitmap;
				if (bitmap.Width == PATTERN_SIZE && bitmap.Height == PATTERN_SIZE)
				{
					UnsafeBitmap fastBitmap = new UnsafeBitmap(bitmap);
					Pattern pattern = new Pattern(PATTERN_SIZE, PATTERN_SIZE);
					fastBitmap.LockBitmap();
					for (int j = 0; j < PATTERN_SIZE; ++j)
					{
						for (int i = 0; i < PATTERN_SIZE; ++i)
						{
							PixelData colour = fastBitmap.GetPixel(i, j);
							pattern[i, j] = colour.GetBrightness() > 0.5f ? PointColour.White : PointColour.Black;
						}
					}
					fastBitmap.UnlockBitmap();
					patternInputPresenter.LoadPattern(pattern);
				}
			}
		}
	}
}
