using System.Collections.Generic;
using System.Threading.Tasks;

namespace OSR.Infrastructure.Email
{
    public class EmailService : IEmailService
    {
        public async Task Send(List<string> recipients, string sender, string subject, string body)
        {
            await Task.CompletedTask;
        }
    }
}