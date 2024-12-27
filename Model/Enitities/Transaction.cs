using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enitities
{
    [Table("Tbl_Transaction")]
    public class Transaction
    {
        [Key]
        public Guid TransactionID { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
