namespace _7_Problem;

public class Program
{
    static List<long> FoundPrimeNumbers = new();

    static void Main()
    {
        long primeNumber = GetPrime(10001);

        Console.WriteLine("Answer of the seventh problem: {0}", primeNumber);
    }

    /// <summary>
    /// Gets nth prime number.
    /// <para>
    ///     For example gets 10001th prime number.
    /// </para>
    /// </summary>
    static long GetPrime(long index)
    {
        // add 2 to found prime numbers
        // because of checking next number
        FoundPrimeNumbers.Add(2);

        // it will continue till list count not touch the index
        // means that list haven't touch index
        for (long i = 3; FoundPrimeNumbers.Count < index; i++)
        {
            // check whether the number is prime or not
            bool isPrime = IsPrime(i);

            // if number is prime add it into prime list
            if (isPrime is true)
            {
                FoundPrimeNumbers.Add(i);
            }
        }

        // get last prime number exists in the prime numbers list
        // it gets the biggest one
        return FoundPrimeNumbers.Last();
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

        return true;
    }
}