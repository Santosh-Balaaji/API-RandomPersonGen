using Microsoft.EntityFrameworkCore;

namespace CeloInterview_RestAPi_Test.Models
{
    //This serves as the interface for the IUserContext to induce Dependency Injection
    public interface IUsersContext
    {
        DbSet<Users> Users { get; set; }

        int SaveChanges();

    }
}