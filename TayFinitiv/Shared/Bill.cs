using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TayFinitiv.Shared
{
	public class Bill
	{
		#region Properties
		[NotMapped]
		public int Value { 
			get
			{
				return GetDenominationValue(Denomination);
			}
		}

		public Denomination Denomination { get; set; }
		#endregion

		#region Constructors
		public Bill (Denomination denomination)
		{
			Denomination = denomination;
		}
		#endregion

		#region Methods
		private int GetDenominationValue(Denomination denomination)
		{
			return (int)denomination;
		}
		#endregion
	}

	public enum Denomination {
		One = 1,
		Five = 5,
		Ten = 10,
		Twenty = 20,
		Fifty = 50,
		Hundred = 100
	}
}
