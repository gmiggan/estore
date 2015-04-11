using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace estore.Models
{
    public class MasterCard : CreditCard
    {
        public MasterCard(String number, String month, String year) : base (number, month, year){}
	
	public MasterCard(string p1, int p2, int p3)
    {
        
        base.cardNumber = p1;
        base.expiryMonth = p2;
        base.expiryYear = p3;
    }


	protected override bool checkNumberOfDigits() {
		int numberOfDigits = cardNumber.Length;
		if (numberOfDigits == 16)
			return true;
		else
			return false;	
	}

	protected override bool checkValidPrefix() {
		String firstDigit = cardNumber.Substring(0, 1);
		String nextDigit = cardNumber.Substring(1, 2);
		String validDigits = "12345";

		if (firstDigit.Equals("5") && (validDigits.IndexOf(nextDigit) >= 0))
			return true;
		else
			return false;
	}
	
}
    }
