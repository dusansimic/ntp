using System;

namespace lista {
	class IntList {
		private IntNode head;

		public void AddLast(int data) {
			IntNode last;

			if (head == null) {
				last = new IntNode(data);
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
			IntNode newElement = new IntNode(data, head);
			head = newElement;
		}
		public void Add(int index) {
			IntNode curr = head;

			for (int i = 0; i < index; i++) {
				if (curr.Next == null) {
					System.Console.WriteLine("Dosao do kraja niza!");
					return;
				} else {
					curr = curr.Next;
				}
			}
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