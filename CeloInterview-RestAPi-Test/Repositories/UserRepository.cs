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

        public  List<Users> GetAllUsers()
        {
            return  _UsersContext.Users.ToList();
        }

        public List<Users> GetUsersBasedOnName(string searchParam)
        {
            var result = (from user in _UsersContext.Users
                          where user.FirstName == searchParam || user.LastName == searchParam
                          select user).ToList();
            return result;
        }

        public List<Users> FetchUsersBasedOnQuantitySpecified(int quantity)
        {
            var  result = _UsersContext.Users.OrderBy(x => Guid.NewGuid()).Take(quantity).ToList();

            return result;
        }

        public Users GetUsersBasedOnId(int id)
        {
            var result = (from user in _UsersContext.Users
                          where user.UserId == id
                          select user).FirstOrDefault();
            return result;
        }

        public bool DeleteUserBasedOnUserId(int id)
        {
            var deleteUserDetails = (from user in _UsersContext.Users
                                     where user.UserId == id
                                     select user);

            foreach (var detail in deleteUserDetails)
            {
                _UsersContext.Users.Remove(detail);
            }

            try
            {
                _UsersContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
            }
            return true;
        }

    }
}
