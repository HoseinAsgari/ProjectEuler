namespace _4_Problem;

class Program
{
    static void Main()
    {
        int lastNumber = GetLastNumberWithCharactersCount(3);
        int largestPalindromic = GetLargestPalindromic(lastNumber);

        Console.WriteLine("\nAnswer of the fourth problem: {0}", largestPalindromic);
    }


    /// <summary>
    /// Get largest palindromic less than given number
    /// <summary>
    static int GetLargestPalindromic(int number)
    {
        List<int> numbers = new();

        // multiple largest number into eachother and add it to numbers list 
        for (int i = number; i > 0; i--)
        {
            for (int j = number; j > 0; j--)
            {
                int multipledNumber = j * i;

                if (IsNumberPalindromic(multipledNumber))
                {
                    numbers.Add(multipledNumber);
                }
            }
        }

        // get the largest number from created numbers
        int largestNumber = numbers.Max();

        return largestNumber;
    }


    /// <summary>
    /// Returns whether number is palindromic or not.
    /// </summary>
    static bool IsNumberPalindromic(int number)
    {
        string copyOfNum = number.ToString();

        string reversedNum = new string(copyOfNum.ToString().Reverse().ToArray());

        // check the given number with reversed
        if (reversedNum == copyOfNum)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// get last number with characters count
    /// </summary>
    static int GetLastNumberWithCharactersCount(int characterCount)
    {
        string stringNumber = "";

        for (int i = 0; i < characterCount; i++)
        {
            stringNumber += "9";
        }

        int number = int.Parse(stringNumber);
        return number;
    }
}