List<string> todos = new List<string>();

static void ShowNoTodosMessage()
{
    Console.WriteLine("Empty TODO's List \n");
}

string userChoice;
do
{
    PrintMenu();
    userChoice = GetUserInput();
    EvaluateUserChoice(userChoice);

} while (!userChoice.Equals("E"));




Console.ReadKey();


void PrintMenu()
{
    Console.WriteLine("Hello!");
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");
}

string GetUserInput()
{
    var validChoices = new List<string> { "S", "A", "R", "E" };

    var input = Console.ReadLine();


    while (input.Length < 1)
    {
        Console.WriteLine("Invalid choice");
        input = Console.ReadLine();
    }

    while (!validChoices.Contains(input.ToUpper()))
    {
        Console.WriteLine("Invalid choice");
        input = Console.ReadLine();
    }

    return input.ToUpper();
}

void EvaluateUserChoice(string userChoice)
{
    switch (userChoice)
    {
        case "S":
            SeeAllTodos();
            break;
        case "A":
            AddTodo();
            break;
        case "R":
            RemoveTodo();
            break;
        case "E":
            Exit();

            break;
        default:
            break;
    }
}

void SeeAllTodos()
{
    if (todos.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }

    int index = 1;
    foreach (var todo in todos)
    {
        Console.WriteLine($"{index}. {todo}");
        index++;
    }
    Console.WriteLine();
}


void AddTodo()
{
    string newTodo = GetNewTodo();
    todos.Add(newTodo);
    Console.WriteLine();
}

string GetNewTodo()
{

    string todo;
    do
    {
        Console.WriteLine("Enter the todo Description");
        todo = Console.ReadLine();
    } while (!IsDescriptionValid(todo));



    return todo;
}

bool IsDescriptionValid(string description)
{
    var emptyDescription = string.IsNullOrEmpty(description);
    if (emptyDescription)
    {
        Console.WriteLine("TODO can't be empty\n");
        return !emptyDescription;
    }

    var todoExists = todos.Any(t => t.ToUpper().Equals(description.ToUpper()));
    if (todoExists) Console.WriteLine("TODO already exists\n");

    return !todoExists;
}


void RemoveTodo()
{
    if (todos.Count < 1)
    {
        ShowNoTodosMessage();
        return;
    }
    int index;
    do
    {
        Console.WriteLine("Please, select the index of the TODO you want to remove\n");
        SeeAllTodos();
    } while (!TryReadIndex(out index));

    RemoveTodoAtIndex(index);
}

void RemoveTodoAtIndex(int index)
{
    var todoRemoved = todos[index];
    todos.RemoveAt(index);

    Console.WriteLine($"TODO removed {todoRemoved}\n");
}

// out -> this is like an object reference
// we can access the value of the variable outside the method
bool TryReadIndex(out int index)
{
    index = 0;
    string userInput = Console.ReadLine();

    if (string.IsNullOrEmpty(userInput))
    {
        Console.WriteLine("Selected index cannot be empty");
        return false;
    }

    var result = int.TryParse(userInput, out index);

    if (index > todos.Count || index < 1)
    {
        Console.WriteLine("The given index is not valid");
        return false;
    }

    index--; // we substract 1 because the user will select 1, 2, 3, 4, 5, etc

    return result;

}

void Exit()
{
    System.Environment.Exit(0);
}





