namespace QSort
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var s1 = SlowSort([6, 3, 8, 9, 1]);
			var s2 = RecSort([6, 3, 8, 9, 1]);
		}

		public static int[] SlowSort(int[] ints)
		{
			for (int i = 0; i < ints.Length; i++)
			{
				for (int j = i + 1; j < ints.Length; j++)
				{
					if (ints[i] > ints[j])
					{
						int tmp = ints[i];
						ints[i] = ints[j];
						ints[j] = tmp;
					}
				}
			}

			return ints;
		}

		public static int[] RecSort(int[] ints)
		{
			//base case
			if (ints.Length <= 1)
				return ints;

			if (ints.Length == 2)
			{
				if (ints[0] < ints[1])
					return ints;
				else
				{
					int tmp = ints[0];
					ints[0] = ints[1];
					ints[1] = tmp;
					return ints;
				}
			}

			//recursive case
			int pivot = ints[0];
			int[] less = ints.Where(x => x < pivot).ToArray();
			int[] more = ints.Where(x => x > pivot).ToArray();

			return RecSort(less).Concat(new int[] { pivot }).Concat(RecSort(more)).ToArray();
		}
	}
}