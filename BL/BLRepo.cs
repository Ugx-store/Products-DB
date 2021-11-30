using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DL;

namespace BL
{
    public class BLRepo : IBLRepo
    {
        private readonly IDLRepo _repo;

        public BLRepo(IDLRepo repo)
        {
            _repo = repo;
        }

        //Product CRUD
        public async Task<Product> AddProductAsync(Product product)
        {
            return await _repo.AddProductAsync(product);
        }
        public async Task<Product> GetOneProductAsync(int id)
        {
            return await _repo.GetOneProductAsync(id);
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _repo.GetAllProductsAsync();
        }
        public async Task DeleteProductAsync(int id)
        {
            await _repo.DeleteProductAsync(id);
        }
        public async Task<Product> UpdateProductAsync(Product product)
        {
            return await _repo.UpdateProductAsync(product);
        }

        //Likes CRUD
        public async Task<Like> AddLikeAsync(Like like)
        {
            return await _repo.AddLikeAsync(like);
        }
        public async Task<List<Like>> GetAllLikesAsync(int productId)
        {
            return await _repo.GetAllLikesAsync(productId);
        }
        public async Task DeleteLikeAsync(int id)
        {
            await _repo.DeleteLikeAsync(id);
        }

        //Product Images CRUD
        public async Task<ProductImage> AddProductImageAsync(ProductImage image)
        {
            return await _repo.AddProductImageAsync(image);
        }
        public async Task<List<ProductImage>> GetAllProductImagesAsync(int productId)
        {
            return await _repo.GetAllProductImagesAsync(productId);
        }
        public async Task DeleteProductImageAsync(int id)
        {
            await _repo.DeleteProductImageAsync(id);
        }

        public async Task<ProductImage> UpdateProductImageAsync(ProductImage image)
        {
            return await _repo.UpdateProductImageAsync(image);
        }
    }
}

