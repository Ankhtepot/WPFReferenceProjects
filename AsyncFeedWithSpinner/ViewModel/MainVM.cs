using AsyncFeedWithSpinner.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace AsyncFeedWithSpinner.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
		private bool spinnerShouldSpin;		

		public bool SpinnerShouldSpin
		{
			get { return spinnerShouldSpin; }
			set { spinnerShouldSpin = value; OnPropertyChanged(nameof(SpinnerShouldSpin)); }
		}

		private string title;

		public string Title
		{
			get { return title; }
			set { title = value; OnPropertyChanged(nameof(Title)); }
		}

		public ObservableCollection<string> ReceivedStrings { get; set; }

		private List<string> dummyStringData = new List<string>();

		public FetchDataCommand SpinSpinnerCommand { get; set; }

		public MainVM()
		{
			spinnerShouldSpin = false;
			Title = "Asynchronous feed with Spinner\nClick Read Data to start the feed.";
			ReceivedStrings = new ObservableCollection<string>();

			SpinSpinnerCommand = new FetchDataCommand(this);

			generateDummyData();
		}

		private void generateDummyData()
		{
			for (int i = 0; i < 20; i++)
			{
				dummyStringData.Add($"Dummy string data, line: {i + 1}");
			}
		}

		public void FetchData()
		{
			ReceivedStrings.Clear();

			BackgroundWorker worker = new BackgroundWorker();
			worker.DoWork += BackgroundWorker_DoWork;
			worker.WorkerReportsProgress = true;
			worker.ProgressChanged += BackgroundWorker_ProgressChanged;
			worker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
			worker.RunWorkerAsync(new BackgrounWorkerState(dummyStringData));
		}

		/// <summary>
		/// Cant update UI thread from DoWork so instead sending data into ProgressChanged
		/// </summary>
		/// <param name="sender">BackgroundWorker</param>
		/// <param name="e"></param>
		private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			SpinSpinner(true);

			var workingData = (e.Argument as BackgrounWorkerState).stringList;
			BackgroundWorker worker = sender as BackgroundWorker;

			double progressStep = (100 / workingData.Count);
			double currentProgress = 0;

			workingData.ForEach(s =>
			{
				currentProgress += progressStep;
				worker.ReportProgress((int)currentProgress, s);
				Thread.Sleep(200);
			});					
		}

		/// <summary>
		/// e.UserState holds state data sent from DoWork
		/// </summary>
		/// <param name="sender">BackgroundWorker</param>
		/// <param name="e"></param>
		private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if(e.UserState != null)
			{
				ReceivedStrings.Add((string)e.UserState);
			}
			Console.WriteLine($"BW-ProgressChanged: ProgressPercentage = {e.ProgressPercentage}");
		}

		private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			var resultLabel = "";
			if (e.Cancelled == true)
			{
				resultLabel = "Canceled!";
			}
			else if (e.Error != null)
			{
				resultLabel = "Error: " + e.Error.Message;
			}
			else
			{
				resultLabel = "Done!";
			}

			Console.WriteLine($"BW-Completed status: {resultLabel}");
			SpinSpinner(false);
		}

		public void SpinSpinner(bool shouldSpin)
		{
			SpinnerShouldSpin = shouldSpin;
			Console.WriteLine($"MainVM/SpinSpinner: SpinnerShouldSpin is: {SpinnerShouldSpin}");
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		/// <summary>
		/// Wrapper class for BackgroundWorker RunWorkerAsync Argument
		/// </summary>
		sealed private class BackgrounWorkerState
		{
			public List<string> stringList { get; private set; }

			public BackgrounWorkerState(List<string> stringList)
			{
				this.stringList = stringList ?? throw new ArgumentNullException(nameof(stringList));
			}
		}
	}
}
