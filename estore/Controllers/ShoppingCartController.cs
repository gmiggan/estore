﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using estore.Models;

namespace estore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductId == id)
                {
                    return i;
                }    
            }
            return -1;
        }

        public ActionResult Delete(int id)
        {
            int index = isExisting(id);
            List<Item> cart = (List<Item>)Session["cart"];
            cart.RemoveAt(index);
            return View("Cart");

        }

        public ActionResult OrderNow(int id)
        {
            if(Session["cart"]==null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(db.Products.Find(id), 1));
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];

                int index = isExisting(id);
                if(index == -1)
                {
                    cart.Add(new Item(db.Products.Find(id), 1));
                }
                else
                {
                    cart[index].Quantity++;
                }
                Session["cart"] = cart;
                
            }
            return View("Cart");
        }
    }
}