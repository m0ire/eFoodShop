using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using eFoodShop.Domain.Entities;
using eFoodShop.Domain.SeedWork.Repositories;
using eFoodShop.Domain.SeedWork.Specification;
using eFoodShop.Domain.Specifications;

namespace eFoodShop.Infrastructure.EF.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly eFoodShopContext _eFoodShopContext;

        public CustomerRepository(eFoodShopContext foodShopContext) : base(foodShopContext)
        {
            _eFoodShopContext = foodShopContext;
        }

        public Customer GetWithCart(int id)
        {
            var include =
                _eFoodShopContext.Customers.Include(
                    p => p.Cart.CartItems.Select(cartItem => cartItem.Product));
            var customer = include.First(new CustomerGetSpecification(id).ToExpression());
            return customer;
        }

        public IEnumerable<Customer> GetWithCart(Specification<Customer> specification)
        {
            return _eFoodShopContext.Customers.Include(p => p.Cart).Where(specification.ToExpression());
        }
    }
}
