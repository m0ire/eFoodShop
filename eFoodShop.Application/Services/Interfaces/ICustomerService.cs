using eFoodShop.Application.Dto;

namespace eFoodShop.Application.Services.Interfaces
{
    public interface ICustomerService
    {
        CustomerDto Get(int id);
        void Register(CustomerDto customer);
        void AddToCart(int id, CartItemDto cartItemDto);
        void RemoveFromCart(int id, CartItemDto cartItemDto);
    }
}