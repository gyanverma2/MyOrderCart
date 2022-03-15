using Microsoft.EntityFrameworkCore;

namespace MyOrderCart.Data
{
    public class InMemoryContext : DbContext
    {
        public InMemoryContext(DbContextOptions<InMemoryContext> options) : base(options) { }

        public DbSet<Cart> Orders { get; set; }
    }
}
