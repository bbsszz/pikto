using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;
using Pikto.ViewModel;
using System.Windows.Input;

namespace Pikto.Views
{
	[ValueConversion(typeof(ViewType), typeof(UIElement))]
	class ViewTypeToUIElementConverter : IValueConverter
	{
		IDictionary<ViewType, ViewTypeManager<UIElement>> mapping;

		public ViewTypeToUIElementConverter(IDictionary<ViewType, ViewTypeManager<UIElement>> mapping)
		{
			this.mapping = mapping;
		}

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			ViewType viewType = (ViewType)value;
			return mapping[viewType].GetView(parameter);
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException("Should not be used.");
		}
	}
}
