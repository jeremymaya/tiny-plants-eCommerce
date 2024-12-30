namespace TinyPlants.Models.Interfaces;

public interface IInventoryManager
{
    // Create
    Task CreateInventoryAsync(Product product);

    // Read - GetAll
    Task<IList<Product>> GetAllInventoriesAsync();

    // Read - GetIsFeatured
    Task<IList<Product>> GetFeaturedInventoriesAsync();

    // Read - GetById
    Task<Product> GetInventoryByIdAsync(int id);

    // Update
    Task UpdateInventoryAsync(Product product);

    // Delete
    Task RemoveInventoryAsync(int id);
}
