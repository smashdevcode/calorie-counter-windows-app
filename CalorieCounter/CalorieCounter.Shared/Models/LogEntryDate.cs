using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounter.Shared.Models
{
	public class LogEntryDate
	{
		public LogEntryDate(DateTime date, UserWeight weight, DailyTarget dailyTarget, List<LogEntry> logEntries)
		{
			this.Date = date;
			this.Weight = weight;
			this.DailyTarget = dailyTarget;
			this.LogEntries = new ObservableCollection<LogEntry>(logEntries);
		}

		public DateTime Date { get; set; }
		public string DateFormatted
		{
			get
			{
				return this.Date.ToString("M/d");
			}
		}
		public UserWeight Weight { get; set; }
		public DailyTarget DailyTarget { get; set; }
		public ObservableCollection<LogEntry> LogEntries { get; set; }
		public int TotalCalories
		{
			get
			{
				return this.LogEntries.Sum(le => le.LogEntryFoodItems
					.Sum(lefi => (int)Math.Round(lefi.Serving * lefi.FoodItem.Calories.Value, 0)));
			}
		}
	}
}
