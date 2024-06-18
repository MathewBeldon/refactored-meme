# refactored-meme

## MVP 

```csharp
class Program
{
    static void Main()
    {
        var shouldContinueAddingItems = true;
        var itemList = new List<Item>();

        while (shouldContinueAddingItems)
        {
            Console.WriteLine("Enter your item's name: ");
            var itemName = Console.ReadLine()!;

            Console.WriteLine("Enter your item's price: ");
            var itemPrice = Convert.ToDouble(Console.ReadLine());

            itemList.Add(new Item(itemName, itemPrice));

            Console.WriteLine("Would you like to input another item? (y/n)");
            var userResponse  = Console.ReadLine()!;

            if (userResponse == "n")
            {
                shouldContinueAddingItems = false;
            }
        }

        var totalPrice = 0.0;

        foreach(var item in itemList)
        {
            Console.WriteLine($"Item: {item.Name} Price: {item.Price}");
            totalPrice += item.Price;
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
```


## Phase Two

```csharp
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
```

## Phase Three

```csharp
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

        Console.WriteLine("");
        Console.WriteLine("*********************");
        Console.WriteLine($"Table Number: {tableNumber}");
        Console.WriteLine($"Server Id: {serverId}");
        Console.WriteLine("");
        Console.WriteLine($"Subtotal: {itemsSubtotal}");
        Console.WriteLine($"Tip: {tipSubtotal}");
        Console.WriteLine("");
        Console.WriteLine($"Total: {itemsSubtotal + tipSubtotal}");
        Console.WriteLine("*********************");
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
```

## Phase 4
```csharp
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

                if (!int.TryParse(menuSelection, out int selectedItem))
                {
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

        Console.WriteLine("");
        Console.WriteLine("*********************");
        Console.WriteLine($"Table Number: {tableNumber}");
        Console.WriteLine($"Server Id: {serverId}");
        Console.WriteLine"");
        foreach(var item in itemList)
        {
            Console.WriteLine($"Item: {item.Key.Name} Price: {item.Key.Price} Quantity: {item.Value}");
        }
        Console.WriteLine("");     
        Console.WriteLine($"Subtotal: {itemsSubtotal}");
        Console.WriteLine($"Tip: {tipSubtotal}");
        Console.WriteLine("");
        Console.WriteLine($"Total: {itemsSubtotal + tipSubtotal}");
        Console.WriteLine("*********************");
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
```

## Phase 5

```csharp
using System.IO.Compression;

namespace refactored_meme;

class Program
{
    static void Main()
    {
        var hasSelectedExit = false;
        while (!hasSelectedExit) 
        {
            Console.WriteLine("1. Start Order");
            Console.WriteLine("2. Exit");

            while (true)
            {
                Console.WriteLine("Menu choice: ");
                var mainMenuSelection  = Console.ReadLine()!;

                if (mainMenuSelection == "1")
                {
                    var order = StartOrder();
                    PrintRecipt(order);
                    break;
                }

                if (mainMenuSelection == "2")
                {
                    hasSelectedExit = true;
                    break;
                }
            }
        }

        Order StartOrder()
        {
            var itemMenu = new List<Item>()
            {
                new Item(1, "item 1", 5.99),
                new Item(2, "item 2", 1.99),
                new Item(3, "item 3", 0.99),
                new Item(4, "item 4", 1.50),
                new Item(5, "item 5", 3.50)
            };

            Console.WriteLine("Enter your table number: ");
            var tableNumber  = Console.ReadLine()!;

            Console.WriteLine("Enter your server ID: ");
            var serverId = Console.ReadLine()!;

            var order = new Order(tableNumber, serverId);

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

                    if (!int.TryParse(menuSelection, out int selectedItem))
                    {
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
                                if (order.OrderItems.ContainsKey(foundItem))
                                {
                                    order.OrderItems[foundItem] += itemQuantity;

                                    break;
                                }

                                order.OrderItems.Add(foundItem, itemQuantity);

                                break;
                            }
                            
                            Console.WriteLine("Invalid quantity. Please enter a valid number.");
                        }

                        break;
                    }
                    
                    Console.WriteLine("Invalid item Id. Please enter a valid Id.");
                }
                
                Console.WriteLine("Would you like to input another item? (y/n)");
                
                var userResponse  = Console.ReadLine()!;
                if (userResponse != "y") 
                {
                    break;
                }
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
                        order.TipAmount = tipPercentage;

                        break;
                    }
                    
                    Console.WriteLine("Invalid tip amount. Please enter a valid number.");
                }           
            }

            return order;
        }

        void PrintRecipt(Order order)
        {
            Console.WriteLine("");
            Console.WriteLine($"*********************");
            Console.WriteLine($"Table Number: {order.TableNumber}");
            Console.WriteLine($"Server Id: {order.ServerId}");
            Console.WriteLine("");
            foreach(var item in order.OrderItems)
            {
                Console.WriteLine($"Item: {item.Key.Name} Price: {item.Key.Price} Quantity: {item.Value}");
            }
            Console.WriteLine("");     
            Console.WriteLine($"Subtotal: {order.GetSubtotal()}");
            Console.WriteLine($"Tip: {order.GetTipAmount()}");
            Console.WriteLine("");
            Console.WriteLine($"Total: {order.GetSubtotal() + order.GetTipAmount()}");
            Console.WriteLine($"*********************");
            Console.WriteLine("");     
        }
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

class Order
{
    public Order(string tableNumber, string serverId)
    {
        TableNumber = tableNumber;
        ServerId = serverId;
        OrderItems = new();
    }

    public string TableNumber {get; set;}
    public string ServerId {get; set;}

    public int TipAmount {get; set; }
    public Dictionary<Item, int> OrderItems {get; set;}

    public double GetSubtotal()
    {
        var subtotal = 0.0;

        foreach(var item in OrderItems)
        {
            subtotal += item.Key.Price * item.Value;
        }

        return subtotal;
    }

    public double GetTipAmount()
    {
        return (GetSubtotal() / 100) * TipAmount;
    }
}
```

## Phase 6
```csharp
using System.IO.Compression;

namespace refactored_meme;

class Program
{
    static void Main()
    {
        var hasSelectedExit = false;
        var orderHistory = new List<Order>();
        while (!hasSelectedExit) 
        {
            Console.WriteLine("1. Start Order");
            Console.WriteLine("2. Order History");
            Console.WriteLine("3. Exit");

            while (true)
            {
                Console.WriteLine("Menu choice: ");
                var mainMenuSelection  = Console.ReadLine()!;

                if (mainMenuSelection == "1")
                {
                    var order = StartOrder();
                    PrintRecipt(order);
                    orderHistory.Add(order);

                    break;
                }

                if (mainMenuSelection == "2")
                {
                    foreach(var order in orderHistory)
                    {
                        PrintRecipt(order);
                    }

                    break;
                }

                if (mainMenuSelection == "3")
                {
                    hasSelectedExit = true;
                    break;
                }
            }
        }

        Order StartOrder()
        {
            var itemMenu = new List<Item>()
            {
                new Item(1, "item 1", 5.99),
                new Item(2, "item 2", 1.99),
                new Item(3, "item 3", 0.99),
                new Item(4, "item 4", 1.50),
                new Item(5, "item 5", 3.50)
            };

            Console.WriteLine("Enter your table number: ");
            var tableNumber  = Console.ReadLine()!;

            Console.WriteLine("Enter your server ID: ");
            var serverId = Console.ReadLine()!;

            var order = new Order(tableNumber, serverId);

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

                    if (!int.TryParse(menuSelection, out int selectedItem))
                    {
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
                                if (order.OrderItems.ContainsKey(foundItem))
                                {
                                    order.OrderItems[foundItem] += itemQuantity;

                                    break;
                                }

                                order.OrderItems.Add(foundItem, itemQuantity);

                                break;
                            }
                            
                            Console.WriteLine("Invalid quantity. Please enter a valid number.");
                        }

                        break;
                    }
                    
                    Console.WriteLine("Invalid item Id. Please enter a valid Id.");
                }
                
                Console.WriteLine("Would you like to input another item? (y/n)");
                
                var userResponse  = Console.ReadLine()!;
                if (userResponse != "y") 
                {
                    break;
                }
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
                        order.TipAmount = tipPercentage;

                        break;
                    }
                    
                    Console.WriteLine("Invalid tip amount. Please enter a valid number.");
                }           
            }

            return order;
        }

        void PrintRecipt(Order order)
        {
            Console.WriteLine("");
            Console.WriteLine("*********************");
            Console.WriteLine($"Table Number: {order.TableNumber}");
            Console.WriteLine($"Server Id: {order.ServerId}");
            Console.WriteLine("");
            foreach(var item in order.OrderItems)
            {
                Console.WriteLine($"Item: {item.Key.Name} Price: {item.Key.Price} Quantity: {item.Value}");
            }
            Console.WriteLine("");     
            Console.WriteLine($"Subtotal: {order.GetSubtotal()}");
            Console.WriteLine($"Tip: {order.GetTipAmount()}");
            Console.WriteLine("");
            Console.WriteLine($"Total: {order.GetSubtotal() + order.GetTipAmount()}");
            Console.WriteLine("*********************");
            Console.WriteLine("");     
        }
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

class Order
{
    public Order(string tableNumber, string serverId)
    {
        TableNumber = tableNumber;
        ServerId = serverId;
        OrderItems = new();
    }

    public string TableNumber {get; set;}
    public string ServerId {get; set;}

    public int TipAmount {get; set; }
    public Dictionary<Item, int> OrderItems {get; set;}

    public double GetSubtotal()
    {
        var subtotal = 0.0;

        foreach(var item in OrderItems)
        {
            subtotal += item.Key.Price * item.Value;
        }

        return subtotal;
    }

    public double GetTipAmount()
    {
        return (GetSubtotal() / 100) * TipAmount;
    }
}
```