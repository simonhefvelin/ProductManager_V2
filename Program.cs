using ProductManager.Data;
using ProductManager.Models;
using static System.Console;

namespace ProductManager;

class Products
{
    static Dictionary<string, Category> categoryDictionary = new Dictionary<string, Category>();

    static Dictionary<string, Product> productDictionary = new Dictionary<string, Product>();
    
    static string connectionString = "Server=.;Database=ProductManager;Integrated Security=true;Encrypt=False";

    static ApplicationContext context = new ApplicationContext(connectionString);
    static void Main(string[] args)
    {

        var applicationRunning = true;
        do
        {
            WriteLine("(1) Ny produkt");
            WriteLine("(2) Sök produkt");
            WriteLine("(3) Ny kategori");
            WriteLine("(4) Lägg till produkt till kategori");
            WriteLine("(5) Lista kategorier");
            WriteLine("(6) Avsluta");

            ConsoleKeyInfo userInput;

            var invalidSelection = true;

            do
            {
                userInput = ReadKey(true);

                invalidSelection = !(
                    userInput.Key == ConsoleKey.D1 ||
                    userInput.Key == ConsoleKey.NumPad1 ||
                    userInput.Key == ConsoleKey.D2 ||
                    userInput.Key == ConsoleKey.NumPad2 ||
                    userInput.Key == ConsoleKey.D3 ||
                    userInput.Key == ConsoleKey.NumPad3 ||
                    userInput.Key == ConsoleKey.D4 ||
                    userInput.Key == ConsoleKey.NumPad4 ||
                    userInput.Key == ConsoleKey.D5 ||
                    userInput.Key == ConsoleKey.NumPad5 ||
                    userInput.Key == ConsoleKey.D6 ||
                    userInput.Key == ConsoleKey.NumPad6
                    );

            } while (invalidSelection);

            Clear();


            switch (userInput.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:

                    AddProduct();

                    break;


                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:

                    SearchProduct();

                    break;


                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:

                    AddCategory();

                    break;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:


                    AddProductToCategory();

                    break;

                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:


                    {
                        WriteLine("Namn");
                        WriteLine("--------------------------------");


                        foreach (var category in categoryDictionary)
                        {
                            WriteLine($"{category.Value.CategoryName} ({category.Value.ListOfProducts.Count()})");
                        }

                        ReadKey();

                        Clear();
                    }

                    break;

                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:

                    applicationRunning = false;

                    break;
            }

            Clear();

        } while (applicationRunning);
    }

    static void SearchProduct()
    {
        Write("Sök efter artikelnummer på produkten: ");

        string searchProduct = ReadLine();

        Clear();

        Product searchResult = productDictionary.ContainsKey(searchProduct)
                ? productDictionary[searchProduct]
                : null;

        bool invalidSelection = false;

        ConsoleKeyInfo userInput = ReadKey();

        if (searchResult != null)
        {

            Clear();

            WriteLine($"Artikelnummer: {searchResult.articleNumber}");
            WriteLine($"Namn: {searchResult.nameOfProduct}");
            WriteLine($"Beskrivning: {searchResult.descriptionOfProduct}");
            WriteLine($"Pris: {searchResult.productPrice}");


            WriteLine("Tryck valfri tangent för att gå tillbaka");
            ReadKey();

            do
            {
                userInput = ReadKey(true);

            } while (invalidSelection);
        }
        else
        {
            Clear();
            WriteLine("Produkt saknas");
            Thread.Sleep(2000);
        }
    }

    static void AddProductToCategory()
    {
        Write("Artikelnummer: ");

        var searchProduct = ReadLine();


        var product = productDictionary.ContainsKey(searchProduct)
            ? productDictionary[searchProduct]
            : null;

        bool productFound = product != null;

        if (productFound)
        {

            WriteLine("Sök kategori:");

            var searchCategory = ReadLine();

            Clear();


            var category = categoryDictionary.ContainsKey(searchCategory)
                ? categoryDictionary[searchCategory]
                : null;


            if (category != null)
            {
                if (category.ListOfProducts.Contains(product) == false)
                {
                    category.AddProduct(product);
                    WriteLine("Produkt tillagd i kategori");
                }
                else
                {
                    WriteLine("Produkt redan tillagd");
                }


            }
            else
            {
                WriteLine("Kategori saknas");
            }


        }
        else
        {
            WriteLine("Produkt finns ej");
        }


        Thread.Sleep(2000);
    }


    static void AddCategory()
    {
        {
            ConsoleKeyInfo userInput;
            string nameOfCategory;
            do
            {

                Write("Namn: ");

                nameOfCategory = ReadLine();

                WriteLine("Korrekta uppgifter tryck (J)a, om inte, tryck (N)ej.");


                bool invalidSelection = false;

                do
                {
                    userInput = ReadKey(true);

                    invalidSelection = !(
                        userInput.Key == ConsoleKey.J ||
                        userInput.Key == ConsoleKey.N
                        );

                } while (invalidSelection);

            } while (userInput.Key == ConsoleKey.N);

            Clear();

            switch (userInput.Key)
            {
                case ConsoleKey.J:


                    try
                    {
                        categoryDictionary.Add(nameOfCategory, new Category(nameOfCategory));
                        WriteLine("Kategori skapad");

                    }
                    catch (ArgumentException) when (categoryDictionary.ContainsKey(nameOfCategory))
                    {
                        WriteLine("Kategori är redan tillagd");
                    }
                    catch (ArgumentNullException)
                    {
                        WriteLine("Ogiltigt namn");
                    }

                    Thread.Sleep(2000);

                    Clear();

                    break;

                case ConsoleKey.N:

                    WriteLine("Åter till menyn");

                    Thread.Sleep(2000);

                    Clear();

                    break;

            }
        }
    }
    static void AddProduct()
    {
        ConsoleKeyInfo userInput;
        string articleNumber;
        string nameOfProduct;
        string descriptionOfProduct;
        decimal productPrice;
        do
        {
            Write("Artikelnummer: ");

            articleNumber = ReadLine();


            Write("Namn: ");

            nameOfProduct = ReadLine();


            Write("Beskrivning: ");

            descriptionOfProduct = ReadLine();


            Write("Pris: ");

            productPrice = decimal.Parse(ReadLine());

            WriteLine("Korrekta uppgifter tryck (J)a, om inte, tryck (N)ej.");


            bool invalidSelection = false;

            do
            {
                userInput = ReadKey(true);

                invalidSelection = !(
                    userInput.Key == ConsoleKey.J ||
                    userInput.Key == ConsoleKey.N
                    );

            } while (invalidSelection);

        } while (userInput.Key == ConsoleKey.N);

        Clear();

        switch (userInput.Key)
        {
            case ConsoleKey.J:


                try
                {
                    productDictionary.Add(articleNumber, new Product(articleNumber, nameOfProduct, descriptionOfProduct, productPrice));
                    WriteLine("Produkt tillagd");

                }
                catch (ArgumentException) when (productDictionary.ContainsKey(articleNumber))
                {
                    WriteLine("Produkt finns redan");
                }
                catch (ArgumentNullException)
                {
                    WriteLine("Ogiltigt artikelnummer");
                }

                Thread.Sleep(2000);

                Clear();

                break;

            case ConsoleKey.N:

                WriteLine("Åter till menyn");

                Thread.Sleep(2000);

                break;

        }
    }
}
