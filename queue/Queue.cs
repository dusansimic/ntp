namespace queue
{
	public class Queue<T>
	{
		private int first, last;
		private T[] q;

		public Queue(int size) {
			q = new T[size];
			first = 0;
			last = -1;
		}

		public void Enqueue(T el) {
			if (last < q.Length-1) {
				last++;
				q[last] = el;
			} else if (first > 1) {
				last = 0;
				q[last] = el;
			}
		}

		public void Dequeue() {
			if (first != last) {
				first++;
			}
		}

		public bool IsEmpty() {
			return (first == last);
		}

		public bool IsFull() {
			return (first == last+2 || (first == 0 && last == q.Length-1));
		}

		/*public T First() {
			if (!IsEmpty()) {
				return q[first];
			}
		}*/

		public void Clear() {
			first = 0;
			last = 0;
		}

		public void MoveToFirst() {
			if (!IsEmpty()) {
				if (first == 0) {
					first = q.Length-1;
				} else {
					first--;
				}
				q[first] = q[last];
				last--;
			}
		}

		public override string ToString() {
			string str = "";

			if (last < first) {
				for (int i = first; i < q.Length; i++) {
					str += " " + q[i];
				}
				for (int i = 0; i < last+1; i++) {
					str += " " + q[i];
				}
			} else {
				for (int i = first; i < last+1; i++) {
					str += " " + q[i];
				}
			}

			return str;
		}
	}
}