
namespace Factorial
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var v = Factorial(5);
			Console.WriteLine(v);
			Console.ReadLine();
		}

		private static int Factorial(int v)
		{
			if (v == 1)
			{
				Console.WriteLine("1");
				return 1;
			}

			Console.Write($"{v} * ");

			return v * Factorial(v - 1);
		}
	}
}
