using Microsoft.EntityFrameworkCore;
using ProductManager.Models;



namespace ProductManager.Data;

class ApplicationContext : DbContext 
{


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server =.; Database = ProductManager; Integrated Security = true; Encrypt = False");
       
    }

    public DbSet<Product> Product { get; set; }

    public DbSet<Category> Category { get; set; }

  
}
