using CalorieCounter.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounter.Shared.Data
{
	public interface IDataService
	{
		Task<User> GetUser(string emailAddress);
	}
}
