using Domain.Enum.v1;
using Domain.Interfaces.v1.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Domain.Commands.v1.Lead.AcceptLead
{
    public class AcceptLeadCommandHandler : IRequestHandler<AcceptLeadCommand>
    {
        private readonly ILeadRepository _leadRepository;
        private readonly ILogger<AcceptLeadCommandHandler> _logger;

        public AcceptLeadCommandHandler(
            ILeadRepository leadRepository,
            ILogger<AcceptLeadCommandHandler> logger)
        {
            _leadRepository = leadRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(AcceptLeadCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"[AcceptLeadCommandHandler] Initializing AcceptLead Id: {request.Id}");
            try
            {
                var lead = _leadRepository.GetById(request.Id);

                if (lead == null)
                {
                    _logger.LogInformation($"[AcceptLeadCommandHandler] Lead not found Id: {request.Id}");
                    throw new Exception("Lead not found");
                }

                if (lead.Status == StatusEnum.Invited)
                {
                    if (lead.Price > 500)
                        lead.Price = lead.Price * (decimal)0.9;

                    lead.Status = StatusEnum.Accepted;
                    _leadRepository.Update(lead);
                    return Unit.Value;
                }
                else
                {
                    _logger.LogInformation($"[AcceptLeadCommandHandler] Invalid Lead status for acceptance Id: {request.Id}");
                    throw new Exception("Invalid Lead status for acceptance");
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"[AcceptLeadCommandHandler] Error accepting Lead: {request.Id} | Error: {e}");
                throw;
            }
        }
    }
}