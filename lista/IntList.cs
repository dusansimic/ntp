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
		public void AddLast(int data, IntNode next) {
			IntNode last;

			if (head == null) {
				head = new IntNode(data);
				return;
			}

			last = head;

			while (last.Next != null) {
				last = last.Next;
			}

			IntNode newElement = new IntNode(data, next);
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
				return;
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
			IntList newList = new IntList();
			IntNode curr = list.Head();

			while (curr.Next != null) {
				newList.AddLast(curr.Data);
				curr = curr.Next;
			}

			newList.AddLast(curr.Data, head);
			head = newList.Head();
		}
		public void AddRangeLast(IntList list) {
			IntNode curr = list.Head();

			while (curr != null) {
				AddLast(curr.Data);
				curr = curr.Next;
			}
		}
		public void AddRange(int index, IntList list) {
			if (index < 0 || index >= Length()) {
				System.Console.WriteLine("Index nije unutar niza!");
				return;
			}
				
			IntNode curr = list.Head();

			if (head != null) {
				int i = index;
				
				while (curr != null) {
					Add(i, curr.Data);
					i++;
					curr = curr.Next;
				}
			} else {
				while (curr != null) {
					AddLast(curr.Data);
					curr = curr.Next;
				}
			}
		}
		public int GetDataAt(int index) {
			if (head == null) {
				System.Console.WriteLine("Lista je prazna!");
				return 0;
			}
			if (index < 0 || index >= Length()) {
				System.Console.WriteLine("Index nije unutar niza!");
				return 0;
			}

			IntNode curr = head;

			for (int i = 0; i < index; i++) {
				curr = curr.Next;
			}

			return curr.Data;
		}
		public void ChangeDataAt(int index, int data) {
			if (head == null) {
				System.Console.WriteLine("Lista je prazna!");
				return;
			}
			if (index < 0 || index >= Length()) {
				System.Console.WriteLine("Index nije unutar niza!");
				return;
			}

			IntNode curr = head;

			for (int i = 0; i < index; i++) {
				curr = curr.Next;
			}

			curr.Data = data;
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
		public void Reverse() {
			IntList newList = new IntList();

			int k = 1;

			for (int i = 0; i < Length(); i++) {
				IntNode curr = head;

				for (int j = 0; j < Length() - k; j++) {
					curr = curr.Next;
				}

				newList.AddLast(curr.Data);

				k++;
			}

			head = newList.Head();
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
		public int[] ToArray() {
			int[] niz = new int[Length()];

			IntNode curr = null;
			int i = 0;

			while (curr != null) {
				niz[i++] = curr.Data;
				curr = curr.Next;
			}

			return niz;
		}

		public override string ToString() {
			string str = "";

			if (head == null) {
				str += "[ ]";
				return str;
			}

			IntNode curr = head;
			str += "[ ";
			while (curr != null) {
				str += curr.Data;
				if (curr.Next != null) {
					str += ", ";
				}
				curr = curr.Next;
			}
			str += " ]";

			return str;
		}
	}
}