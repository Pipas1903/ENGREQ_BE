using System.Collections.Generic;
using AMAP_FARM.Models;
using Microsoft.EntityFrameworkCore;

namespace AMAP_FARM.Data
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
