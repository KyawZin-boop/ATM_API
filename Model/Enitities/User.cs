using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.ApplicationConfig;

namespace Model.Enitities
{
    [Table("Tbl_User")]
    public class User : Common
    {
        [Key]
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
    }
}
