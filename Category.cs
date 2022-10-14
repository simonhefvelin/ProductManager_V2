

namespace ProductManager;

class Category
{
    public Category(string name)
    {
        Name = name;

    }

    public string Name
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



    public string name;

    public List<Product> listOfProducts = new List<Product>();
    public void AddProduct(Product product)
    {
        // TODO Kolla efter dublett, oom sådan kast aexcpetion, och fånga där AddProduct anropas

        listOfProducts.Add(product);

    }

}
