namespace ProductManager.Models;

public class Category
{
    public Category(string? name)
    {
        CategoryName = name;

    }

    public string CategoryName
    {
        get
        {

            return name;

        }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("Ogiltligt namn");
            name = value;
        }


    }



    private string name;

    public List<Product> ListOfProducts { get; } = new List<Product>();

    public void AddProduct(Product product)
    {

        if (ListOfProducts.Contains(product))
        {
            throw new ArgumentException("Produkt finns redan i kategorin");
        }
        else
        {
            ListOfProducts.Add(product);
        }


    }

}
