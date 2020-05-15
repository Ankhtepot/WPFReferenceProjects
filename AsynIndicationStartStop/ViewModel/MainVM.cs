using AsynIndicationStartStop.Commands;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AsynIndicationStartStop.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        private string progressText;

        public string ProgressText
        {
            get { return progressText; }
            set { progressText = value; OnPropertyChanged(); }
        }

        private bool isRunning;

        public bool IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; OnPropertyChanged(); }
        }

        public UpdateProgressCommand UpdateProgressCommand { get; set; }

        public MainVM()
        {
            ProgressText = "Progress";

            UpdateProgressCommand = new UpdateProgressCommand(this);
        }

        public async void RunProgressTextUpdate()
        {
            IsRunning = !IsRunning; //TODO remake this to use cancelation token

            if (IsRunning)
            {
                UpdateProgressTextAsync();
                string longTaskText = await Task.Run(() => LongTask());
                ProgressText = longTaskText;
            }
            else
            {
                ProgressText = "Progress";
            }
        }

        private async void UpdateProgressTextAsync()
        {
            while(IsRunning)
            {
                await Task.Delay(200);
                var dotsCount = ProgressText.Count<char>(ch => ch == '.');

               ProgressText = dotsCount < 6 ? ProgressText + "." : ProgressText.Replace(".", "");
            }
        }

        private async Task<string> LongTask()
        {
            await Task.Delay(5000);
            IsRunning = false;
            return "long task finished";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
