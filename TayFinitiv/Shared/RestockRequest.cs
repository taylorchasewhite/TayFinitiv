using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TayFinitiv.Shared
{
	public class RestockRequest
	{
		public RestockRequest()
		{

		}

		[Range(0, int.MaxValue, ErrorMessage = "You can't restock a negative amount!")]
		public int Ones { get; set; }

		[Range(0, int.MaxValue, ErrorMessage = "You can't restock a negative amount!")]
		public int Fives { get; set; }

		[Range(0, int.MaxValue, ErrorMessage = "You can't restock a negative amount!")]
		public int Tens { get; set; }

		[Range(0, int.MaxValue, ErrorMessage = "You can't restock a negative amount!")]
		public int Twenties { get; set; }

		[Range(0, int.MaxValue, ErrorMessage = "You can't restock a negative amount!")]
		public int Fifties { get; set; }

		[Range(0, int.MaxValue, ErrorMessage = "You can't restock a negative amount!")]
		public int Hundreds { get; set; }

		public Dictionary<Denomination,int> ToDictionary()
		{
			Dictionary<Denomination,int> dict = new Dictionary<Denomination, int>();
			dict.Add(Denomination.One, Ones);
			dict.Add(Denomination.Five, Fives);
			dict.Add(Denomination.Ten, Tens);
			dict.Add(Denomination.Twenty, Twenties);
			dict.Add(Denomination.Fifty, Fifties);
			dict.Add(Denomination.Hundred, Hundreds);
			return dict;
		}
	}
}
