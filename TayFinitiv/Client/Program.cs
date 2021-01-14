using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TayFinitiv.Client.Services;
using TayFinitiv.Client.Services.State;

namespace TayFinitiv.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

			builder.Services.AddScoped<HistoryService>();
			builder.Services.AddScoped<WithdrawalService>();
			builder.Services.AddScoped<UserService>();
			builder.Services.AddScoped<RestockService>();
			builder.Services.AddScoped<PageHistoryState>();
			await builder.Build().RunAsync();
		}
	}
}
