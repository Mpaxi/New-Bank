﻿using NB.CheckingAccountTransaction.Domain.Entities;
using NB.SupportPackages.DataBase.Contract;

namespace NB.CheckingAccountTransaction.Domain.Contract
{
    public interface ICheckingAccountTransactionStatusRepository : IGenericRepository<CheckingAccountTransactionStatus>
    {
    }
}
