using NB.SupportPackages.DataBase.Contract;

namespace NB.CheckingAccountTransaction.Domain.Contract
{
    public interface ICheckingAccountTransactionRepository : IGenericRepository<Aggregates.CheckingAccountTransaction>
    {
    }
}
