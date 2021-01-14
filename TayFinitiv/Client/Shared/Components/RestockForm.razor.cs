using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TayFinitiv.Client.Services;
using TayFinitiv.Shared;

namespace TayFinitiv.Client.Shared.Components
{
	public partial class RestockForm
	{
		private Dictionary<Denomination, int> _billsNowInATM;
		private RestockRequest _billsToRestock;
		private bool awaitingResponse;
		[Inject]
		private WithdrawalService _withdrawalService { get; set; }
		protected override void OnInitialized()
		{
			base.OnInitialized();
			resetBillsToRestock();
		}

		private void OnCancel()
		{
			resetBillsToRestock();
		}

		private void OnSave()
		{
			Save();
		}
		private async void Save()
		{
			_billsNowInATM = await _withdrawalService.Restock(_billsToRestock);
			StateHasChanged();
		}

		private void resetBillsToRestock()
		{
			_billsToRestock = new RestockRequest();
		}
	}
}
