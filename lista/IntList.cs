using System;

namespace lista {
	class IntList {
		private IntNode head;

		public int Length() {
			if (head == null) {
				return 0;
			}
			
			IntNode curr = head;
			int len = 0;

			while (curr != null) {
				curr = curr.Next;
				len++;
			}

			return len;
		}
		public IntNode Head() {
			return head;
		}
		public bool Equals(IntList list) {
			if (Length() != list.Length()) {
				return false;
			}

			IntNode curr1 = head;
			IntNode curr2 = list.Head();
			
			if (curr1 == null && curr2 == null) {
				return true;
			} else if (curr1 == null && curr2 != null) {
				return false;
			} else if (curr1 != null && curr2 == null) {
				return false;
			}

			while (curr1 != null) {
				if (curr1.Data != curr2.Data) {
					return false;
				}
				curr1 = curr1.Next;
				curr2 = curr2.Next;
			}

			return true;
		}
		public void AddLast(int data) {
			IntNode last;

			if (head == null) {
				head = new IntNode(data);
				return;
			}

			last = head;

			while (last.Next != null) {
				last = last.Next;
			}

			IntNode newElement = new IntNode(data);
			last.Next = newElement;
		}
		public void AddFirst(int data) {
			IntNode newElement;

			if (head == null) {
				head = new IntNode(data);
				return;
			}

			newElement = new IntNode(data);
			newElement.Next = head;
			head = newElement;
		}
		public void Add(int index, int data) {
			if (head == null) {
				head = new IntNode(data);
				return;
			}

			if (index < 0 || index >= Length()) {
				System.Console.WriteLine("Index nije unutar niza!");
			}

			IntNode curr = head;

			for (int i = 0; i < index - 1; i++) {
				curr = curr.Next;
			}

			IntNode next = curr.Next;
			IntNode newElement = new IntNode(data);
			curr.Next = newElement;
			newElement.Next = next;
		}
		public void AddRangeFirst(IntList list) {
			/*
			 * Uraditi kopiranje preko for-a!
			 */
			IntNode curr = list.Head();

			if (curr == null) {
				return;
			}

			while (curr.Next != null) {
				curr = curr.Next;
			}

			curr.Next = head;
		}
		public void AddRangeLast(IntList list) {
			/*
			 * Uraditi kopiranje preko for-a!
			 */
			IntNode curr = head;

			if (curr == null) {
				head = list.Head();
				return;
			}

			while (curr.Next != null) {
				curr = curr.Next;
			}

			curr.Next = list.Head();
		}
		public void Destroy(int index) {
			if (head == null) {
				System.Console.WriteLine("Nothing to destroy.");
				return;
			}
			if (index < 0 || index >= Length()) {
				System.Console.WriteLine("Index nije unutar niza!");
				return;
			}

			IntNode prev = head;
			for (int i = 0; i < index - 1; i++) {
				if (prev.Next == null) {
					System.Console.WriteLine("Dosao do kraja niza!");
					return;
				}
				prev.Next = prev;
			}

			IntNode curr = prev.Next;
			IntNode next = curr.Next;

			prev.Next = next;
		}

		public void Clear() {
			if (head == null) {
				return;
			}

			IntNode curr = head;
			IntNode prev = curr;
			head = null;

			while (curr.Next != null) {
				prev = curr;
				curr = curr.Next;
				prev.Next = null;
			}

			curr = null;
			prev = null;
		}

		public bool Contains(int data) {
			if (head == null) {
				return false;
			}

			IntNode curr = head;

			while (curr.Next != null) {
				if (curr.Data == data) {
					return true;
				}
				curr = curr.Next;
			}

			return false;
		}

		public override string ToString() {
			string str = "";

			IntNode curr = head;
			while (curr != null) {
				str += (curr.Data + " ");
				curr = curr.Next;
			}

			return str;
		}
	}
}