using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class DLRepo : IDLRepo
    {
        private readonly ProductDbContext _context;

        public DLRepo(ProductDbContext context){
            _context = context;
        }

        //Product CRUD
        public async Task<Product> AddProductAsync(Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            return product;
        }
        public async Task<Product> GetOneProductAsync(int id)
        {
            return await _context.Products
                .AsNoTracking()
                .Include(l => l.Like)
                .Select(p => new Product()
                {
                    Id = p.Id,
                    Description = p.Description,
                    Condition = p.Condition,
                    ItemPrice = p.ItemPrice,
                    OriginalPrice = p.OriginalPrice,
                    Quantity = p.Quantity,
                    OwnerName = p.OwnerName,
                    Category = p.Category,
                    SubCategory = p.SubCategory,
                    Brand = p.Brand,
                    Color = p.Color,
                    Size = p.Size,
                    Age = p.Age,
                    Town = p.Town,
                    City = p.City,
                    FreeDelivery = p.FreeDelivery,
                    DateTimeAdded = p.DateTimeAdded,
                    Like = _context.Likes.Where(l => l.ProductId == p.Id).Select(l => new Like()
                    {
                        Id = l.Id,
                        LikerName = l.LikerName,
                        ProductId = l.ProductId
                    }).ToList()
                })
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products
                .Include(l => l.Like)
                .Select(p => new Product()
                {
                    Id = p.Id,
                    Description = p.Description,
                    Condition = p.Condition,
                    ItemPrice = p.ItemPrice,
                    OriginalPrice = p.OriginalPrice,
                    Quantity = p.Quantity,
                    OwnerName = p.OwnerName,
                    Category = p.Category,
                    SubCategory = p.SubCategory,
                    Brand = p.Brand,
                    Color = p.Color,
                    Size = p.Size,
                    Age = p.Age,
                    Town = p.Town,
                    City = p.City,
                    FreeDelivery = p.FreeDelivery,
                    DateTimeAdded = p.DateTimeAdded,
                    Like = _context.Likes.Where(l => l.ProductId == p.Id).Select(l => new Like()
                    {
                        Id = l.Id,
                        LikerName = l.LikerName,
                        ProductId = l.ProductId
                    }).ToList(),
                    ProductImages = _context.ProductImages.Where(q => q.ProductId == p.Id).Select(q => new ProductImage()
                    {
                        Id = q.Id,
                        ProductId = q.ProductId,
                        ImageData = q.ImageData
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<List<Product>> GetAllUserProductsAsync(string username)
        {
            return await _context.Products
                .Include(l => l.Like)
                .Include(q => q.ProductImages)
                .Where(p => p.OwnerName == username)
                .Select(p => new Product()
                {
                    Id = p.Id,
                    Description = p.Description,
                    Condition = p.Condition,
                    ItemPrice = p.ItemPrice,
                    OriginalPrice = p.OriginalPrice,
                    Quantity = p.Quantity,
                    OwnerName = p.OwnerName,
                    Category = p.Category,
                    SubCategory = p.SubCategory,
                    Brand = p.Brand,
                    Color = p.Color,
                    Size = p.Size,
                    Age = p.Age,
                    Town = p.Town,
                    City = p.City,
                    FreeDelivery = p.FreeDelivery,
                    DateTimeAdded = p.DateTimeAdded,
                    Like = _context.Likes.Where(l => l.ProductId == p.Id).Select(l => new Like()
                    {
                        Id = l.Id,
                        LikerName = l.LikerName,
                        ProductId = l.ProductId
                    }).ToList(),
                    ProductImages = _context.ProductImages.Where(q => q.ProductId == p.Id).Select(q => new ProductImage()
                    {
                        Id = q.Id,
                        ProductId = q.ProductId,
                        ImageData = q.ImageData
                    }).ToList()
                }).ToListAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            _context.Products.Remove(await GetOneProductAsync(id));
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }
        public async Task<Product> UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            return new Product()
            {
                Id = product.Id,
                Description = product.Description,
                Condition = product.Condition,
                ItemPrice = product.ItemPrice,
                OriginalPrice = product.OriginalPrice,
                Quantity = product.Quantity,
                OwnerName = product.OwnerName,
                Category = product.Category,
                SubCategory = product.SubCategory,
                Brand = product.Brand,
                Color = product.Color,
                Size = product.Size,
                Age = product.Age,
                Town = product.Town,
                City = product.City,
                FreeDelivery = product.FreeDelivery,
                DateTimeAdded = product.DateTimeAdded
            };
        }

        //Like CRUD
        public async Task<Like> AddLikeAsync(Like like)
        {
            await _context.AddAsync(like);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            return like;
        }

        public async Task<Like> GetOneLikeAsync(int id)
        {
            return await _context.Likes
                .Select(l => new Like()
                {
                    Id = l.Id,
                    ProductId = l.ProductId,
                    LikerName = l.LikerName
                })
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<Like>> GetAllLikesAsync(int productId)
        {
            return await _context.Likes
                .Where(like => like.ProductId == productId)
                .Select(l => new Like()
                {
                    Id = l.Id,
                    ProductId = l.ProductId,
                    LikerName = l.LikerName
                }).ToListAsync();
        }

        public async Task DeleteLikeAsync(int id)
        {
            _context.Likes.Remove(await GetOneLikeAsync(id));
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        //Product Images CRUD
        public async Task<ProductImage> AddProductImageAsync(ProductImage image)
        {
            
            await _context.AddAsync(image);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            return image;
        }
        public async Task<ProductImage> GetOneProductImageAsync(int id)
        {
            return await _context.ProductImages
                .AsNoTracking()
                .Select(i => new ProductImage()
                {
                    Id = i.Id,
                    ProductId = i.ProductId,
                    ImageData = i.ImageData
                })
                .FirstOrDefaultAsync(i => i.ProductId == id);
        }
        public async Task<List<ProductImage>> GetAllProductImagesAsync(int productId)
        {
            return await _context.ProductImages
                .Where(image => image.ProductId == productId)
                .Select(i => new ProductImage()
                {
                    Id = i.Id,
                    ProductId = i.ProductId,
                    ImageData = i.ImageData
                }).ToListAsync();
        }
        public async Task DeleteProductImageAsync(int id)
        {
            _context.ProductImages.Remove(await GetOneProductImageAsync(id));
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        public async Task<ProductImage> UpdateProductImageAsync(ProductImage image)
        {
            _context.ProductImages.Update(image);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            return new ProductImage()
            {
                Id = image.Id,
                ProductId = image.Id,
                ImageData = image.ImageData
            };
        }
    }
}
