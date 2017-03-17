using System;
using System.Collections.Generic;
using eFoodShop.Domain.SeedWork;

namespace eFoodShop.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public ICollection<CartItem> CartItems { get; private set; }

        [Obsolete("Only for model binders and EF, don\'t use it in your code", true)]
        public Product() { }

        public Product(string name)
        {
            Name = name;
        }
    }
}