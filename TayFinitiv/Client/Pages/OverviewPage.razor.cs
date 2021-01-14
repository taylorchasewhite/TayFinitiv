using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TayFinitiv.Client.Services;
using TayFinitiv.Shared;

namespace TayFinitiv.Client.Pages
{
	public partial class OverviewPage
	{
		private Dictionary<Denomination, int> _bills;

		[Inject]
		private WithdrawalService _withdrawalService { get; set; }

		protected override async Task OnInitializedAsync()
		{

			await getOverview();
			await base.OnInitializedAsync();
		}

		private async void OnFactoryReset()
		{
			await getOverview();
		}

		private async Task getOverview()
		{
			_bills = await _withdrawalService.GetOverview();
			StateHasChanged();
		}
	}
}
