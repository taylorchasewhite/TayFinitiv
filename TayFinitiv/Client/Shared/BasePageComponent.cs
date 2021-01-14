using TayFinitiv.Client.Services.State;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TayFinitiv.Client.Pages
{
	[Authorize]
	public class BasePageComponent : ComponentBase
	{
		[Inject]
		protected NavigationManager _navManager { get; set; }
		[Inject]
		protected PageHistoryState _pageState { get; set; }
		public BasePageComponent(NavigationManager navManager, PageHistoryState pageState)
		{
			_navManager = navManager;
			_pageState = pageState;
		}
		public BasePageComponent()
		{
		}
		protected override void OnInitialized()
		{
			base.OnInitialized();
			_pageState.AddPage(_navManager.Uri);
		}

	}
}
