using System;

namespace blic_1
{
    class Program
    {
        static void Main(string[] args)
        {
            BST tr = new BST(8);
            Node n1 = new Node(5);
            Node n2 = new Node(10);
            Node n3 = new Node(1);
            Node n4 = new Node(6);
            Node n5 = new Node(9);
            Node n6 = new Node(7);
            Node nonNode = new Node(15);
            tr.AddNode(n1);
            tr.AddNode(n2);
            tr.AddNode(n3);
            tr.AddNode(n4);
            tr.AddNode(n5);
            tr.AddNode(n6);
            System.Console.WriteLine(tr.FindNode(n4));
        }
    }
}
