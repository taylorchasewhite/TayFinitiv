using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TayFinitiv.Shared;

namespace TayFinitiv.Client.Services
{
	public class RestockService
	{
		private const string API_PREFIX = "/api/requests/";
		private HttpClient _client { get; }
		public RestockService(HttpClient client)
		{
			_client = client;
		}
		/// <summary>
		/// Performs a factory reset on the current ATM. This means that the whole withdrawal history
		/// will be deleted, and the bills will be stocked to 10 in quantity per denomination.
		/// </summary>
		/// <returns>The bill quantity by denomination</returns>
		public async Task<Dictionary<Denomination, int>> FactoryReset()
		{
			HttpResponseMessage response = await _client.DeleteAsync(API_PREFIX + "reset");
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadFromJsonAsync<Dictionary<Denomination, int>>();
		}

		/// <summary>
		/// Sends a POST request to the server, allowing the consumer to *add* (negative bill quantities are not accepted)
		/// bills to the ATM.
		/// </summary>
		/// <param name="billsToRestock">The quantity of bills by denomination the consumer wishes to add.</param>
		/// <returns>The overview/summary of the quantity of bills by denomination</returns>
		public async Task<Dictionary<Denomination, int>> Restock(RestockRequest billsToRestock)
		{
			HttpResponseMessage response = await _client.PostAsJsonAsync(API_PREFIX + "restock", billsToRestock);
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadFromJsonAsync<Dictionary<Denomination, int>>();
		}
	}
}
