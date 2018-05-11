using System;
using System.Collections.Generic;

namespace blic_1 {
	class BST {
		private Node root;

		public BST(int data) {
			root = new Node(data);
		}

		public void AddNode(Node node) {
			addNode(root, node);
		}
		private void addNode(Node curr, Node node) {
			if (node.Data < curr.Data) {
				if (curr.Left == null) {
					curr.Left = node;
				} else {
					addNode(curr.Left, node);
				}
			} else if (node.Data > curr.Data) {
				if (curr.Right == null) {
					curr.Right = node;
				} else {
					addNode(curr.Right, node);
				}
			} else {
				throw new Exception("PUČE MILOJKOOOOO!!! Nemo stavljat već postojeće.");
			}
		}
		public int FindNode(Node node) {
			return findNode(root, node, 1);
		}
		private int findNode(Node curr, Node node, int nivo) {
			if (node.Data < curr.Data) {
				if (curr.Left == null) {
					return -1;
				} else {
					return findNode(curr.Left, node, nivo + 1);
				}
			} else if (node.Data > curr.Data) {
				if (curr.Right == null) {
					return -1;
				} else {
					return findNode(curr.Right, node, nivo + 1);
				}
			} else {
				return nivo;
			}
		}
	}

	class Node {
		private int data;
		public int Data {
			get { return data; }
		}

		private Node left;
		public Node Left {
			get { return left; }
			set { left = value; }
		}
		private Node right;
		public Node Right {
			get { return right; }
			set { right = value; }
		}

		public Node(int data) {
			this.data = data;
		}
	}
}