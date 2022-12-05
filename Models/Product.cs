using System.Xml.Linq;

namespace ProductManager.Models;

public class Product
{
    public string articleNumber;
    public string nameOfProduct;
    public string descriptionOfProduct;
    public decimal productPrice;

    public Product(string articleNumber,
    string nameOfProduct,
    string descriptionOfProduct,
    decimal productPrice)
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

