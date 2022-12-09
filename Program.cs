using Microsoft.EntityFrameworkCore;
using ProductManager.Data;
using ProductManager.Models;
using static System.Console;

namespace ProductManager;

class Products
{


    static ApplicationContext context = new ApplicationContext();
    static void Main(string[] args)
    {
        context.Database.Migrate();

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

                    ListCategorys();

                    break;

                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:

                    applicationRunning = false;

                    break;
            }

            Clear();

        } while (applicationRunning);
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

                    context.Product.Add(new Product(articleNumber, nameOfProduct, descriptionOfProduct, productPrice));

                    context.SaveChanges();

                    WriteLine("Produkt tillagd");

                }
                catch (ArgumentException)
                {
                    WriteLine("Ogiltigt artikelnummer");
                }
                catch (DbUpdateException)
                {
                    WriteLine("Produkt finns redan");
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
    static void SearchProduct()
    {
        Write("Sök efter artikelnummer på produkten: ");

        var searchProduct = ReadLine();

        Clear();

        var searchResult = FindProduct(searchProduct);


        //Product searchResult = context.Product.FirstOrDefault(x => x.ArticleNumber == searchProduct);

        bool invalidSelection = false;

        ConsoleKeyInfo userInput;

        if (searchResult != null)
        {

            Clear();

            WriteLine($"Artikelnummer: {searchResult.ArticleNumber}");
            WriteLine($"Namn: {searchResult.Name}");
            WriteLine($"Beskrivning: {searchResult.Description}");
            WriteLine($"Pris: {searchResult.Price}");
            WriteLine();

            WriteLine("Tryck valfri tangent för att gå tillbaka");

            do
            {
                userInput = ReadKey(true);

            } while (invalidSelection);
        }
        else
        {
            Clear();
            WriteLine("Produkt saknas");
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
                        context.Category.Add(new Category(nameOfCategory));

                        context.SaveChanges();

                        WriteLine("Kategori tillagd");
                    }
                    catch (ArgumentException)
                    {
                        WriteLine("Ogiltigt namn");
                    }
                    catch (DbUpdateException)
                    {
                        WriteLine("Kategori finns redan");
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

    static void AddProductToCategory()
    {
        Write("Ange artikelnummer: ");

        var searchProduct = ReadLine();

        Clear();

        var product = FindProduct(searchProduct);


        if (product != null)
        {

            WriteLine("Sök kategori:");

            var category = ReadLine();

            Clear();

            var searchCategory = FindCategory(category);


            if (searchCategory != null)
            {                            
                try
                {
                    searchCategory.Product.Add(product);

                    var updateSuccess = context.SaveChanges();

                    if (updateSuccess == 0) throw new Exception("");
                    
                    WriteLine("Produkt tillagd i kategori");
                }
                catch (Exception)
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


    static void ListCategorys()
    {
        WriteLine("Namn");
        WriteLine("--------------------------------");

        var getCategory = context.Category.Include(x => x.Product);

        foreach (var categorys in getCategory)
        {
            WriteLine($"{categorys.Name} ({categorys.Product.Count})");
        }

        ReadKey();

        Clear();
    }



    static Product? FindProduct(string? searchProduct)
    {       

        var searchResult = context.Product
            .FirstOrDefault(x => x.ArticleNumber == searchProduct);

        return searchResult;
    }


    static Category? FindCategory(string category)
    {
   
        return context.Category.Include(x => x.Product).FirstOrDefault(x => x.Name == category);

    }




}
