using System;
using System.Collections.Generic;
using eFoodShop.Domain.SeedWork;

namespace eFoodShop.Domain.Entities
{
    public class Product : Entity
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException();

                if(value.Length < 4)
                    throw new ArgumentOutOfRangeException();

                _name = value;
            }
        }

        public ICollection<CartItem> CartItems { get; private set; }

        [Obsolete("Only for model binders and EF, don\'t use it in your code", true)]
        public Product() { }

        public Product(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}