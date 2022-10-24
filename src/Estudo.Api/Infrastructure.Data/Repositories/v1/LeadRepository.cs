using Domain.Entities.v1;
using Domain.Enum.v1;
using Domain.Interfaces.v1.Repositories;

namespace Infrastructure.Data.Repositories.v1
{
    public class LeadRepository : ILeadRepository
    {
        private readonly DatabaseContext _context;
        public LeadRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<LeadModel> GetAll()
        {
            return _context.Lead;
        }

        public IEnumerable<LeadModel> GetByAcceptedStatus(StatusEnum status)
        {
            var teste = _context.Lead.Where(x => x.Status == status).ToList();
            return _context.Lead.Where(x => x.Status == status);
        }

        public LeadModel GetById(Guid id)
        {
            return _context.Lead.Find(id);
        }

        public LeadModel Update(LeadModel leadModel)
        {
            leadModel.ModifiedUser = "Admin";
            leadModel.ModifiedDate = DateTime.Now;
            var lead = _context.Lead.Attach(leadModel);
            lead.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return leadModel;
        }
    }
}