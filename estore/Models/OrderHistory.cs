using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace estore.Models
{
    public class OrderHistory
    {
        [Key]
        public int id { get; set; }
        public ApplicationUser user { get; set; }
        public Product product { get; set; }
        public DateTime date { get; set; }
    }
}