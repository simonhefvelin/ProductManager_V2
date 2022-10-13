
using System.ComponentModel;

namespace ProductManager
{
    class Products
    {
        static Dictionary<string, Category> categoryDictionary = new Dictionary<string, Category>();
        static Dictionary<string, Product> productDictionary = new Dictionary<string, Product>();

        static void Main(string[] args)
        {



            var applicationRunning = true;
            do
            {
                Console.WriteLine("(1) Ny produkt");
                Console.WriteLine("(2) Sök produkt");
                Console.WriteLine("(3) Ny kategori");
                Console.WriteLine("(4) Avsluta");

                ConsoleKeyInfo userInput;

                var invalidSelection = true;

                do
                {
                    userInput = Console.ReadKey(true);

                    invalidSelection = !(
                        userInput.Key == ConsoleKey.D1 ||
                        userInput.Key == ConsoleKey.NumPad1 ||
                        userInput.Key == ConsoleKey.D2 ||
                        userInput.Key == ConsoleKey.NumPad2 ||
                        userInput.Key == ConsoleKey.D3 ||
                        userInput.Key == ConsoleKey.NumPad3 ||
                        userInput.Key == ConsoleKey.D4 ||
                        userInput.Key == ConsoleKey.NumPad4
                        );

                } while (invalidSelection);

                Console.Clear();


                switch (userInput.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        AddProduct();

                        break;


                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:

                        Console.Write("Sök efter artikelnummer på produkten: ");

                        string searchProduct = Console.ReadLine();

                        // tenerary operator

                        //var exist = productDictionary.ContainsKey(searchProduct);
                        Product searchResult = productDictionary.ContainsKey(searchProduct)
                                ? productDictionary[searchProduct]
                                : null;

                        if (searchResult != null)
                        {
                            //Product findProduct = productDictionary.FirstOrDefault(searchProduct);

                            

                            Console.Clear();
                            Console.WriteLine($"Artikelnummer: {searchResult.articleNumber}");
                            Console.WriteLine($"Namn: {searchResult.nameOfProduct}");
                            Console.WriteLine($"Beskrivning: {searchResult.descriptionOfProduct}");
                            Console.WriteLine($"Pris: {searchResult.productPrice}");


                            Console.WriteLine("Tryck Escape för att återgå till menyn");
                            Console.ReadKey();

                            do
                            {
                                userInput = Console.ReadKey(true);

                                invalidSelection = !(
                                    userInput.Key == ConsoleKey.Escape
                                    );

                            } while (invalidSelection);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Finns ingen registrerad produkt med det Namnet!");
                            Thread.Sleep(2000);
                        }

                        break;


                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:



                        Console.WriteLine("Ny katergori ");


                        Console.Write("Namn: ");

                        string newCategory = Console.ReadLine();

                        Console.Write("Korrekta uppgifter tryck (J)a, om inte, tryck (N)ej.");



                        break;


                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:

                        applicationRunning = false;

                        break;
                }

                Console.Clear();

            } while (applicationRunning);
        }

        private static void AddProduct()
        {
            ConsoleKeyInfo userInput;
            string articleNumber;
            string nameOfProduct;
            string descriptionOfProduct;
            string productPrice;
            do
            {
                Console.Write("Artikelnummer: ");

                articleNumber = Console.ReadLine();


                Console.Write("Namn: ");

                nameOfProduct = Console.ReadLine();


                Console.Write("Beskrivning: ");

                descriptionOfProduct = Console.ReadLine();


                Console.Write("Pris: ");

                productPrice = Console.ReadLine();

                Console.WriteLine("Korrekta uppgifter tryck (J)a, om inte, tryck (N)ej.");


                bool invalidSelection = false;

                do
                {
                    userInput = Console.ReadKey(true);

                    invalidSelection = !(
                        userInput.Key == ConsoleKey.J ||
                        userInput.Key == ConsoleKey.N
                        );

                } while (invalidSelection);

            } while (userInput.Key == ConsoleKey.N);

            Console.Clear();

            switch (userInput.Key)
            {
                case ConsoleKey.J:



                    try
                    {
                        productDictionary.Add(articleNumber, new Product(articleNumber, nameOfProduct, descriptionOfProduct, productPrice));
                        Console.WriteLine("Produkt tillagd");
                        
                    }
                    catch (ArgumentException) when (productDictionary.ContainsKey(articleNumber))
                    {
                        Console.WriteLine("Produkten är redan tillagd");
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("Ogiltigt artikelnummer");
                    }
                    Thread.Sleep(2000);
                    Console.Clear();

                    break;

                case ConsoleKey.N:
                    Console.WriteLine("Åter till menyn");
                    Thread.Sleep(2000);
                    break;

            }
        }
    }
}