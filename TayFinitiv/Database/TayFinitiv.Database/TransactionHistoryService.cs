using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TayFinitiv.Shared;

namespace TayFinitiv.Database
{
	public class TransactionHistoryService
	{
		public ApplicationDbContext _context;
		public TransactionHistoryService(ApplicationDbContext context)
		{
			_context = context;
		}

		public void AuditRequest(WithdrawRequest request)
		{
			_context.Requests.Add(request);
			_context.SaveChanges();
		}

		public void FactoryReset()
		{
			_context.Requests.RemoveRange(_context.Requests);
			_context.SaveChanges();
		}
	}
}
