using AsynIndicationStartStop.ViewModel.Commands;
using JetBrains.Annotations;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace AsynIndicationStartStop.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        private const string PROGRESS = "Progress";
        private const int PROGRESS_DELAY = 200;

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

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(nameof(Title)); }
        }

        public UpdateProgressCommand UpdateProgressCommand { get; set; }

        public MainVM()
        {
            ProgressText = PROGRESS;
            Title = "Async process looping till long working task finishes.";

            UpdateProgressCommand = new UpdateProgressCommand(this);
        }

        public async void RunProgressTextUpdate()
        {
            var cts = new CancellationTokenSource();

            if (!IsRunning)
            {
                IsRunning = true;
                UpdateProgressTextTask(cts.Token);
                string longTaskText = await Task.Run(() => LongTask(cts));
                await Task.Delay(PROGRESS_DELAY);
                ProgressText = longTaskText;
                IsRunning = false;
            }                  
        }

        private void UpdateProgressTextTask(CancellationToken token)
        {
            Task.Run(async () =>
            {
                ProgressText = PROGRESS;
                while (!token.IsCancellationRequested)
                {
                    await Task.Delay(PROGRESS_DELAY);
                    var dotsCount = ProgressText.Count<char>(ch => ch == '.');

                    ProgressText = dotsCount < 6 ? ProgressText + "." : ProgressText.Replace(".", "");
                }
            });
           
        }

        private string LongTask(CancellationTokenSource cts)
        {
            var result = Task.Run(async () =>
            {
                await Task.Delay(5000);
                cts.Cancel();
                return "Long task finished.";
            });

            return result.Result;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
