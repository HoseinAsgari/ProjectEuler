namespace _3_Problem;

class Program
{
    // this is for keeping found prime numbers into it
    static List<long> FoundPrimeNumbers = new();

    static void Main()
    {
        Console.WriteLine("running for find value can take an hour to process and calculate...");

        // add first prime number for being not null
        FoundPrimeNumbers.Add(2);

        // call the main method
        long largestValue = GetLargestPrimeFactor(600851475143);

        Console.WriteLine("\nAnswer of the third problem: {0}", largestValue);
    }


    /// <summary>
    /// Gets largest prime number of factor of a number and returns it.
    /// </summary>
    private static long GetLargestPrimeFactor(long number)
    {
        // get half of number and run for loop on it
        // because we know that our answer is less than half of number
        // this is for better performance
        long halfOfNumber = number / 2;

        // runs it on numbers that are less than half of number
        for (long i = halfOfNumber; i >= 2; i--)
        {
            // checks that whether i is factor of number and is prime or not
            if (IsFactorOf(i, number) && IsPrime(i))
            {
                // answer found!!!
                return i;
            }
        }
        throw new Exception("the given number is not valid");
    }

    /// <summary>
    /// Checks whether number is prime or not. Returns true when number is prime.
    /// </summary>
    private static bool IsPrime(long number)
    {
        // check that if the number is multiple of prime numbers that we found it before
        // it returns that number is not prime
        foreach (var primeNum in FoundPrimeNumbers)
        {
            if (number % primeNum is 0)
            {
                return false;
            }
        }

        // when you want to find whether a number is prime or not,
        // you can check it by checking sqrt of that number
        // this is not necessary, but it can give us better performance
        double sqrtOfNumber = Math.Sqrt(number);

        // get biggest number that found before, and
        // we keep it in FoundPrimeNumbers variable
        // this is for not calculating last prime numbers again
        // this is not necessary, but it can give us better performance
        long biggestFoundPrimeNumber = FoundPrimeNumbers.Last();

        for (long i = biggestFoundPrimeNumber; i < sqrtOfNumber; i++)
        {
            if (number % i is 0)
            {
                return false;
            }

            // this means a number that found is a new prime number that
            // it doesn't exist in FoundPrimeNumbers variable
            // we check that number is prime or not
            if (FoundPrimeNumbers.Any(n => i % n == 0) is false)
            {
                FoundPrimeNumbers.Add(i);
            }
        }

        // it means that number cannot devide by a number so that is prime
        return true;
    }

    /// <summary>
    /// Check whether a number is factor of mainNumber or not.
    /// </summary>
    /// <param name="factor">the number that want to check that is prime of a number or not</param>
    /// <param name="mainNumber">main number that want to check</param>
    private static bool IsFactorOf(long factor, long mainNumber)
    {
        if (mainNumber % factor == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}