using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TayFinitiv.Client.Services;

namespace TayFinitiv.Client.Pages
{
	public partial class Index
	{
		[Inject]
		private UserService _userService { get; set; }
	}
}
