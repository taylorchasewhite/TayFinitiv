using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;namespace TayFinitiv.Shared
{
	public class WithdrawRequest
	{
		public WithdrawRequest()
		{
		}

		public string Id { get; set; }

		public DateTimeOffset RequestInstant { get; set; }

		[Required]
		public Denomination DenominationRequested { get; set; }

		[Range(1,int.MaxValue, ErrorMessage = "You must request at least ${1} USD.")]
		public int AmountRequested { get; set; }

		public bool WasSuccessful { get; set; }
		public string MessageToUser { get; set; }
	}
}
