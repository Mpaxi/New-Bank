using NB.CheckingAccount.Domain.Entities;
using NB.SupportPackages.DataBase.Contract;

namespace NB.CheckingAccount.Domain.Contract
{
    public interface ICheckingAccountTransactionTypeRepository : IGenericRepository<CheckingAccountTransactionType>
    {
    }
}
