namespace Productspace
{
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
            this.articleNumber = articleNumber;
            this.nameOfProduct = nameOfProduct; 
            this.descriptionOfProduct = descriptionOfProduct;
            this.productPrice = productPrice;

    }
        }
}