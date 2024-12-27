﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DTO;

namespace BAL.IServices
{
    public interface ITransactionService
    {
        Task Deposit(Guid id, TransactionDTO inputModel);
        Task Withdraw(Guid id, TransactionDTO inputModel);
    }
}
