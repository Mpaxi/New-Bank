using NB.CheckingAccount.Domain.Context;
using NB.CheckingAccount.Domain.Contract;
using NB.SupportPackages.DataBase.Implementation;

namespace NB.CheckingAccount.Repository.Implementation
{
    public class CheckingAccountRepository : GenericRepository<Domain.Aggregates.CheckingAccount>, ICheckingAccountRepository
    {
        public CheckingAccountRepository(DataContext context) : base(context)
        {
        }
    }
}

