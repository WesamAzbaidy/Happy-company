using Happy_company.Model.Domain;

namespace Happy_company.Repositories.WarehouseRepository
{
    public interface IWarehouseRepository
    {
        Task<List<Warehouse>> GetAllWarehouses(int pageNumber, int pageSize);
        Task<Warehouse> GetWarehouseById(Guid id);
        Task<int> GetTotalWarehouses();
        Task<bool> WarehouseExistsByName(string name, Guid? warehouseId = null);
        Task<Warehouse> CreateWarehouse(Warehouse warehouse);
        Task UpdateWarehouse(Warehouse warehouse);
        Task DeleteWarehouse(Warehouse warehouse);
    }
}
