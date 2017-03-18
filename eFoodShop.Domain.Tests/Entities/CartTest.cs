using System.Linq;
using eFoodShop.Domain.Entities;
using NUnit.Framework;

namespace eFoodShop.Domain.Tests.Entities
{
    [TestFixture]
    public class CartTest
    {
        [Test]
        public void ShoulAdd()
        {
            var cart = new Cart(new Customer(1, "qqqqq", "qqqqqq@gmail.com", "qqQqqQq11"));
            var product = new Product(1, "iphone 7s");
            cart.Add(product, 4);

            Assert.Contains(new CartItem(cart, product, 1), cart.CartItems.ToList());
        }

        [Test]
        public void ShoulAddAndRemove()
        {
            var cart = new Cart(new Customer(1, "qqqqq", "qqqqqq@gmail.com", "qqQqqQq11"));
            var product = new Product(1, "iphone 7s");
            cart.Add(product, 4);
            cart.Remove(product, 3);

            Assert.True(cart.CartItems.First().Count == 1);

            cart.Remove(product, 1);

            Assert.True(cart.CartItems.Count == 0);
        }
    }
}