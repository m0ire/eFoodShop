using System;
using System.Text.RegularExpressions;
using eFoodShop.Domain.SeedWork;

namespace eFoodShop.Domain.Entities
{
    public class Customer : Entity
    {
        public string Name {
            get
            {
                return _name;
            }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException();
                if(value.Length < 4)
                    throw new ArgumentOutOfRangeException();

                _name = value;
            }
        }

        public string Password
        {
            get { return _password; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException();

                if (Regex.IsMatch(value, @"^(.{0,7}|[^0-9]*|[^A-Z])$"))
                    throw new FormatException();

                _password = value;
            }
        }

        public string Email
        {
            get { return _email; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException();

                if (!Regex.IsMatch(value, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                    throw new FormatException();

                _email = value;
            }
        }

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

        private string _name;
        private Cart _cart;
        private string _password;
        private string _email;

        [Obsolete("Only for model binders and EF, don\'t use it in your code", true)]
        public Customer() { }

        public Customer(int id, string name, string email, string password) : base(id)
        {
            Name = name;
            Email = email;
            Password = password;

            Cart = new Cart(this);
        }
    }
}
