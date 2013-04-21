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
	class ViewTypeToUIElementConverter : IMultiValueConverter
	{
		IDictionary<ViewType, ViewTypeManager<UIElement>> mapping;

		public ViewTypeToUIElementConverter(IDictionary<ViewType, ViewTypeManager<UIElement>> mapping)
		{
			this.mapping = mapping;
		}

		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			ViewType viewType = (ViewType)values[0];
			return mapping[viewType].GetView(values.Length > 1 ? values[1] : null);
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException("Should not be used.");
		}
	}
}
