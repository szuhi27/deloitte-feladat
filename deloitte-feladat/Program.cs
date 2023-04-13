using deloitte_feladat;
using System.Diagnostics;

const int MIN_INT = 10;
const int MAX_INT = 9999;
const int MIN_STR_LEN = 5;
const int MAX_STR_LEN = 45;
const string APPEND_STRING = "Making an impact that matters –Deloitte";
List<Tuple<int, string>> inputList = new(7);

Console.WriteLine($"Add an item to the list: (current items: {inputList.Count}/7)");
Console.WriteLine("To exit press 'x'");
Console.WriteLine("To see previous records press 'r'");

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
            else if (input == "x")
            {
                Environment.Exit(1);
            }
            else if (input == "r") // 4 debugging
            {
                if (inputList.Count == 0)
                {
                    Console.WriteLine("There is no data commited.");
                }
                else
                {
                    WriteAllItemsRaw();
                }
            }
            else
            {
                int intInput;
                if (int.TryParse(input, out intInput))
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
    
    WriteCompleteList();

}

void WriteAllItemsRaw()
{
    foreach (var item in inputList)
    {
        if (item.Item1 == 0)
        {
            Console.WriteLine($"{item.Item2}\n");
        }
        else
        {
            Console.WriteLine($"{item.Item1}\n");
        }
    }
}

void HandleIntInput(int input)
{
    try
    {
        if (input < MIN_INT || input > MAX_INT)
        {
            throw new WrongInputException("Number needs to be between 10 and 9999");
        }
        else
        {
            inputList.Add(new Tuple<int, string>(input, ""));
            Console.WriteLine($"{input} added to the list");
        }
    }
    catch (WrongInputException e)
    {
        Console.WriteLine(e.Message);
    }
}

void HandleStringInput(string input)
{

}

void WriteCompleteList()
{

}