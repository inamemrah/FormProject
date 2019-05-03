using System.Data.Entity;

namespace Data.Entity
{
    public class LenaDbContext : DbContext
    {
        public LenaDbContext() : base("ConnectionString")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormField> FormFields { get; set; }
        
    }
}
