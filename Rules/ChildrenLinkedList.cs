using System.Collections.Generic;

namespace Game
{
	public class ChildrenLinkedList<T> 
	{
		Child<T> first = null;
		Child<T> last = null;

	    readonly IEqualityComparer<T> comparer;

		public Child<T> First { get { return first; }}
		public Child<T> Last { get { return last; }}
        public int Count { get; private set; }

		public ChildrenLinkedList ()
		{
		    Count = 0;
		    comparer = EqualityComparer<T>.Default;
		}

	    public void Add (T item)
		{
			AddLast (item);
		}

		private void AddFirst(T item)
		{
			first = new Child<T>(item);
			last = first;
			first.Next = last;
			first.Previous = last;
		}

		private void AddLast(T item)
		{
			if (first == null)
				AddFirst (item);
			else {
				var newNode = new Child<T> (item);
				last.Next = newNode;
				newNode.Previous = last;
				newNode.Next = first;
				last = newNode;
				first.Previous = last;
			}

			Count++;
		}

	    public bool Remove (T item)
		{
			var child = Find (item);
			return child != null && RemoveChild (child);
		}

		private bool RemoveChild (Child<T> item)
		{
		    if (item == null) return false;

			item.Previous.Next = item.Next;
			item.Next.Previous = item.Previous;

			    first = item.Next;
			    last = item.Previous;

			Count = Count - 1;

			return true;
		}

		public Child<T> Find(T item)
		{
            if (first == null) return null;

		    if (Compare (first, item)) return first;

            var child = first.Next;
		    
            while (child != first)
            {
                if (Compare(child, item)) return child;
                child = child.Next;
            }

		    return null;
		}

		public Child<T> FindNextChildToExitCircle(int kOffset)
		{
			if (first == null)
				return null;

			Child<T> result = null;
			for (var i = 0; i < kOffset-1; i++) {
				result = first.Next;
				first = result;
			}
			return result;
		}

		public bool Compare(Child<T> node, T item)
		{
			return comparer.Equals (node.NumberTag, item);

		}

        public IEnumerable<T> FindWinner(int kOffset)
        {
            if (Count <= 1) yield break;

            for (var i = Count-1; i >= 0; i--)
            {
                var removedChild = FindNextChildToExitCircle(kOffset);
                if (removedChild != null)
                {
                    RemoveChild(removedChild);
                    yield return removedChild.NumberTag;
                }
            }
        }
	}
}

