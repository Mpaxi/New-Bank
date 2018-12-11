using NB.CheckingAccountTransaction.Domain.Contract;
using NB.CheckingAccountTransaction.Domain.Entities;
using NB.SupportPackages.Entities.Command.CheckingAccount;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NB.CheckingAccountTransaction.Domain.Implementation
{
    public class CheckingAccountDomain : ICheckingAccountDomain
    {
        public readonly ICheckingAccountRepository checkingAccountRepository;
        public CheckingAccountDomain(ICheckingAccountRepository checkingAccountRepository)
        {
            this.checkingAccountRepository = checkingAccountRepository;
        }  
        public async Task<bool> AddCheckingAccount(AddCheckingAccountSucessEvent checkingAccount)
        {

            try
            {
                CheckingAccount NewAccount = new CheckingAccount()
                {
                    ID = checkingAccount.ID,
                    Active = checkingAccount.Active,
                    Created = checkingAccount.Created,
                    Updated = checkingAccount.Updated,
                    StatusID = checkingAccount.StatusID
                };

                await checkingAccountRepository.AddAsync(NewAccount);
                await checkingAccountRepository.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
