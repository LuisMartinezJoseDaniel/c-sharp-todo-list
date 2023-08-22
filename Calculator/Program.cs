


Console.WriteLine("Hello");

Console.WriteLine("Input the first number");
string inputUser = Console.ReadLine();
int number1  = validAndParseUserInput(inputUser);



Console.WriteLine("Input the second number");
inputUser = Console.ReadLine();
int number2 = validAndParseUserInput(inputUser);


PrintMenu();

string userChoise = Console.ReadLine();



while(!EvaluateChoice(userChoise, number1, number2))
{
    Console.WriteLine("Please Select a valid Option");
    PrintMenu();
    userChoise = Console.ReadLine();
}


Console.WriteLine("Press any key to close");
Console.ReadKey();



int Add(int a , int b)
{
    return a + b;
}

int Substract(int a , int b)
{
    return (a - b);
}

int Multiply(int a , int b)
{
    return a * b;
}

void PrintSelectedOption(string option) {
    Console.WriteLine($"Selected Option: {option}");
}

void PrintMenu()
{
    Console.WriteLine("---MENU---");

    Console.WriteLine("[A]dd");
    Console.WriteLine("[S]ubstract");
    Console.WriteLine("[M]ultply");

    Console.WriteLine("----------");
}

// operator is a KeyWord of C#
void PrintResult(int a, int b, int result, string @operator) {
    Console.WriteLine($"{a} {@operator} {b} = {result}");
}

bool EvaluateChoice(string userChoice, int number1, int number2) {
    switch (userChoice.ToUpper())
    {
        case "A":
            PrintResult(number1, number2, Add(number1, number2), "+");
            return true;
        case "S":
            PrintResult(number1, number2, Substract(number1, number2), "-");
            return true;
        case "M":
            PrintResult(number1, number2, Multiply(number1, number2), "*");
            return true;
        default:
            Console.WriteLine("Invalid Choice");
            return false;
    }
}

bool isValidUserInput(string userInput) {
    try
    {
       int.Parse(userInput);
        return true;
    }catch(FormatException e) {
        
        return false;
    }
}

int validAndParseUserInput(string userInput) {

    while (!isValidUserInput(userInput))
    {
        Console.WriteLine("Please enter a valid number");
        userInput = Console.ReadLine();
    }

    return int.Parse(userInput);
}