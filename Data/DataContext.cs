using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapp_backend.Entities;

namespace webapp_backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        //Creamos la tabla de la bd Products en base a la entity Product
        public DbSet<Product> Products { get; set; } 
    }
}