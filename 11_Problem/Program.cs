namespace _11_Problem;

class Program
{
    private static string _fileName = "InputNums.txt";

    static void Main()
    {
        // Get all nums infos
        var inputNums = GetInputNumsFromFile();
        var inputNumsCount = inputNums.Count;

        // Get column and rows infos
        var columnsCount = GetColumnsCountFromFile();
        var rowsCount = GetRowsCountFromFile();

        var consecutiveRowNumsTotal =
            GetConsecutiveRowNumbersTotal(inputNums, columnsCount);

        var consecutiveColumnNumsTotal =
            GetConsecutiveColumnNumbersTotal(inputNums, columnsCount, rowsCount);

        var consecutiveDiagonallyToRightNumsTotal =
            GetConsecutiveDiagonallyToRightNumbersTotal(inputNums, columnsCount, rowsCount);

        var consecutiveDiagonallyToLeftNumsTotal =
            GetConsecutiveDiagonallyToLeftNumbersTotal(inputNums, columnsCount, rowsCount);

        List<ulong> totalOfRelationalNums = new();
        totalOfRelationalNums.AddRange(consecutiveRowNumsTotal);
        totalOfRelationalNums.AddRange(consecutiveColumnNumsTotal);
        totalOfRelationalNums.AddRange(consecutiveDiagonallyToRightNumsTotal);
        totalOfRelationalNums.AddRange(consecutiveDiagonallyToLeftNumsTotal);

        var biggestSum = totalOfRelationalNums.Max();
        Console.WriteLine($"Answer of the eleventh problem: {biggestSum}");
    }

    static List<int> GetInputNumsFromFile()
    {
        List<int> inputNums = new();
        using (StreamReader textReader =
                new StreamReader($"./{_fileName}"))
        {
            var inputText = textReader.ReadToEnd();
            inputText = inputText.Replace('\n', ' ');
            var nums = inputText.Split(' ');
            foreach (var num in nums)
            {
                inputNums.Add(int.Parse(num));
            }
        }
        return inputNums;
    }

    static int GetColumnsCountFromFile()
    {
        var count = 0;
        using (StreamReader textReader =
                new StreamReader($"./{_fileName}"))
        {
            var inputText = textReader.ReadToEnd();
            var nums = inputText.Split(' ');
            foreach (var num in nums)
            {
                count++;
                if (num.Contains('\n'))
                {
                    return count;
                }
            }
        }
        throw new IndexOutOfRangeException();
    }

    static int GetRowsCountFromFile()
    {
        using (StreamReader textReader =
                new StreamReader($"./{_fileName}"))
        {
            var inputText = textReader.ReadToEnd();
            if (inputText is null)
            {
                throw new NullReferenceException();
            }
            return inputText.Split('\n').Count();
        }
        throw new IndexOutOfRangeException();
    }

    static List<ulong> GetConsecutiveRowNumbersTotal(List<int> inputNums, int rowNumsCount)
    {
        List<ulong> multiplesResults = new();

        // a loop for each four numbers that exists in table
        for (int i = 0; (i + 3) < inputNums.Count; i++)
        {
            // get multiple the number by three next numbers
            var multiple =
                (ulong)inputNums[i] * (ulong)inputNums[i + 1] * (ulong)inputNums[i + 2] * (ulong)inputNums[i + 3];

            // add multiple to list
            multiplesResults.Add(multiple);

            // checks that wether is i first number in last group(4 nums) in a row or not
            var isLastGroupInRow = (i + 4) % rowNumsCount == 0;
            if (isLastGroupInRow)
            {
                i += 3;
            }
        }
        return multiplesResults;
    }

    static List<ulong> GetConsecutiveColumnNumbersTotal(List<int> inputNums, int rowNumsCount, int rowsCount)
    {
        List<ulong> multiples = new();

        // loop will walk on input nums
        for (int i = 0; i < inputNums.Count; i++)
        {
            // get last number index in a horizontal group of 4 numbers
            var lastNumberInGroupIndex = i + (rowNumsCount * 3);
            if (lastNumberInGroupIndex >= inputNums.Count)
            {
                break;
            }

            var multiple = (ulong)1;

            // a loop that walk on a number and it four down numbers
            for (int j = 0; j < 4; j++)
            {
                // get down of last number index
                var indexOfNextNum = i + rowNumsCount * j;
                // multiply current number to it group numbers
                multiple *= (ulong)inputNums[indexOfNextNum];
            }

            // add multiple of four horizontal consecutive numbers to list
            multiples.Add(multiple);
        }

        return multiples;
    }

    static List<ulong> GetConsecutiveDiagonallyToRightNumbersTotal(List<int> inputNums, int rowNumsCount, int rowsCount)
    {
        List<ulong> multiples = new();

        // loop will walk on input nums
        for (int i = 0; i < inputNums.Count; i++)
        {
            // get last number index in a horizontal group of 4 numbers
            var lastNumberInGroupIndex = i + (rowNumsCount * 3);
            if (lastNumberInGroupIndex >= inputNums.Count)
            {
                break;
            }

            var multiple = (ulong)1;

            // a loop that walk on a number and it four down numbers
            for (int j = 0; j < 4; j++)
            {
                // get down of last number index
                var indexOfNextNum = i + rowNumsCount * j + j;
                // multiply current number to it group numbers
                multiple *= (ulong)inputNums[indexOfNextNum];
            }

            // add multiple of four horizontal consecutive numbers to list
            multiples.Add(multiple);

            // checks that wether is i first number in last group(4 nums) in a row or not
            var isLastGroupInRow = (i + 4) % rowNumsCount == 0;
            if (isLastGroupInRow)
            {
                i += 3;
            }
        }

        return multiples;
    }

    static List<ulong> GetConsecutiveDiagonallyToLeftNumbersTotal(List<int> inputNums, int rowNumsCount, int rowsCount)
    {
        List<ulong> multiples = new();

        // loop will walk on input nums
        for (int i = 0; i < inputNums.Count; i++)
        {
            // checks that wether is i first number in last group(4 nums) in a row or not
            var isFirstGroupInRow = i % rowNumsCount == 0;
            if (isFirstGroupInRow)
            {
                i += 3;
            }

            // get last number index in a horizontal group of 4 numbers
            var lastNumberInGroupIndex = i + (rowNumsCount * 3);
            if (lastNumberInGroupIndex >= inputNums.Count)
            {
                break;
            }

            var multiple = (ulong)1;

            // a loop that walk on a number and it four down numbers
            for (int j = 0; j < 4; j++)
            {
                // get down of last number index
                var indexOfNextNum = i + rowNumsCount * j - j;
                // multiply current number to it group numbers
                multiple *= (ulong)inputNums[indexOfNextNum];
            }

            // add multiple of four horizontal consecutive numbers to list
            multiples.Add(multiple);
        }

        return multiples;
    }
}