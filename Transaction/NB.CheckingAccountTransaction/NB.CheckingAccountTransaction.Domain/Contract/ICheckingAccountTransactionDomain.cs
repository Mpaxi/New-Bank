using NB.SupportPackages.Entities.Command.CheckingAccountTransaction;
using NB.SupportPackages.Entities.Transport;
using System.Threading.Tasks;

namespace NB.CheckingAccountTransaction.Domain.Contract
{
    public interface ICheckingAccountTransactionDomain
    {
        Task<TransportEntity> AddInternalTransaction(AddInternalTransactionCommand Command);
        Task<TransportEntity> AddCardTransaction(AddCreditCardTransactionCommand Event);
        Task<TransportEntity> CreditAccountTransaction(AddInternalTransactionSucessEvent Event);
    }
}
