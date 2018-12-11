using NB.CheckingAccount.Domain.Aggregates;
using NB.CheckingAccount.Domain.Context;
using NB.CheckingAccount.Domain.Contract;
using NB.SupportPackages.DataBase.Implementation;

namespace NB.CheckingAccount.Repository.Implementation
{
    public class CheckingAccountTransactionRepository : GenericRepository<CheckingAccountTransaction>, ICheckingAccountTransactionRepository
    {
        public CheckingAccountTransactionRepository(DataContext context) : base(context)
        {
        }
    }
}
