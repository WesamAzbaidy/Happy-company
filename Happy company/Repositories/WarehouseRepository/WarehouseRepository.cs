using Happy_company.Data;
using Happy_company.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Happy_company.Repositories.WarehouseRepository
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly DataContext _context;

        public WarehouseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Warehouse>> GetAllWarehouses(int pageNumber, int pageSize)
        {
            return await _context.Warehouses
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Warehouse> GetWarehouseById(Guid id)
        {
            return await _context.Warehouses.FindAsync(id);
        }

        public async Task<int> GetTotalWarehouses()
        {
            return await _context.Warehouses.CountAsync();
        }

        public async Task<bool> WarehouseExistsByName(string name, Guid? warehouseId = null)
        {
            return await _context.Warehouses.AnyAsync(w => w.Name == name && (!warehouseId.HasValue || w.Id != warehouseId.Value));
        }

        public async Task<Warehouse> CreateWarehouse(Warehouse warehouse)
        {
            _context.Warehouses.Add(warehouse);
            await _context.SaveChangesAsync();
            return warehouse;
        }

        public async Task UpdateWarehouse(Warehouse warehouse)
        {
            _context.Warehouses.Update(warehouse);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWarehouse(Warehouse warehouse)
        {
            _context.Warehouses.Remove(warehouse);
            await _context.SaveChangesAsync();
        }
    }
}
