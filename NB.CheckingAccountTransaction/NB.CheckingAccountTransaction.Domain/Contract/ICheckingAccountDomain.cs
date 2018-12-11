using NB.CheckingAccountTransaction.Domain.Entities;
using NB.SupportPackages.Entities.Command.CheckingAccount;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NB.CheckingAccountTransaction.Domain.Contract
{
    public interface ICheckingAccountDomain
    {
        Task<bool> AddCheckingAccount(AddCheckingAccountSucessEvent checkingAccount);
    }
}
