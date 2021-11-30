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
        Task DeleteProductAsync(int id);
        Task<Product> UpdateProductAsync(Product product);

        //Like CRUD
        Task<Like> AddLikeAsync(Like like);
        Task<Like> GetOneLikeAsync(int id);
        Task<List<Like>> GetAllLikesAsync(int productId);
        Task DeleteLikeAsync(int id);

        //Product Images CRUD
        Task<ProductImage> AddProductImageAsync(ProductImage image);
        Task<ProductImage> GetOneProductImageAsync(int id);
        Task<List<ProductImage>> GetAllProductImagesAsync(int productId);
        Task DeleteProductImageAsync(int id);
        Task<ProductImage> UpdateProductImageAsync(ProductImage image);

    }
}
