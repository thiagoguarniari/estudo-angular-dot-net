using MediatR;

namespace Domain.Commands.v1.Lead.AcceptLead
{
    public class AcceptLeadCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}