using NB.CheckingAccount.Domain.Aggregates;
using NB.CheckingAccount.Domain.Commands;
using NB.CheckingAccount.Domain.Contract;
using NB.CheckingAccount.Domain.Enum;
using NB.SupportPackages.Entities.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NB.CheckingAccount.Domain.Implementation
{
    public class CheckingAccountDomain : ICheckingAccountDomain
    {
        readonly ICheckingAccountStatusRepository checkingAccountStatusRepository;
        readonly ICheckingAccountRepository checkingAccountRepository;
        readonly ICheckingAccountTransactionRepository checkingAccountTransactionRepository;
        readonly ICheckingAccountTransactionStatusRepository checkingAccountTransactionStatusRepository;
        readonly ICheckingAccountTransactionTypeRepository checkingAccountTransactionTypeRepository;
        readonly ICurrencyRepository currencyRepository;

        public CheckingAccountDomain(ICheckingAccountStatusRepository checkingAccountStatusRepository,
                                     ICheckingAccountRepository checkingAccountRepository,
                                     ICheckingAccountTransactionRepository checkingAccountTransactionRepository,
                                     ICheckingAccountTransactionStatusRepository checkingAccountTransactionStatusRepository,
                                     ICheckingAccountTransactionTypeRepository checkingAccountTransactionTypeRepository,
                                     ICurrencyRepository currencyRepository)
        {
            this.checkingAccountStatusRepository = checkingAccountStatusRepository;
            this.checkingAccountRepository = checkingAccountRepository;
            this.checkingAccountTransactionRepository = checkingAccountTransactionRepository;
            this.checkingAccountTransactionStatusRepository = checkingAccountTransactionStatusRepository;
            this.checkingAccountTransactionTypeRepository = checkingAccountTransactionTypeRepository;
            this.currencyRepository = currencyRepository;
        }

        readonly TransportEntity ObjReturn = new TransportEntity();

        public async Task<TransportEntity> InternalTransaction(AddCheckingAccountTransactionCommand Command)
        {
            try
            {
                if (Command.CreditCheckingAccount == Command.DebitCheckingAccount)
                {
                    ObjReturn.Sucess = false;
                    ObjReturn.Messages.Add("Conta de Debito e Credito iguais");
                    return ObjReturn;
                }

                if (Command.Value <= 0)
                {
                    ObjReturn.Sucess = false;
                    ObjReturn.Messages.Add("Valor deve ser maior que 0");
                    return ObjReturn;
                }

                Aggregates.CheckingAccount DebitCheckingAccount = await ValidatedCheckingAccount(Command.DebitCheckingAccount);

                if (DebitCheckingAccount.Active.Equals(false))
                {
                    ObjReturn.Sucess = false;
                    ObjReturn.Messages.Add("Conta de Debito invalidas");
                    return ObjReturn;
                }

                Aggregates.CheckingAccount CreditCheckingAccount = await ValidatedCheckingAccount(Command.CreditCheckingAccount);

                if (CreditCheckingAccount.Active.Equals(false))
                {
                    ObjReturn.Sucess = false;
                    ObjReturn.Messages.Add("Conta de Credito invalidas");
                    return ObjReturn;
                }

                if (Command.Value > GetBalance(Command.DebitCheckingAccount))
                {
                    ObjReturn.Sucess = false;
                    ObjReturn.Messages.Add("Saldo Insuficiente");
                    return ObjReturn;
                }

                Guid TracedID = Guid.NewGuid();

                IEnumerable<CheckingAccountTransaction> TransactionList = new List<CheckingAccountTransaction>()
                {
                        new CheckingAccountTransaction()
                            {
                                ID = Guid.NewGuid(),
                                TracedID = TracedID,
                                CheckingAccount = DebitCheckingAccount,
                                Value = (Command.Value * -1),
                                CheckingAccountTransactionStatus = await checkingAccountTransactionStatusRepository.GetAsync(w => w.Code.Equals((int)CheckingAccountTransactionStatusEnum.Authorized), true),
                                CheckingAccountTransactionType = await checkingAccountTransactionTypeRepository.GetAsync(w => w.Code.Equals((int)CheckingAccountTransactionTypeEnum.InternalTransfer), true),
                                CurrencyType = await currencyRepository.GetAsync(w => w.Code.Equals((int)CurrencyEnum.BRL), true)

                            },
                        new CheckingAccountTransaction()
                            {
                                ID = Guid.NewGuid(),
                                TracedID = TracedID,
                                CheckingAccount = CreditCheckingAccount,
                                Value = Command.Value,
                                CheckingAccountTransactionStatus = await checkingAccountTransactionStatusRepository.GetAsync(w => w.Code.Equals((int)CheckingAccountTransactionStatusEnum.Authorized), true),
                                CheckingAccountTransactionType = await checkingAccountTransactionTypeRepository.GetAsync(w => w.Code.Equals((int)CheckingAccountTransactionTypeEnum.InternalTransfer), true),
                                CurrencyType = await currencyRepository.GetAsync(w => w.Code.Equals((int)CurrencyEnum.BRL), true)

                            }
                };


                await checkingAccountTransactionRepository.AddRangeAsync(TransactionList);
                ObjReturn.Sucess = true;
                ObjReturn.Data = true;
                return ObjReturn;
            }
            catch (Exception ex)
            {
                ObjReturn.Sucess = false;
                ObjReturn.Messages.Add(ex.Message);
                return ObjReturn;
            }

        }


        public TransportEntity GetStatement(Guid CheckingAccountID)
        {

            try
            {
                ObjReturn.Sucess = true;
                ObjReturn.Data = checkingAccountTransactionRepository
                                    .Where(w => w.CheckingAccountID.Equals(CheckingAccountID) && w.CheckingAccountTransactionStatus.Code.Equals((int)CheckingAccountTransactionStatusEnum.Authorized), true, i => i.CheckingAccountTransactionStatus)
                                    .Select(s => new { s.ID, s.Value, s.CurrencyType.Symbol, s.Created, s.CheckingAccountTransactionType.Description, s.TracedID })
                                    .OrderBy(o => o.Created);

                return ObjReturn;
            }
            catch (Exception ex)
            {
                ObjReturn.Sucess = false;
                ObjReturn.Messages.Add(ex.Message);
                return ObjReturn;
            }

        }

        public async Task<Aggregates.CheckingAccount> ValidatedCheckingAccount(Guid CheckingAccountID)
        {
            return await checkingAccountRepository.GetAsync(w => w.ID.Equals(CheckingAccountID) && w.Status.Code.Equals((int)CheckingAccountStatusEnum.Authorized), true, i => i.Status);

        }

        public decimal GetBalance(Guid CheckingAccountID)
        {
            return checkingAccountTransactionRepository.Where(w => w.CheckingAccountID.Equals(CheckingAccountID) && w.CheckingAccountTransactionStatus.Code.Equals((int)CheckingAccountTransactionStatusEnum.Authorized), true, i => i.CheckingAccountTransactionStatus).Sum(s => s.Value);
        }

        public async Task<Aggregates.CheckingAccount> AddCheckingAccount(Aggregates.CheckingAccount CheckingAccount)
        {
            return await checkingAccountRepository.AddAsync(CheckingAccount);
        }

    }
}
