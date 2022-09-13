using FoodStoreApp2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FoodStoreApp2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext > options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }

        public DbSet<Manufacturer> Manufacturer { get; set; }
    }
}
