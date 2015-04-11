using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace estore.Models
{
    public class CardDetailsModel
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("ApplicationUser")]
        public int UserID { get; set; }
        public CreditCard card { get; set; }

    }
}