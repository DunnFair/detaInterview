using detaInterview.Models;
using Microsoft.EntityFrameworkCore;

namespace detaInterview.Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {


        }
        public DbSet<Detail> Details { get; set; }
    }
}
