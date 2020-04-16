using CeloInterview_RestAPi_Test.Models;
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

        public Users[] GetUsers()
        {
            return _UsersContext.Users.ToArray();
        }
    }
}
