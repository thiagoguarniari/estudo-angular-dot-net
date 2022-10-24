using Domain.Entities.v1;

namespace Domain.Interfaces.v1.Services
{
    public interface ISendEmailService
    {
        public void SendEmail(LeadModel leadModel);
    }
}