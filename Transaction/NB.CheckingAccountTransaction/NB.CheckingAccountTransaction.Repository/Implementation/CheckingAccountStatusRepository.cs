using NB.CheckingAccountTransaction.Domain.Contract;
using NB.CheckingAccountTransaction.Domain.Entities;
using NB.CheckingAccountTransaction.Repository.Context;
using NB.SupportPackages.DataBase.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NB.CheckingAccountTransaction.Repository.Implementation
{
    public class CheckingAccountStatusRepository : GenericRepository<CheckingAccountStatus>, ICheckingAccountStatusRepository
    {
        public CheckingAccountStatusRepository(DataContext context) : base(context)
        {
        }
    }
}
