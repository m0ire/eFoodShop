using System;
using eFoodShop.Domain.SeedWork;

namespace eFoodShop.Domain.Entities
{
    public class Customer : Entity
    {
        public string Name { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        public Cart Cart
        {
            get
            {
                return _cart;
            }
            private set
            {
                if(_cart != null)
                    throw new Exception();

                _cart = value;
            }
        }

        private Cart _cart;

        [Obsolete("Only for model binders and EF, don\'t use it in your code", true)]
        public Customer() { }

        public Customer(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;

            Cart = new Cart(this);

            if (!IsValid())
                throw new Exception();
        }

        public bool IsValid()
        {
            return IsValidName() && IsValidEmail() && IsValidPassword();
        }

        public bool IsValidName()
        {
            return true;
        }

        public bool IsValidEmail()
        {
            return true;
        }

        public bool IsValidPassword()
        {
            return true;
        }

        public void AddToCart(Product product, int count)
        {
            Cart.Add(product, count);
        }

        public void RemoveFromCart(Product product, int count)
        {
            Cart.Remove(product, count);
        }
    }
}
