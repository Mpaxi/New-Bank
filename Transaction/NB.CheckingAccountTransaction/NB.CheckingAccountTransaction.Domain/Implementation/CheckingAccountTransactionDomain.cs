using MessagePack;
using NB.CheckingAccountTransaction.Domain.Contract;
using NB.SupportPackages.Entities.Command.CheckingAccountTransaction;
using NB.SupportPackages.Entities.Transport;
using RedLockNet;
using StackExchange.Redis;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NB.CheckingAccountTransaction.Domain.Implementation
{
    public class saldo
    {
        public int ID { get; set; }
        public int value { get; set; }
    }
    public class CheckingAccountTransactionDomain : ICheckingAccountTransactionDomain
    {
        readonly TransportEntity ObjReturn = new TransportEntity();
        readonly ICurrencyRepository currencyRepository;
        readonly ICheckingAccountTransactionRepository checkingAccountTransactionRepository;
        readonly IConnectionMultiplexer connectionMultiplexer;
        readonly IDistributedLockFactory distributedLockFactory;

        public CheckingAccountTransactionDomain(ICurrencyRepository currencyRepository, ICheckingAccountTransactionRepository checkingAccountTransactionRepository, IConnectionMultiplexer connectionMultiplexer, IDistributedLockFactory distributedLockFactory)
        {
            this.currencyRepository = currencyRepository;
            this.checkingAccountTransactionRepository = checkingAccountTransactionRepository;
            this.connectionMultiplexer = connectionMultiplexer;
            this.distributedLockFactory = distributedLockFactory;
        }

        public async Task<TransportEntity> AddInternalTransaction(AddInternalTransactionCommand Command)
        {
            Stopwatch watch = new Stopwatch();
            IDatabase db = connectionMultiplexer.GetDatabase(0);
            double DebitCheckingAccountBalance = 0;
            // the code that you want to measure comes here
            try
            {

                Guid TracedID = Guid.NewGuid();

                if (Command.Value <= 0)
                {
                    ObjReturn.Sucess = false;
                    ObjReturn.Messages.Add("Valor deve ser maior que 0");
                    return ObjReturn;
                }

                watch.Start();
                using (var redLock = await distributedLockFactory.CreateLockAsync($"CheckingAccount:{Command.DebitCheckingAccount}", TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2), TimeSpan.FromMilliseconds(20)))
                {
                    if (redLock.IsAcquired)
                    {
                        DebitCheckingAccountBalance = await GetBalance(Command.DebitCheckingAccount, Command.CurrencyTypeID);
                        if (DebitCheckingAccountBalance < Command.Value)
                        {
                            ObjReturn.Sucess = false;
                            ObjReturn.Messages.Add("Saldo Insuficiente");
                            return ObjReturn;
                        }
                        await DebitAccountTransaction($"CheckingAccountBalance:{Command.DebitCheckingAccount}", $"CurrencyType:{Command.CurrencyTypeID}", Command.Value);

                    }
                }

                var DebitAccount = new Aggregates.CheckingAccountTransaction()
                {
                    ID = Guid.NewGuid(),
                    TracedID = TracedID,
                    CheckingAccountID = Command.DebitCheckingAccount,
                    TransactionValue = (Command.Value * -1),
                    CheckingAccountTransactionStatusID = Guid.Parse("D314587D-3EDB-4911-8B21-0249B0BB0005"),
                    CheckingAccountTransactionTypeID = Guid.Parse("30685F6D-F398-46F4-A147-2E99D7EC045A"),
                    CurrencyTypeID = Guid.Parse("6B577276-DDC9-4C8E-896A-EEE8396EFF82"),
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,
                    Active = true

                };

                await checkingAccountTransactionRepository.AddAsync(DebitAccount);

                var CreditAccount = new Aggregates.CheckingAccountTransaction()
                {
                    ID = Guid.NewGuid(),
                    TracedID = TracedID,
                    CheckingAccountID = Command.CreditCheckingAccount,
                    TransactionValue = Command.Value,
                    CheckingAccountTransactionStatusID = Guid.Parse("000C0E7B-3A34-4612-803B-B6510DDFDB26"),
                    CheckingAccountTransactionTypeID = Guid.Parse("30685F6D-F398-46F4-A147-2E99D7EC045A"),
                    CurrencyTypeID = Guid.Parse("6B577276-DDC9-4C8E-896A-EEE8396EFF82"),
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,
                    Active = true

                };
                await checkingAccountTransactionRepository.AddAsync(CreditAccount);

                await checkingAccountTransactionRepository.SaveChangesAsync();

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;

                ObjReturn.Sucess = true;
                ObjReturn.Data = true;
                ObjReturn.Messages.Add($"Tempo de execução em ms: {elapsedMs.ToString()}");
                return ObjReturn;
            }
            catch (Exception ex)
            {
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                await CreditAccountTransaction($"CheckingAccountBalance:{Command.DebitCheckingAccount}", $"CurrencyType:{Command.CurrencyTypeID}", Command.Value);

                ObjReturn.Sucess = false;
                ObjReturn.Messages.Add(ex.Message);
                ObjReturn.Data = $"Tempo de execução em ms: {elapsedMs.ToString()}";
                return ObjReturn;
            }
        }
        public async Task<TransportEntity> CreditAccountTransaction(AddInternalTransactionSucessEvent Event)
        {
            Stopwatch watch = new Stopwatch();
            IDatabase db = connectionMultiplexer.GetDatabase(0);

            var Trasaction = await checkingAccountTransactionRepository.GetAsync(w => w.TracedID.Equals(Event.TraceID)
            && w.CheckingAccountID.Equals(Event.CreditCheckingAccount)
            && w.CheckingAccountTransactionStatusID.Equals(Guid.Parse("000C0E7B-3A34-4612-803B-B6510DDFDB26")));

            try
            {
                if (Trasaction != null)
                {
                    using (var redLock = await distributedLockFactory.CreateLockAsync($"CheckingAccount:{Event.CreditCheckingAccount}", TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2), TimeSpan.FromMilliseconds(20)))
                    {
                        if (redLock.IsAcquired)
                        {

                            if (Event.Value <= 0)
                            {
                                ObjReturn.Sucess = false;
                                ObjReturn.Messages.Add("Valor deve ser maior que 0");
                                return ObjReturn;
                            }

                            await CreditAccountTransaction($"CheckingAccountBalance:{Event.CreditCheckingAccount}", $"CurrencyType:{Event.CurrencyTypeID}", Event.Value);

                        }
                    }

                    //Libero o Credito na conta
                    Trasaction.CheckingAccountTransactionStatusID = Guid.Parse("000C0E7B-3A34-4612-803B-B6510DDFDB26");

                    await checkingAccountTransactionRepository.AddAsync(Trasaction);
                    await checkingAccountTransactionRepository.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                await DebitAccountTransaction($"CheckingAccountBalance:{Event.CreditCheckingAccount}", $"CurrencyType:{Event.CurrencyTypeID}", Event.Value);
                throw;
            }



            return ObjReturn;
        }
        public async Task<TransportEntity> AddCardTransaction(AddCreditCardTransactionCommand Event)
        {
            throw new NotImplementedException();
        }
        private async Task<double> GetBalance(Guid CheckingAccountID, Guid CurrencyTypeID)
        {

            IDatabase db = connectionMultiplexer.GetDatabase(0);

            RedisValue resultado = await db.HashGetAsync($"CheckingAccountBalance:{CheckingAccountID}", $"CurrencyType:{CurrencyTypeID}");

            if (resultado.IsNull)
            {
                double BalanceByCurrencyType = checkingAccountTransactionRepository
                    .Where(w => w.CheckingAccountID.Equals(CheckingAccountID) && w.CurrencyTypeID.Equals(CurrencyTypeID))
                    .Sum(s => s.TransactionValue);

                await db.HashSetAsync($"CheckingAccountBalance:{CheckingAccountID}", $"CurrencyType:{CurrencyTypeID}", MessagePackSerializer.Serialize<double?>(BalanceByCurrencyType));

                return BalanceByCurrencyType;
            }

            return MessagePackSerializer.Deserialize<double>(resultado);
        }
        private async Task DebitAccountTransaction(string Key, string Hash,double Value)
        {
            IDatabase db = connectionMultiplexer.GetDatabase(0);
            await db.HashDecrementAsync(Key, Hash, Value);
        }
        private async Task CreditAccountTransaction(string Key, string Hash, double Value)
        {
            IDatabase db = connectionMultiplexer.GetDatabase(0);
            await db.HashIncrementAsync(Key, Hash, Value);
        }

    }
}
