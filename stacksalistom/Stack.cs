namespace stack {
	class Stack<T> {
		Element<T> head;
		int size;

		public int Size {
			get { return size; }
		}

		public Stack() {
			head = null;
			size = 0;
		}

		public void Push(T data) {
			size++;
			head = new Element<T>(data, head);
		}

		public T Top() {
			if (head == null) {
				// Kako vratiti null?
			}

			return head.Data;
		}
		
		public T Pop() {
			if (head == null) {
				// Kako vratiti null?
			}

			T top = Top();

			head = head.Next;

			size--;

			return top;
		}
	}
}