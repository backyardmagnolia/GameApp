namespace Game
{
	public sealed class Child<T>
	{
		public T NumberTag { get; private set; }

		public Child<T> Next { get; internal set; }

		public Child<T> Previous { get; internal set; }

		public Child(T item)
		{
			NumberTag = item;
		}
	}
}