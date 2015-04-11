using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using estore.Models;
using System.ComponentModel.DataAnnotations;

namespace estore.Models
{
    
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public String Manufacturer { get; set; }
        public String Title { get; set; }
        public Double Price { get; set; }
        public Category Category { get; set; }
        public String imageRef { get; set; }
        public int stock { get; set; }
        public virtual List<ReviewModel> reviews { get; set; }
    }
}