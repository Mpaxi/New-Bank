using NB.CheckingAccountTransaction.Domain.Contract;
using NB.CheckingAccountTransaction.Domain.Entities;
using NB.CheckingAccountTransaction.Repository.Context;
using NB.SupportPackages.DataBase.Implementation;

namespace NB.CheckingAccountTransaction.Repository.Implementation
{
    public class CheckingAccountTransactionTypeRepository : GenericRepository<CheckingAccountTransactionType>, ICheckingAccountTransactionTypeRepository
    {
        public CheckingAccountTransactionTypeRepository(DataContext context) : base(context)
        {
        }
    }
}