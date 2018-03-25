using System;

namespace OSR.Domain.Common.Exceptions
{
    public class DomainLayerException : Exception
    {
        public DomainLayerException( string message )
            : base( message )
        { }

        public DomainLayerException( string message , Exception innerException )
            : base( message , innerException )
        { }
    }
}
