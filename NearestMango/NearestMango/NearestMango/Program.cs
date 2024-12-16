
namespace NearestMango
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, string[]> sellers = new();
			sellers["me"] = ["Alice", "Bob", "Clare"];

			sellers["Alice"] = ["Peggy"];
			sellers["Bob"] = ["Peggy", "Anuj"];
			sellers["Clare"] = ["Johnny", "Tom"];

			sellers["Peggy"] = [];
			sellers["Anuj"] = [];
			sellers["Johnny"] = [];
			sellers["Tom"] = [];

			Queue<string> queue = new();
			EnqueueStrings(sellers["me"], queue);

			while (queue.Count > 0)
			{
				string seller = queue.Dequeue();
				if (IsMangoSeller(seller))
				{
					Console.WriteLine($"Peach seller {seller}");
					break;
				}

				EnqueueStrings(sellers[seller], queue);
			}

			Console.ReadLine();
		}

		private static bool IsMangoSeller(string seller) => seller[^1] == 'm';

		static void EnqueueStrings(string[] strings, Queue<string> queue)
		{
			foreach (string s in strings)
			{
				queue.Enqueue(s);
			}
		}
	}
}
