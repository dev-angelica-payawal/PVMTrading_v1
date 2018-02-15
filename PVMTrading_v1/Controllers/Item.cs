using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PVMTrading_v1.Models;

namespace PVMTrading_v1.Controllers
{
    public class Item
    {
        public Product product = new Product();

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
            this.Product = product;
            this.quantity = quantity;

        }
    }
}