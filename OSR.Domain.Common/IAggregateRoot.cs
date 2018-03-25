
using System.Collections.Generic;
using MediatR;

namespace OSR.Domain.Common
{
    public interface IAggregateRoot
    {
        IList<INotification> DomainEvents { get; }
        void AddDomainEvent(INotification eventItem);
        void RemoveDomainEvent(INotification eventItem);

        void ClearEvents();
    }
}