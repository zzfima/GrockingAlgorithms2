namespace QSort
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var s1 = SelectionSort([6, 3, 8, 9, 1]);
			var s2 = RecSort([6, 3, 8, 9, 1, 5]);
		}

		public static int[] SelectionSort(int[] ints)
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

			//recursive case
			int pivot = ints[0];
			int[] less = ints.Where(x => x < pivot).ToArray();
			int[] more = ints.Where(x => x > pivot).ToArray();

			return RecSort(less).Concat(new int[] { pivot }).Concat(RecSort(more)).ToArray();
		}
	}
}