using System;
using System.Collections.Generic;

namespace tree {
	class Tree<T> {
		private Node<T> root;
		public Node<T> Root {
			get { return root; }
		}

		public Tree(Node<T> root) {
			this.root = root;
		}
		public int FindNode(Node<T> node) {
			Stack<Node<T>> stack = new Stack<Node<T>>();
			stack.Push(root);
			List<Node<T>> visited = new List<Node<T>>();
			visited.Add(root);
			int level = 0;
			return findNodeTool(node, stack, visited, level);
		}
		private int findNodeTool(Node<T> node, Stack<Node<T>> stack, List<Node<T>> visited, int level) {
			if (stack.Count == 0) {
				return -1;
			} else if (stack.Peek().Equals(node)) {
				return level;
			} else if (stack.Peek().Children.Count > 0) {
				foreach (Node<T> child in stack.Peek().Children) {
					if (!visited.Find(x => !x.Equals(child)).Equals(child)) {
						stack.Push(child);
						visited.Add(child);
						level++;
						return findNodeTool(node, stack, visited, level);
					}
				}
			} else {
				stack.Pop();
				level--;
				return findNodeTool(node, stack, visited, level);
			}
			return -1;
		}
	}

	class Node<T> {
		private T data;
		public T Data {
			get { return data; }
		}
		private List<Node<T>> children;
		public List<Node<T>> Children {
			get { return children; }
		}

		public Node(T data) {
			this.data = data;
			children = new List<Node<T>>();
		}
		public Node(T data, List<Node<T>> children) {
			this.data = data;
			this.children = new List<Node<T>>();
			children.CopyTo(this.children.ToArray());
		}
		public Node(T data, Node<T>[] children) {
			this.data = data;
			this.children = new List<Node<T>>();
			children.CopyTo(this.children.ToArray(), 0);
		}
		public void AddChild(Node<T> child) {
			children.Add(child);
		}
		public bool RemoveChild(Node<T> child) {
			return this.children.Remove(child);
		}
	}
}
