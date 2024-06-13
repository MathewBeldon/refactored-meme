namespace refactored_meme;

class Program
{
    static void Main()
    {
        var itemList = new List<Item>();

        Console.WriteLine("Enter your table number: ");
        var tableNumber  = Console.ReadLine()!;

        Console.WriteLine("Enter your server ID: ");
        var serverId = Console.ReadLine()!;

        while (true) 
        {
            Console.WriteLine("Enter your item's name: ");
            var itemName = Console.ReadLine()!;

            while (true)
            {
                Console.WriteLine("Enter your item's price: ");

                if (double.TryParse(Console.ReadLine(), out double itemPrice)) 
                {
                    itemList.Add(new Item(itemName, itemPrice));
                    break;
                }
                
                Console.WriteLine("Invalid price. Please enter a valid number.");
            }
            
            Console.WriteLine("Would you like to input another item? (y/n)");
            var userResponse  = Console.ReadLine()!;

            if (userResponse == "n") 
            {
                break;
            }
        }

        Console.WriteLine($"Table Number: {tableNumber}");
        Console.WriteLine($"Server Id: {serverId}");

        var totalPrice = 0.0;

        foreach(var item in itemList)
        {
            Console.WriteLine($"Item: {item.Name} Price: {item.Price}");
            totalPrice += item.{item.Price};
        }

        Console.WriteLine($"Total: {totalPrice}");
    }
}

class Item
{
    public Item(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public string Name {get; set;}
    public double Price {get; set;}
}