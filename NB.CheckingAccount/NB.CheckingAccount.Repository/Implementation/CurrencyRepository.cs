using NB.CheckingAccount.Domain.Context;
using NB.CheckingAccount.Domain.Contract;
using NB.CheckingAccount.Domain.Entities;
using NB.SupportPackages.DataBase.Implementation;

namespace NB.CheckingAccount.Repository.Implementation
{
    public class CurrencyRepository : GenericRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(DataContext context) : base(context)
        {
        }
    }
}