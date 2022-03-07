namespace _2_Problem;

class Program
{
    static void Main()
    {
        List<int> numbers = GetEvenFibonacciNumbers(4000000);

        // get sum of even fibunacci numbers
        int sum = numbers.Sum();

        Console.WriteLine("Answer of the second problem: {0}", sum);
    }


    /// <summary>
    /// Gets fibunacci's even numbers and return it.
    /// </summary>
    private static List<int> GetEvenFibonacciNumbers(int maxValue = int.MaxValue)
    {
        List<int> numbers = new();

        int beforeLastNumber = 0;
        int lastNumber = 1;

        for (int i = 1; i <= maxValue; i = beforeLastNumber + lastNumber)
        {
            bool isNumberEven = IsEven(i);

            // check whether number is even or not. If yes it adds the number.
            if (isNumberEven is true)
            {
                numbers.Add(i);
            }

            beforeLastNumber = lastNumber;
            lastNumber = i;
        }

        return numbers;
    }

    /// <summary>
    /// Checks whether number is even or not. Returns true when number is even.
    /// </summary>
    private static bool IsEven(int number)
    {
        if (number % 2 is 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}