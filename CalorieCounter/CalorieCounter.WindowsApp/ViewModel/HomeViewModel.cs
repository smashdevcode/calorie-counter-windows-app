using System;
using GalaSoft.MvvmLight;
using CalorieCounter.Shared.Data;
using CalorieCounter.Shared.Helpers;
using GalaSoft.MvvmLight.Command;
using CalorieCounter.Shared.Models;
using System.Collections.ObjectModel;
using System.Linq;

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
			this.CurrentLogEntryDate = user.LogEntryDates[0];
		}
		#endregion

		#region User
		/// <summary>
		/// The <see cref="User" /> property's name.
		/// </summary>
		public const string UserPropertyName = "User";

		private User _user = null;

		/// <summary>
		/// Sets and gets the User property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public User User
		{
			get
			{
				return _user;
			}

			set
			{
				if (_user == value)
				{
					return;
				}

				RaisePropertyChanging(UserPropertyName);
				_user = value;
				RaisePropertyChanged(UserPropertyName);
			}
		}
		#endregion

		#region CurrentLogEntryDate
		/// <summary>
		/// The <see cref="CurrentLogEntryDate" /> property's name.
		/// </summary>
		public const string CurrentLogEntryDatePropertyName = "CurrentLogEntryDate";

		private LogEntryDate _currentLogEntryDate = null;

		/// <summary>
		/// Sets and gets the CurrentLogEntryDate property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public LogEntryDate CurrentLogEntryDate
		{
			get
			{
				return _currentLogEntryDate;
			}

			set
			{
				if (_currentLogEntryDate == value)
				{
					return;
				}

				RaisePropertyChanging(CurrentLogEntryDatePropertyName);
				_currentLogEntryDate = value;
				RaisePropertyChanged(CurrentLogEntryDatePropertyName);
			}
		}
		#endregion
	}
}