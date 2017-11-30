namespace stack {
	class Stack<T> {
		private T[] arr;
		int space;
		int size;

		public int Space {
			get { return space; }
		}
		public int Size {
			get { return size; }
		}

		public Stack() {
			space = 16;
			size = 0;
			arr = new T[space];
		}

		public Stack(T[] arr) {
			space = 16;
			size = arr.Length;
			while (size > space) {
				space *= 2;
			}

			this.arr = new T[space];

			for (int i = 0; i < size; i++) {
				this.arr[i] = arr[i];
			}
		}

		private void Resize(int upOrDown) {
			if (upOrDown > 0) {
				space *= 2;
			} else if (upOrDown < 0) {
				if (space > 16) {
					space /= 2;
				}
			} else {
				return;
			}

			T[] newArr = new T[space];

			for (int i = 0; i < size; i++) {
				newArr[i] = arr[i];
			}

			arr = newArr;
		}

		public int Push(T data) {
			if (size == space) {
				Resize(1);
			}

			arr[size++] = data;
			return size;
		}

		public T Top() {
			if (size == 0) {
				// Kako returnovati nista?
			}

			return arr[size - 1];
		}

		public T Pop() {
			if (size == 0) {
				// Kako returnovati nista?
			}
			T top = Top();

			size--;
			if (size == space/2) {
				Resize(-1);
			}
			return top;
		}
	}
}