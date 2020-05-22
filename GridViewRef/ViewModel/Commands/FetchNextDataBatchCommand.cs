using GridView.ViewModel;
using System;
using System.Windows.Input;

namespace GridViewRef.Commands
{
    public class FetchNextDataBatchCommand : ICommand
    {
        private MainVM MainVM;

        public event EventHandler CanExecuteChanged;

        public FetchNextDataBatchCommand(MainVM mainVM)
        {
            MainVM = mainVM ?? throw new ArgumentNullException(nameof(mainVM));
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MainVM.FetchNextDataBatch();
        }
    }
}
