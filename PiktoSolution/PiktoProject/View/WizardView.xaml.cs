﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pikto.View
{
	/// <summary>
	/// Interaction logic for WizardView.xaml
	/// </summary>
	public partial class WizardView : Page, IWizardView
	{
		public WizardView()
		{
			InitializeComponent();
		}

		public object StepContent
		{
			set { stepContent.Content = value; }
		}
	}
}
