using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ART1Paint
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			ART1PaintForm mainForm = BuildMainForm();
			Application.Run(mainForm);
		}

		private static ART1PaintForm BuildMainForm()
		{
			ART1PaintForm mainForm = new ART1PaintForm();

			PatternInputTranslator translator = new PatternInputTranslator(mainForm);
			PatternInputProcessor processor = new PatternInputProcessor(translator);
			PatternInputPresenter presenter = new PatternInputPresenter(processor);
			presenter.Renew(50, 50, 0.7f);
			OpenFileDialog openDialog = new OpenFileDialog();
			new ART1PaintPresenter(mainForm, presenter, openDialog);

			return mainForm;
		}
	}
}
