using NB.CheckingAccount.Domain.Context;
using NB.CheckingAccount.Domain.Contract;
using NB.CheckingAccount.Domain.Entities;
using NB.SupportPackages.DataBase.Implementation;

namespace NB.CheckingAccount.Repository.Implementation
{
    public class CheckingAccountTransactionStatusRepository : GenericRepository<CheckingAccountTransactionStatus>, ICheckingAccountTransactionStatusRepository
    {
        public CheckingAccountTransactionStatusRepository(DataContext context) : base(context)
        {
        }
    }
}