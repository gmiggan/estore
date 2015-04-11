using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace estore.Models
{
    public class Customer
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("ApplicationUser")]
        public int customerId { get; set; }
        public String Name { get; set; }
        public String billingaddress1 { get; set; }
        public String billingaddress2 { get; set; }
        public String billingaddress3 { get; set; }
        public String postaladdress1 { get; set; }
        public String postaladdress2 { get; set; }
        public String postaladdress3 { get; set; }


    }
}