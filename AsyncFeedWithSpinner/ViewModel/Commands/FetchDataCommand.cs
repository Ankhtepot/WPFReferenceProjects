using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace AsyncFeedWithSpinner.ViewModel.Commands
{
    public class FetchDataCommand : ICommand
    {
        private MainVM VM = null;

        public event EventHandler CanExecuteChanged;

        public FetchDataCommand(MainVM vM)
        {
            VM = vM ?? throw new ArgumentNullException(nameof(vM));
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.FetchData();
        }
    }
}
