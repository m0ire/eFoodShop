using System.Web.Http;
using eFoodShop.Application.Dto;
using eFoodShop.Application.Services.Interfaces;

namespace eFoodShop.WebAPI.Controllers
{
    public class CartsController : ApiController
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public CartDto Get(int id)
        {
            return _cartService.Get(id);
        }

        [HttpPut]
        public void Add(int id, CartItemDto cartItemDto)
        {
            _cartService.Add(id, cartItemDto);
        }

        [HttpPut]
        public void Remove(int id, CartItemDto cartItemDto)
        {
            _cartService.Remove(id, cartItemDto);
        }
    }
}
