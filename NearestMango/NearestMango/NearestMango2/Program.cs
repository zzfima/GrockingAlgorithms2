﻿



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
			RunSequntial();
			RunRecursive();
			Console.ReadLine();
		}

		private static void RunRecursive()
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
			HashSet<FruitsSeller> checkedSellers = new();
			EnqueueSellerFirstTime(sellers[me], queue, checkedSellers);

			RecFindSeller(queue, sellers, checkedSellers);
		}

		private static void RecFindSeller(Queue<FruitsSeller> queue, Dictionary<FruitsSeller, FruitsSeller[]> sellers, HashSet<FruitsSeller> checkedSellers)
		{
			if (queue.Count == 0)
			{
				Console.WriteLine($"No Peach seller");
				return;
			}
			FruitsSeller seller = queue.Dequeue();
			if (seller.Fruit == FruitType.Peach)
			{
				Console.WriteLine($"Peach seller {seller.Name}");
				return;
			}

			EnqueueSellerFirstTime(sellers[seller], queue, checkedSellers);
			RecFindSeller(queue, sellers, checkedSellers);
		}

		private static void RunSequntial()
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

			Queue<FruitsSeller> featureSellers = new();
			HashSet<FruitsSeller> checkedSellers = new();
			EnqueueSellerFirstTime(sellers[me], featureSellers, checkedSellers);

			while (featureSellers.Count > 0)
			{
				FruitsSeller seller = featureSellers.Dequeue();

				if (seller.Fruit == FruitType.Peach)
				{
					Console.WriteLine($"Peach seller {seller.Name}");
					break;
				}

				EnqueueSellerFirstTime(sellers[seller], featureSellers, checkedSellers);
			}

		}

		static void EnqueueSellerFirstTime(FruitsSeller[] sellers, Queue<FruitsSeller> featureSellers, HashSet<FruitsSeller> checkedSellers)
		{
			foreach (FruitsSeller s in sellers)
			{
				if (!checkedSellers.Contains(s))
				{
					checkedSellers.Add(s);
					featureSellers.Enqueue(s);
				}
				else
					Console.WriteLine($" seller {s.Name} already checked!");
			}
		}
	}
}