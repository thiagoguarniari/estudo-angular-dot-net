using MediatR;

namespace Domain.Commands.v1.Lead.DeclineLead
{
    public class DeclineLeadCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}