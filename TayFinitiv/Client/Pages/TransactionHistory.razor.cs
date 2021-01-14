using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TayFinitiv.Client.Services;
using TayFinitiv.Shared;

namespace TayFinitiv.Client.Pages
{
	public partial class TransactionHistory
	{
		private IList<WithdrawRequest> _requests;
		[Inject]
		private HistoryService _histService { get; set;  }

		protected override async Task OnInitializedAsync()
		{

			await getRequests();
			await base.OnInitializedAsync();
		}

		private async void OnFactoryReset()
		{
			await getRequests();
		}

		private async Task getRequests()
		{
			_requests = await _histService.GetRequestHistory();
			_requests = _requests.OrderByDescending(req => req.RequestInstant).ToList();
			StateHasChanged();
		}
	}
}
