using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DbContext(DbContextOptions options) : IdentityDbContext<User>(options)
    {
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Client> Clients { get; set; }
    }

}
