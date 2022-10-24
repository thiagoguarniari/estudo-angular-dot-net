using Domain.Entities.v1;
using Domain.Enum.v1;
using MediatR;

namespace Domain.Commands.v1.Lead.GetLeadByStatus
{
    public class GetLeadByStatusCommand : IRequest<IEnumerable<LeadModel>>
    {
        public StatusEnum Status { get; set; }
    }
}