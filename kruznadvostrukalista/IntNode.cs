namespace kruznadvostrukalista {
	class IntNode {
		private int data;
		private IntNode next;
		private IntNode prev;

		public int Data {
			get { return data; }
			set { data = value; }
		}
		public IntNode Next {
			get { return next; }
			set { next = value; }
		}
		public IntNode Prev {
			get { return prev; }
			set { prev = value; }
		}

		public IntNode(int data = 0, IntNode next = null, IntNode prev = null) {
			this.data = data;
			this.next = next;
			this.prev = prev;
		}
	}
}