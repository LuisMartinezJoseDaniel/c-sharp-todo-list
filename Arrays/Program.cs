/* Arrays */
//int [] numbers = new int[5];

//* Array Initializer
var numbers = new int[] { -1, 2, -3, 4, -5 };

//out keyword allowed us to bypass the limitation of returning only one value from a method.
// if a parameter has the out modifier, the code will not compile if it is not assigned in the method

// this method still returns a list of integers but also sets a value of a variable passed
// this is like a reference to a variable

var onlyPositive = GetOnlyPositive(numbers, out int nonPositiveCount);

Console.WriteLine($"Count on non positive : {nonPositiveCount}");

foreach (var number in onlyPositive)
{
    Console.WriteLine(number);
}






// shift + 6 = ^
var lastValue = numbers[^1]; //numbers[numbers.Length - 1 ]
var secondLastValue = numbers[^2]; //numbers[numbers.Length - 2]

/* Two dimensional array*/
//* This is equal to letters2
char[,] letters = new char[2, 3];
letters[0, 0] = 'a';
letters[0, 1] = 'b';
letters[0, 2] = 'c';
letters[1, 0] = 'd';
letters[1, 1] = 'e';
letters[1, 2] = 'f';

var height = letters.GetLength(0); // 2 -> getDimesion 1
var width = letters.GetLength(1); // 3 -> getDimesion 2

var letters2 = new char[,]
{
    {'a', 'b', 'c'},
    {'d', 'e', 'f'}
};

var myWords = new List<string> { "one", "TWO", "THREE", "four", "TWO" };






Console.ReadKey();



/** Exercices*/
int FindMax(int[,] numbers)
{
    var height = numbers.GetLength(0);
    var width = numbers.GetLength(1);

    if (height == 0 || width == 0)
        return -1;


    var max = numbers[0, 0];


    for (int i = 0; i < height; i++)
    {
        for (int j = 1; j < width; j++)
        {

        }
    }


    return max == 0 ? -1 : max;
}
List<string> GetOnlyUpperCaseWords(List<string> words)
{
    List<string> upperCaseWords = new List<string>();

    foreach (var word in words)
    {
        var upperCaseWord = word.ToUpper();

        if (upperCaseWords.Contains(upperCaseWord))
            continue;

        if (word.Equals(upperCaseWord) && upperCaseWord.All(char.IsLetter))
        {
            upperCaseWords.Add(upperCaseWord);
        }
    }

    return upperCaseWords;

}

//* out Keyword -> allows to return multiple values
// GetOnlyPositive -> returns only positive numbers in an array
// then we can get a second value with out keyword
List<int> GetOnlyPositive(
    int[] numbers, out int countOfNonPositive)
{
    countOfNonPositive = 0;
    var result = new List<int>();
    foreach (var number in numbers)
    {
        if (number > 0)
        {
            result.Add(number);

        }
        else
        {
            countOfNonPositive++;
        }
    }

    return result;
}