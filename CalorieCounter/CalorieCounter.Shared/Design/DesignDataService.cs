using CalorieCounter.Shared.Data;
using CalorieCounter.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounter.Shared.Design
{
	public class DesignDataService : IDataService
	{
		public async Task<User> GetUser(string emailAddress)
		{
			return GetUser();
		}

		internal static User GetUser()
		{
			var dailyTargets = new List<DailyTarget>();
			//dailyTargets.Add(
			//	new DailyTarget()
			//	{
			//		Calories = 1850
			//	});
			dailyTargets.Add(
				new DailyTarget()
				{
					Calories = 1850,
					Date = new DateTime(2012, 8, 1)
				});
			//dailyTargets.Add(
			//	new DailyTarget()
			//	{
			//		Calories = 1850,
			//		Date = new DateTime(2012, 11, 7)
			//	});
			//dailyTargets.Add(
			//	new DailyTarget()
			//	{
			//		Calories = 1850,
			//		Date = new DateTime(2012, 11, 8)
			//	});

			var weights = new List<UserWeight>();
			weights.Add(
				new UserWeight()
				{
					Weight = 217.8m,
					Date = new DateTime(2012, 11, 7)
				});
			weights.Add(
				new UserWeight()
				{
					Weight = 216.8m,
					Date = new DateTime(2012, 11, 8)
				});
			weights.Add(
				new UserWeight()
				{
					Weight = 218.6m,
					Date = new DateTime(2012, 11, 9)
				});

			var mealTypeBreakfast = new MealType() { Name = "Breakfast" };
			var mealTypeLunch = new MealType() { Name = "Lunch" };
			var mealTypeDinner = new MealType() { Name = "Dinner" };
			var mealTypeSnack = new MealType() { Name = "Snack" };

			var foodItems = new List<FoodItem>();
			var foodItemCheerios = AddFoodItem("Cheerios", "1 cup", 150, foodItems);
			var foodItemTurkeySausage = AddFoodItem("Turkey Sausage", "1 sausage", 110, foodItems);
			var foodItemYogurt = AddFoodItem("Yogurt", "1 container", 90, foodItems);
			var foodItemCheeseStick = AddFoodItem("Cheese Stick", "1 stick", 80, foodItems);
			var foodItemPizza = AddFoodItem("Pizza", "1 slice", 300, foodItems);
			var foodItemDinnerRoll = AddFoodItem("Dinner Roll", "1 roll", 80, foodItems);
			var foodItemTortillaChips = AddFoodItem("Tortilla Chips", "9 chips", 140, foodItems);
			var foodItemGratedCheese = AddFoodItem("Grated Cheese", "1 oz", 120, foodItems);
			var foodItemSalsa = AddFoodItem("Salsa", "2 tbsp", 10, foodItems);
			var foodItemRiceCrispies = AddFoodItem("Rice Crispies", "1 1/4 cups", 180, foodItems);
			var foodItemPumpkinBread = AddFoodItem("Pearl Bakery Pumpkin Bread", "1 slice", 200, foodItems);
			var foodItemNewEnglandClamChowder = AddFoodItem("Campbell's New England Clam Chowder", "1 can", 420, foodItems);
			var foodItemCornBread = AddFoodItem("Pearl Bakery Corn Bread", "1 slice", 200, foodItems);
			var foodItemBeer = AddFoodItem("Beer", "1 bottle", 200, foodItems);
			var foodItemChickenChowMein = AddFoodItem("Chicken Chow Mein", "1 cup", 100, foodItems);
			var foodItemFriedNoodles = AddFoodItem("Fried Noodles", "1/2 cup", 130, foodItems);
			var marriottHotelBreaksfast = AddFoodItem("Marriott Hotel Breakfast", null, 800, foodItems);
			var marriottHotelLunch = AddFoodItem("Marriott Hotel Lunch", null, 800, foodItems);
			var jumboOlives = AddFoodItem("Jumbo Olives", "3 olives", 25, foodItems);
			var enchiladaSauce = AddFoodItem("Enchilada Sauce", "1/4 cup", 20, foodItems);
			var tortilla = AddFoodItem("Tortilla", "1 tortilla", 150, foodItems);
			var refriedBeans = AddFoodItem("Refried Beans", "1/2 cup", 100, foodItems);
			var seasonedBeef = AddFoodItem("Seasoned Beef", "4 oz", 290, foodItems);
			var gratedCheese = AddFoodItem("Grated Cheese", "1 oz", 120, foodItems);
			var iceCream = AddFoodItem("Ice Cream", "1/2 cup", 140, foodItems);
			var chocolateSyrup = AddFoodItem("Chocolate Syrup", "2 tbsp", 100, foodItems);
			var banana = AddFoodItem("Banana", "1 banana", 100, foodItems);

			var logEntries = new List<LogEntry>();
			AddLogEntry(mealTypeBreakfast, "11/7/2012 7:00am", logEntries,
				new LogEntryFoodItem(foodItemCheerios, 1m)
			);
			AddLogEntry(mealTypeLunch, "11/7/2012 1:00pm", logEntries,
				new LogEntryFoodItem(foodItemTurkeySausage, 2m),
				new LogEntryFoodItem(foodItemYogurt, 1m)
			);
			AddLogEntry(mealTypeSnack, "11/7/2012 4:00pm", logEntries,
				new LogEntryFoodItem(foodItemCheeseStick, 1m)
			);
			AddLogEntry(mealTypeDinner, "11/7/2012 6:15pm", logEntries,
				new LogEntryFoodItem(foodItemPizza, 1.5m)
			);
			AddLogEntry(mealTypeSnack, "11/7/2012 9:30pm", logEntries,
				new LogEntryFoodItem(foodItemDinnerRoll, 2m)
			);
			AddLogEntry(mealTypeSnack, "11/7/2012 10:00pm", logEntries,
				new LogEntryFoodItem(foodItemTortillaChips, 3m),
				new LogEntryFoodItem(foodItemGratedCheese, 1m),
				new LogEntryFoodItem(foodItemSalsa, 2m)
			);
			AddLogEntry(mealTypeSnack, "11/7/2012 10:30pm", logEntries,
				new LogEntryFoodItem(foodItemRiceCrispies, 1m)
			);

			AddLogEntry(mealTypeBreakfast, "11/8/2012 10:00am", logEntries,
				new LogEntryFoodItem(foodItemPumpkinBread, 1m)
			);
			AddLogEntry(mealTypeLunch, "11/8/2012 1:00pm", logEntries,
				new LogEntryFoodItem(foodItemNewEnglandClamChowder, 1m),
				new LogEntryFoodItem(foodItemYogurt, 1m)
			);
			AddLogEntry(mealTypeSnack, "11/8/2012 4:00pm", logEntries,
				new LogEntryFoodItem(foodItemCheeseStick, 1m),
				new LogEntryFoodItem(foodItemCornBread, 0.5m)
			);
			AddLogEntry(mealTypeSnack, "11/8/2012 6:00pm", logEntries,
				new LogEntryFoodItem(foodItemBeer, 1m)
			);
			AddLogEntry(mealTypeSnack, "11/8/2012 8:00pm", logEntries,
				new LogEntryFoodItem(foodItemChickenChowMein, 2m),
				new LogEntryFoodItem(foodItemFriedNoodles, 3m)
			);
			AddLogEntry(mealTypeSnack, "11/8/2012 10:30pm", logEntries,
				new LogEntryFoodItem(foodItemRiceCrispies, 1m)
			);

			AddLogEntry(mealTypeBreakfast, "11/9/2012 8:00am", logEntries,
				new LogEntryFoodItem(marriottHotelBreaksfast, 1m)
			);
			AddLogEntry(mealTypeLunch, "11/9/2012 12:00pm", logEntries,
				new LogEntryFoodItem(marriottHotelLunch, 1m)
			);
			AddLogEntry(mealTypeDinner, "11/9/2012 6:15pm", logEntries,
				new LogEntryFoodItem(jumboOlives, 4m),
				new LogEntryFoodItem(enchiladaSauce, 4.5m),
				new LogEntryFoodItem(tortilla, 2m),
				new LogEntryFoodItem(refriedBeans, 3m),
				new LogEntryFoodItem(seasonedBeef, 0.5m),
				new LogEntryFoodItem(gratedCheese, 2m)
			);
			AddLogEntry(mealTypeSnack, "11/9/2012 10:00pm", logEntries,
				new LogEntryFoodItem(iceCream, 2m),
				new LogEntryFoodItem(chocolateSyrup, 1m),
				new LogEntryFoodItem(banana, 0.5m)
			);
			AddLogEntry(mealTypeSnack, "11/9/2012 11:00pm", logEntries,
				new LogEntryFoodItem(foodItemRiceCrispies, 1m)
			);

			return new User("jchurchill", "James Churchill", "james@smashdev.com", dailyTargets, weights, foodItems, logEntries);
		}
		private static FoodItem AddFoodItem(string name, string servingSize, int calories, List<FoodItem> foodItems)
		{
			var foodItem = new FoodItem() { Name = name, ServingSize = servingSize, Calories = calories };
			foodItems.Add(foodItem);
			return foodItem;
		}
		private static void AddLogEntry(MealType mealType, string dateTime, List<LogEntry> logEntries, params LogEntryFoodItem[] logEntryFoodItems)
		{
			var logEntry = new LogEntry()
			{
				MealType = mealType,
				DateTimeUTC = DateTime.SpecifyKind(DateTime.Parse(dateTime), DateTimeKind.Local).ToUniversalTime()
			};
			foreach (var logEntryFoodItem in logEntryFoodItems)
			{
				logEntryFoodItem.LogEntry = logEntry;
				logEntry.LogEntryFoodItems.Add(logEntryFoodItem);
			}
			logEntries.Add(logEntry);
		}
	}
}
