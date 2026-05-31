namespace CustomLinkedListImplementation;

internal class Program
{
    static void Main(string[] args)
    {
        var customLinkedList = new CustomLinkedList<string>();
        customLinkedList.Add("Milos");
        customLinkedList.Add("Test");
        customLinkedList.Add("Test 2");
        customLinkedList.Add("Test 3");
        customLinkedList.Add("Test 4");
        customLinkedList.Add("Test 5");

        foreach(var item in customLinkedList)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Hello, World!");
        Console.ReadKey();
    }
}
