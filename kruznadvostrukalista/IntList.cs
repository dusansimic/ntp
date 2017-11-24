using System;

namespace kruznadvostrukalista {
	class IntList {
		private IntNode head;
		private uint length;

		public IntList() {
			head = null;
			length = 0;
		}

		public IntNode GetFirst() {
			return head;
		}

		public IntNode GetLast() {
			if (head == null) {
				return null;
			}
			return head.Prev;
		}

		public IntNode GetMax() {
			if (head == null) {
				return null;
			}

			IntNode curr = head;
			IntNode max = head;

			do {
				if (curr.Data > max.Data) {
					max = curr;
				}
				curr = curr.Next;
			} while (curr != head);

			return max;
		}

		public IntNode GetMin() {
			if (head == null) {
				return null;
			}

			IntNode curr = head;
			IntNode min = head;

			do {
				if (curr.Data < min.Data) {
					min = curr;
				}
				curr = curr.Next;
			} while (curr != head);

			return min;
		}

		public void AddFirst(int data) {
			length++;
			if (head == null) {
				head = new IntNode(data);
				head.Next = head;
				head.Prev = head;
				return;
			}

			IntNode tail = head.Prev;
			IntNode element = new IntNode(data, head, tail);
			tail.Next = element;
			head.Prev = element;
			head = element;
		}
		
		public void AddLast(int data) {
			length++;
			if (head == null) {
				head = new IntNode(data);
				head.Next = head;
				head.Prev = head;
				return;
			}

			IntNode tail = head.Prev;
			IntNode element = new IntNode(data, head, tail);
			tail.Next = element;
			head.Prev = element;
		}

		public void Add(int data, uint index) {
			if (index > length - 1) {
				System.Console.WriteLine("Error: index out of bound of list.");
				return;
			}
			if (index == 0) {
				AddFirst(data);
				return;
			}
			if (index == length - 1) {
				AddLast(data);
				return;
			}
			length++;

			IntNode curr = head;
			for (int i = 0; i <= index; i++) {
				curr = curr.Next;
			}

			IntNode element = new IntNode(data, curr.Prev.Next, curr.Prev);
			curr.Prev.Next = element;
			curr.Prev = element;
		}

		public void RemoveFirst() {
			if (head == null) {
				return;
			}
			length--;

			head.Prev.Next = head.Next;
			head.Next.Prev = head.Prev;
			head = head.Next;
		}

		public void RemoveLast() {
			if (head == null) {
				return;
			}
			length--;

			IntNode tail = head.Prev;

			tail.Prev.Next = tail.Next;
			tail.Next.Prev = tail.Prev;
		}

		public void Remove(uint index) {
			if (index > length - 1) {
				System.Console.WriteLine("Error: index out of bound of list.");
				return;
			}
			if (index == 0) {
				RemoveFirst();
				return;
			}
			if (index == length - 1) {
				RemoveLast();
				return;
			}
			length--;

			IntNode curr = head;
			for (int i = 0; i <= index; i++) {
				curr = curr.Next;
			}

			curr.Prev.Next = curr.Next;
			curr.Next.Prev = curr.Prev;
		}

		public bool Find(int data) {
			if (head == null) {
				return false;
			}

			IntNode curr = head;

			do {
				if (curr.Data == data) {
					return true;
				}
				curr = curr.Next;
			} while (curr != head);

			return false;
		}

		public IntNode FindAndGet(int data) {
			if (head == null) {
				return null;
			}

			IntNode curr = head;

			do {
				if (curr.Data == data) {
					return curr;
				}
				curr = curr.Next;
			} while (curr != head);

			return null;
		}

		public void Megre(IntList lista) {
			if (head == null) {
				head = lista.GetFirst();
				return;
			}
			if (lista == null) {
				return;
			}

			IntNode thisTail = head.Prev;
			IntNode thisHead = head;
			IntNode newTail = lista.GetLast();
			IntNode newHead = lista.GetFirst();

			thisTail.Next = newHead;
			newHead.Prev = thisTail;
			newTail.Next = thisHead;
			thisHead.Prev = newTail;
		}

		// Nije gotova
		public void Reverse() {
			if (head == null) {
				return;
			}

			IntList lista = new IntList();
			IntNode curr = head.Prev;

			while(curr != head) {
				lista.AddLast(curr.Data);
				System.Console.WriteLine(curr.Data);
				curr = curr.Prev;
			}

			Clear();
			head = lista.GetFirst();
		}

		public void MaxFirst() {
			if (head == null) {
				return;
			}

			IntNode curr = head;
			IntNode max = GetMax();
			uint i = 0;

			do {
				if (curr.Data == max.Data) {
					AddFirst(curr.Data);
					curr = curr.Next;
					Remove(i);
				} else {
					curr = curr.Next;
				}
				i++;
			} while (curr != head);
		}

		public void MinFirst() {
			if (head == null) {
				return;
			}

			IntNode curr = head;
			IntNode min = GetMin();
			uint i = 0;

			do {
				if (curr.Data == min.Data) {
					AddFirst(curr.Data);
					curr = curr.Next;
					Remove(i);
				} else {
					curr = curr.Next;
				}
				i++;
			} while (curr != head);
		}

		public void RemoveDuplicates() {
			if (head == null) {
				return;
			}

			IntNode curr = head;
			uint i = 0;

			do {
				if (FindAndGet(curr.Data) != curr) {
					curr = curr.Next;
					Remove(i);
				} else {
					curr = curr.Next;
					i++;
				}
			} while (curr != head);
		}

		public void Clear() {
			if (head == null) {
				return;
			}
			length = 0;

			IntNode curr = head;
			while (curr != null) {
				curr.Prev = null;
			}
		}

		public override string ToString() {
			string str = "";
			if (head == null) {
				return str;
			}

			IntNode curr = head;
			do {
				str += (" " + curr.Data.ToString());
				curr = curr.Next;
			} while (curr != head);

			return str;
		}
	}
}