using CalorieCounter.Shared.Design;
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
			return DesignDataService.GetUser();
		}
	}
}
