using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Pikto.ViewModel.WizardViewModel;
using System.Windows.Input;

namespace Pikto.View.ViewManager.ViewWizardManager
{
	abstract class ViewTypeWizardManager<V, VM> : ViewTypeManager<V> where V : FrameworkElement where VM : WizardBaseViewModel
	{
		private IDictionary<object, V> stepsMap;
		private WizardNavigationViewModel<VM> navigationViewModel;

		protected Action<string> refreshStepAction;
		protected ICommand cancelCmd;

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
				var view = CreateView(parameter);
				view.Loaded += view_Loaded;
				view.Unloaded += view_Unloaded;
				stepsMap.Add(parameter, view);
			}
			return stepsMap[parameter];
		}

		private void view_Loaded(object sender, RoutedEventArgs e)
		{
			navigationViewModel.Loaded();
		}

		void view_Unloaded(object sender, RoutedEventArgs e)
		{
			navigationViewModel.Unloaded();
		}

		protected abstract V CreateView(object parameter);
		protected abstract WizardNavigationViewModel<VM> CreateViewModel();

		public virtual void Loaded() { }
	}
}
