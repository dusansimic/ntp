using System;

namespace tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> root = new Node<int>(1);
            Node<int> child1 = new Node<int>(2);
            root.AddChild(child1);
            Node<int> child2 = new Node<int>(3);
            root.AddChild(child2);
            Node<int> child3 = new Node<int>(4);
            root.AddChild(child3);
            Node<int> child4 = new Node<int>(5);
            child1.AddChild(child4);
            Tree<int> t = new Tree<int>(root);
            System.Console.WriteLine(t.FindNode(child1));
        }
    }
}
