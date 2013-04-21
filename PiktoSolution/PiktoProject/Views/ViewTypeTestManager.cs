﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Pikto.ViewModel;
using Pikto.ViewModel.Commands;

namespace Pikto.Views
{
	class ViewTypeTestManager : ViewTypeManager<UIElement>
	{
		public UIElement GetView(object parameter)
		{
			/*var viewModel = new ExaminationPathSourceViewModel();

			var content = new WizardView();
			var innerContent = new ExaminationPathSource();
			content.stepContent.Content = innerContent;
			innerContent.DataContext = viewModel;*/

			var vm = new AboutViewModel(new Command(p => {}));
			var v = new AboutView();
			v.DataContext = vm;

			return v;
		}
	}
}
