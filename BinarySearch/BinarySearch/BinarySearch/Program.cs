
namespace BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var b1 = IsPerfectSquare(2147483647);
            var b2 = IsPerfectSquare(2147302921);

            int[] ints = new int[100];

            for (int i = 0; i < ints.Length; i++)
                ints[i] = i * 2;

            for (int i = 0; i < 210; i++)
            {
                Console.WriteLine($"Rec: num {i} exists: {IsNumberExistsRecursion(ints, i)}");
                Console.WriteLine($"Loop: num {i} index: {IsNumberExists(ints, i)}");
            }

            Console.ReadLine();
        }

        public static bool IsPerfectSquare(int num)
        {
            for (Int64 i = 0, j = num; i <= j;)
            {
                Int64 middle = (j + i) / 2;
                if (middle * middle == num)
                    return true;
                if (middle * middle > num)
                    j = middle - 1;
                else
                    i = middle + 1;
            }

            return false;
        }

        private static bool IsNumberExistsRecursion(int[] ints, int v)
        {
            if (ints.Length == 0)
                return false;

            int middleIndex = ints.Length / 2;
            int numInTheMiddle = ints[middleIndex];

            if (numInTheMiddle == v)
                return true;

            if (ints.Length == 1)
                return false;

            if (numInTheMiddle > v)
                return IsNumberExistsRecursion(ints[..middleIndex], v);

            return IsNumberExistsRecursion(ints[(middleIndex + 1)..], v);
        }

        private static int IsNumberExists(int[] ints, int v)
        {
            int highIndex = ints.Length - 1;
            int lowIndex = 0;

            while (lowIndex < highIndex)
            {
                int middleIndex = (highIndex - lowIndex) / 2;

                if (ints[middleIndex] == v)
                    return middleIndex;
                else if (ints[middleIndex] > v)
                    highIndex = middleIndex;
                else
                    lowIndex = middleIndex;
            }

            return -1;
        }
    }
}
