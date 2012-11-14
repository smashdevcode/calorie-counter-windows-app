using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounter.Shared.Models
{
	public class LogEntryFoodItem
	{
		public LogEntryFoodItem(FoodItem foodItem, decimal serving)
		{
			this.FoodItem = foodItem;
			this.Serving = serving;
		}

		public int LogEntryFoodItemID { get; set; }
		public int LogEntryID { get; set; }
		public int FoodItemID { get; set; }
		public decimal Serving { get; set; }

		public LogEntry LogEntry { get; set; }
		public FoodItem FoodItem { get; set; }
	}
}
