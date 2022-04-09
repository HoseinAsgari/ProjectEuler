namespace _12_Problem;

class Program
{
    static void Main()
    {
        // it may take a long time to get answer, for me it took 20 mins
        var firstOverOneHundredFactorsTriangleNum = GetFirstOverOneHundredFactorsTriangleNum();

        Console.WriteLine($"Twelve project's answer is: {firstOverOneHundredFactorsTriangleNum}");
    }

    static ulong GetFirstOverOneHundredFactorsTriangleNum()
    {
        // enumerate on triangle nums
        ulong tNum = 0;
        ulong index = 1;
        while (true)
        {
            // it goes to next triangle number
            tNum += index;

            // get factors of current triangle number
            var factorsCount = GetFactorsCount(tNum);

            // it will return answer if it has found
            if (factorsCount >= 500)
            {
                return tNum;
            }

            // goes to next index
            index++;
        }

        throw new Exception("Answer not found");
    }

    static int GetFactorsCount(ulong num)
    {
        // the num has at least two factors, one and itself 
        var factorsCount = 2;

        // get half of num because factors cannot be upper than it half
        // this is for better performance
        var halfOfNum = num / 2;

        // enumerate on all nums less than half of input num
        for (ulong i = 2; i <= halfOfNum; i++)
        {
            // it says that i is factors of input num
            if (num % i == 0)
            {
                // i is factor so it adds a value to count
                factorsCount++;
            }
        }

        return factorsCount;
    }
}