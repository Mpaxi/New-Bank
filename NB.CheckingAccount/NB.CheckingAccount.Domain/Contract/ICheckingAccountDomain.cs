using NB.CheckingAccount.Domain.Commands;
using NB.SupportPackages.Entities.Transport;
using System;
using System.Threading.Tasks;

namespace NB.CheckingAccount.Domain.Contract
{
    public interface ICheckingAccountDomain
    {
        Task<TransportEntity> InternalTransaction(AddCheckingAccountTransactionCommand Command);
        TransportEntity GetStatement(Guid CheckingAccountID);
        Task<Aggregates.CheckingAccount> AddCheckingAccount(Aggregates.CheckingAccount CheckingAccount);
    }
}
