﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL;
using Model.Enitities;
using Repository.Repositories.IRepository;

namespace Repository.Repositories.Repository
{
    internal class UserRepository : GenericRepository<User> , IUserRepository
    {
        public UserRepository(DataContext context) : base(context) { }
    }
}
