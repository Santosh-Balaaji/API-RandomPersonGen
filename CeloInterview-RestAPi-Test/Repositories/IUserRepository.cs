using CeloInterview_RestAPi_Test.Models;
using System.Collections.Generic;

namespace CeloInterview_RestAPi_Test.Repositories
{
    public interface IUserRepository
    {
        Users[] GetAllUsers();
        List<Users> GetUsersBasedOnName(string searchParam);
    }
}