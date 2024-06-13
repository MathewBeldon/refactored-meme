namespace refactored_meme;

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