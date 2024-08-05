using Happy_company.Data;
using Happy_company.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Happy_company.Repositories.ItemsRepository
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly DataContext context;

        public ItemsRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<Items> CreateAsync(Items item)
        {
            context.Items.Add(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(Items item)
        {
            context.Items.Remove(item);
            await context.SaveChangesAsync();
        }

        public async Task<List<Items>> GetAllAsync()
        {
            return await context.Items.ToListAsync();
        }

        public async Task<Items> GetByIdAsync(Guid id)
        {
            return await context.Items.FindAsync(id);
        }

        public async Task UpdateAsync(Items item)
        {
            context.Items.Update(item);
            await context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await context.Items.AnyAsync(i => i.Name == name);
        }

        public async Task<bool> ExistsByNameAsync(string name, Guid excludeId)
        {
            return await context.Items.AnyAsync(i => i.Name == name && i.Id != excludeId);
        }
        public async Task<(Items HighQtyItem, Items LowQtyItem)> GethighLowItemsAsync()
        {
            var items = await context.Items.ToListAsync();

            if (!items.Any())
            {
                return (null, null);
            }

            var highQtyItem = items.OrderByDescending(i => i.QTY).FirstOrDefault();
            var lowQtyItem = items.OrderBy(i => i.QTY).FirstOrDefault();

            return (highQtyItem, lowQtyItem);
        }

    }
}