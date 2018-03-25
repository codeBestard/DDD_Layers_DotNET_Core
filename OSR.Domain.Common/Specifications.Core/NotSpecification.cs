using System;
using System.Linq.Expressions;

namespace OSR.Domain.Common.Specifications.Core
{
    public class NotSpecification<T> : CompositeSpecification<T>
    {
        ISpecification<T> other;
        public NotSpecification( ISpecification<T> other )
        {
            this.other = other;
        }
        public override bool IsSatisfiedBy( T candidate ) => !other.IsSatisfiedBy( candidate );
    }

    public abstract class Specification<T> : CompositeSpecification<T>
    {
        public abstract Expression<Func<T , bool>> AsExpression( );

        public override bool IsSatisfiedBy( T candidate )
        {
            return AsExpression().Compile()( candidate );
        }
    }

}