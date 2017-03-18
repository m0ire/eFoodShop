using System.Collections.Generic;
using eFoodShop.Domain.Entities;
using eFoodShop.Domain.SeedWork.Specification;

namespace eFoodShop.Domain.SeedWork.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        Cart GetWithCartItems(int id);
        IEnumerable<Cart> GetWithCartItems(Specification<Cart> specification);
    }
}