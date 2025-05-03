using System.Collections.Generic;
using System;
using ASP.Net_API_06._04._2025.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net_API_06._04._2025.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Student> Students { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
