using NB.CheckingAccountTransaction.Domain.Contract;
using NB.CheckingAccountTransaction.Repository.Context;
using NB.SupportPackages.DataBase.Implementation;

namespace NB.CheckingAccountTransaction.Repository.Implementation
{
    public class CheckingAccountTransactionRepository : GenericRepository<Domain.Aggregates.CheckingAccountTransaction>, ICheckingAccountTransactionRepository
    {
        public CheckingAccountTransactionRepository(DataContext context) : base(context)
        {

        }
    }
}
