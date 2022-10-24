using Domain.Entities.v1;
using Domain.Interfaces.v1.Services;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Service
{
    public class SendEmailService : ISendEmailService
    {
        private readonly ILogger<SendEmailService> _logger;

        public SendEmailService(ILogger<SendEmailService> logger)
        {
            _logger = logger;
        }

        public void SendEmail(LeadModel leadModel)
        {
            _logger.LogInformation($"[SendEmailService] Sending email to: {leadModel.Email}");
        }
    }
}