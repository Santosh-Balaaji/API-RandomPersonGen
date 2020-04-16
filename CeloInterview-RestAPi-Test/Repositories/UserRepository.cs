﻿using CeloInterview_RestAPi_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CeloInterview_RestAPi_Test.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUsersContext _UsersContext;

        public UserRepository(IUsersContext usersContext)
        {
            _UsersContext = usersContext;
        }

        public Users[] GetAllUsers()
        {
            return _UsersContext.Users.ToArray();
        }

        public List<Users> GetUsersBasedOnName(string searchParam)
        {
            var result = (from user in _UsersContext.Users
                          where user.FirstName == searchParam
                          select user).ToList();
            return result;
        }
    }
}
