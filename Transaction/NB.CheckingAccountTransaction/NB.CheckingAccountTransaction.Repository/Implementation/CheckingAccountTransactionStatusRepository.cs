using NB.CheckingAccountTransaction.Domain.Contract;
using NB.CheckingAccountTransaction.Domain.Entities;
using NB.CheckingAccountTransaction.Repository.Context;
using NB.SupportPackages.DataBase.Implementation;

namespace NB.CheckingAccountTransaction.Repository.Implementation
{
    public class CheckingAccountTransactionStatusRepository : GenericRepository<CheckingAccountTransactionStatus>, ICheckingAccountTransactionStatusRepository
    {
        public CheckingAccountTransactionStatusRepository(DataContext context) : base(context)
        {
        }
    }
}