using NB.CheckingAccountTransaction.Domain.Contract;
using NB.CheckingAccountTransaction.Domain.Entities;
using NB.CheckingAccountTransaction.Repository.Context;
using NB.SupportPackages.DataBase.Implementation;

namespace NB.CheckingAccountTransaction.Repository.Implementation
{
    public class CurrencyRepository : GenericRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(DataContext context) : base(context)
        {
        }
    }
}