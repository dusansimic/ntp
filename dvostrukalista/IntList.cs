/*
 * TODO
 * 
 * Functions:
 *	AddRangeFirst()
 *	AddRangeLast()
 *	AddRange()
 */

using System;

namespace dvostrukalista {
	class IntList {
		private IntNode head;
		private IntNode tail;
		private int Length;

		public int GetLength() {
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
		public IntNode GetHead() {
			return head;
		}
		public IntNode GetTail() {
			return tail;
		}
		public bool Equals(IntList list) {
			if (GetLength() != list.GetLength()) {
				return false;
			}

			IntNode curr1 = head;
			IntNode curr2 = list.GetHead();
			
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
			Length++;
			if (head == null) {
				head = new IntNode(data);
				return;
			}

			IntNode last = head;

			while (last.Next != null) {
				last = last.Next;
			}

			IntNode newElement = new IntNode(data);
			last.Next = newElement;
			
			tail = newElement;
		}
		public void AddLast(int data, IntNode prev) {
			Length++;
			if (head == null) {
				head = new IntNode(data);
				return;
			}

			IntNode last = head;

			while (last.Next != null) {
				last = last.Next;
			}

			IntNode newElement = new IntNode(data, null, last);
			last.Next = newElement;

			tail = newElement;
		}
		public void AddLast(int data, IntNode next, IntNode prev) {
			Length++;
			if (head == null) {
				head = new IntNode(data);
				return;
			}

			IntNode last = head;

			while (last.Next != null) {
				last = last.Next;
			}

			IntNode newElement = new IntNode(data, next, last);
			last.Next = newElement;

			tail = newElement;
		}
		public void AddFirst(int data) {
			Length++;
			if (head == null) {
				head = new IntNode(data);
				return;
			}

			IntNode newElement = new IntNode(data);
			newElement.Next = head;
			head.Prev = newElement;
			head = newElement;
			Length++;

			if (Length == 1) {
				tail = newElement;
			} 
		}
		public void Add(int index, int data) {
			if (index < 0 || index > Length) {
				System.Console.WriteLine("Index nije unutar niza!");
				return;
			}

			Length++;
			if (head == null) {
				head = new IntNode(data);
				return;
			}
			if (index == 0) {
				AddFirst(data);
				return;
			}
			if (index == Length - 1) {
				AddLast(data);
				return;
			}

			IntNode curr = head;
			IntNode afterCurr = curr.Next;

			for (int i = 0; i < index - 1; i++) {
				curr = curr.Next;
				afterCurr = curr.Next;
			}

			IntNode newElement = new IntNode(data);
			curr.Next = newElement;
			newElement.Next = afterCurr;
			newElement.Prev = curr;
			afterCurr.Prev = newElement;
		}
		public void AddRangeFirst(IntList list) {
			IntList newList = new IntList();
			IntNode curr = list.GetHead();

			while (curr.Next != null) {
				newList.AddLast(curr.Data);
				curr = curr.Next;
			}

			newList.AddLast(curr.Data, head);
			head = newList.GetHead();
		}
		public void AddRangeLast(IntList list) {
			IntNode curr = list.GetHead();

			while (curr != null) {
				AddLast(curr.Data);
				curr = curr.Next;
			}
		}
		public void AddRange(int index, IntList list) {
			if (index < 0 || index >= GetLength()) {
				System.Console.WriteLine("Index nije unutar niza!");
				return;
			}
				
			IntNode curr = list.GetHead();

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
			if (index < 0 || index >= GetLength()) {
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
			if (index < 0 || index >= GetLength()) {
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
			if (index < 0 || index >= Length) {
				System.Console.WriteLine("Index nije unutar niza!");
				return;
			}
			if (head == null) {
				System.Console.WriteLine("Nothing to destroy.");
				return;
			}

			IntNode beforeCurr = head;
			for (int i = 0; i < index - 1; i++) {
				if (beforeCurr.Next == null) {
					System.Console.WriteLine("Dosao do kraja niza!");
					return;
				}
				beforeCurr.Next = beforeCurr;
			}

			IntNode curr = beforeCurr.Next;
			IntNode afterCurr = curr.Next;

			beforeCurr.Next = afterCurr;
			afterCurr.Prev = beforeCurr;
			Length--;
		}

		public void Clear() {
			if (head == null) {
				return;
			}

			IntNode curr = head;
			IntNode prev = curr.Next;
			head = null;

			while (curr.Next != null) {
				prev = curr;
				curr = curr.Next;
				prev.Next = null;
				curr.Prev = null;
			}

			Length = 0;
		}
		public void Reverse() {
			IntList newList = new IntList();

			int k = 1;

			for (int i = 0; i < Length; i++) {
				IntNode curr = head;

				for (int j = 0; j < Length - k; j++) {
					curr = curr.Next;
				}

				newList.AddLast(curr.Data);

				k++;
			}

			Clear();
			head = newList.GetHead();
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
			int[] niz = new int[GetLength()];

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