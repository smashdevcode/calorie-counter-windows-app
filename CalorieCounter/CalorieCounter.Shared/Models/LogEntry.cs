using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounter.Shared.Models
{
	public class LogEntry
	{
        public LogEntry()
        {
            LogEntryFoodItems = new ObservableCollection<LogEntryFoodItem>();
        }

		public int LogEntryID { get; set; }
		public int UserID { get; set; }
		public int MealTypeID { get; set; }
		public DateTime DateTimeUTC { get; set; }

		public User User { get; set; }
		public MealType MealType { get; set; }
		public ObservableCollection<LogEntryFoodItem> LogEntryFoodItems { get; set; }
	}
}
