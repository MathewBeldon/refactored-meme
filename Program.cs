using System.IO.Compression;

namespace refactored_meme;

class Program
{
    static void Main()
    {
        var itemMenu = new List<Item>()
        {
            new Item(1, "item 1", 5.99),
            new Item(2, "item 2", 1.99),
            new Item(3, "item 3", 0.99),
            new Item(4, "item 4", 1.50),
            new Item(5, "item 5", 3.50)
        };

        var itemList = new Dictionary<Item, int>();

        Console.WriteLine("Enter your table number: ");
        var tableNumber  = Console.ReadLine()!;

        Console.WriteLine("Enter your server ID: ");
        var serverId = Console.ReadLine()!;

        while (true) 
        {
            foreach (var item in itemMenu)
            {
                Console.WriteLine($"{item.ItemId}. {item.Name} - £{item.Price:0.00}");
            }

            while (true)
            {
                Console.WriteLine("Select your item: ");
                var menuSelection  = Console.ReadLine()!;

                if (!int.TryParse(menuSelection, out int selectedItem)){
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                var foundItem = itemMenu.SingleOrDefault(x => x.ItemId == selectedItem);
                if (foundItem is not null)
                {
                    while (true)
                    {
                        Console.WriteLine("Quantity of items: ");

                        if (int.TryParse(Console.ReadLine(), out int itemQuantity)) 
                        {
                            if (itemList.ContainsKey(foundItem))
                            {
                                itemList[foundItem] += itemQuantity;

                                break;
                            }

                            itemList.Add(foundItem, itemQuantity);

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
            itemsSubtotal += item.Key.Price * item.Value;
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

        Console.WriteLine($"");
        Console.WriteLine($"*********************");
        Console.WriteLine($"Table Number: {tableNumber}");
        Console.WriteLine($"Server Id: {serverId}");
        Console.WriteLine($"");
        foreach(var item in itemList)
        {
            Console.WriteLine($"Item: {item.Key.Name} Price: {item.Key.Price} Quantity: {item.Value}");
        }
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
    public Item(int itemId, string name, double price)
    {
        ItemId = itemId;
        Name = name;
        Price = price;
    }

    public int ItemId {get; set;}
    public string Name {get; set;}
    public double Price {get; set;}
}