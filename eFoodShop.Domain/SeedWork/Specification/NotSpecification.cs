using System;
using System.Linq;
using System.Linq.Expressions;

namespace eFoodShop.Domain.SeedWork.Specification
{
    public class NotSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _originalSpecification;


        public NotSpecification(Specification<T> originalSpecification)
        {
            _originalSpecification = originalSpecification;
        }


        public override Expression<Func<T, bool>> ToExpression()
        {
            var originalExpression = _originalSpecification.ToExpression();

            var notExpression = Expression.Not(originalExpression.Body);

            return Expression.Lambda<Func<T, bool>>(notExpression, originalExpression.Parameters.Single());
        }
    }
}