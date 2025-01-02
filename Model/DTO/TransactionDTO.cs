using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class TransactionDTO
    {
        public Guid UserID { get; set; }
        public decimal Amount { get; set; }
    }
}
