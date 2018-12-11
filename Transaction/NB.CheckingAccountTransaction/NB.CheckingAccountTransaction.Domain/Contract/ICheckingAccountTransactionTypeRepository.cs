using NB.CheckingAccountTransaction.Domain.Entities;
using NB.SupportPackages.DataBase.Contract;

namespace NB.CheckingAccountTransaction.Domain.Contract
{
    public interface ICheckingAccountTransactionTypeRepository : IGenericRepository<CheckingAccountTransactionType>
    {
    }
}
