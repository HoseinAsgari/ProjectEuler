namespace _1_Problem;

class Program
{
    static void Main(string[] args)
    {
        List<int> rightNumbers = GetRightNumbers();

        int sumOfNumbers = rightNumbers.Sum();

        Console.WriteLine("Answer of the first problem: {0}", sumOfNumbers);
    }

    /// <summary>
    /// Returns list of numbers that are natural, less than 1000 and multiple of 3 or 5.
    /// </summary>
    private static List<int> GetRightNumbers()
    {
        List<int> numbers = new();

        for (int i = 1; i < 1000; i++)
        {
            if (HasNumberTrueCondition(i))
            {
                numbers.Add(i);
            }
        }

        return numbers;
    }

    /// <summary>
    /// Return whether condition of problem is true or not for a number.
    /// </summary>
    /// <params>
    /// Gets natural integer less than 1000.
    /// </params>
    private static bool HasNumberTrueCondition(int number)
    {
        if (number % 3 == 0 || number % 5 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}