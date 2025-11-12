using Microsoft.EntityFrameworkCore;
using MiniJobBoard.Web.Models;

namespace MiniJobBoard.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Application> Applications { get; set; }
    }
}
