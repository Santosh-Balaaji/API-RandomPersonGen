using CeloInterview_RestAPi_Test.Models;
using System.Collections.Generic;

namespace CeloInterview_RestAPi_Test.Repositories
{
    public interface IUserRepository
    {
        List<Users> GetAllUsers();
        List<Users> GetUsersBasedOnName(string searchParam);
        List<Users> FetchUsersBasedOnQuantitySpecified(int quantity);
        Users GetUsersBasedOnId(int id);
    }
}