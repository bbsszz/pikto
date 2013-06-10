using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.Command;
using Pikto.Utils;

namespace Pikto.ViewModel.WizardViewModel
{
	class CategoriesManagementPathNavigationViewModel : WizardNavigationViewModel<CategoriesManagementPathViewModel>
	{

        ICommand finishCmd;

		public CategoriesManagementPathNavigationViewModel(
			CategoriesManagementPathViewModel viewModel, 
			Action<string> refreshStepAction, 
			ICommand cancelCmd, ICommand finishedCmd)
			: base(viewModel, refreshStepAction, cancelCmd)
		{
            finishCmd = finishedCmd;
		}



		protected override void PrepareForwardCmds(IDictionary<string, ICommand> commands)
		{
            commands.Add("", new BasicCommand(p =>
            {
                switch (ViewModel.Action)
                {
                    case ChooseEnum.New:
                        {
                            NextStep("new_category");
                            break;
                        }
                    case ChooseEnum.Existing:
                        {
                            NextStep("update_category");
                            ViewModel.HandleUpdateCategory();
                            break;
                        }
                }
            }));

            commands.Add("new_category", new BasicCommand(p =>
            {
                ViewModel.AddCategory();
                System.Windows.MessageBox.Show("Dodawanie kategorii zakończone powodzeniem.", "Gratulacje", System.Windows.MessageBoxButton.OK);
                finishCmd.Execute(null);
            }));

            commands.Add("update_category", new BasicCommand(p =>
            {
                
                var param = ViewModel.ChosenCategory;
                if (param == null)
                {
                    System.Windows.MessageBox.Show("Wybierz kategorię.", "Błąd", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
                else
                {
                    ViewModel.ChooseCategory();
                    NextStep("edit_category");
                }
                
            }));

            commands.Add("edit_category", new BasicCommand(p =>
            {
                switch (ViewModel.EditAction)
                {
                    case ActionEnum.Update:
                        {
                            ViewModel.EditCategory();
                            System.Windows.MessageBox.Show("Edycja kategorii zakończona powodzeniem.", "Gratulacje", System.Windows.MessageBoxButton.OK);
                            finishCmd.Execute(null);
                            break;
                        }
                    case ActionEnum.Delete:
                        {
                            ViewModel.DeleteCategory();
                            System.Windows.MessageBox.Show("Usunięcie kategorii zakończone powodzeniem.", "Gratulacje", System.Windows.MessageBoxButton.OK);
                            finishCmd.Execute(null);
                            break;
                        }
                }
                
            }));
		}
	}
}
