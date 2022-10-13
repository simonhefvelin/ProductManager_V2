using Productspace;


namespace ProductManager
{
    class Products
    {
        

        static void Main(string[] args)
        {
            List<Product> listOfProducts = new List<Product>();

            var applicationRunning = true;
            do
            {
                Console.WriteLine("(1) Ny produkt");
                Console.WriteLine("(2) Sök produkt");
                Console.WriteLine("(3) Avsluta");

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
                        userInput.Key == ConsoleKey.NumPad3
                        );

                } while (invalidSelection);

                Console.Clear();


                switch (userInput.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        Console.Write("Artikelnummer: ");

                        string articleNumber = Console.ReadLine();


                        Console.Write("Namn: ");

                        string nameOfProduct = Console.ReadLine();


                        Console.Write("Beskrivning: ");

                        string descriptionOfProduct = Console.ReadLine();


                        Console.Write("Pris: ");

                        string productPrice = Console.ReadLine();

                        Console.WriteLine("Korrekta uppgifter tryck (J)a, om inte, tryck (N)ej.");

                        

                        var newProduct = new Product
                            (articleNumber,
                            nameOfProduct,
                            descriptionOfProduct,
                            productPrice);
                        
                        
                        
                        do
                        {
                            userInput = Console.ReadKey(true);

                            invalidSelection = !(
                                userInput.Key == ConsoleKey.J ||
                                userInput.Key == ConsoleKey.N
                                );

                        } while (invalidSelection);

                        Console.Clear();

                        switch (userInput.Key)
                        {
                            case ConsoleKey.J:

                                bool notExists = !listOfProducts.Any(x => x.nameOfProduct == newProduct.nameOfProduct);

                                if (notExists)
                                {
                                    listOfProducts.Add(newProduct);
                                   
                                    Console.WriteLine("Produkt tillagd");

                                }
                                else
                                {
                                    
                                    Console.WriteLine("Produkten är redan tillagd");
                                    
                                }
                                Thread.Sleep(2000);
                                Console.Clear();
                                
                                break;

                            case ConsoleKey.N:
                                Console.WriteLine("Åter till menyn");
                                Thread.Sleep(2000);
                                break;

                        }

                        break;


                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:

                        Console.Write("Sök efter namn på produkten: ");

                        string searchProduct = Console.ReadLine();

                        

                        bool exist = listOfProducts.Any(x => x.nameOfProduct == searchProduct);

                        if (exist)
                        {
                            Product findProduct = listOfProducts.First(x => x.nameOfProduct == searchProduct);

                            Console.Clear();
                            Console.WriteLine($"Artikelnummer: {findProduct.articleNumber}");
                            Console.WriteLine($"Namn: {findProduct.nameOfProduct}");
                            Console.WriteLine($"Beskrivning: {findProduct.descriptionOfProduct}");
                            Console.WriteLine($"Pris: {findProduct.productPrice}");


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

                        applicationRunning = false;

                        break;
                }

                Console.Clear();

            } while (applicationRunning);
        }



    }
}