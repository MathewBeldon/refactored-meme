# refactored-meme

## MVP 

### Code Breakdown

```csharp
var shouldContinueAddingItems = true;
var itemList = new List<(string, double)>();
```
This is where we initialised variables for later use; 
 * `shouldContinueAddingItems`: A boolean flag that controls the continuation of the item entry loop. It allows the loop to run until the user indicates they are finished adding items.
 * `itemList`: A list of tuples where each tuple contains a `string` (item name) and a `double` (item price). This list stores all the items entered by the user.

___

```csharp
while (shouldContinueAddingItems) {
    ...
}
```
This is the main loop of the program. It keeps running, allowing the user to input item details until `shouldContinueAddingItems` is set to `false`.
___

```csharp
Console.WriteLine("Enter your item's name: ");
var itemName = Console.ReadLine()!;
```
`Console.ReadLine()` reads the user's input until the Enter key is pressed and stores it in the variable `itemName`.
___
```csharp
Console.WriteLine("Enter your item's price: ");
var itemPrice = Convert.ToDouble(Console.ReadLine());
```
 * `Console.ReadLine()` reads the user's input until the Enter key is pressed.
 * `Convert.ToDouble()` converts the input `string` to a `double` and stores it in the variable `itemPrice`.
___
```csharp
itemList.Add((itemName, itemPrice));
```
This line adds a `tuple` `(itemName, itemPrice)` to the `itemList`.
___
```csharp
Console.WriteLine("Would you like to input another item? (y/n)");
var userResponse  = Console.ReadLine()!;
```
`Console.ReadLine()` reads the user's response and stores it in the variable `userResponse`.
___
```csharp
if (userResponse == "n") {
    shouldContinueAddingItems = false;
}
```
This `if` statement checks if the user's response is 'n'.
If it is, `shouldContinueAddingItems` is set to `false`, which will terminate the loop after the current iteration.
___
```csharp
var totalPrice = 0.0;
```
`totalPrice` is initialized to `0.0` outside the loop to accumulate the total price of all items, `0.0` is the default initialisation for a double
___
```csharp
foreach(var item in itemList){
    Console.WriteLine($"Item: {item.Item1} Price: {item.Item2}");
    totalPrice += item.Item2;
}
```
 * This foreach loop iterates over each `item` in `itemList`.
 * For each item, it prints the item's name and price using string interpolation.
 * It also adds the item's price to `totalPrice` using the `+=` operator.
___

```csharp
Console.WriteLine($"Total: {totalPrice}");
```
This final line prints the total price of all items using string interpolation.