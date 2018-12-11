using NB.CheckingAccountTransaction.Domain.Contract;
using NB.CheckingAccountTransaction.Domain.Entities;
using NB.CheckingAccountTransaction.Repository.Context;
using NB.SupportPackages.DataBase.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NB.CheckingAccountTransaction.Repository.Implementation
{
    public class CheckingAccountRepository : GenericRepository<CheckingAccount>, ICheckingAccountRepository
    {
        public CheckingAccountRepository(DataContext context) : base(context)
        {
        }
    }
}
