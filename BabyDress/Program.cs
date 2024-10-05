using System;
using System.Collections.Generic;

//Creating class for BabyDress
public class BabyDress
{
    public int Size { get; set; }
    public string Color { get; set; }
    public string Brand { get; set; }
    public double Price { get; set; }
}


//Creating BabyDressUtility class consist of methods
public class BabyDressUtility
{
    //Adding dress to cart
    public static void AddDressToCart(BabyDress dress)
    {
        Program.DressesCart.Add(dress);
    }

    //removing dress from cart
    public static bool RemoveDressFromCart(string brand)
    {
        return Program.DressesCart.RemoveAll(d => d.Brand == brand) > 0;
    }

    //calculating total price
    public static double CalculateTotalPrice()
    {
        return Program.DressesCart.Sum(d => d.Price);
    }
}

public class Program
{
    public static List<BabyDress> DressesCart = new List<BabyDress>();

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Add dress to cart");
            Console.WriteLine("2. Remove dress from cart");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter the dress size ");
                    int size = int.Parse(Console.ReadLine());
                    Console.Write("Enter the dress color ");
                    string color = Console.ReadLine();
                    Console.Write("Enter the dress brand ");
                    string brand = Console.ReadLine();
                    Console.Write("Enter the dress price ");
                    double price = Convert.ToDouble(Console.ReadLine());

                    BabyDress dress = new BabyDress { Size = size, Color = color, Brand = brand, Price = price };
                    BabyDressUtility.AddDressToCart(dress);
                    Console.WriteLine("Successfully added to the dress cart");
                    break;
                case 2:
                    Console.Write("Enter the dress brand to remove from cart ");
                    string removeBrand = Console.ReadLine();
                    if (BabyDressUtility.RemoveDressFromCart(removeBrand))
                    {
                        Console.WriteLine("Successfully removed from the cart");
                    }
                    else
                    {
                        Console.WriteLine("Dress not found in the cart");
                    }
                    break;
                case 3:
                    Console.WriteLine("Thank you!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    break;
            }
        }
    }
}
