using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.ProductDb
{
    public class ProductDbContext : DbContext
    {
        public DbSet<ProductDetails> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
    }
}
