using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;
using OrderManagement.Infrastructure.Context;

namespace OrderManagement.Infrastructure.Repositories
{
    public class ClienteRepository(AppDbContext appDbContext) : IClienteRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public async Task<IEnumerable<Cliente>> GetAllAsync() => await _appDbContext.Cliente.AsNoTracking().ToListAsync();

        public async Task<Cliente?> GetByIdAsync(int id) => await _appDbContext.Cliente.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            await _appDbContext.Cliente.AddAsync(cliente);
            await _appDbContext.SaveChangesAsync();
            return cliente;
        }
        public async Task<Cliente?> UpdateAsync(Cliente cliente)
        {
            var result = await _appDbContext.Cliente.AsNoTracking().FirstOrDefaultAsync(x => x.Id == cliente.Id);

            if(result is not null)
            {
               _appDbContext.Cliente.Update(cliente);
               await _appDbContext.SaveChangesAsync();
               return cliente;
            }

            return result;
        }

        public async Task<Cliente?> RemoveAsync(Cliente cliente)
        {
            var result = await _appDbContext.Cliente.AsNoTracking().FirstOrDefaultAsync(x => x.Id == cliente.Id);

            if (result is not null)
            {
                _appDbContext.Cliente.Remove(cliente);
                await _appDbContext.SaveChangesAsync();
                return cliente;
            }

            return result;
        }

        public async Task<Cliente?> RemoveByIdAsync(int id)
        {
            var cliente = await _appDbContext.Cliente.FirstOrDefaultAsync(x => x.Id == id);
           
            if(cliente is not null)
            {
                _appDbContext.Cliente.Remove(cliente!);
                await _appDbContext.SaveChangesAsync();
            }

            return cliente;
        }
    }
}
