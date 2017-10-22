using System;

namespace dvostrukalista {
	class IntNode {
		private int data;
		public int Data {
			get { return data; }
			set { data = value; }
		}
		private IntNode next;
		public IntNode Next {
			get { return next; }
			set { next = value; }
		}
		private IntNode prev;
		public IntNode Prev {
			get { return prev; }
			set { prev = value; }
		}

		public IntNode(int data, IntNode next, IntNode prev)
		{
			Data = data;
			Next = next;
			Prev = prev;
		}

		public IntNode(int data) {
			Data = data;
		}
	}
}