using System.Collections.Generic;
using eFoodShop.Domain.Entities;
using eFoodShop.Domain.SeedWork.Specification;

namespace eFoodShop.Domain.SeedWork.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetWithCart(int id);
        IEnumerable<Customer> GetWithCart(Specification<Customer> specification);
    }
}
