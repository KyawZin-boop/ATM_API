using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Model.DTO;
using Model.Enitities;

namespace BAL.IServices
{
    public interface ITransactionService
    {
        Task Deposit(TransactionDTO inputModel);
        Task Withdraw(TransactionDTO inputModel);
        Task<IEnumerable<Model.Enitities.Transaction>> GetTransactions();
        Task<IEnumerable<Model.Enitities.Transaction>> GetTransactionByUserID(Guid id);
    }
}
