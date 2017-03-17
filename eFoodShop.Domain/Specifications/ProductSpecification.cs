using System;
using System.Linq.Expressions;
using eFoodShop.Domain.Entities;
using eFoodShop.Domain.SeedWork.Specification;

namespace eFoodShop.Domain.Specifications
{
    public class ProductSpecification : Specification<Product>
    {
        private readonly int _id;

        public ProductSpecification(int id)
        {
            _id = id;
        }

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return product => product.Id == _id;
        }
    }
}