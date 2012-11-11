using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounter.Shared.Models
{
	public class UserWeight
	{
		public int UserWeightID { get; set; }
		public int UserID { get; set; }
		public decimal Weight { get; set; }
		public DateTime Date { get; set; }

		public User User { get; set; }
	}
}
