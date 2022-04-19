using System;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IBLRepo
    {
        //Product CRUD
        Task<Product> AddProductAsync(Product product);
        Task<Product> GetOneProductAsync(int id);
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Product>> GetAllUserProductsAsync(string username);
        Task DeleteProductAsync(int id);
        Task<Product> UpdateProductAsync(Product product);

        //Like CRUD
        Task<Like> AddLikeAsync(Like like);
        Task<List<Like>> GetAllLikesAsync(int productId);
        Task DeleteLikeAsync(int id);

        //Product Images CRUD
        Task<ProductImage> AddProductImageAsync(ProductImage image);
        Task<List<ProductImage>> GetAllProductImagesAsync(int productId);
        Task DeleteProductImageAsync(int id);
        Task<ProductImage> UpdateProductImageAsync(ProductImage image);

        //Product Boosts CRUD
        Task<Boost> AddBoostAsync(Boost boost);
        Task<List<Boost>> GetAllBoostedItems();
        Task<Boost> UpdateProductBoost(Boost boost);
    }
}
