using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TayFinitiv.Shared;

namespace TayFinitiv.Database
{
	public class TellerService
	{
		private ApplicationDbContext _context;
		private TellerMachine _atm;
		private TransactionHistoryService _historyService;
		public TellerService(ApplicationDbContext context, TransactionHistoryService historyService)
		{
			_context = context;
			_historyService = historyService;
			_atm = context.ATMs.Find("1"); // For this demo application, we only use one ATM
		}

		public string Withdraw(WithdrawRequest newRequest)
		{
			newRequest.Id = Guid.NewGuid().ToString();
			int amount = newRequest.AmountRequested;
			bool success = _atm.RequestMoney(newRequest.DenominationRequested, amount);
			string messageToUser = success ? $"Dispensed ${amount}" : "Insufficient funds";

			newRequest.WasSuccessful = success;
			newRequest.MessageToUser = messageToUser;
			_historyService.AuditRequest(newRequest);
			if(success)
			{
				_context.Entry(_atm).State = EntityState.Modified;
				_context.SaveChanges();
			}
			return messageToUser;
		}

		public Dictionary<Denomination, int> GetOverview()
		{
			return _atm.Bills;
		}

		public Dictionary<Denomination,int> FactoryReset()
		{
			_historyService.FactoryReset();
			_atm.Stock(new RestockRequest()
			{
				Ones = 10,
				Fives = 10,
				Tens = 10,
				Twenties = 10,
				Fifties = 10,
				Hundreds = 10
			});
			_context.SaveChanges();
			return _atm.Bills;
		}

		public Dictionary<Denomination,int> Stock(RestockRequest billsToStock)
		{
			_atm.Stock(billsToStock);
			_context.Entry(_atm).State = EntityState.Modified;
			_context.SaveChanges();
			return _atm.Bills;
		}

		public Dictionary<Denomination,int> Restock(RestockRequest bills)
		{
			_atm.Restock(bills);
			_context.Entry(_atm).State = EntityState.Modified;
			_context.SaveChanges();
			return _atm.Bills;
		}

		#region Helpers
		private WithdrawRequest buildNewRequest(Denomination denomination, int amount, DateTimeOffset requestInstant)
		{
			WithdrawRequest request = new WithdrawRequest();

			request.DenominationRequested = denomination;
			request.AmountRequested = amount;
			request.RequestInstant = requestInstant;
			return request;
		}
		#endregion
	}
}
