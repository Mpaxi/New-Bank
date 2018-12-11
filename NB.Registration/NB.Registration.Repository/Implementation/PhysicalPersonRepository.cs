using NB.Registration.Domain.Aggregates;
using NB.Registration.Domain.Contract;
using NB.Registration.Repository.Context;
using NB.SupportPackages.DataBase.Implementation;

namespace NB.Registration.Repository.Implementation
{
    public class PhysicalPersonRepository : GenericRepository<PhysicalPerson>, IPhysicalPersonRepository
    {
        public PhysicalPersonRepository(DataContext context) : base(context)
        {
        }
    }
}
