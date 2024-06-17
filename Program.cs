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
                    while (true)
                    {
                        Console.WriteLine("Quantity of items: ");

                        if (int.TryParse(Console.ReadLine(), out int itemQuantity)) 
                        {
                            itemList.Add(new Item(itemName, itemPrice, itemQuantity));

                            break;
                        }
                        
                        Console.WriteLine("Invalid quantity. Please enter a valid number.");
                    }

                    break;
                }
                
                Console.WriteLine("Invalid price. Please enter a valid number.");
            }
            
            Console.WriteLine("Would you like to input another item? (y/n)");
            
            var userResponse  = Console.ReadLine()!;

            if (userResponse != "y") 
            {
                break;
            }
        }

        var tipSubtotal = 0.0;
        var itemsSubtotal = 0.0;
        
        foreach(var item in itemList)
        {
            itemsSubtotal += item.Price * item.Quantity;
        }

        Console.WriteLine("Would you like to add a tip? (y/n)");
        var addTip  = Console.ReadLine()!;

        if (addTip == "y") 
        {
            while (true)
            {
                Console.WriteLine("Tip percentage: ");

                if (int.TryParse(Console.ReadLine(), out int tipPercentage)) 
                {
                    tipSubtotal += (itemsSubtotal / 100) * tipPercentage;

                    break;
                }
                
                Console.WriteLine("Invalid tip amount. Please enter a valid number.");
            }           
        }

        
        foreach(var item in itemList)
        {
            Console.WriteLine($"Item: {item.Name} Price: {item.Price} Quantity: {item.Quantity}");
        }

        Console.WriteLine($"");
        Console.WriteLine($"*********************");
        Console.WriteLine($"Table Number: {tableNumber}");
        Console.WriteLine($"Server Id: {serverId}");
        Console.WriteLine($"");
        Console.WriteLine($"Subtotal: {itemsSubtotal}");
        Console.WriteLine($"Tip: {tipSubtotal}");
        Console.WriteLine($"");
        Console.WriteLine($"Total: {itemsSubtotal + tipSubtotal}");
        Console.WriteLine($"*********************");
    }
}

class Item
{
    public Item(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public string Name {get; set;}
    public double Price {get; set;}
    public int Quantity {get; set;}
}