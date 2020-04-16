using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace CeloInterview_RestAPi_Test.Models
{
    public interface IUsersContext
    {
        DbSet<Users> Users { get; set; }

        int SaveChanges();
        EntityEntry Entry(Object entity);

    }
}