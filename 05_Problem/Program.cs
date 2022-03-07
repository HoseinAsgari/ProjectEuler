namespace _4_Problem;

class Program
{
    static void Main()
    {
        long number = GetDividableNumberInRange(1, 20);

        Console.WriteLine("Answer of the fifth problem: {0}", number);
    }

    /// <summary>
    ///  Find minimum number that can devide from all numbers in a range.
    /// </summary>
    static long GetDividableNumberInRange(long from, long to)
    {
        long i = 2;

        CorrectInputs(ref from, ref to);

        // loop will repeat till finding correct answer
        while (true)
        {
            bool canBeDivide = CanBeDivideByFromNToN(from, to, i);

            if (canBeDivide is true)
            {
                return i;
            }

            i++;
        }
    }

    /// <summary>
    /// Whether number can be devided by first argument to second argument or not.
    /// </summary>
    static bool CanBeDivideByFromNToN(long from, long to, long number)
    {
        for (long i = from; i < to; i++)
        {
            if (number % i is not 0)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// If numbers are negative, zero or one, changes it to three or upper.
    /// </summary>
    static void CorrectInputs(ref long from, ref long to)
    {
        if (to < 4)
        {
            to = 3;
        }

        if (from < 2)
        {
            from = 2;
        }
    }
}