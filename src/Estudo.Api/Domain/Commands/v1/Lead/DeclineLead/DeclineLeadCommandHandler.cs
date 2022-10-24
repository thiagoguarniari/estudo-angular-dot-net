using Domain.Enum.v1;
using Domain.Interfaces.v1.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Domain.Commands.v1.Lead.DeclineLead
{
    public class DeclineLeadCommandHandler : IRequestHandler<DeclineLeadCommand>
    {
        private readonly ILeadRepository _leadRepository;
        private readonly ILogger<DeclineLeadCommandHandler> _logger;

        public DeclineLeadCommandHandler(
            ILeadRepository leadRepository,
            ILogger<DeclineLeadCommandHandler> logger)
        {
            _leadRepository = leadRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeclineLeadCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"[DeclineLeadCommandHandler] Initializing DeclineLead Id: {request.Id}");
            try
            {
                var lead = _leadRepository.GetById(request.Id);

                if (lead == null)
                {
                    _logger.LogInformation($"[DeclineLeadCommandHandler] Lead not found Id: {request.Id}");
                    throw new Exception("Lead not found");
                }

                if (lead.Status == StatusEnum.Invited)
                {
                    lead.Status = StatusEnum.Declined;
                    _leadRepository.Update(lead);
                    return Unit.Value;
                }
                else
                {
                    _logger.LogInformation($"[DeclineLeadCommandHandler] Invalid Lead status for decline Id: {request.Id}");
                    throw new Exception("Invalid Lead status for decline");
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"[DeclineLeadCommandHandler] Error declining Lead: {request.Id} | Error: {e}");
                throw;
            }
        }
    }
}