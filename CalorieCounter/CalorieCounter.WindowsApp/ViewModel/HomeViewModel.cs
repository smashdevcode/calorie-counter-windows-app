using System;
using GalaSoft.MvvmLight;
using CalorieCounter.Shared.Data;
using CalorieCounter.Shared.Helpers;
using GalaSoft.MvvmLight.Command;
using CalorieCounter.Shared.Models;

namespace CalorieCounter.WindowsApp.ViewModel
{
	/// <summary>
	/// This class contains properties that the main View can data bind to.
	/// <para>
	/// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
	/// </para>
	/// <para>
	/// You can also use Blend to data bind with the tool's support.
	/// </para>
	/// <para>
	/// See http://www.galasoft.ch/mvvm
	/// </para>
	/// </summary>
	public class HomeViewModel : ViewModelBase
	{
		private readonly IDataService _dataService;
		private readonly INavigationService _navigationService;

		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public HomeViewModel(IDataService dataService, INavigationService navigationService)
		{
			_dataService = dataService;
			_navigationService = navigationService;

			LoadUserCommand.Execute(null);

			//this.Date = DateTime.Today;

			////if (IsInDesignMode)
			////{
			////    // Code runs in Blend --> create design time data.
			////}
			////else
			////{
			////    // Code runs "for real"
			////}
		}



		#region LoadUserCommand
		private RelayCommand _loadUserCommand;
		public RelayCommand LoadUserCommand
		{
			get
			{
				return _loadUserCommand
					?? (_loadUserCommand = new RelayCommand(ExecuteLoadUserCommand));
			}
		}
		private async void ExecuteLoadUserCommand()
		{
			var user = await _dataService.GetUser("james@smashdev.com");
			this.User = user;
			if (user.LogEntries.Count > 0)
				this.CurrentLogEntry = user.LogEntries[0];
		}
		#endregion



		public User User { get; set; }

		#region CurrentLogEntry
		/// <summary>
		/// The <see cref="CurrentLogEntry" /> property's name.
		/// </summary>
		public const string CurrentLogEntryPropertyName = "CurrentLogEntry";

		private LogEntry _currentLogEntry = null;

		/// <summary>
		/// Sets and gets the CurrentLogEntry property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public LogEntry CurrentLogEntry
		{
			get
			{
				return _currentLogEntry;
			}

			set
			{
				if (_currentLogEntry == value)
				{
					return;
				}

				RaisePropertyChanging(CurrentLogEntryPropertyName);
				_currentLogEntry = value;
				RaisePropertyChanged(CurrentLogEntryPropertyName);
			}
		}
		#endregion

		//// JCTODO move this into the model???

		//#region Date
		///// <summary>
		///// The <see cref="Date" /> property's name.
		///// </summary>
		//public const string DatePropertyName = "Date";

		//private DateTime? _date = null;

		///// <summary>
		///// Sets and gets the Date property.
		///// Changes to that property's value raise the PropertyChanged event. 
		///// </summary>
		//public DateTime? Date
		//{
		//	get
		//	{
		//		return _date;
		//	}

		//	set
		//	{
		//		if (_date == value)
		//		{
		//			return;
		//		}

		//		RaisePropertyChanging(DatePropertyName);
		//		_date = value;
		//		RaisePropertyChanged(DatePropertyName);
		//		RaisePropertyChanged(DateFormattedPropertyName);
		//	}
		//}
		//#endregion

		#region DateFormatted
		/// <summary>
		/// The <see cref="DateFormatted" /> property's name.
		/// </summary>
		public const string DateFormattedPropertyName = "DateFormatted";

		/// <summary>
		/// Gets the Date property as a formatted string.
		/// </summary>
		public string DateFormatted
		{
			get
			{
				if (this.CurrentLogEntry != null)
					return this.CurrentLogEntry.DateTimeUTC.ToString("M/d");
				else
					return null;
			}
		}
		#endregion
	}
}