using System.Collections.Generic;

namespace eFoodShop.Application.Dto
{
    public class CartDto
    {
        public IEnumerable<CartItemDto> CartItems { get; set; }
    }
}