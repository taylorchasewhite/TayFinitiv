using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TayFinitiv.Client.Services;
using TayFinitiv.Shared;

namespace TayFinitiv.Client.Shared.Components
{
	public partial class NewWithdrawal
	{
		[Inject]
		private WithdrawalService _requestService { get; set; }
		private WithdrawRequest newRequest,requestResponse;
		private bool awaitingResponse;
		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();
			newRequest = new WithdrawRequest();
			awaitingResponse = false;
		}

		private void OnSave()
		{
			Save();

		}

		private void OnCancel()
		{
			Restart();
		}
		private async void Save()
		{
			newRequest.RequestInstant = DateTimeOffset.Now;
			awaitingResponse = true;
			requestResponse = await _requestService.SubmitRequest(newRequest);
			awaitingResponse = false;
			StateHasChanged();
		}

		private void Restart()
		{
			requestResponse = null;
			newRequest = new WithdrawRequest();
			awaitingResponse = false;
		}
	}
}
