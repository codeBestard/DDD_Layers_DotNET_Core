using System;

using System.Linq.Expressions;


namespace OSR.Domain.Common.Specifications.Core
{
    public class ExpressionSpecification<T> : CompositeSpecification<T>
    {
        private readonly Expression<Func<T , bool>> _expression;
        private ExpressionSpecification( Expression<Func<T , bool>> expression )
        {
            if( expression is null )
                throw new ArgumentNullException();
            else
                _expression = expression;
        }

        private  Expression<Func<T , bool>> AsExpression( )
        {
            return _expression;
        }

        public override bool IsSatisfiedBy( T candidate )
        {
            return AsExpression().Compile()( candidate );
        }

        public static ExpressionSpecification<T> Create( Func<T , bool> func )
        {
            // create expression
            Expression<Func<T , bool>> expr = arg => func( arg );

            return new ExpressionSpecification<T>( expr );
        }

    }
}
