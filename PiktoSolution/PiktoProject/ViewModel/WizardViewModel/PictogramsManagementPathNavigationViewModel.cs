using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Pikto.Utils;
using Pikto.Command;

namespace Pikto.ViewModel.WizardViewModel
{
	class PictogramsManagementPathNavigationViewModel : WizardNavigationViewModel<PictogramsManagementPathViewModel>
	{
		public PictogramsManagementPathNavigationViewModel(PictogramsManagementPathViewModel viewModel, Action<string> refreshStepAction, ICommand cancelCmd)
			: base(viewModel, refreshStepAction, cancelCmd)
		{
		}
			
		protected override void PrepareForwardCmds(IDictionary<string, ICommand> commands)
		{
			commands.Add("", new BasicCommand(p =>
			{
				switch (ViewModel.Action)
				{
					case ChooseEnum.New:
					{
						NextStep("new_picto");
                        ViewModel.HandleCategories();
                        ViewModel.PreparePictogram();
						break;
					}
					case ChooseEnum.Existing:
					{
						NextStep("update_picto");
						break;
					}
				}

                ViewModel.HandleCategories();
			}));

			commands.Add("new_picto", new BasicCommand(p =>
			{
                if (ViewModel.ChosenCategory==null || ViewModel.PictoName==null)
                {
                    System.Windows.MessageBox.Show("Wypełnij pola.", "Błąd", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
                else
                {
                    ViewModel.PutName();
                    ViewModel.PutCategory();
                    NextStep("picto_camera");
                }
                
			}));

			commands.Add("update_picto", new BasicCommand(p =>
			{

			}));
		}
	}
}
