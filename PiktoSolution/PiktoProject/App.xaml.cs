using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Pikto.ViewModel.SimpleViewModel;
using Pikto.Utils;
using Pikto.View;
using Pikto.View.ViewManager;
using Pikto.View.ViewManager.ViewSimpleManager;
using Pikto.View.ViewManager.ViewWizardManager;
using Pikto.ViewModel;
using Pikto.Database;

namespace Pikto
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		private AppView mainView;

		private void Application_Startup(object sender, StartupEventArgs e)
		{
			// temporary window
			var tmpMainWindow = new MainWindow();
			tmpMainWindow.Show();

			BuildApplication();
			mainView.Show();
		}

		private void BuildApplication()
		{
			var appViewModel = new AppViewModel();
			var parameterTransfer = new ParameterTransfer();

			var contentManagementService = new ContentManagementService(appViewModel, parameterTransfer);

			var mapping = PrepareMapping(contentManagementService, parameterTransfer);
			var viewTypeConverter = new ViewTypeToUIElementConverter(mapping);
			Application.Current.Resources.Add("viewTypeConverter", viewTypeConverter);

			mainView = new AppView();
			mainView.DataContext = appViewModel;

			appViewModel.PrimaryViewType = ViewType.MainWindow;
			appViewModel.SecondaryViewType = ViewType.Default;
		}

		private IDictionary<ViewType, ViewTypeManager<FrameworkElement>> PrepareMapping(ContentManagementService cms, IParameterTransfer parameterTransfer)
		{
			var mapping = new Dictionary<ViewType, ViewTypeManager<FrameworkElement>>();

			mapping[ViewType.Default] = new ViewTypeDefaultManager();
			mapping[ViewType.Test] = new ViewTypeTestManager();

			mapping[ViewType.MainWindow] = new ViewTypeMainWindowManager(cms.OpenLearningPathPromptCommand, cms.OpenExaminationPathWizardCommand, cms.OpenSettingsWindowCommand, cms.ShowAboutWindowCommand, cms.CloseApplicationCommand);
			
			mapping[ViewType.LearningPathPrompt] = new ViewTypeLearningPathPromptManager(cms.StartLearningPathCommand);
			mapping[ViewType.ExaminationPathWizard] = new ViewTypeExaminationPathWizardManager(vt => { cms.RefreshSecondaryView(ViewType.ExaminationPathWizard, vt); }, cms.HideSecondaryWindowCommand, cms.StartExaminationPathCommand);
			mapping[ViewType.SettingsWindow] = new ViewTypeSettingsWindowManager(cms.OpenPictogramsManagementWizardCommand, cms.OpenCategoriesManagementWizardCommand, cms.OpenCameraCalibrationToolCommand, cms.ReturnToMainWindowCommand);
			mapping[ViewType.AboutWindow] = new ViewTypeAboutManager(cms.HideSecondaryWindowCommand);

			DatabaseService databaseService = new DatabaseService();
			mapping[ViewType.LearningPath] = new ViewTypeLearningPathManager(databaseService);
			mapping[ViewType.ExaminationPath] = new ViewTypeExaminationPathManager(cms.ToExaminationPathPipe);

            mapping[ViewType.PictogramsManagementWizard] = new ViewTypePictogramsManagementWizardManager(vt => { cms.RefreshSecondaryView(ViewType.PictogramsManagementWizard, vt); }, cms.HideSecondaryWindowCommand, cms.OpenSettingsWindowCommand);
            mapping[ViewType.CategoriesManagementWizard] = new ViewTypeCategoriesManagementWizardManager(vt => { cms.RefreshSecondaryView(ViewType.CategoriesManagementWizard, vt); }, cms.HideSecondaryWindowCommand, cms.OpenSettingsWindowCommand);
			mapping[ViewType.CalibrationWindow] = new ViewTypeCalibrationManager();

			return mapping;
		}
	}
}
