using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_ECommerce.Models.Interfaces
{
    interface IInventory
    {
        // Create
        Task CreateInventoryAsync(Product product);

        // Read - Get All
        Task<List<Product>> GetAllInventoriesAsync();

        // Read - Gey By ID
        Task<Product> GetInventoryByIdAsync(int id);

        // Update
        Task UpdateInventoryAsync(Product product);

        // Delete
        Task RemoveInventoryAsync(int id);
    }
}
