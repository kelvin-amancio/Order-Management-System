using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Infrastructure.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> opt) : DbContext(opt)
    {
        public DbSet<Cliente> Cliente {  get; set; }
        public DbSet<Pedido> Pedido { get; set; }
    }
}
