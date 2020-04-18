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
                                     select user).FirstOrDefault();
            if (deleteUserDetails == null)
                return false;

                _UsersContext.Users.Remove(deleteUserDetails);
            

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

        public bool UpdateUserBasedOnId(int id, Users userDetails)
        {
            var userfetchedBasedOnId = (from user in _UsersContext.Users
                                        where user.UserId == id
                                        select user).FirstOrDefault();
            if (userfetchedBasedOnId == null)
                return false;

            if(userDetails.Title!= null)
                userfetchedBasedOnId.Title = userDetails.Title;
            if(userDetails.FirstName!=null)
                userfetchedBasedOnId.FirstName = userDetails.FirstName;
            if(userDetails.LastName!=null)
                userfetchedBasedOnId.LastName = userDetails.LastName;
            if(userDetails.PhoneNumber!=null)
                userfetchedBasedOnId.PhoneNumber = userDetails.PhoneNumber;
            if(userDetails.ProfileImages!=null)
                userfetchedBasedOnId.ProfileImages = userDetails.ProfileImages;
            if(userDetails.EmailId!=null)
                userfetchedBasedOnId.EmailId = userDetails.EmailId;

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

        public bool InsertNewUser(Users user)
        {
            if (user == null)
                return false;

            if (user.Title == null)
                return false;
            if (user.FirstName == null)
                return false;
            if (user.LastName == null)
                return false;
            if (user.PhoneNumber == null)
                return false;
            if (user.EmailId == null)
                return false;


            _UsersContext.Users.Add(user);
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
