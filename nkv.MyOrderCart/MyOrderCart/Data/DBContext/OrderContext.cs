using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MyOrderCart.Data
{
	public class OrderContext : DbContext
    {
        public static readonly string RowVersion = nameof(RowVersion);
        public static readonly string OrderDb = nameof(OrderDb).ToLower();
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }
        public DbSet<Cart> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .Property<byte[]>(RowVersion)
                .IsRowVersion();

            base.OnModelCreating(modelBuilder);
        }
        public override void Dispose()
        {
            base.Dispose();
        }
        public override ValueTask DisposeAsync()
        {
            return base.DisposeAsync();
        }
    }
}
