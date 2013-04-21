using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Pikto.ViewModel
{
	class AboutViewModel : BaseViewModel
	{
		public ICommand OkCmd { get; private set; }

		public AboutViewModel(ICommand okCmd)
		{
			OkCmd = okCmd;
		}
	}
}
