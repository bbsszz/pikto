using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Pikto.ViewModel;

namespace Pikto.Views
{
    class ViewTypeAddPiktogramFirstStep :  ViewTypeWizardManager<UIElement>
    {
        public UIElement GetView(object parameter)
        {
            var viewModel = new AddPiktogramFirstStepViewModel();

            var content = new WizardView();
            var innerContent = new AddPiktogramFirstStep();
            content.stepContent.Content = innerContent;
            innerContent.DataContext = viewModel;

            return content;
        }
    }
}
