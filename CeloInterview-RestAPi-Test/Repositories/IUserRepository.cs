using CeloInterview_RestAPi_Test.Models;

namespace CeloInterview_RestAPi_Test.Repositories
{
    public interface IUserRepository
    {
        Users[] GetUsers();
    }
}