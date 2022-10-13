

namespace ProductManager;

class Category
{
    public Category(string name)
    {
        Name = name;
        
    }

    public string Name { 
        get
        {
            
            return name;
        
        }
        set 
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Ogiltligt namn");
            name = value;
        }
    
       
    }

   

    public string name;

    private List<Product> listOfProducts = new List<Product>();
    public void AddProduct(Product product)
    {

    }
}
