using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TayFinitiv.Shared;

namespace TayFinitiv.Client.Services
{
	public class WithdrawalService
	{
		private const string API_PREFIX = "/api/requests/";
		private HttpClient _client { get; }
		public WithdrawalService(HttpClient client)
		{
			_client = client;
		}

		public async Task<WithdrawRequest> SubmitRequest(WithdrawRequest request)
		{
			WithdrawRequest withdrawRequestResp;
			HttpResponseMessage response = await _client.PostAsJsonAsync(API_PREFIX, request);
			response.EnsureSuccessStatusCode();
			withdrawRequestResp = await response.Content.ReadFromJsonAsync<WithdrawRequest>();
			return withdrawRequestResp;
		}


		public async Task<Dictionary<Denomination, int>> GetOverview()
		{
			return await _client.GetFromJsonAsync<Dictionary<Denomination, int>>(API_PREFIX + "overview");
		}
	}
}
