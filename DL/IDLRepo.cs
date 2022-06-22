using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public interface IDLRepo
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
        Task<Like> GetOneLikeAsync(int id);
        Task<List<Like>> GetAllLikesAsync(int productId);
        Task DeleteLikeAsync(int id);
        Task DeleteLikesAsync(int id);

        //Product Images CRUD
        Task<ProductImage> AddProductImageAsync(ProductImage image);
        Task<ProductImage> GetOneProductImageAsync(int id);
        Task<List<ProductImage>> GetAllProductImagesAsync(int productId);
        Task DeleteProductImageAsync(int id);
        Task DeleteProductImagesAsync(int id);
        Task<ProductImage> UpdateProductImageAsync(ProductImage image);

        //Product Boosts CRUD
        Task<Boost> AddBoostAsync(Boost boost);
        Task<List<Boost>> GetAllBoostedItems();
        Task<Boost> UpdateProductBoost(Boost boost);
    }
}
