using System.Collections.Generic;

namespace eFoodShop.Application.Dto
{
    public class CartDto
    {
        public int Id { get; set; }
        public IEnumerable<CartItemDto> CartItems { get; set; }
    }
}