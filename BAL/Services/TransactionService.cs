using System;
using System.Collections.Generic;
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
        public async Task Deposit(Guid id, TransactionDTO inputModel)
        {
            try
            {
                var user = (await _unitOfWork.User.GetByCondition(x => x.UserID == id && x.ActiveFlag)).FirstOrDefault();
                if (user is null)
                {
                    throw new Exception("User not found.");
                }

                user.Balance += inputModel.Amount;
                var transaction = new Transaction
                {
                    UserId = id,
                    TransactionType = "Deposit",
                    Amount = inputModel.Amount,
                };
                await _unitOfWork.Transaction.Add(transaction);
                await _unitOfWork.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task Withdraw(Guid id, TransactionDTO inputModel)
        {
            try
            {
                var user = (await _unitOfWork.User.GetByCondition(x => x.UserID == id)).FirstOrDefault();
                if (user is null)
                {
                    throw new Exception("User not found.");
                }

                if(user.Balance < inputModel.Amount)
                {
                    throw new Exception("Insufficient balance.");
                }

                user.Balance -= inputModel.Amount;
                var transaction = new Transaction
                {
                    UserId = id,
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
    }
}
