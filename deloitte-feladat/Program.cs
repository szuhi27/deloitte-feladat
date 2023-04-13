using deloitte_feladat;

internal class Program
{

    static List<Tuple<int, string>> datasList = new(7);

    private static void Main(string[] args)
    {
        Console.WriteLine($"Add an item to the list: (current items: {datasList.Count}/7)");

        try
        {
            GetInput();
        }
        catch (WrongInputException e) 
        { 
            Console.WriteLine(e.Message); 
        }
    }

    static void GetInput()
    {
        var input = Console.ReadLine();

        if(string.IsNullOrEmpty(input) )
        {
            throw new WrongInputException("Input can't be null");
        }
    }


}