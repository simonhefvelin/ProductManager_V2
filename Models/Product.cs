using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProductManager.Models;

public class Product
{
    public Product(string articleNumber, string name, string description, decimal price)
    {
        ArticleNumber = string.IsNullOrEmpty(articleNumber) ? throw new ArgumentNullException("Ogiltligt artikelnummer") : articleNumber;
        Name = name;
        Description = description;
        Price = price;
    }

    [Key]
    [MaxLength(6)]
    public string ArticleNumber { get; set; }   

    [MaxLength(20)]
    public string Name { get; set; }

    [MaxLength(50)]
    public string Description { get; set; }

    [MaxLength(18)]
    [Precision(18,2)]
    public decimal Price { get; set; }
}

