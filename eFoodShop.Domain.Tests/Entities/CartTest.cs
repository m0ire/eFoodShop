using System.Linq;
using eFoodShop.Domain.Entities;
using eFoodShop.Domain.SeedWork;
using NUnit.Framework;
using Moq;

namespace eFoodShop.Domain.Tests.Entities
{
    [TestFixture]
    public class CartTest
    {

        [Test]
        public void ShouldCreateSuccessfully()
        {
            var customerId = 1;

            var customerMock = new Mock<Customer>(new object[] { customerId, "qqqqq", "qqqqqq@gmail.com", "qqQqqQq11" });

            var cart = new Cart(customerMock.Object);

            Assert.AreEqual(customerId, cart.Id);
            Assert.AreEqual(customerMock.Object, cart.Customer);
            Assert.IsNotNull(cart.CartItems);
            Assert.IsEmpty(cart.CartItems);
        }

        [Test]
        public void ShouldCreateFailed()
        {
            Assert.Throws<DomainException>(() =>
            {
                var cart = new Cart(null);
            });
        }


        [Test]
        public void ShouldAddNewCartItemSuccessfully()
        {
            var customer = new Customer(1, "qqqqq", "qqqqqq@gmail.com", "qqQqqQq11");
            var cart = new Cart(customer);
            var product = new Product(1, "new_product");
            var productsCount = 2;
            cart.Add(product, productsCount);
        }



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