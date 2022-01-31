namespace _9_Problem;

public class Program
{
    static void Main()
    {
        double number = 1000;

        var numbers = GetTripleNumbers(number);

        double multipledNumbers = MultipleEach(numbers);

        Console.WriteLine("Answer of the ninth problem: {0}", multipledNumbers);
    }

    static double[] GetTripleNumbers(double number)
    {
        for (double c = 0; c < number; c++)
        {
            // Checks the number to c because of a<b<c relation
            for (double b = 0; b < c; b++)
            {
                // Checks the number to b because of a<b<c relation
                for (double a = 0; a < b; a++)
                {
                    bool isPhythaqourean = IsPhythaqourean(a, b, c);

                    // Checks whether the sum of a, b, c is equal to number or not
                    bool isSumEqualNum = a + b + c == number;

                    if (isPhythaqourean && isSumEqualNum)
                        return new double[] { a, b, c };
                }
            }
        }

        throw new Exception("Not found");
    }

    /// <summary>
    ///     Multiple numbers to each other.
    /// <summary>
    static double MultipleEach(double[] nums)
    {
        double result = 1;

        foreach (var num in nums)
        {
            result *= num;
        }
        
        return result;
    }

    /// <summary>
    ///     Checks numbers make a Phythaqourean relation or not. (a.a + b.b = c.c)
    /// <summary>
    static bool IsPhythaqourean(double a, double b, double c)
    {
        return Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2);
    }
}