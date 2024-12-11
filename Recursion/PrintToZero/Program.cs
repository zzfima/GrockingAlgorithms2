namespace Recursion
{
	internal class Program
	{
		static void Main(string[] args)
		{
			PrintToZero(5);

			Console.ReadLine();
		}

		static void PrintToZero(int num)
		{
			Console.WriteLine(num);
			if (num == 0)
				return;
			PrintToZero(num - 1);
		}
	}
}
