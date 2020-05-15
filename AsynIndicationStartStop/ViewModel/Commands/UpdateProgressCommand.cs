using AsynIndicationStartStop.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace AsynIndicationStartStop.ViewModel.Commands
{
    public class UpdateProgressCommand : ICommand
    {
        private MainVM MainVM;

        public event EventHandler CanExecuteChanged;

        public UpdateProgressCommand(MainVM mainVM)
        {
            MainVM = mainVM ?? throw new ArgumentNullException(nameof(mainVM));
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MainVM.RunProgressTextUpdate();
        }
    }
}
