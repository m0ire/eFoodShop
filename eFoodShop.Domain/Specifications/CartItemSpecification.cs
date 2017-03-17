using System;
using System.Linq.Expressions;
using eFoodShop.Domain.Entities;
using eFoodShop.Domain.SeedWork.Specification;

namespace eFoodShop.Domain.Specifications
{
    public class CartItemByProductSpecification : Specification<CartItem>
    {
        private readonly Product _product;

        public CartItemByProductSpecification(Product product)
        {
            _product = product;
        }

        public override Expression<Func<CartItem, bool>> ToExpression()
        {
            return cartItem => cartItem.Product == _product;
        }
    }
}