using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BAL.IServices;
using Model.DTO;
using Model.Enitities;
using Repository.Repositories.IRepository;
using Repository.UnitOfWork;

namespace BAL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {
                var users = await _unitOfWork.User.GetByCondition(x => x.ActiveFlag);
                return users;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetUserById(Guid id)
        {
            try
            {
                var user = (await _unitOfWork.User.GetByCondition(x => x.UserID == id && x.ActiveFlag)).FirstOrDefault();
                if (user is null)
                {
                    throw new Exception("User not found.");
                }
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task CreateUser(UserDTO inputModel)
        {
            try
            {
                var user = new User
                {
                    UserName = inputModel.UserName,
                    Password = inputModel.Password,
                    Balance = inputModel.Balance
                };
                await _unitOfWork.User.Add(user);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateUser(UpdateUserDTO inputModel)
        {
            try
            {
                var user = (await _unitOfWork.User.GetByCondition(x => x.UserID == inputModel.UserID && x.ActiveFlag)).FirstOrDefault();
                if (user is null)
                {
                    throw new Exception("User not found.");
                }

                if(inputModel.UserName != null)
                {
                    user.UserName = inputModel.UserName;
                }
                if(inputModel.Password != null)
                {
                    user.Password = inputModel.Password;
                }
                if (inputModel.Balance != 0)
                {
                    user.Balance = inputModel.Balance;
                }
                if(inputModel.UpdatedBy != null)
                {
                    user.UpdatedBy = inputModel.UpdatedBy;
                }

                user.UpdatedAt = DateTime.UtcNow;
                _unitOfWork.User.Update(user);
                await _unitOfWork.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteUser(Guid id)
        {
            try
            {
                var user = (await _unitOfWork.User.GetByCondition(x=>x.UserID==id)).FirstOrDefault();
                if (user is null)
                {
                    throw new Exception("User not found.");
                }

                user.UpdatedAt = DateTime.UtcNow;
                user.ActiveFlag = false;
                _unitOfWork.User.Update(user);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task LoginUser(LoginUserDTO inputModel)
        {
            try
            {
                var user = (await _unitOfWork.User.GetByCondition(x => x.UserName == inputModel.UserName && x.Password == inputModel.Password && x.ActiveFlag)).FirstOrDefault();
                if (user is null)
                {
                    throw new Exception("Incorrect Password or UserName.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
