namespace ToDoList;

internal class Program
{
    static void Main(string[] args)
    {
        bool isRunning = true;
        List<string> todoItems = new List<string>();

        do
        {
            DisplayMenu();
            string userChoiceInput = Console.ReadLine();
            char.TryParse(userChoiceInput.ToLower(), out char userChoice);


            Console.WriteLine(); // just some spacing
            switch (userChoice)
            {
                case 's':
                    ListTodoItems(todoItems);
                    break;
                case 'a':
                    AddTodoItem(todoItems);
                    break;
                case 'r':
                    RemoveTodo(todoItems);
                    break;
                case 'e':
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Incorrect input.");
                    break;
            }
            Console.WriteLine(); // just some spacing
        }
        while (isRunning);
    }

    static void RemoveTodo(List<string> todoItems)
    {
        ListTodoItems(todoItems);

        if (todoItems.Count > 0)
        {

            Console.WriteLine("Select the index of the TODO you want to remove:");
            int index;
            string userInput = Console.ReadLine();
            bool isCorrectInput = int.TryParse(userInput, out index);

            if (isCorrectInput && index < todoItems.Count)
            {
                string choiceItem = todoItems[index - 1];
                todoItems.RemoveAt(index - 1);
                Console.WriteLine($"TODO removed: {choiceItem}.");
            }
            else
            {
                Console.WriteLine("The given index is not valid.");
                RemoveTodo(todoItems);
            }
        }
    }
    static void ListTodoItems(List<string> todoItems)
    {
        if (todoItems.Count > 0)
        {
            for (int i = 0; i < todoItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {todoItems[i]}");
            }
        }
        else
        {
            Console.WriteLine("No TODOs have been added yet.");
        }
    }

    static void AddTodoItem(List<string> todoList)
    {
        Console.WriteLine("Enter the TODO description: ");
        string userInput = Console.ReadLine();

        if (userInput.Length > 0)
        {
            if (todoList.Contains(userInput))
            {
                Console.WriteLine("The description must be unique.");
                AddTodoItem(todoList);
            }
            else
            {
                todoList.Add(userInput);
                Console.WriteLine($"TODO successfully added: {userInput}.");
            }
        }
        else
        {
            Console.WriteLine("The description cannot be empty.");
            AddTodoItem(todoList);
        }

    }

    static void DisplayMenu()
    {
        Console.WriteLine("Hello");
        Console.WriteLine("What do you want to do?");

        Console.WriteLine("[S]ee all TODOs");
        Console.WriteLine("[A]dd a TODO");
        Console.WriteLine("[R]emove a TODO");
        Console.WriteLine("[E]xit");
    }
}
