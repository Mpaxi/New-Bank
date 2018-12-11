using NB.SupportPackages.DataBase.Contract;

namespace NB.CheckingAccount.Domain.Contract
{
    public interface ICheckingAccountRepository : IGenericRepository<Aggregates.CheckingAccount>
    {
    }
}
