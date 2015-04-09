﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using estore.Models;

namespace estore.Controllers
{
    public class Item
    {
        private Product product = new Product();

        public Product Product
        {
            get { return product; }
            set { product = value; }
        }
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public Item()
        { }

        public Item(Product product, int quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }
    }
}