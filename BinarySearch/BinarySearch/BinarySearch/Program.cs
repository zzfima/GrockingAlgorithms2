
namespace BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            int[] ints = new int[100];

            for (int i = 0; i < ints.Length; i++)
                ints[i] = i * 2;

            for (int i = 0; i < 210; i++)
                Console.WriteLine($"num {i} exists: {IsNumberExists(ints, i)}");

            Console.ReadLine();
        }

        private static bool IsNumberExists(int[] ints, int v)
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
                return IsNumberExists(ints[..middleIndex], v);

            return IsNumberExists(ints[(middleIndex + 1)..], v);
        }
    }
}
