using Microsoft.EntityFrameworkCore;
using ProductManager.Models;
using System;


namespace ProductManager.Data;

public class ApplicationContext : DbContext 
{
    private string connectionString;

    public ApplicationContext(string connectionString)
    {
        this.connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
       
    }

    public DbSet<Product> Product { get; set; }

    public DbSet<Category> Category { get;set; }

  
}
