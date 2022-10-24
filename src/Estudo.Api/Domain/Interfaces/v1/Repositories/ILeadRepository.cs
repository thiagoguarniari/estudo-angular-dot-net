using Domain.Entities.v1;
using Domain.Enum.v1;

namespace Domain.Interfaces.v1.Repositories
{
    public interface ILeadRepository
    {
        IEnumerable<LeadModel> GetAll();
        IEnumerable<LeadModel> GetByAcceptedStatus(StatusEnum acceptedStatus);
        LeadModel GetById(Guid id);
        LeadModel Update(LeadModel leadModel);
    }
}