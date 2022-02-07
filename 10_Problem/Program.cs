namespace _10_Problem;

class Program
{
    static void Main()
    {
        ulong from = 4;
        ulong to = 2000000;

        ulong sum = SumOfPrimeRange(from, to);

        Console.WriteLine("Answer of the tenth problem: {0}", sum);
    }

    /// <summary>
    /// Get sum of primes of a range.
    /// </summary>
    static ulong SumOfPrimeRange(ulong from, ulong to)
    {
        // checks 'from' input because algorythm can't start from 3 or lower
        ulong sum = CheckFromNum(ref from);

        for (ulong i = from; i < to; i++)
        {
            // get square root of number
            // because it is faster than checking it with all inputs
            var sqrtI = Math.Sqrt(i);

            for (ulong j = 2; (double)j <= sqrtI; j++)
            {
                // it can devide by a number except 1 and itself
                // so number isn't prime and it go for checking next num
                if (i % j == 0)
                {
                    break;
                }
                // this number was last checking and 
                // number couldn't devide by a number
                // so it is prime and add it to sum var
                if ((double)j + 1 > sqrtI)
                {
                    sum += i;
                }
            }
        }

        return sum;
    }

    static ulong CheckFromNum(ref ulong from)
    {
        ulong sum = 5;

        switch (from)
        {
            case <= 2:
                from = 4;
                break;
            case 3:
                from = 4;
                sum = 3;
                break;
        };
        
        return sum;
    }
}