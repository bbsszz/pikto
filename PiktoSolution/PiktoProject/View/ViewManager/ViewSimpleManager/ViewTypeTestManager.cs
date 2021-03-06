﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Pikto.ViewModel.SimpleViewModel;
using Pikto.Command;

namespace Pikto.View.ViewManager.ViewSimpleManager
{
	class ViewTypeTestManager : ViewTypeManager<FrameworkElement>
	{
		public FrameworkElement GetView(object parameter)
		{
			/*var viewModel = new ExaminationPathSourceViewModel();

			var content = new WizardView();
			var innerContent = new ExaminationPathSource();
			content.stepContent.Content = innerContent;
			innerContent.DataContext = viewModel;*/

			var vm = new AboutViewModel(new BasicCommand(p => {}));
			var v = new AboutView();
			v.DataContext = vm;

			return v;
		}

		public void Loaded() { }
	}
}
