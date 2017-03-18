using eFoodShop.Domain.Entities;
using eFoodShop.Domain.SeedWork.Repositories;
using eFoodShop.Infrastructure.EF.Repositories;

namespace eFoodShop.Infrastructure.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly eFoodShopContext _context;

        public ICustomerRepository Customers { get; }
        public ICartRepository Carts { get; }
        public IRepository<CartItem> CartItems { get; }
        public IRepository<Product> Products { get; }

        public UnitOfWork()
        {
            _context = new eFoodShopContext();

            Customers = new CustomerRepository(_context);
            Carts = new CartRepository(_context);
            CartItems = new Repository<CartItem>(_context);
            Products = new Repository<Product>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
