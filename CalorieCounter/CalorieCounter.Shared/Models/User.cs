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
		public User(string username, string name, string email,
			List<DailyTarget> dailyTargets, List<UserWeight> weights, List<FoodItem> foodItems, List<LogEntry> logEntries)
		{
			this.Username = username;
			this.Name = name;
			this.Email = email;

			foreach (var dailyTarget in dailyTargets)
				dailyTarget.User = this;
			foreach (var weight in weights)
				weight.User = this;
			foreach (var foodItem in foodItems)
				foodItem.User = this;
			foreach (var logEntry in logEntries)
				logEntry.User = this;

			// JCTODO do these need to be observable collections???
			DailyTargets = new ObservableCollection<DailyTarget>(dailyTargets);
			Weights = new ObservableCollection<UserWeight>(weights);
			FoodItems = new ObservableCollection<FoodItem>(foodItems);
			LogEntries = new ObservableCollection<LogEntry>(logEntries);

			var logEntryDates = (from le in logEntries
								 group le by le.DateTime.Date into g
								 orderby g.Key descending
								 select new LogEntryDate(
									 g.Key, 
									 weights.Where(w => w.Date == g.Key).FirstOrDefault(),
									 dailyTargets.Where(dt => dt.Date <= g.Key).FirstOrDefault(),
									 g.OrderBy(le => le.DateTime).ToList()
									)).ToList();
			this.LogEntryDates = new ObservableCollection<LogEntryDate>(logEntryDates);
		}

		public int UserID { get; set; }
		// TODO use oAuth instead???
		public string Username { get; set; }
		public string HashedPassword { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }

		public ObservableCollection<DailyTarget> DailyTargets { get; private set; }
		public ObservableCollection<UserWeight> Weights { get; private set; }
		public ObservableCollection<FoodItem> FoodItems { get; private set; }
		public ObservableCollection<LogEntry> LogEntries { get; private set; }
		public ObservableCollection<LogEntryDate> LogEntryDates { get; private set; }
	}
}
