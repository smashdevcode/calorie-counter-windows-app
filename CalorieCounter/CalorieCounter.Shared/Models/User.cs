using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounter.Shared.Models
{
	public class User
	{
        public User()
        {
            Weights = new ObservableCollection<UserWeight>();
            DailyTargets = new ObservableCollection<DailyTarget>();
            FoodItems = new ObservableCollection<FoodItem>();
            LogEntries = new ObservableCollection<LogEntry>();
        }

		public int UserID { get; set; }
		// TODO use oAuth instead???
		public string Username { get; set; }
		public string HashedPassword { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }

		public int TotalCalories
		{
			get
			{
				return this.LogEntries.Sum(le => le.LogEntryFoodItems.Sum(lefi => lefi.FoodItem.Calories.Value));
			}
		}

		public ObservableCollection<UserWeight> Weights { get; set; }
		public ObservableCollection<DailyTarget> DailyTargets { get; set; }
		public ObservableCollection<FoodItem> FoodItems { get; set; }
		public ObservableCollection<LogEntry> LogEntries { get; set; }
	}
}
