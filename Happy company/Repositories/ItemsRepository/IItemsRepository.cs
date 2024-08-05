using Happy_company.Model.Domain;

namespace Happy_company.Repositories.ItemsRepository
{
    public interface IItemsRepository
    {
        Task<List<Items>> GetAllAsync();
        Task<(Items HighQtyItem, Items LowQtyItem)> GethighLowItemsAsync();

        Task<Items> GetByIdAsync(Guid id);
        Task<Items> CreateAsync(Items item);
        Task UpdateAsync(Items item);
        Task DeleteAsync(Items item);
        Task<bool> ExistsByNameAsync(string name);
        Task<bool> ExistsByNameAsync(string name, Guid excludeId);
    }
}
