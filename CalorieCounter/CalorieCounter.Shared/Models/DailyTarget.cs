using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounter.Shared.Models
{
	public class DailyTarget
	{
		public int DailyTargetID { get; set; }
		public int UserID { get; set; }
		public int Calories { get; set; }
        //public decimal? Fat { get; set; }
        //public int? Carbohydrates { get; set; }
		public DateTime Date { get; set; }

		public User User { get; set; }
	}
}
