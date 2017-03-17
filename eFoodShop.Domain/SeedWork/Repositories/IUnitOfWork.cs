using System;
using eFoodShop.Domain.Entities;

namespace eFoodShop.Domain.SeedWork.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IRepository<Cart> Carts { get; }
        IRepository<CartItem> CartItems { get; }
        IRepository<Product> Products { get; }
        int Complete();
    }
}
