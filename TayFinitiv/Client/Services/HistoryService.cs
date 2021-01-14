using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TayFinitiv.Shared;

namespace TayFinitiv.Client.Services
{
	public class HistoryService
	{
		private const string API_PREFIX = "/api/requests/";
		private HttpClient _client { get; }
		public HistoryService(HttpClient client)
		{
			_client = client;
		}

		public async Task<IList<WithdrawRequest>> GetRequestHistory()
		{
			return await _client.GetFromJsonAsync < IList < WithdrawRequest>>(API_PREFIX);
		}
	}
}
