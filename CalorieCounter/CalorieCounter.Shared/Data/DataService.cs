using CalorieCounter.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounter.Shared.Data
{
	public class DataService : IDataService
	{
		public async Task<User> GetUser(string emailAddress)
		{
			var user = new User() { Name = "James Churchill", Email = "james@smashdev.com", Username = "jchurchill" };

			user.DailyTargets.Add(
				new DailyTarget()
				{
					User = user,
					Calories = 1850
				});
			user.DailyTargets.Add(
				new DailyTarget()
				{
					User = user,
					Calories = 1850,
					Date = new DateTime(2012, 11, 6)
				});
			user.DailyTargets.Add(
				new DailyTarget()
				{
					User = user,
					Calories = 1850,
					Date = new DateTime(2012, 11, 7)
				});
			user.DailyTargets.Add(
				new DailyTarget()
				{
					User = user,
					Calories = 1850,
					Date = new DateTime(2012, 11, 8)
				});

			user.Weights.Add(
				new UserWeight()
				{
					User = user,
					Weight = 217.8m,
					Date = new DateTime(2012, 11, 6)
				});
			user.Weights.Add(
				new UserWeight()
				{
					User = user,
					Weight = 216.8m,
					Date = new DateTime(2012, 11, 7)
				});
			user.Weights.Add(
				new UserWeight()
				{
					User = user,
					Weight = 218.6m,
					Date = new DateTime(2012, 11, 8)
				});

			var mealTypeBreakfast = new MealType() { Name = "Breakfast" };
			var mealTypeLunch = new MealType() { Name = "Lunch" };
			var mealTypeDinner = new MealType() { Name = "Dinner" };
			var mealTypeSnack = new MealType() { Name = "Snack" };
			//context.MealTypes.AddOrUpdate(mt => mt.Name,
			//	mealTypeBreakfast,
			//	mealTypeLunch,
			//	mealTypeDinner,
			//	mealTypeSnack);

			// JCTODO setup helper method to return collection of food items???
			var foodItemCheerios = new FoodItem() { Name = "Cheerios", ServingSize = "1 cup", Calories = 150, UserID = user.UserID };
			var foodItemTurkeySausage = new FoodItem() { Name = "Turkey Sausage", ServingSize = "1 sausage", Calories = 110, UserID = user.UserID };
			var foodItemYogurt = new FoodItem() { Name = "Yogurt", ServingSize = "1 container", Calories = 90, UserID = user.UserID };
			var foodItemCheeseStick = new FoodItem() { Name = "Cheese Stick", ServingSize = "1 stick", Calories = 80, UserID = user.UserID };
			var foodItemPizza = new FoodItem() { Name = "Pizza", ServingSize = "1 slice", Calories = 300, UserID = user.UserID };
			var foodItemDinnerRoll = new FoodItem() { Name = "Dinner Roll", ServingSize = "1 roll", Calories = 80, UserID = user.UserID };
			var foodItemTortillaChips = new FoodItem() { Name = "Tortilla Chips", ServingSize = "9 chips", Calories = 140, UserID = user.UserID };
			var foodItemGratedCheese = new FoodItem() { Name = "Grated Cheese", ServingSize = "1 oz", Calories = 120, UserID = user.UserID };
			var foodItemSalsa = new FoodItem() { Name = "Salsa", ServingSize = "2 tbsp", Calories = 10, UserID = user.UserID };
			var foodItemRiceCrispies = new FoodItem() { Name = "Rice Crispies", ServingSize = "1 1/4 cups", Calories = 180, UserID = user.UserID };
			user.FoodItems.Add(foodItemCheerios);
			user.FoodItems.Add(foodItemTurkeySausage);
			user.FoodItems.Add(foodItemYogurt);
			user.FoodItems.Add(foodItemCheeseStick);
			user.FoodItems.Add(foodItemPizza);
			user.FoodItems.Add(foodItemDinnerRoll);
			user.FoodItems.Add(foodItemTortillaChips);
			user.FoodItems.Add(foodItemGratedCheese);
			user.FoodItems.Add(foodItemSalsa);
			user.FoodItems.Add(foodItemRiceCrispies);

			// JCTODO setup helper method to add a log entry (accepts a params list of food items and serving sizes???)
			var logEntry1 = new LogEntry()
			{
				User = user,
				MealType = mealTypeBreakfast,
				DateTimeUTC = DateTime.Parse("11/7/2012 7:00am").ToUniversalTime()
			};
			logEntry1.LogEntryFoodItems.Add(new LogEntryFoodItem()
			{
				FoodItem = foodItemCheerios,
				LogEntry = logEntry1,
				Serving = 1m
			});
			user.LogEntries.Add(logEntry1);

			var logEntry2 = new LogEntry()
			{
				User = user,
				MealType = mealTypeLunch,
				DateTimeUTC = DateTime.Parse("11/7/2012 1:00pm").ToUniversalTime()
			};
			logEntry2.LogEntryFoodItems.Add(new LogEntryFoodItem()
			{
				FoodItem = foodItemTurkeySausage,
				LogEntry = logEntry2,
				Serving = 2m
			});
			logEntry2.LogEntryFoodItems.Add(new LogEntryFoodItem()
			{
				FoodItem = foodItemYogurt,
				LogEntry = logEntry2,
				Serving = 1m
			});
			user.LogEntries.Add(logEntry2);


			//7:00am	Cheerios	1	1 cup	150	150
			//1:00pm	Turkey Sausage	2	1 sausage	110	220
			//	Yogurt	1	1 container	100	100
			//4:00pm	Cheese Stick	1		80	80
			//6:15pm	Pizza	1.5	1 slice	300	450
			//9:30pm	Dinner Rolls	2	1 roll	80	160
			//10:00pm	Tortilla Chips	3	9 chips	140	420
			//	Grated Cheese	1	1 oz	120	120
			//	Salsa	2	2 tbsp	10	20
			//10:30pm	Rice Crispies	1	1 1/4 cups	180	180

			//10:00am	Pearl Bakery Pumpkin Bread	1	1 slice	200	200
			//1:00pm	Campbell's New England Clam Chowder	1	1 can	420	420
			//	Yogurt	1	1 container	100	100
			//4:00pm	Cheese Stick	1		80	80
			//	Pearl Bakery Corn Bread	0.5	1 slice	200	100
			//6:00pm	Beer	1	1 bottle	200	200
			//8:00pm	Chicken Chow Mein	2	1 cup	100	200
			//	Fried Noodles	3	1/2 cup	130	390
			//10:30pm	Rice Crispies	1	1 1/4 cups	180	180

			//8:00am	Marriott Hotel Breakfast	1		800	800
			//	Marriott Hotel Lunch	1		800	800
			//6:15pm	Jumbo Olives	4	3 olives	25	100
			//	Enchilada Sauce	4.5	1/4 cup	20	90
			//	Tortilla	2	1 tortilla	150	300
			//	Refried Beans	3	1/2 cup	100	300
			//	Seasoned Beef	0.5	4 oz	290	145
			//	Grated Cheese	2	1 oz	120	240
			//10:00pm	Ice Cream	2	1/2 cup	140	280
			//	Chocolate Syrup	1	2 tbsp	100	100
			//	Banana	0.5	1 banana	100	50
			//11:00pm	Rice Crispies	1	1 1/4 cups	180	180



			return user;
		}
	}
}
