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
		private IDictionary<object, object> stepsViewMap;
		private V wizardView;
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

		protected V WizardView
		{
			get { return wizardView; }
		}

		public ViewTypeWizardManager(Action<string> refreshStepAction, ICommand cancelCmd)
		{
			this.refreshStepAction = refreshStepAction;
			this.cancelCmd = cancelCmd;
			stepsViewMap = new Dictionary<object, object>();
		}

		public V GetView(object parameter)
		{
			if (parameter == null)
			{
				parameter = "";
			}
			if (wizardView == null)
			{
				wizardView = CreateWizardView();
				wizardView.Loaded += view_Loaded;
				wizardView.Unloaded += view_Unloaded;
			}
			if (!stepsViewMap.ContainsKey(parameter))
			{
				var view = CreateView(parameter);
				stepsViewMap.Add(parameter, view);
			}
			ChangeStepContent(stepsViewMap[parameter]);
			return wizardView;
		}

		private void view_Loaded(object sender, RoutedEventArgs e)
		{
			navigationViewModel.Loaded();
		}

		void view_Unloaded(object sender, RoutedEventArgs e)
		{
			navigationViewModel.Unloaded();
		}

		protected abstract object CreateView(object parameter);
		protected abstract V CreateWizardView();
		protected abstract void ChangeStepContent(object content);
		protected abstract WizardNavigationViewModel<VM> CreateViewModel();
	}
}
