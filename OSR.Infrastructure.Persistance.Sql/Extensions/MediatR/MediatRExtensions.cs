using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace OSR.Infrastructure.Persistance.Sql.Extensions.MediatR
{
    public static class MediatRExtensions{

        public static async Task DispatchDomainEventsAsync(this IMediator mediator,
            IEnumerable<INotification> noticNotifications)
        {
            if ( noticNotifications is null )
            {
                throw new ArgumentNullException(nameof(noticNotifications));
            }

            var tasks = noticNotifications
                .Select( async ( domainEvent ) => {
                    await mediator.Publish<INotification>( domainEvent );
                } );

            await Task.WhenAll( tasks );
        }
    }
}