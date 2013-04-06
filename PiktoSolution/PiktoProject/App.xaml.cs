using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Pikto.Utils;
using Pikto.ViewModel.Commands;
using Pikto.Views;
using Pikto.ViewModel;

namespace Pikto
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		private void Application_Startup(object sender, StartupEventArgs e)
		{
			BuildApplication();
		}

		private void BuildApplication()
		{

			var contentManagementService = new ContentManagementService();
			contentManagementService.LoadMainPage = new Command(p => { });

			var mapping = PrepareMapping();
			var viewTypeConverter = new ViewTypeToUIElementConverter(mapping);
			Application.Current.Resources.Add("viewTypeConverter", viewTypeConverter);

			var mainViewModel = new MainViewModel();
			mainViewModel.PrimaryViewType = ViewType.MainPage;
			mainViewModel.SecondaryViewType = ViewType.Test;

			var mainView = new MainView();
			mainView.DataContext = mainViewModel;

			mainView.Show();
		}

		private IDictionary<ViewType, ViewTypeManager<UIElement>> PrepareMapping()
		{
			var mapping = new Dictionary<ViewType, ViewTypeManager<UIElement>>();

			mapping.Add(ViewType.Default, new ViewTypeDefaultManager());
			mapping.Add(ViewType.Test, new ViewTypeTestManager());
			mapping.Add(ViewType.MainPage, new ViewTypeMainPageManager(null, null, null, new Command(p => Application.Current.Shutdown())));

			return mapping;
		}
	}
}
