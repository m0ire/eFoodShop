using System;
using System.Linq.Expressions;
using eFoodShop.Domain.Entities;
using eFoodShop.Domain.SeedWork.Specification;

namespace eFoodShop.Domain.Specifications
{
    public class CustomerGetSpecification : Specification<Customer>
    {
        private readonly int _id;

        public CustomerGetSpecification(int id)
        {
            _id = id;
        }

        public override Expression<Func<Customer, bool>> ToExpression()
        {
            return customer => customer.Id == _id;
        }
    }
}