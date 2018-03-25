using System.Collections.Generic;
using System.Threading.Tasks;

namespace OSR.Infrastructure.Email
{
    public interface IEmailService
    {
        Task Send(List<string> recipients, string sender, string subject, string body);
    }
}
