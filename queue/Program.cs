using System;

namespace queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> q = new Queue<int>(5);

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Dequeue();
            q.Dequeue();
            q.Enqueue(4);
            q.Enqueue(5);
            q.Enqueue(6);

            System.Console.WriteLine(q);
        }
    }
}
