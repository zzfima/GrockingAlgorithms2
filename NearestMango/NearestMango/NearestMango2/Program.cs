namespace NearestMango2
{
	public enum FruitType
	{
		Mango, Peach, Apple
	}
	public class FruitsSeller(string name, FruitType fruit)
	{
		public string Name { get; } = name;
		public FruitType Fruit { get; } = fruit;
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			FruitsSeller me = new("me", FruitType.Mango);
			FruitsSeller alice = new("Alice", FruitType.Mango);
			FruitsSeller bob = new("Bob", FruitType.Mango);
			FruitsSeller clare = new("Clare", FruitType.Apple);
			FruitsSeller peggy = new("Peggy", FruitType.Mango);
			FruitsSeller anunj = new("Anuj", FruitType.Mango);
			FruitsSeller johny = new("Johnny", FruitType.Mango);
			FruitsSeller tom = new("Tom", FruitType.Peach);

			Dictionary<FruitsSeller, FruitsSeller[]> sellers = new();
			sellers[me] = [alice, bob, clare];

			sellers[alice] = [peggy];
			sellers[bob] = [peggy, anunj];
			sellers[clare] = [johny, tom];

			sellers[peggy] = [];
			sellers[anunj] = [];
			sellers[johny] = [];
			sellers[tom] = [];

			Queue<FruitsSeller> queue = new();
			EnqueueStrings(sellers[me], queue);

			while (queue.Count > 0)
			{
				FruitsSeller seller = queue.Dequeue();
				if (seller.Fruit == FruitType.Peach)
				{
					Console.WriteLine($"Peach seller {seller.Name}");
					break;
				}

				EnqueueStrings(sellers[seller], queue);
			}

			Console.ReadLine();
		}
		static void EnqueueStrings(FruitsSeller[] sellers, Queue<FruitsSeller> queue)
		{
			foreach (FruitsSeller s in sellers)
			{
				queue.Enqueue(s);
			}
		}
	}
}