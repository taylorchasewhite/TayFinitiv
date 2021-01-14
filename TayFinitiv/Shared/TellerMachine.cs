using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TayFinitiv.Shared
{
	public class TellerMachine
	{
		#region Properties
		[NotMapped]
		[JsonIgnore]
		public Dictionary<Denomination,int> Bills { 
			get {
				Dictionary<Denomination, int> bills = new Dictionary<Denomination, int>();
				bills.Add(Denomination.One, Ones);
				bills.Add(Denomination.Five, Fives);
				bills.Add(Denomination.Ten, Tens);
				bills.Add(Denomination.Twenty, Twenties);
				bills.Add(Denomination.Fifty, Fifties);
				bills.Add(Denomination.Hundred, Hundreds);
				return bills;
			} 
		}

		public string Id { get; set; }
		public int Ones { get; set; }
		public int Fives { get; set; }
		public int Tens { get; set; }
		public int Twenties { get; set; }
		public int Fifties { get; set; }
		public int Hundreds { get; set; }
		#endregion

		public TellerMachine()
		{

		}

		public bool RequestMoney(Denomination denomination, int amount)
		{
			if(!canDenominationServiceAmount(denomination,amount))
			{
				return false;
			}
			int billsNeeded = amount / (int)denomination;
			if(billsNeeded<=Bills[denomination])
			{
				switch(denomination)
				{
					case Denomination.One:
						Ones -= billsNeeded;
						break;
					case Denomination.Five:
						Fives -= billsNeeded;
						break;
					case Denomination.Ten:
						Tens -= billsNeeded;
						break;
					case Denomination.Twenty:
						Twenties -= billsNeeded;
						break;
					case Denomination.Fifty:
						Fifties -= billsNeeded;
						break;
					case Denomination.Hundred:
						Fifties -= billsNeeded;
						break;
				}
				return true;
			}
			return false;
		}
		
		/// <summary>
		/// Replaces the bills in the ATM with the quantity of bills of each denomination in the RestockRequest object.
		/// </summary>
		/// <param name="bills">An object identifying the quantity of bills to stock in each denomination</param>
		public void Stock(RestockRequest bills)
		{
			Ones = bills.Ones;
			Fives = bills.Fives;
			Tens = bills.Tens;
			Twenties = bills.Twenties;
			Fifties = bills.Fifties;
			Hundreds = bills.Hundreds;
		}

		/// <summary>
		/// Adds the bills in the ATM with the quantity of bills of each denomination in the RestockRequest object.
		/// </summary>
		/// <param name="bills">An object identifying the quantity of bills to add to the stock of each denomination</param>
		public void Restock(RestockRequest bills)
		{
			Ones += bills.Ones;
			Fives += bills.Fives;
			Tens += bills.Tens;
			Twenties += bills.Twenties;
			Fifties += bills.Fifties;
			Hundreds += bills.Hundreds;
		}
		#region Helpers

		/// <summary>
		/// Determines whether or not the type of bill requested (Denomination) can be used to 
		/// return back the amount of money requested.
		/// </summary>
		/// <param name="denomination">The Denomination bill type, ex. One, Fifty, etc.</param>
		/// <param name="amount">The integer amount of money requested</param>
		/// <returns>Whether the denomination requested can service the amount of money by itself</returns>
		private bool canDenominationServiceAmount(Denomination denomination, int amount)
		{
			if (amount % (int)denomination != 0)
			{
				return false; // Cannot get 101 dollars from hundos (hundreds)
			}
			return true;
		}
		#endregion
	}
}
