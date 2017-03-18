using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using eFoodShop.Domain.Entities;
using eFoodShop.Domain.SeedWork.Repositories;
using eFoodShop.Domain.SeedWork.Specification;

namespace eFoodShop.Infrastructure.EF.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private readonly eFoodShopContext _eFoodShopContext;

        public CartRepository(eFoodShopContext foodShopContext) : base(foodShopContext)
        {
            _eFoodShopContext = foodShopContext;
        }

        public Cart GetWithCartItems(int id)
        {
            var include = _eFoodShopContext.Carts.Include(p => p.CartItems.Select(q => q.Product));
            var cart = include.First(p => p.Id == id);
            return cart;
        }

        public IEnumerable<Cart> GetWithCartItems(Specification<Cart> specification)
        {
            return _eFoodShopContext.Carts.Include(p => p.CartItems).Where(specification.ToExpression());
        }
    }
}