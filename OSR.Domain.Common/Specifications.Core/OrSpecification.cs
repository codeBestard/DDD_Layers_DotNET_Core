namespace OSR.Domain.Common.Specifications.Core
{
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        ISpecification<T> left;
        ISpecification<T> right;

        public OrSpecification( ISpecification<T> left , ISpecification<T> right )
        {
            this.left = left;
            this.right = right;
        }

        public override bool IsSatisfiedBy( T candidate ) => left.IsSatisfiedBy( candidate ) || right.IsSatisfiedBy( candidate );
    }
}