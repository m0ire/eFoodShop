using eFoodShop.Application.Dto;

namespace eFoodShop.Application.Services.Interfaces
{
    public interface ICartService
    {
        CartDto Get(int id);
        void Add(int id, CartItemDto cartItemDto);
        void Remove(int id, CartItemDto cartItemDto);
    }
}