
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using OSR.Domain.Events.Course;
using OSR.Infrastructure.Email;

namespace OSR.Application.EventHandlers.Course
{


    public class StudentEnrolledDomainEventHandler : INotificationHandler<StudentEnrolledDomainEvent>
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<StudentEnrolledDomainEventHandler> _logger;

        public StudentEnrolledDomainEventHandler( 
            IEmailService emailService , 
            ILogger<StudentEnrolledDomainEventHandler> logger )
        {
            _emailService = emailService;
            _logger = logger;
        }

        public async Task Handle( StudentEnrolledDomainEvent notification , CancellationToken cancellationToken )
        {
            _logger.LogDebug( $" Handling {notification.GetType().Name}" );

            //await _emailService.Send();

            await Task.CompletedTask;
        }
    }
}
