using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace estore.Models
{
    public class AmericanExpressCard : CreditCard {
       
	public AmericanExpressCard(String number, String month, String year) : base(number, month, year){}

    public AmericanExpressCard(string p1, int p2, int p3)
    {


        base.cardNumber = p1;
        base.expiryMonth = p2;
        base.expiryYear = p3;
    }

    protected override bool checkNumberOfDigits()
    {
		int numberOfDigits = cardNumber.Length;
		if (numberOfDigits == 15)
			return true;
		else
			return false;
	}

	protected override bool checkValidPrefix() {
		String prefix = cardNumber.Substring(0, 2);
		if (prefix.Equals("34") || prefix.Equals("37"))
			return true;
		else
			return false;
	}
	
}
}