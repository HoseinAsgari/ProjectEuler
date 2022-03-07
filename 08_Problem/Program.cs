namespace _8_Problem;

public class Program
{
    static List<long> MultipleOfAdjacentNumbers = new List<long>();
    static string mainNumber = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";


    static void Main()
    {
        int countOfAdjacentNums = 13;

        SearchOnMainNumberForDigitAdjastingMultiple(countOfAdjacentNums);

        // get greatest value exists in multiple list
        long greatestMultiple = MultipleOfAdjacentNumbers.Max();

        Console.WriteLine("Answer of the eighth problem: {0}", greatestMultiple);
    }

    /// <summary>
    ///  <para>
    ///   Take a loop on the string and take a character and 4 characters after that.
    ///  </para>
    ///  <para>
    ///   Add multipled number to numbers list.
    ///  </para>
    /// </summary>
    static void SearchOnMainNumberForDigitAdjastingMultiple(int countOfAdjacentNums)
    {
        for (int i = 0; i < mainNumber.Length; i++)
        {
            // check that is a number more than max index
            bool isIndexValid = i + countOfAdjacentNums >= mainNumber.Length;

            // check whether the number is more than index, If yes, add it to list
            if (isIndexValid is false)
            {
                long multiple = GetDigitAdjacentMultiple(i, countOfAdjacentNums);

                // add the multiple to multiple list
                MultipleOfAdjacentNumbers.Add(multiple);
            }
        }
    }

    /// <summary>
    /// Take a character and 4 characters after that and
    /// add multipled number to numbers list.
    /// </summary>
    static long GetDigitAdjacentMultiple(int characterNum, int countOfAdjacentNums)
    {
        long multiple = 1;

        // this run on next four number and multiple it
        for (int i = 0; i < countOfAdjacentNums; i++)
        {
            // multiple last multiple nums to next num
            multiple *= CharToLong(mainNumber[characterNum + i]);
        }

        return multiple;
    }

    /// <summary>
    /// Convert char to string after that will parse to long.
    /// </summary>
    static long CharToLong(char character)
    {
        string characterToString = character.ToString();
        long num = Int64.Parse(characterToString);

        return num;
    }
}