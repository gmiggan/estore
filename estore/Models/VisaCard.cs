using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace estore.Models
{
    public class VisaCard : CreditCard {

        public VisaCard(String number, String month, String year) : base(number, month, year) { } 

        public VisaCard(string p1, int p2, int p3)
    {
       
        base.cardNumber = p1;
        base.expiryMonth = p2;
        base.expiryYear = p3;
    }

        public VisaCard()
        {
            
        }
	
	
	protected override bool checkNumberOfDigits() {
		int numberOfDigits = cardNumber.Length;
		if (numberOfDigits == 13 || numberOfDigits == 16)
			return true;
		else
			return false;	
	}

	protected override bool checkValidPrefix() {
		String firstDigit = cardNumber.Substring(0, 1);

		if (firstDigit.Equals("4"))
			return true;
		else
			return false;
	}
	
}
}