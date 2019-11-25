using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_ECommerce.Models.Interfaces
{
    public interface IInventory
    {
        // Create
        Task CreateInventoryAsync(Product product);

        // Read - GetAll
        Task<IList<Product>> GetAllInventoriesAsync();

        Task<IList<Product>> GetFeaturedInventoriesAsync();

        // Read - GeyByID
        Task<Product> GetInventoryByIdAsync(int id);

        // Update
        Task UpdateInventoryAsync(Product product);

        // Delete
        Task RemoveInventoryAsync(int id);
    }
}
