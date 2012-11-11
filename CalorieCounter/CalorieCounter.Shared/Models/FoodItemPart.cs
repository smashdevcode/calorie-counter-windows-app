using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounter.Shared.Models
{
	public class FoodItemPart
	{
		public int FoodItemPartID { get; set; }
		public int FoodItemID { get; set; }
		public int ContainsFoodItemID { get; set; }
		public decimal Serving { get; set; }

		public FoodItem FoodItem { get; set; }
		public FoodItem ContainsFoodItem { get; set; }
	}
}
