namespace _6_Problem;

public static class Program
{
    static void Main()
    {
        List<long> rangeOfNumber = GetRange(1, 100);

        long squareOfSum = GetSquareOfSum(rangeOfNumber);
        long sumOfSquare = GetSumOfSquare(rangeOfNumber);

        long difference = Absolute(squareOfSum - sumOfSquare);

        Console.WriteLine("Answer of the sixth problem: {0}", difference);
    }

    /// <summary>
    /// Get sum of the square of each number in a range.
    /// </summary>
    static long GetSumOfSquare(List<long> range)
    {
        // copy range variable to another variable for not changingmain variable
        List<long> copyOfRange = range;

        // change the range numbers to their squares
        for (int i = 0; i < copyOfRange.Count; i++)
        {
            copyOfRange[i] = Square(copyOfRange[i]);
        }

        // get square of numbers sum
        long sum = copyOfRange.Sum();

        return sum;
    }

    /// <summary>
    /// Get square of sum of a range.
    /// </summary>
    static long GetSquareOfSum(List<long> range)
    {
        long sum = range.Sum();

        long squareOfSum = Square(sum);

        return squareOfSum;
    }

    /// <summary>
    /// Create a list of range of numbers from n to n.
    /// </summary>
    static List<long> GetRange(long from, long to)
    {
        List<long> range = new();

        for (long num = from; num <= to; num++)
        {
            range.Add(num);
        }

        return range;
    }

    /// <summary>
    /// Get square of a number.
    /// </summary>
    static long Square(long number)
    {
        long squareOfNumber = number * number;

        return squareOfNumber;
    }

    /// <summary>
    /// Get absolute of a number.
    /// <para>
    ///     If the number is negative changes it to a positive value.
    ///     Else returns the value.
    /// </para>
    /// </summary>
    static long Absolute(long number)
    {
        if (number < 0)
        {
            return -number;
        }
        return number;
    }
}