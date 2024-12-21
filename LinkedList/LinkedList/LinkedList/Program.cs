
namespace LinkedList
{
	internal class Program
	{
		static void Main(string[] args)
		{
			LinkedListContainer container = new LinkedListContainer();
			container.Add(1);
			container.Add(2);
			container.Add(3);

			container.PrintAllNodes();

			Console.ReadLine();
		}
	}

	public class LinkedListContainer
	{
		private Node _head;
		private Node _tail;

		public LinkedListContainer()
		{
			_head = null;
			_tail = null;
		}

		public void Add(int val)
		{
			Node node = new Node() { Val = val };

			if (_head == null)
			{
				_head = node;
				_tail = node;
			}
			else
			{
				_tail.NextNode = node;
				_tail = node;
			}
		}

		public void PrintAllNodes()
		{
			Node node = _head;
			while (true)
			{
				if (node == null)
					return;
				Console.WriteLine(node.Val);
				node = node.NextNode;
			}
		}
	}

	class Node
	{
		public int Val { get; set; }
		public Node NextNode { get; set; }
	}
}
