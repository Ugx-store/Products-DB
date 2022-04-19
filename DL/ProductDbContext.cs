using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext() : base() { }
        public ProductDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<ProductImage> ProductImages { set; get; }
        public DbSet<Boost> Boost { set; get; }
    }
}
