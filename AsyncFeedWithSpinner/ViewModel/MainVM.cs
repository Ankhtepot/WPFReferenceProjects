using AsyncFeedWithSpinner.ViewModel.Commands;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

			//dummyStringData.ForEach(s => ReceivedStrings.Add(s));
		}

		private void generateDummyData()
		{
			for (int i = 0; i < 20; i++)
			{
				dummyStringData.Add($"Dummy string data, line: {i}");
			}
		}

		public async void FetchData()
		{
			SpinSpinner();
			ReceivedStrings.Add(await FetchDataAsync(dummyStringData));
			SpinSpinner();
		}

		private async Task<string> FetchDataAsync(List<string> dummyStringData)
		{
			await Task.Delay(5000);
			return "jojo";
		}

		public void SpinSpinner()
		{
			SpinnerShouldSpin = !SpinnerShouldSpin;
			Console.WriteLine($"MainVM/SpinSpinner: SpinnerShuldSpin is: {SpinnerShouldSpin}");
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
