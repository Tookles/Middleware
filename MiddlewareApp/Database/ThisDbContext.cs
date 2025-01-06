using Microsoft.EntityFrameworkCore;
using MiddlewareApp.Model.Entity; 


namespace MiddlewareApp.Database
{
    public class ThisDbContext : DbContext 
    {

        public ThisDbContext(DbContextOptions<ThisDbContext> options) : base(options) { }

        public DbSet<Adventurer> Adventurers { get; set; }


    }
}
