using deloitte_feladat;

const int MIN_INT = 10;
const int MAX_INT = 9999;
const int MIN_STR_LEN = 5;
const int MAX_STR_LEN = 45;
const string APPEND_STRING = "Making an impact that matters –Deloitte";
List<Tuple<int, string>> inputList = new(7);

Console.WriteLine($"Add an item to the list: (current items: {inputList.Count}/7)");

GetInput();

void GetInput()
{
    while(inputList.Count < 7)
    {
        try
        {
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                throw new WrongInputException("Input can't be null!");
            }
            else
            {
                if (int.TryParse(input, out int intInput))
                {
                    HandleIntInput(intInput);
                }
                else
                {
                    HandleStringInput(input);
                }
            }
        }
        catch (WrongInputException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    Console.WriteLine();

    WriteCompleteList();

}

void HandleIntInput(int input)
{
    if (input >= MIN_INT && input <= MAX_INT)
    {
        inputList.Add(new Tuple<int, string>(input, ""));
        Console.WriteLine($"{input} added to the list (current items: {inputList.Count}/7)");
    }
    else
    {
        throw new WrongInputException("Number needs to be between 10 and 9999");
    }
}

void HandleStringInput(string input)
{
    if (input.Length >= MIN_STR_LEN && input.Length <= MAX_STR_LEN)
    {
        inputList.Add(new Tuple<int, string>(0, input));
        Console.WriteLine($"{input} added to the list (current items: {inputList.Count}/7)");
    }
    else
    {
        throw new WrongInputException("String's length needs to be between 5 and 45");
    }
}

void WriteCompleteList()
{
    foreach (var item in inputList)
    {
        if(item.Item1 != 0)
        {
            WriteInt(item.Item1);
        }
        else
        {
            Console.WriteLine(string.Concat(item.Item2, APPEND_STRING.AsSpan(0, item.Item2.Length)));
        }
    }
}

void WriteInt(int item)
{
    if(item % 2 == 0)
    {
        Console.WriteLine(item / 2 + CheckIfPrimeNumber(item));
    }
    else
    {
        Console.WriteLine(item * 2 + CheckIfPrimeNumber(item));
    }
}

string CheckIfPrimeNumber(int number)
{
    for (int i = 2; i < number / 2; i++)
    {
        if (number % i == 0)
        {
            return "";
        }
    }
    return " [prime number]";
}