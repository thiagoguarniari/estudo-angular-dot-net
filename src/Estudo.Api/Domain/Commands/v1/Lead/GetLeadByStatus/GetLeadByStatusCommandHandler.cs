using Domain.Entities.v1;
using Domain.Interfaces.v1.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Domain.Commands.v1.Lead.GetLeadByStatus
{
    public class GetLeadByStatusCommandHandler : IRequestHandler<GetLeadByStatusCommand, IEnumerable<LeadModel>>
    {
        private readonly ILeadRepository _leadRepository;
        private readonly ILogger<GetLeadByStatusCommandHandler> _logger;

        public GetLeadByStatusCommandHandler(
            ILeadRepository leadRepository,
            ILogger<GetLeadByStatusCommandHandler> logger)
        {
            _leadRepository = leadRepository;
            _logger = logger;
        }

        Task<IEnumerable<LeadModel>> IRequestHandler<GetLeadByStatusCommand, IEnumerable<LeadModel>>.Handle(GetLeadByStatusCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"[GetLeadByAcceptedStatusCommandHandler] Initializing GetByAcceptedStatus Status: {request.Status}");
            try
            {
                return Task.FromResult(_leadRepository.GetByAcceptedStatus(request.Status));
            }
            catch (Exception e)
            {
                _logger.LogError($"[GetLeadByAcceptedStatusCommandHandler] Error searching for Leads: {request.Status} | Error: {e}");
                throw;
            }
        }
    }
}