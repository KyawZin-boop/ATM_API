using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.IServices;
using Model.DTO;
using Model.Enitities;
using Repository.UnitOfWork;

namespace BAL.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Deposit(TransactionDTO inputModel)
        {
            try
            {
                var user = (await _unitOfWork.User.GetByCondition(x => x.UserID == inputModel.UserID && x.ActiveFlag)).FirstOrDefault();
                if (user is null)
                {
                    throw new Exception("User not found.");
                }

                user.Balance += inputModel.Amount;
                var transaction = new Transaction
                {
                    UserId = inputModel.UserID,
                    TransactionType = "Deposit",
                    Amount = inputModel.Amount,
                };
                await _unitOfWork.Transaction.Add(transaction);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Withdraw(TransactionDTO inputModel)
        {
            try
            {
                var user = (await _unitOfWork.User.GetByCondition(x => x.UserID == inputModel.UserID)).FirstOrDefault();
                if (user is null)
                {
                    throw new Exception("User not found.");
                }

                if (user.Balance < inputModel.Amount)
                {
                    throw new Exception("Insufficient balance.");
                }

                user.Balance -= inputModel.Amount;
                var transaction = new Transaction
                {
                    UserId = inputModel.UserID,
                    TransactionType = "Withdraw",
                    Amount = inputModel.Amount,
                };
                await _unitOfWork.Transaction.Add(transaction);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            try
            {
                var transaction = await _unitOfWork.Transaction.GetAll();
                if (transaction is null)
                {
                    throw new Exception("Transaction not found.");
                }

                return transaction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Transaction>> GetTransactionByUserID(Guid id)
        {
            try
            {
                var transaction = await _unitOfWork.Transaction.GetByCondition(x => x.UserId == id);
                return transaction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
