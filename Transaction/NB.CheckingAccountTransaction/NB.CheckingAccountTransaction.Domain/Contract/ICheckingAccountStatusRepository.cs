using NB.CheckingAccountTransaction.Domain.Entities;
using NB.SupportPackages.DataBase.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace NB.CheckingAccountTransaction.Domain.Contract
{
    public interface ICheckingAccountStatusRepository : IGenericRepository<CheckingAccountStatus>
    {
    }
}
