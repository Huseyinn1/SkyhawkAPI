using Microsoft.EntityFrameworkCore;
using SkyhawkAPI.Entities;

namespace SkyhawkAPI.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Login> Logins {  get; set; }
        public DbSet<Tespit> Tespitler { get; set; }
        
    }
}
