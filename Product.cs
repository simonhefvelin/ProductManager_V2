using System.Xml.Linq;

namespace ProductManager;

class Product
{
    public string articleNumber;
    public string nameOfProduct;
    public string descriptionOfProduct;
    public string productPrice;

    public Product(string articleNumber,
    string nameOfProduct,
    string descriptionOfProduct,
    string productPrice)
    {
        ArticleNumber = articleNumber;
        this.nameOfProduct = nameOfProduct; 
        this.descriptionOfProduct = descriptionOfProduct;
        this.productPrice = productPrice;


    
    
    }

    public string ArticleNumber
    {
        get
        {

            return articleNumber;

        }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("Ogiltligt artikelnummer");
            articleNumber = value;
        }


    }
}

