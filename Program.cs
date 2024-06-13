namespace refactored_meme;

class Program
{
    static void Main()
    {
        var shouldContinueAddingItems = true;
        var itemList = new List<(string, double)>();

        while (shouldContinueAddingItems) {
            Console.WriteLine("Enter your item's name: ");
            var itemName = Console.ReadLine()!;

            Console.WriteLine("Enter your item's price: ");
            var itemPrice = Convert.ToDouble(Console.ReadLine());

            itemList.Add((itemName, itemPrice));

            Console.WriteLine("Would you like to input another item? (y/n)");
            var userResponse  = Console.ReadLine()!;

            if (userResponse == "n") {
                shouldContinueAddingItems = false;
            }
        }

        var totalPrice = 0.0;

        foreach(var item in itemList){
            Console.WriteLine($"Item: {item.Item1} Price: {item.Item2}");
            totalPrice += item.Item2;
        }

        Console.WriteLine($"Total: {totalPrice}");
    }
}
