using System.Collections.Generic;
using MediatR;

namespace OSR.Domain.Common
{
    public sealed class EmptyAggregateRoot : IAggregateRoot
    {
        public static readonly EmptyAggregateRoot Instance = new EmptyAggregateRoot();

        static EmptyAggregateRoot( ){}
        private EmptyAggregateRoot()
        {
            DomainEvents = new List<INotification>();
        }

        public IList<INotification> DomainEvents { get; }
        public void AddDomainEvent(INotification eventItem){}
        public void RemoveDomainEvent(INotification eventItem){}
        public void ClearEvents(){}
    }
}