using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;
using OrderManagement.Infrastructure.Context;

namespace OrderManagement.Infrastructure.Repositories
{
    public class PedidoRepository(AppDbContext appDbContext) : IPedidoRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public async Task<IEnumerable<Pedido>> GetAllAsync() => await _appDbContext.Pedido.Include(x => x.Cliente).ToListAsync();
        
        public async Task<Pedido?> GetByIdAsync(int id) => await _appDbContext.Pedido.Include(x => x.Cliente).FirstOrDefaultAsync(x => x.Id == id);
        
        public async Task<Pedido> CreateAsync(Pedido pedido)
        {
            await _appDbContext.Pedido.AddAsync(pedido);
            await _appDbContext.SaveChangesAsync();
            return pedido;
        }

        public async Task<Pedido?> UpdateAsync(Pedido pedido)
        {
            var result = await _appDbContext.Pedido.FirstOrDefaultAsync(x => x.Id == pedido.Id);

            if (result is not null)
            {
                _appDbContext.Pedido.Update(pedido);
                await _appDbContext.SaveChangesAsync();
                return pedido;
            }

            return result;
        }

        public async Task<Pedido?> RemoveAsync(Pedido pedido)
        {
            var result = await _appDbContext.Pedido.FirstOrDefaultAsync(x => x.Id == pedido.Id);

            if (result is not null)
            {
                _appDbContext.Pedido.Remove(pedido);
                await _appDbContext.SaveChangesAsync();
                return pedido;
            }

            return pedido;
        }

        public async Task<Pedido?> RemoveByIdAsync(int id)
        {
            var result = await _appDbContext.Pedido.FirstOrDefaultAsync(x => x.Id == id);

            if (result is not null)
            {
                _appDbContext.Pedido.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }

            return result;
        }
    }
}
