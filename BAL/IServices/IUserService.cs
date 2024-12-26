using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DTO;
using Model.Enitities;
using Repository.Repositories;

namespace BAL.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(Guid id);
        Task CreateUser(UserDTO inputModel);
        Task UpdateUser(UpdateUserDTO inputModel);
        Task DeleteUser(Guid id);
        Task LoginUser(LoginUserDTO inputModel);
    }
}
