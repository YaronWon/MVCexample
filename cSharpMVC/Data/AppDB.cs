using cSharpMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace cSharpMVC.Data
{
    public class AppDB : DbContext
    {
        public AppDB(DbContextOptions<AppDB> Options) : base(Options)
        {

        }

        public DbSet<Category> categories { get; set; }
        

    }
}
