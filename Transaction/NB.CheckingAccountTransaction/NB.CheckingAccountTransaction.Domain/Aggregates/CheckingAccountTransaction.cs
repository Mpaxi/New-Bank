using NB.CheckingAccountTransaction.Domain.Entities;
using NB.SupportPackages.DataBase.Base;
using System;

namespace NB.CheckingAccountTransaction.Domain.Aggregates
{
    public class CheckingAccountTransaction : EntityBase
    {
        public double TransactionValue { get; set; }
        public Guid TracedID { get; set; }
        public Guid CheckingAccountTransactionStatusID { get; set; }
        public CheckingAccountTransactionStatus CheckingAccountTransactionStatus { get; set; }
        public Guid CheckingAccountTransactionTypeID { get; set; }
        public CheckingAccountTransactionType CheckingAccountTransactionType { get; set; }
        public Guid CheckingAccountID { get; set; }
        public CheckingAccount CheckingAccount { get; set; }
        public Guid CurrencyTypeID { get; set; }
        public Currency CurrencyType { get; set; }
    }
}
