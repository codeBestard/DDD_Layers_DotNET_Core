using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using OSR.Domain.Events.Course;
using OSR.Infrastructure.Email;

namespace OSR.Application.EventHandlers.Course
{
    public class StudentUnenrolledDomainEventHandler : INotificationHandler<StudentUnenrolledDomainEvent>
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<StudentUnenrolledDomainEventHandler> _logger;

        public StudentUnenrolledDomainEventHandler(
            IEmailService emailService ,
            ILogger<StudentUnenrolledDomainEventHandler> logger )
        {
            _emailService = emailService;
            _logger = logger;
        }

        public async Task Handle( StudentUnenrolledDomainEvent notification , CancellationToken cancellationToken )
        {
            _logger.LogDebug( $" Handling {notification.GetType().Name}" );

            //await _emailService.Send();

            await Task.CompletedTask;
        }
    }
}