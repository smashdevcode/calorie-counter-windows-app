using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounter.Shared.Models
{
	public class FoodItem
	{
        public FoodItem()
        {
            FoodItemParts = new ObservableCollection<FoodItemPart>();
            ContainedByFoodItemParts = new ObservableCollection<FoodItemPart>();
        }

		public int FoodItemID { get; set; }
		public int? UserID { get; set; }
		public string Name { get; set; }
        public string ServingSize { get; set; }
        // TODO update the next three getters to check the food item parts collection
		// and if not null, use that to calculate the values
		public int? Calories { get; set; }
        //public decimal? Fat { get; set; }
        //public int? Carbohydrates { get; set; }

		public User User { get; set; }
		public ObservableCollection<FoodItemPart> FoodItemParts { get; set; }
		public ObservableCollection<FoodItemPart> ContainedByFoodItemParts { get; set; }
	}
}
