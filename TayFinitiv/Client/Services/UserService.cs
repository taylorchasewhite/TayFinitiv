using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TayFinitiv.Client.Services
{
	public class UserService
	{
		private IList<string> randomUserNames;
		public string CurrentUser { get; set; }
		public UserService() 
		{ 
			randomUserNames = new List<string>()
			{
				"Cody",
				"Mike",
				"Andrew",
				"Eric",
				"Taylor"
			};
			CurrentUser = randomUserNames[new Random(DateTime.Now.Second).Next(randomUserNames.Count - 1)];
		}
	}
}
