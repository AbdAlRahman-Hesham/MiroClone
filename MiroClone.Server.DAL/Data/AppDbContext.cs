using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiroClone.Server.DAL.Model;
using System.Reflection;

namespace MiroClone.Server.DAL.Data
{
    public class AppDbContext(DbContextOptions options) : IdentityDbContext<AppUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        DbSet<Board> Boards { get; set; }
        DbSet<Users_Boards> Users_Boards { get; set; }
    }
}
