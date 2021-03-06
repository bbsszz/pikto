﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;
using System.Windows.Input;
using Pikto.View.ViewManager;

namespace Pikto.View
{
	[ValueConversion(typeof(ViewType), typeof(FrameworkElement))]
	class ViewTypeToUIElementConverter : IMultiValueConverter
	{
		IDictionary<ViewType, ViewTypeManager<FrameworkElement>> mapping;

		public ViewTypeToUIElementConverter(IDictionary<ViewType, ViewTypeManager<FrameworkElement>> mapping)
		{
			this.mapping = mapping;
		}

		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			switch (parameter as string)
			{
				case "Primary":
				{
					var viewType = (ViewType)values[0];
					var manager = mapping[viewType];
					return manager.GetView("");
				}

				case "Secondary":
				{
					var viewType = (ViewType)values[0];
					var manager = mapping[viewType];
					return manager.GetView(values[1]);
				}

				default:
				{
					throw new NotSupportedException("Container not supported.");
				}
			}
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException("This method should not be used.");
		}
	}
}
