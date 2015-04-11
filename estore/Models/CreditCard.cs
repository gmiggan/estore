using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace estore.Models
{
    public abstract class CreditCard
    {
        
        public CreditCard()
        {

        }

        [Key]
        public int id { get; set; }

        public String cardNumber { get; set; }
        
        public int expiryMonth {get; set;}

        public int expiryYear { get; set; }

        public String type { get; set; }
        public virtual ApplicationUser user { get; set; }

        
        public CreditCard(String number, String month, String year)
        {
            //cardType = type;
            cardNumber = number;
            try
            {
                expiryMonth = Convert.ToInt32(month);
            }
            catch
            {
                expiryMonth = 1;
            }
            try
            {
                expiryYear = Convert.ToInt32(year);
            }
            catch
            {
                expiryYear = 2014;
            }
        }

        /* This is the validation method called from outside and which consists of a series of steps.
         * An error message will be displayed if one of the steps fails, in which case the entire
         * validation process fails. */
        public bool validate()
        {
            if (!checkExpiryDateValid())
            {
                MessageBox.Show("Invalid Expiry Date");
                
                return false;
            }
            if (!checkAllCharsDigits())
            {
                MessageBox.Show("Invalid character in credit card number");
                return false;
            }
            if (!checkNumberOfDigits())
            {
                MessageBox.Show("Invalid number of digits");
                return false;
            }
            if (!checkValidPrefix())
            {
                MessageBox.Show("Invalid prefix for card type");
                return false;
            }
            if (!checkCheckSumDigit())
            {
                MessageBox.Show("Invalid credit card number");
                return false;
            }
            return true;
        }

        /* This checks to see that the card's expiry date is after the current month and year */
        protected bool checkExpiryDateValid()
        {


            Calendar cal = new GregorianCalendar();
            
            int currentMonth = cal.GetMonth(new DateTime()) + 1;
            int currentYear = cal.GetYear(new DateTime());
           

            if (currentYear > expiryYear)
            {
                return false;
            }
            else if (currentYear == expiryYear && currentMonth > expiryMonth)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /* This checks to see that all 'digits' in the credit card number are valid */
        protected bool checkAllCharsDigits()
        {
            String validDigits = "0123456789";
            bool result = true;

            for (int i = 0; i < cardNumber.Length; i++)
            {
                if (validDigits.IndexOf(cardNumber.Substring(i, i + 1)) < 0)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        /* This checks the number of digits in the card number.
         * Different card types will have different numbers of digits.
         * Details on this and on other aspects of credit card 
         * validation at:
         * http://web.eecs.umich.edu/~bartlett/credit_card_number.html
         */
        protected abstract bool checkNumberOfDigits();

        /* Each card type will have a standard series of digits at
         * the beginning of the credit card number, called the
         * prefix. Valid prefixes vary from one type to another. 
         * More details at the link given in the comments of the 
         * previous method.
         */
        protected abstract bool checkValidPrefix();

        /* All credit card numbers use the notion of a check sum digit,
         * at the end of the string, whose value is determined by the
         * values of all the previous digits in the string. The most
         * common checksum algorithm for credit card numbers is Luhn's
         * algorithm, an implementation of which is given here.
         */
        protected bool checkCheckSumDigit()
        {
            bool result = true;
            int sum = 0;
            int multiplier = 1;
            int stringLength = cardNumber.Length;

            for (int i = 0; i < stringLength; i++)
            {
                String currentDigit = cardNumber.Substring(stringLength - i - 1, stringLength - i);
                int currentProduct = Convert.ToInt32(currentDigit) * multiplier;
                if (currentProduct >= 10)
                    sum += (currentProduct % 10) + 1;
                else
                    sum += currentProduct;
                if (multiplier == 1)
                    multiplier++;
                else
                    multiplier--;
            }
            if ((sum % 10) != 0)
                result = false;

            return result;
        }

    }
}