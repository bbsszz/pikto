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
			var appViewModel = new AppViewModel();

			var contentManagementService = new ContentManagementService(appViewModel);

			var mapping = PrepareMapping(contentManagementService);
			var viewTypeConverter = new ViewTypeToUIElementConverter(mapping);
			Application.Current.Resources.Add("viewTypeConverter", viewTypeConverter);

			var mainView = new AppView();
			mainView.DataContext = appViewModel;

			appViewModel.PrimaryViewType = ViewType.MainPage;
			appViewModel.SecondaryViewType = ViewType.Default;

			mainView.Show();
		}

		private IDictionary<ViewType, ViewTypeManager<UIElement>> PrepareMapping(ContentManagementService contentManagementService)
		{
			var mapping = new Dictionary<ViewType, ViewTypeManager<UIElement>>();

			mapping.Add(ViewType.Default, new ViewTypeDefaultManager());
			mapping.Add(ViewType.Test, new ViewTypeTestManager());
			mapping.Add(ViewType.MainPage, new ViewTypeMainPageManager(new StartLearningPathCommand(), contentManagementService.ShowStartExaminationPathWizardCommand, new SettingsCommand(), contentManagementService.ShowAboutWindowCommand, contentManagementService.CloseApplicationCommand));
			mapping.Add(ViewType.StartExaminationPathWizard, new ViewTypeExaminationPathWizardManager());
			mapping.Add(ViewType.AboutWindow, new ViewTypeAboutManager(contentManagementService.HideSecondaryWindowCommand));

			return mapping;
		}
	}
}
