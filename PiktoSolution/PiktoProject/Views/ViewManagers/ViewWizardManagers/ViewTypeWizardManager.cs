using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Pikto.Views
{
	abstract class ViewTypeWizardManager<V> : ViewTypeManager<V> where V : UIElement
	{
		protected IDictionary<object, V> stepsMap;
		protected Action<string> refreshStepAction;

		public ViewTypeWizardManager(Action<string> refreshStepAction)
		{
			this.refreshStepAction = refreshStepAction;
			stepsMap = new Dictionary<object, V>();
		}

		public V GetView(object parameter)
		{
			if (parameter == null)
			{
				parameter = "";
			}
			if (!stepsMap.ContainsKey(parameter))
			{
				var v = Create(parameter);
				stepsMap.Add(parameter, v);
			}
			return stepsMap[parameter];
		}

		protected abstract V Create(object parameter);

		public virtual void Reset() { }
	}
}
