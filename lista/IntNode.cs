using System;

namespace lista {
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

		public IntNode(int data, IntNode next)
		{
			Data = data;
			Next = next;
		}

		public IntNode(int data) {
			Data = data;
		}
	}
}