using System.Web.Http;
using eFoodShop.Application.Dto;
using eFoodShop.Application.Services.Interfaces;

namespace eFoodShop.WebAPI.Controllers
{
    [RoutePrefix("api/v1/customers")]
    public class CustomersController : ApiController
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public CustomerDto Get(int id)
        {
            var customerDto = _customerService.Get(id);

            return customerDto;
        }

        public int Post(CustomerDto customerDto)
        {
            _customerService.Register(customerDto);
            return customerDto.Id;
        }

        [Route("{id}/add-to-cart")]
        public void AddToCart(int id, CartItemDto cartItemDto)
        {
            _customerService.AddToCart(id, cartItemDto);
        }

        [Route("{id}/remove-from-cart")]
        public void RemoveFromCart(int id, CartItemDto cartItemDto)
        {
            _customerService.RemoveFromCart(id, cartItemDto);
        }
    }
}
