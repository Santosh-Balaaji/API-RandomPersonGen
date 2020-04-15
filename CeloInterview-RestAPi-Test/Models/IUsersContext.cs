using Microsoft.EntityFrameworkCore;

namespace CeloInterview_RestAPi_Test.Models
{
    public interface IUsersContext
    {
        DbSet<Users> Users { get; set; }
    }
}