

namespace OSR.Domain.Common.Specifications.Core
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy( T candidate );
        ISpecification<T> And( ISpecification<T> other );
        ISpecification<T> AndNot( ISpecification<T> other );
        ISpecification<T> Or( ISpecification<T> other );
        ISpecification<T> OrNot( ISpecification<T> other );
        ISpecification<T> Not( );
    }
}
