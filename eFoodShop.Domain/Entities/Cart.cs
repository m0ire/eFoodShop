using System;
using System.Collections.Generic;
using System.Linq;
using eFoodShop.Domain.SeedWork;
using eFoodShop.Domain.Specifications;

namespace eFoodShop.Domain.Entities
{
    public class Cart : Entity
    {
        public Customer Customer { get; private set; }
        public ICollection<CartItem> CartItems { get; private set; }

        [Obsolete("Only for model binders and EF, don\'t use it in your code", true)]
        public Cart() { }

        public Cart(Customer customer)
        {
            Customer = customer;
        }

        public void Add(Product product, int count)
        {
            var cartItem = CartItems.SingleOrDefault(new CartItemByProductSpecification(product).IsSatisfiedBy);
            if (cartItem == null)
            {
                cartItem = new CartItem(this, product, count);
                CartItems.Add(cartItem);
            }
            else
            {
                cartItem.SetCount(cartItem.Count + count);
            }
        }

        public void Remove(Product product, int count)
        {
            var cartItem = CartItems.Single(new CartItemByProductSpecification(product).IsSatisfiedBy);

            if (cartItem.Count - count <= 0)
                CartItems.Remove(cartItem);
            else
            {
                cartItem.SetCount(cartItem.Count - count);
            }
        }

        public void Set(Product product, int count)
        {
            var cartItem = CartItems.Single(new CartItemByProductSpecification(product).IsSatisfiedBy);

            cartItem.SetCount(count);
        }
    }
}