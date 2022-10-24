using Domain.Commands.v1.Lead.AcceptLead;
using Domain.Commands.v1.Lead.DeclineLead;
using Domain.Commands.v1.Lead.GetLeadByStatus;
using Domain.Entities.v1;
using Domain.Enum.v1;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("v1/lead/accept")]
        public async Task<Unit> AcceptLead([FromBody] AcceptLeadCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        [Route("v1/lead/decline")]
        public async Task<Unit> DeclineLead([FromBody] DeclineLeadCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet]
        [Route("v1/lead/status")]
        public async Task<IEnumerable<LeadModel>> GetByStatus(StatusEnum status)
        {
            return await _mediator.Send(new GetLeadByStatusCommand { Status = status });
        }
    }
}
