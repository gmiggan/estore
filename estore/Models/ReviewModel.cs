using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace estore.Models
{
    public class ReviewModel
    {
        public int id { get; set; }
        public Product product { get; set; }
        public ApplicationUser user { get; set; }
        public int rating { get; set; }
        public String comment { get; set; }
    }
}