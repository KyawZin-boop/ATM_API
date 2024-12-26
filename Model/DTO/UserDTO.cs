using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
    }

    public class UpdateUserDTO
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
    }

    public class LoginUserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
