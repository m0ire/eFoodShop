using eFoodShop.Application.Dto;

namespace eFoodShop.Application.Services.Interfaces
{
    public interface IProductService
    {
        ProductDto Get(int id);
        void Create(ProductDto productDto);
    }
}