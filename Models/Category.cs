using System.ComponentModel.DataAnnotations;

namespace ProductManager.Models;

public class Category
{
    public Category(string name)
    {
        Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException("Ogiltligt namn") : name;

    }

    public int CategoryId { get; set; } 

    [MaxLength(50)]
    public string Name { get; set; }

    public ICollection<Product> Product { get; set; } = new List<Product>();

}
