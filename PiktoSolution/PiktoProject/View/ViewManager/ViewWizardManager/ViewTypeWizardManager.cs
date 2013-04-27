using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Pikto.ViewModel.WizardViewModel;
using System.Windows.Input;

namespace Pikto.View.ViewManager.ViewWizardManager
{
	abstract class ViewTypeWizardManager<V, VM> : ViewTypeManager<V> where V : UIElement where VM : WizardBaseViewModel
	{
		protected IDictionary<object, V> stepsMap;
		protected Action<string> refreshStepAction;
		protected ICommand cancelCmd;

		private WizardNavigationViewModel<VM> navigationViewModel;

		protected WizardNavigationViewModel<VM> NavigationViewModel
		{
			get
			{
				if (navigationViewModel == null)
				{
					navigationViewModel = CreateViewModel();
				}
				return navigationViewModel;
			}
		}

		public ViewTypeWizardManager(Action<string> refreshStepAction, ICommand cancelCmd)
		{
			this.refreshStepAction = refreshStepAction;
			this.cancelCmd = cancelCmd;
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
				var v = CreateView(parameter);
				stepsMap.Add(parameter, v);
			}
			return stepsMap[parameter];
		}

		protected abstract V CreateView(object parameter);
		protected abstract WizardNavigationViewModel<VM> CreateViewModel();

		public virtual void Reset() { }
	}
}
