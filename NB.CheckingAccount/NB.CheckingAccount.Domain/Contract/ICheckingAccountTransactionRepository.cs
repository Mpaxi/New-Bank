using NB.CheckingAccount.Domain.Aggregates;
using NB.SupportPackages.DataBase.Contract;

namespace NB.CheckingAccount.Domain.Contract
{
    public interface ICheckingAccountTransactionRepository : IGenericRepository<CheckingAccountTransaction>
    {
    }
}
